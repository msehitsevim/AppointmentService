$("#Search").on('click', function (e) {


    if ($("#IdentityNumber").val() !== "" && $("#IdentityNumber").val() !== null && $("#IdentityNumber").val().length == 11) {

        window.location.href = "/home/PatientControl?IdentityNumber=" + $("#IdentityNumber").val();
    }
    else { alert("input must be 11 characters") }

})