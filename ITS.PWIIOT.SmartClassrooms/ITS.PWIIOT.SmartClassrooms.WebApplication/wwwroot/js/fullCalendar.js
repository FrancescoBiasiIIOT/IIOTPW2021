
document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');
    var calendar = new FullCalendar.Calendar(calendarEl, {
        locale: 'it',
        slotMinTime: '08:00',
        slotMaxTime: '21:00',
        expandRows: true,
        events: {
            url: 'https://localhost:44310/Calendar',
            method: 'GET',
            extraParams: {

            },
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
    console.log(calendar.events)
    calendar.render();
});
