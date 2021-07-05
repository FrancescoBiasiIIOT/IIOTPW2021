const resourcesUrl = "/calendar/buildings";
const classroomUrl = "/calendar/classrooms";
document.addEventListener('DOMContentLoaded', function () {
    var calendarEl = document.getElementById('calendar');
    var calendar = new FullCalendar.Calendar(calendarEl, {
        schedulerLicenseKey: 'CC-Attribution-NonCommercial-NoDerivatives',
        timeZone: 'UTC',
        initialView: 'resourceTimelineDay',
        customButtons: {
            myCustomButton: {
                text: 'Aggiungi Lezione',
                click: function () {
                    $('#addEventModal').modal('show');
                }
            }
        },
        headerToolbar: {
            left: 'prev,next,myCustomButton',
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
            },
        },
        resourceLabelDidMount: function (info) {
            var questionMark = document.createElement('a');
            questionMark.setAttribute('href', "yourlink.htm");
            questionMark.innerText = '(Pianifica)';
            var value = $(info.el).find('.fc-datagrid-cell-main')
            value.prepend("a href='google.it'");
        },
        slotLabelFormat: {
            hour: 'numeric',
            minute: '2-digit',
        },
        eventDidMount: function (info) {
            $(info.el).find(".fc-datagrid-cell fc-resource").prepend("<span class='closeon test'>X</span>");
            $(info.el).find(".closeon").click(function () {
                fetch(url + '?lessonId=' + info.event.id, {
                    method: 'DELETE',
                })
                info.event.remove();
            });
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