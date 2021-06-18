
// Test di prova
//---------------------------------------------------------

var Protocol = require('azure-iot-device-amqp').AmqpWs;
var DeviceClient = require('azure-iot-device').Client;
const config = require('./config.json');  //Stringa di connessione al Device 

var connectionString = config.connectionString;

/*  // Questo serve per la seriale
//gestione errori
port.on('error', function(err) {
    console.log('Error: ', err.message)
});*/


//ricezione messaggio-----------------------------
client.on('message', function (msg) {
    client.complete(msg, function (err) {
      if (err) {
        console.error('complete error: ' + err.toString());
      } else {
          console.log('Id: ' + msg.messageId + ' Body: ' + msg.data);
          var json = JSON.parse(msg.data);
          



          console.log(json);
          console.log('completed');
    }
  });
});





/**  ---- Callback che manda e riceve un messaggio-----------

 
 var connectCallback = function (err) {
  if (err) {
    console.error('Could not connect: ' + err);
  } else {
    console.log('Client connected');
    var message = new Message('some data from my device');
    client.sendEvent(message, function (err) {
      if (err) console.log(err.toString());
    });

    client.on('message', function (msg) { 
      console.log(msg); 
      client.complete(msg, function () {
        console.log('completed');
      });
    }); 
  }
};
 */

//client.open(connectCallback);