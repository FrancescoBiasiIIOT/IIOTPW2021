var device = require('azure-iot-device');
// Define the client object that communicates with Azure IoT Hubs
var Client = require('azure-iot-device').Client;
// Define the message object that will define the message format going into Azure IoT Hubs
var Message = require('azure-iot-device').Message;
// Define the protocol that will be used to send messages to Azure IoT Hub
var Protocol = require('azure-iot-device-mqtt').Mqtt
//Device ConnectionString
var connectionString = 'HostName=ProjectWorkHub.azure-devices.net;DeviceId=TestDato;SharedAccessKey=NbF6zU6Vbjf9G8PRuvp8DwQRO8gFTh27L19KuHrW7/k='


// Create the client instanxe that will manage the connection to your IoT Hub
var client = Client.fromConnectionString(connectionString,Protocol);

// Extract the Azure IoT Hub device ID from the connection string
var deviceId = device.ConnectionString.parse(connectionString).DeviceId;


//---------------------------INVIO MESSAGGIO---------------------------------------------------------------------------
function sendMessage(src, val){
  // Define the message body
  var payload = JSON.stringify({
      msg : 'prova123'
  });

  var message = new Message(payload);
  console.log('Sending message: ' + message.getData());
  
  // Send the message to Azure IoT Hub
  client.sendEvent(message, printResultFor('send'));
  
  console.log('- - - -');
}

//print message result in the console
function printResultFor(op) {
  return function printResult(err, res) {
    if (err) console.log(op + ' error: ' + err.toString());
    if (res) console.log(op + ' status: ' + res.constructor.name);
  };
}
//-------------------------------------INVIO MESSAGGI INTERVALLATI---------------------------------------------------------------------------------------
var connectCallback = function (err) {
  var payload = JSON.stringify({
    msg : 'asoinaosifnaoisndaoi'
});

var message = new Message(payload);
  console.log('Open Azure IoT connection...');
  
  // *********************************************
  // If there is a connection error, display it 
  // in the console.
  // *********************************************
  if(err) {
      console.error('...could not connect: ' + err);
      
  // *********************************************
  // If there is no error, send and receive
  // messages, and process completed messages.
  // *********************************************
  } else {
      console.log('...client connected');
      
      // *********************************************
      // Create a message and send it to the IoT Hub
      // every two-seconds
      // *********************************************
      var sendInterval = setInterval(function () {
          sendMessage('provaMessaggio', message);
      }, 2000);
      
      // *********************************************
      // Listen for incoming messages
      // *********************************************
      client.on('message', function (msg) {
          console.log('*********************************************');
          console.log('**** Message Received - Id: ' + msg.messageId + ' Body: ' + msg.data);
          console.log('*********************************************');

          // *********************************************
          // Process completed messages and remove them 
          // from the message queue.
          // *********************************************
          client.complete(msg, printResultFor('completed'));
      });
          
      // *********************************************
      // If the client gets an error, dsiplay it in
      // the console.
      // *********************************************
      client.on('error', function (err) {
          console.error(err.message);
      });
          
      // *********************************************
      // If the client gets disconnected, cleanup and
      // reconnect.
      // *********************************************
      client.on('disconnect', function () {
          clearInterval(sendInterval);
          client.removeAllListeners();
          client.connect(connectCallback);
      });
  }
}
//invio di un solo messaggio
//client.open(sendMessage);

//invio di piu messaggi ad intervalli prestabiliti
client.open(connectCallback);