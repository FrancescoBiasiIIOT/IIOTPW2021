const ByteLength = require('@serialport/parser-byte-length')

const SerialPort = require('serialport')
const DeviceId = 100;
const port = new SerialPort('COM3', {
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
    var teacher = message.Teacher + new Array((32 - message.length) + 1).join(' ');
    var subject = message.Subject + new Array((32 - message.length) + 1).join(' ');
    var bufferToDuration = new Buffer.alloc(1); 
    port.write(teacher + subject); 

    bufferToDuration[1] = message.Duration;
    port.write(buffer); 

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
  
    var header =  new Parser()
    .uint8("mittente")
    .uint8("operazione")
    .uint8("payload")
    var message = header.parse(data);
    console.log(message)
    client.sendEvent(new Message(JSON.stringify(message)));
    
  })
