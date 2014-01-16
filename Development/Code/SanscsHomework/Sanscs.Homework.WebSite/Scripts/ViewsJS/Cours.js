
jQuery.support.cors = true;
var coursAddress = "http://localhost:10561/api/Cours/";
$.getJSON(coursAddress, function (data) {
   //ko.applyBindings({
   //     Cours: [
   //         { Name: 'Bert', lastName: 'Bertington' },
   //         { firstName: 'Charles', lastName: 'Charlesforth' },
   //         { firstName: 'Denise', lastName: 'Dentiste' }
   //     ]
    // });
    ko.applyBindings({ Cours: data });
})

   