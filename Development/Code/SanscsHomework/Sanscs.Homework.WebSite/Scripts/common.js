var webapiURL = "";
var answerAddress = "http://localhost:10561/api/Question/GetAnswer/";
function getanswer(o) {
    var id = $(o).attr("id");
    var serverUrl = answerAddress + id;
    $.get(serverUrl, function (data) {
        alert(data);
    });
}
function getCurrent() {
    var current;
    $(".question").each(function (e) {
        if ($(this).css("display")=="block") {
            current = $(this);
            return false;
        }
    });
    return current;
}
function prev() {
    var current = getCurrent();
    current.hide();
    current.prev();
}