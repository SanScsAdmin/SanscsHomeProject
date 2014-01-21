/***** TODO ******
- Flag for allowing one or multiple draggables per dropable.
- Function to see if the elements have been dropped in correct droppable

******     ******/
function draggableInit() {
    $('.draggable-objects').each(function () {
        //get original draggable position to revert a non valid drop
        $(this).data(
          {
              "originalTopPosition": $(this).position().top, "originalLeftPosition": $(this).position().left
          });
    });


    //create a 
    $('.dropable-container').droppable(
     {
         accept: '.draggable-objects',
         drop: function (event, ui) {
             $(ui.draggable).offset($(this).offset());
             ui.draggable.data('dropped', true);

             //only accept the dragged element into a dropable
             if (ui.draggable.data('allowOne')) {
                 $(this).droppable('option', 'accept', ui.draggable);
             }
             //console.log(ui.draggable.data("allowOne"));
         },
         out: function (event, ui) {
             //if element doesn't have an object accept only specified draggable element.
             //console.log(ui.draggable.data("allowOne"));
             if (ui.draggable.data('allowOne')) {
                 $(this).droppable('option', 'accept', '.draggable-objects');
             }
         }
     });

    $('.draggable-objects').draggable(
     {
         revert: function (validDrop) {
             if (!validDrop) {
                 $(this).offset({ "top": $(this).data("originalTopPosition"), "left": $(this).data("originalLeftPosition") });
             }
         },
         start: function (event, ui) {
             ui.helper.data('dropped', false);
         },
         stop: function (event, ui) {
             if (!ui.helper.data('dropped')) { }
         }

     });

    init();
};

function resetAllDraggables() {
    $('.draggable-objects').each(function () {
        $(this).offset({ "top": $(this).data("originalTopPosition"), "left": $(this).data("originalLeftPosition") });
    });
}

$('#reset-draggables').click(function (event) {
    event.preventDefault();
    resetAllDraggables();
});

$('#allow-one').click(function (event) {
    event.preventDefault();
    $('.draggable-objects').data("allowOne", true);
    resetAllDraggables();
});

$('#allow-more').click(function (event) {
    event.preventDefault();
    $('.draggable-objects').data("allowOne", false);
    resetAllDraggables();
});

function touchHandler(event) {

    var touches = event.changedTouches,
          first = touches[0],
          type = "";
    switch (event.type) {
        case "touchstart": type = "mousedown"; break;
        case "touchmove": type = "mousemove"; break;
        case "touchend": type = "mouseup"; break;
        default: return;
    }

    //initMouseEvent(type, canBubble, cancelable, view, clickCount, 
    //           screenX, screenY, clientX, clientY, ctrlKey, 
    //           altKey, shiftKey, metaKey, button, relatedTarget);

    var simulatedEvent = document.createEvent("MouseEvent");
    simulatedEvent.initMouseEvent(type, true, true, window, 1,
                              first.screenX, first.screenY,
                              first.clientX, first.clientY, false,
                              false, false, false, 0/*left*/, null);
    first.target.dispatchEvent(simulatedEvent);
    event.preventDefault();
}

function init() {
    var touchElement = document.getElementById("wrapper");

    touchElement.addEventListener("touchstart", touchHandler, true);
    touchElement.addEventListener("touchmove", touchHandler, true);
    touchElement.addEventListener("touchend", touchHandler, true);
    touchElement.addEventListener("touchcancel", touchHandler, true);
}