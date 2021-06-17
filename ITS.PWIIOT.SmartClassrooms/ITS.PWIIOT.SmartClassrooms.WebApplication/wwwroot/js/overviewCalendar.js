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
            right: 'today'
        },

        resourceAreaWidth: '10%',
        selectable: true,
        navLinks: true,
        resourceAreaHeaderContent: 'Edificio',
        resources: {
            url: resourcesUrl,
            method: 'GET',
            failure: function () {
                alert('there was an error while fetching events!');
            },
        },
        slotLabelFormat: {
            hour: 'numeric',
            minute: '2-digit',
        },
        events: {
            url: classroomUrl,
            method: 'GET',
            failure: function () {
                alert('there was an error while fetching events!');
            },
        },

        locale: 'it',
        themeSystem: 'bootstrap',
        slotMinTime: '08:00',
        slotMaxTime: '21:00',
    });

    calendar.render();
});