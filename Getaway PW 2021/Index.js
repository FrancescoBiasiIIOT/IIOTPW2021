//Getaway di comunicazione  
//Invio dalla APP ---> verso la schedina.
//Bisogna definire che dati da inviare e con quali BIT
//---------------------------------------------------------------------------------------------------------------------------------

//Questo è il require per la seriale
const SerialPort = require('serialport')
const ByteLength = require('@serialport/parser-byte-length');

// configurazione seriale
const port = new SerialPort('   ',{baudRate:38400});   //Inserire la COM della seriale e il corretto baudrate (eventualmente)

// configurazione del parser.   Non avendo idea di quanto Bit verranno usati, è impostato per adesso a 2 byte alla volta
const parser = port.pipe(new ByteLength({ length: 2 }))
parser.on('data', parseMsg)


// require di Azure
var Protocol = require('azure-iot-device-amqp').AmqpWs;
var DeviceClient = require('azure-iot-device').Client;
const config = require('./config.json');
var connectionString = config.connectionString;

//gestione errori
port.on('error', function(err) {
    console.log('Error: ', err.message)
});

//la connectionString è impostata per essere messa in un altro file, il "config.json".  
//Da definire


//Configurazione del cloud
var client = DeviceClient.fromConnectionString(connectionString, Protocol);


client.on('error', function (err) {
    console.error(err.message);
    process.exit(-1);
});

//------------------------------------------------------