'use strict';

var fs = require('fs');
var Mqtt = require('azure-iot-device-mqtt').Mqtt;
var DeviceClient = require('azure-iot-device').Client
const schedule = require('node-schedule');
const date = new Date(2021,6,21,14,58,0);
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
        ScheduleLessons(data);
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

ScheduleLessons()
function ScheduleLessons()
{
    var date =  new Date(2021,5,21,15,50,0);
    var obj = JSON.parse(fs.readFileSync('calendar.json', 'utf8'));
    var classrooms = obj.ClassroomsCalendar.map(c => c.ClassroomId);
   
    classrooms.forEach(classroom => {
        var classroomsLessons = obj.ClassroomsCalendar.find(c => c.ClassroomId == classroom).Lessons;
        var nextLesson = classroomsLessons.find(c => new Date(c.StartDate) > date);
        var dateTest = new Date(nextLesson.StartDate);
        var month = dateTest.getMonth();
        var day  = dateTest.getDay();
        var hour = dateTest.getHours();
        console.log("mese" + month)
        console.log("giorno"+ day )
        console.log("ora"+  hour)
    });
    const job = schedule.scheduleJob(date, ()=>{
      console.log("ciao");
    })

}
