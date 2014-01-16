

$.getJSON("/api/Cours", function (data) {
   //ko.applyBindings({
   //     Cours: [
   //         { Name: 'Bert', lastName: 'Bertington' },
   //         { firstName: 'Charles', lastName: 'Charlesforth' },
   //         { firstName: 'Denise', lastName: 'Dentiste' }
   //     ]
    // });
    ko.applyBindings(data);
})

   