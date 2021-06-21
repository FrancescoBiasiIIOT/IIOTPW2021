'use strict';

var fs = require('fs');
var Mqtt = require('azure-iot-device-mqtt').Mqtt;
var DeviceClient = require('azure-iot-device').Client

var connectionString = 'HostName=ProjectWorkHub.azure-devices.net;DeviceId=TestDato;SharedAccessKey=NbF6zU6Vbjf9G8PRuvp8DwQRO8gFTh27L19KuHrW7/k=';
var client = DeviceClient.fromConnectionString(connectionString, Mqtt);

//funzione di ascolto 
client.on('message', function (msg) {
  ManageMessage(msg.data)
  client.complete(msg, function (err) {
    if (err) {
      console.error('complete error: ' + err.toString());
    } else {
      console.log('complete sent');
    }
  });
});

function ManageMessage(msg)
{
  var message = JSON.parse(msg);
  message.Operation = 2;
  switch (message.Operation) {

//----------------------------
//aggiunta
//----------------------------
    case 0:
      
      break;
//----------------------------
//update
//----------------------------
    case 1:
    
      break;
//----------------------------
//delete
//----------------------------
    case 2:
      fs.readFile('calendar.json',msg,function(err){
        var data = JSON.parse(msg);
        console.log(data);
        if(err) throw err;
      })
    break;
//-----------------------------
//calendar
//----------------------------
    case 3:
      fs.writeFile('calendar.json',msg,function(err){
        if(err) throw err;
      })
      //far partire lo schedulatore
      break;
  }
}


