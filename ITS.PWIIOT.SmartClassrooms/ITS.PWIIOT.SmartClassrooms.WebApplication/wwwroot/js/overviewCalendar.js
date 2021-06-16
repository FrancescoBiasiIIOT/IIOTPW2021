const resourcesUrl = "/calendar/buildings";
const classroomUrl = "/calendar/classrooms";
document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');
      var calendar = new FullCalendar.Calendar(calendarEl, {
          schedulerLicenseKey: 'CC-Attribution-NonCommercial-NoDerivatives',
      timeZone: 'UTC',
      initialView: 'resourceTimelineDay',
      headerToolbar: {
        left: 'prev,next',
        center: 'title',
        right: 'resourceTimelineDay'
      },
      editable: true,
      resourceAreaHeaderContent: 'Edificio',
          resources: {
              url: resourcesUrl,
              method: 'GET',
              failure: function () {
                  alert('there was an error while fetching events!');
              },
          },
          events: {
              url: classroomUrl,
              method: 'GET',
              failure: function () {
                  alert('there was an error while fetching events!');
              },
          },

          locale: 'it',
          slotMinTime: '08:00',
          slotMaxTime: '21:00',
          expandRows: true,
    });

    calendar.render();
  });