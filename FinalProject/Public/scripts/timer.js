$(document).ready(function () {
    $('.countdown').final_countdown({
        start: '1362139200',
        end: '1388461320',
        now: '1387461319',
        selectors: {
            value_seconds: '.clock-seconds .val',
            canvas_seconds: 'canvas_seconds',
            value_minutes: '.clock-minutes .val',
            canvas_minutes: 'canvas_minutes',
            value_hours: '.clock-hours .val',
            canvas_hours: 'canvas_hours',
            value_days: '.clock-days .val',
            canvas_days: 'canvas_days'
        },
        seconds: {
            borderColor: '#5ec3d5',
            borderWidth: '5'
        },
        minutes: {
            borderColor: '#5ec3d5',
            borderWidth: '5'
        },
        hours: {
            borderColor: '#5ec3d5',
            borderWidth: '5'
        },
        days: {
            borderColor: '#5ec3d5',
            borderWidth: '5'
        }}, function() {
        // Finish callback
        });
});
