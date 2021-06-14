const classroomId = document.getElementById("classroomId");




document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');
    var calendar = new FullCalendar.Calendar(calendarEl, {
        headerToolbar: {
            left: '',
            right: 'dayGridMonth,timeGridWeek,timeGridDay',
            center: 'title',
        },
        selectable: true,
        dateClick: function (info) {
        },
        select: function (info) {
            $('#addEventModal').modal('show');
            var startDate = document.getElementById("startDate");
            var endDate = document.getElementById("endDate");
            startDate.value = info.startStr;
            endDate.value = info.endStr;
        },
        locale: 'it',
        slotMinTime: '08:00',
        slotMaxTime: '21:00',
        expandRows: true,

        events: {
            url: 'https://localhost:44310/Calendar',
            method: 'GET',
            extraParams: {
                classroomId: classroomId.value
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

    calendar.render();
});

