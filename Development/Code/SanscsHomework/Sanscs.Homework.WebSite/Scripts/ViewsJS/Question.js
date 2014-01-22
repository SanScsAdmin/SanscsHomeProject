
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
    var  QuestionModel=function()  {
        this.prev = function () {
            alert();
            var current = getCurrent();
            current.hide();
            current.prev().show();
        };
        this.next= function () {
            alert();
            var current = getCurrent();
            current.hide();
            current.next().show();
        };
        this.IsSubmitted = ko.observable(false);
        this.IsFirst= function () {
            return true;
        };
        this.IsLast= function () {
            return false;
        }
    };
    ko.applyBindings(new QuestionModel());
});
