const ByteLength = require('@serialport/parser-byte-length')

const SerialPort = require('serialport')
const DeviceId = 100;
const port = new SerialPort('COM9', {
  baudRate: 9600
})     


var clientFromConnectionString = require('azure-iot-device-mqtt').clientFromConnectionString;
var Message = require('azure-iot-device').Message;
var Parser = require("binary-parser").Parser;
const parser = port.pipe(new ByteLength({length: 4}))
var connectionString =  'HostName=ProjectWorkHub.azure-devices.net;DeviceId=TestDato;SharedAccessKey=NbF6zU6Vbjf9G8PRuvp8DwQRO8gFTh27L19KuHrW7/k=';

var client = clientFromConnectionString(connectionString);


client.on('message', function (msg) {
    var message = JSON.parse(msg.data);
    var buffer = new Buffer.alloc(2); 
    buffer[0] =  message.MicrocontrollerId;   
    buffer[1] =  message.Operation;   
    port.write(buffer);    
    var teacher = message.Teacher + '\n';
    var subject = message.Subject + '\n';
    port.write(teacher + subject); 
    buffer = new Buffer.alloc(1); 
    buffer[0] = message.Duration;
    port.write(buffer); 
    port.write('\r');
 
    console.log(message)
    client.complete(msg, function (err) {
      if (err) {
        console.error('complete error: ' + err.toString());
      } else {
        console.log('complete sent');
      }
    });
  });


  parser.on('data', function (data) {
  
    //
    var header =  new Parser()
    .uint8("destinatario")
    .uint8("operazione")
    .uint8("mittente")
    .uint8("payload")
    var message = header.parse(data);
    var messageToSend = {
      PicId : message.mittente,
      Operation : message.operazione
    };
    console.log(messageToSend);
    client.sendEvent(new Message(JSON.stringify(messageToSend)));
     
  })   
        

  port.on('error', function(err) {
    var message = {
      Operation : 10,
      Message : err.message
    }
    client.sendEvent(new Message(JSON.stringify(message)));
  })