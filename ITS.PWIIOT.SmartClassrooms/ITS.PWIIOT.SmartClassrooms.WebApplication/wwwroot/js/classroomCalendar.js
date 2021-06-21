
const classroom = document.getElementById("classroomId");
const params = { classroomId: classroom.value }
const url = '/calendar'
var calendarEl = document.getElementById('calendar');
var startTime = document.getElementById('startTime');
var endTime = document.getElementById('endTime');
document.addEventListener('DOMContentLoaded', function () {
    var calendar = BuildCalendar(calendarEl, params, url);
    calendar.render();
});

function BuildCalendar(calendarEl, params, url) {
    return new FullCalendar.Calendar(calendarEl, {
        schedulerLicenseKey: 'CC-Attribution-NonCommercial-NoDerivatives',
        headerToolbar: {

            left: 'prev,next,today',
            right: 'dayGridMonth,timeGridWeek,timeGridDay',
            center: 'title',
        },
        selectable: true,
        dateClick: function (info) {
        },
        slotLabelFormat: {
            hour: 'numeric',
            minute: '2-digit',
        },
        navLinks: true,
        select: function (info) {
            $('#addEventModal').modal('show');
            var startDate = document.getElementById("startDate");
            var endDate = document.getElementById("endDate");
            startDate.value = info.startStr;
            endDate.value = info.endStr;
            startTime.value = new Date(info.startStr).toISOString().substring(11, 16);
            endTime.value = new Date(info.endStr).toISOString().substring(11, 16);
        },
        eventClick: function (info) {
            var eventObj = info.event;
            $('#addEventModal').modal('show');
            fetch("/lesson?id=" + eventObj.id).then((response) => {
                return response.json();  // converting byte data to json
            }).then(data => {
                startDate.value = data.startDate;
                endDate.value = data.endDate;
                startTime.value = new Date(data.startDate).toISOString().substring(11, 16);
                endTime.value = new Date(data.endDate).toISOString().substring(11, 16);
            })
        },
        eventDidMount: function (info) {
            $(info.el).find(".fc-event-main").prepend("<span class='closeon test'>X</span>");
            $(info.el).find(".closeon").click(function () {
                fetch(url + '?lessonId=' + info.event.id, {
                    method: 'DELETE',
                })
                info.event.remove();
            });
        },
        locale: 'it',
        slotMinTime: '08:00',
        slotMaxTime: '21:00',
        expandRows: true,
        eventRender: function (eventObj, $el) {
            $el.popover({
                title: eventObj.title,
                content: eventObj.description,
                trigger: 'hover',
                placement: 'top',
                html: true,
                container: 'body'
            });
        },
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
