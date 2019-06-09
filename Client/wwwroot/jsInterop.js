window.calendar = {
    setCalendar: function (call) {
        $('#standard_calendar')
            .calendar({
                type: 'date',
                onChange: function (selectedDate) {
                    DotNet.invokeMethodAsync('Statistics.Client', 'GetSelectedDate', selectedDate);
                    //window.selectedDate = selectedDate;
                    call.invokeMethodAsync(selectedDate);
                    console.log("hey1", selectedDate)
                    console.log("hey2", call.selected)
                }
            });
    },
    getSelectedDate: function () {
        $('#standard_calendar')
            .calendar({
                type: 'date',
                onChange: function (selectedDate) {
                    //DotNet.invokeMethodAsync('Statistics.Client', 'GetSelectedDate', selectedDate);
                    //window.selectedDate = selectedDate;
                    console.log("hey",selectedDate)
                }
            });
    },
}

window.dropdown = {
    setDropdown: function () {
        $('.ui.dropdown')
            .dropdown();
    }
}