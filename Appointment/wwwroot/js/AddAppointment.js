var servicesIDs = new Array();

$(":checkbox").on("click", function () {
    servicesIDs = $("input:checkbox:checked").map(function () {
        return $(this).val();
    }).get();

});

$("#AppointmentSave").on('click', function () {
    if (servicesIDs.length == 0 || servicesIDs == null || servicesIDs == "" || $("#BeginTime").val() == "" || $("#EndTime").val() == "" || $("#AppointmentDate").val() == "") {
        alert("Fill in the blank")
    } else {
        console.log(servicesIDs);
        var Begin = $("#BeginTime").val();
        var End = $("#EndTime").val();
        var Date = $("#AppointmentDate").val();
        var model = {
            PatientId: $("#pId").val(),
            EndTime: End,
            BeginTime: Begin,
            AppointmentDate: Date,
            ServicesList: servicesIDs
        };


        $.post({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            dataType: 'json',
            url: '/api/AddApp',
            data: JSON.stringify(model),

            success: function (result) {
                window.location.href = "/Home/PatientControl?IdentityNumber=" + result;
            }
        })
    }

});