
const teacher = document.getElementById("teacherId");
const url = '/calendar/teachers'
var calendarEl = document.getElementById('calendar');
const params = { teacherId: teacher.value }


document.addEventListener('DOMContentLoaded', function () {
    var calendar = BuildCalendar(calendarEl, params, url);
    calendar.render();
});

function BuildCalendar(calendarEl, params, url) {
    return new FullCalendar.Calendar(calendarEl, {
        schedulerLicenseKey: 'CC-Attribution-NonCommercial-NoDerivatives',
        initialView: 'timeGridDay',
        headerToolbar: {
            left: 'prev,next,today,myCustomButton',
            right: 'dayGridMonth,timeGridWeek,timeGridDay',
            center: 'title',
        },
        slotLabelFormat: {
            hour: 'numeric',
            minute: '2-digit',
        },
        customButtons: {
            myCustomButton: {
                text: 'Richiedi supporto',
                click: function () {
                    $('#addEventModal').modal('show');
                }
            }
        },
        navLinks: true,
        locale: 'it',
        slotMinTime: '08:00',
        slotMaxTime: '21:00',
        expandRows: true,

        events: {
            url: url,
            method: 'GET',
            extraParams: params,
            failure: function () {
                alert('there was an error while fetching events!');
            },

        },

        allDaySlot: false,

        initialView: 'timeGridWeek',
        timeZone: 'UTC',
        themeSystem: 'bootstrap',
        locale: 'it',

        hiddenDays: [0, 6]
    });
}
