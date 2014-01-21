
jQuery.support.cors = true;
var queAddress = "http://localhost:10561/api/Question/GetQuestions/1";
$(function () {
    $.getJSON(
        queAddress,
        function (data) {
            for (e in data) {
                $("#question").append(data[e].ContentResult);
            }
            draggableInit();
        }
        );
    var QuestionModel = {
        prev: function () {
            var current = getCurrent();
            current.hide();
            current.prev().show();
        },
        next: function () {
            var current = getCurrent();
            current.hide();
            current.next().show();
        }
    }
    ko.applyBindings(QuestionModel);
});
