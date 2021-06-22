
! function (t) {
    "use strict";
    function s() {
        for (var e = document.getElementById("topnav-menu-content").getElementsByTagName("a"), t = 0, n = e.length; t < n; t++) "nav-item dropdown active" === e[t].parentElement.getAttribute("class") && (e[t].parentElement.classList.remove("active"), e[t].nextElementSibling.classList.remove("show"))
    }

    function n(e) {
        1 == t("#light-mode-switch").prop("checked") && "light-mode-switch" === e ? (t("html").removeAttr("dir"), t("#dark-mode-switch").prop("checked", !1), t("#rtl-mode-switch").prop("checked", !1), t("#bootstrap-style").attr("href", "assets/css/bootstrap.min.css"), t("#app-style").attr("href", "assets/css/app.min.css"), sessionStorage.setItem("is_visited", "light-mode-switch")) : 1 == t("#dark-mode-switch").prop("checked") && "dark-mode-switch" === e ? (t("html").removeAttr("dir"), t("#light-mode-switch").prop("checked", !1), t("#rtl-mode-switch").prop("checked", !1), t("#bootstrap-style").attr("href", "assets/css/bootstrap-dark.min.css"), t("#app-style").attr("href", "assets/css/app-dark.min.css"), sessionStorage.setItem("is_visited", "dark-mode-switch")) : 1 == t("#rtl-mode-switch").prop("checked") && "rtl-mode-switch" === e && (t("#light-mode-switch").prop("checked", !1), t("#dark-mode-switch").prop("checked", !1), t("#bootstrap-style").attr("href", "assets/css/bootstrap-rtl.min.css"), t("#app-style").attr("href", "assets/css/app-rtl.min.css"), t("html").attr("dir", "rtl"), sessionStorage.setItem("is_visited", "rtl-mode-switch"))
    }

    function e() {
        document.webkitIsFullScreen || document.mozFullScreen || document.msFullscreenElement || (console.log("pressed"), t("body").removeClass("fullscreen-enable"))
    }
    var a;
    t("#side-menu").metisMenu(), t("#vertical-menu-btn").on("click", function (e) {
        e.preventDefault(), t("body").toggleClass("sidebar-enable"), 992 <= t(window).width() ? t("body").toggleClass("vertical-collpsed") : t("body").removeClass("vertical-collpsed")
    }), t("#sidebar-menu a").each(function () {
        var e = window.location.href.split(/[?#]/)[0];
        this.href == e && (t(this).addClass("active"), t(this).parent().addClass("mm-active"), t(this).parent().parent().addClass("mm-show"), t(this).parent().parent().prev().addClass("mm-active"), t(this).parent().parent().parent().addClass("mm-active"), t(this).parent().parent().parent().parent().addClass("mm-show"), t(this).parent().parent().parent().parent().parent().addClass("mm-active"))
    }), t(".navbar-nav a").each(function () {
        var e = window.location.href.split(/[?#]/)[0];
        this.href == e && (t(this).addClass("active"), t(this).parent().addClass("active"), t(this).parent().parent().addClass("active"), t(this).parent().parent().parent().addClass("active"), t(this).parent().parent().parent().parent().addClass("active"), t(this).parent().parent().parent().parent().parent().addClass("active"))
    }), t(document).ready(function () {
        var e;
        0 < t("#sidebar-menu").length && 0 < t("#sidebar-menu .mm-active .active").length && (300 < (e = t("#sidebar-menu .mm-active .active").offset().top) && (e -= 300, t(".vertical-menu .simplebar-content-wrapper").animate({
            scrollTop: e
        }, "slow")))
    }), t('[data-bs-toggle="fullscreen"]').on("click", function (e) {
        e.preventDefault(), t("body").toggleClass("fullscreen-enable"), document.fullscreenElement || document.mozFullScreenElement || document.webkitFullscreenElement ? document.cancelFullScreen ? document.cancelFullScreen() : document.mozCancelFullScreen ? document.mozCancelFullScreen() : document.webkitCancelFullScreen && document.webkitCancelFullScreen() : document.documentElement.requestFullscreen ? document.documentElement.requestFullscreen() : document.documentElement.mozRequestFullScreen ? document.documentElement.mozRequestFullScreen() : document.documentElement.webkitRequestFullscreen && document.documentElement.webkitRequestFullscreen(Element.ALLOW_KEYBOARD_INPUT)
    }), document.addEventListener("fullscreenchange", e), document.addEventListener("webkitfullscreenchange", e), document.addEventListener("mozfullscreenchange", e), t(".right-bar-toggle").on("click", function (e) {
        t("body").toggleClass("right-bar-enabled")
    }), t(document).on("click", "body", function (e) {
        0 < t(e.target).closest(".right-bar-toggle, .right-bar").length || t("body").removeClass("right-bar-enabled")
    }),
        function () {
            if (document.getElementById("topnav-menu-content")) {
                for (var e = document.getElementById("topnav-menu-content").getElementsByTagName("a"), t = 0, n = e.length; t < n; t++) e[t].onclick = function (e) {
                    "#" === e.target.getAttribute("href") && (e.target.parentElement.classList.toggle("active"), e.target.nextElementSibling.classList.toggle("show"))
                };
                window.addEventListener("resize", s)
            }
        }(), t(function () {
            t('[data-bs-toggle="tooltip"]').tooltip()
        }), t(function () {
            t('[data-bs-toggle="popover"]').popover()
        }), window.sessionStorage && ((a = sessionStorage.getItem("is_visited")) ? (t(".right-bar input:checkbox").prop("checked", !1), t("#" + a).prop("checked", !0), n(a)) : sessionStorage.setItem("is_visited", "light-mode-switch")), t("#light-mode-switch, #dark-mode-switch, #rtl-mode-switch").on("change", function (e) {
            n(e.target.id)
        }), t(window).on("load", function () {
            t("#status").fadeOut(), t("#preloader").delay(350).fadeOut("slow")
        }), Waves.init()
}(jQuery);


$(document).ready(() => {
    window.addEventListener("pageshow", function (event) {
        var historyTraversal = event.persisted ||
            (typeof window.performance != "undefined" &&
                window.performance.navigation.type === 2);
        if (historyTraversal) {
            // Handle page restore.
            window.location.reload();
        }
    });

    $("#Id_sector").change(() => {
        $("#nm_sector").val($("#Id_sector option:selected").html());
    })

    $("#Id_item").change(() => {
        $("#nm_item").val($("#Id_item option:selected").html());
    })

    $("#password").val("")

    var ordenesObj = $("#calendar-content").val();
    var calendarObj = [];
    if (ordenesObj != "") {
        let obj = ordenesObj.replace(/\//g, '/')
        console.log(obj);
        ordenesObj = JSON.parse(obj);
        console.log(ordenesObj);
        ordenesObj.map(orden => {
            calendarObj.push({
                id: orden.Id,
                title: orden.Sitio,
                start: moment(orden.Fecha, "DD/MM/YYYY").format("YYYY-MM-DD"),
                end: moment(orden.Fecha, "DD/MM/YYYY").format("YYYY-MM-DD"),
                allDay: false,
                className: orden.className + " py-1",
                url: `/Admin/Gestionar/${orden.Id}`
            })
        })
    }
    console.log(calendarObj);


    /*
     Template Name: Veltrix - Responsive Bootstrap 4 Admin Dashboard
     Author: Themesbrand
     File: Calendar Init
     */


    $(document).ready(function () {
        var date = new Date();
        var d = date.getDate();
        var m = date.getMonth();
        var y = date.getFullYear();

        /*  className colors
    
         className: default(transparent), important(red), chill(pink), success(green), info(blue)
    
         */


        /* initialize the external events
         -----------------------------------------------------------------*/

        $('#external-events div.external-event').each(function () {

            // create an Event Object (http://arshaw.com/fullcalendar/docs/event_data/Event_Object/)
            // it doesn't need to have a start or end
            var eventObject = {
                title: $.trim($(this).text()) // use the element's text as the event title
            };

            // store the Event Object in the DOM element so we can get to it later
            $(this).data('eventObject', eventObject);

            // make the event draggable using jQuery UI
            $(this).draggable({
                zIndex: 999,
                revert: true,      // will cause the event to go back to its
                revertDuration: 0  //  original position after the drag
            });

        });


        /* initialize the calendar
         -----------------------------------------------------------------*/

        var calendar = $('#calendar').fullCalendar({
            header: {
                left: 'title',
                center: '',
                right: 'prev,next today'
            },
            editable: false,
            firstDay: 1, //  1(Monday) this can be changed to 0(Sunday) for the USA system
            selectable: false,
            defaultView: 'month',

            axisFormat: 'h:mm',
            columnFormat: {
                month: 'ddd',    // Mon
                week: 'ddd d', // Mon 7
                day: 'dddd M/d',  // Monday 9/7
                agendaDay: 'dddd d'
            },
            titleFormat: {
                month: 'MMMM YYYY', // September 2009
                week: "MMMM YYYY", // September 2009
                day: 'MMMM YYYY'                  // Tuesday, Sep 8, 2009
            },
            allDaySlot: false,
            selectHelper: true,
            select: function (start, end, allDay) {
                var title = prompt('Event Title:');
                if (title) {
                    calendar.fullCalendar('renderEvent',
                        {
                            title: title,
                            start: start,
                            end: end,
                            allDay: allDay
                        },
                        true // make the event "stick"
                    );
                }
                calendar.fullCalendar('unselect');
            },
            droppable: true, // this allows things to be dropped onto the calendar !!!
            drop: function (date, allDay) { // this function is called when something is dropped

                // retrieve the dropped element's stored Event Object
                var originalEventObject = $(this).data('eventObject');

                // we need to copy it, so that multiple events don't have a reference to the same object
                var copiedEventObject = $.extend({}, originalEventObject);

                // assign it the date that was reported
                copiedEventObject.start = date;
                copiedEventObject.allDay = allDay;

                // render the event on the calendar
                // the last `true` argument determines if the event "sticks" (http://arshaw.com/fullcalendar/docs/event_rendering/renderEvent/)
                $('#calendar').fullCalendar('renderEvent', copiedEventObject, true);

                // is the "remove after drop" checkbox checked?
                if ($('#drop-remove').is(':checked')) {
                    // if so, remove the element from the "Draggable Events" list
                    $(this).remove();
                }
            },
            events: calendarObj
        });
    });
   
})

$("#showModalSector").click(() => {

    $("#showModalSector").modal("show")


})