$('#PatientSave').click(function () {

    if ($("#IdentityNumber").val() == "" || $("#IdentityNumber").val() == null || $("#IdentityNumber").val().length != 11) { alert("IdentityNumber must be 11 characters") }
    else if ($("#Telephone").val() == "" || $("#Telephone").val() == null || $("#Telephone").val().length != 10) {
        alert("Telephone must be 10 characters")
    }
    else if ($("#Age").val() <= "0" && $("#Age").val() == "") { alert("Age must be higher than zero") }
    else if ($("#Name").val() != "" && $("#Surname").val() != "" && $("#Address").val() != "") {
        var Name = $('#Name').val();
        var Surname = $('#Surname').val();
        var Age = $('#Age').val();
        var Address = $('#Address').val();
        var IdentityNumber = $('#IdentityNumber').val();
        var Telephone = $('#Telephone').val();

        var model = JSON.stringify({

            IdentityNumber: IdentityNumber,
            Name: Name,
            Surname: Surname,
            Age: Age,
            Address: Address,
            Telephone: Telephone
        })

        $.post({
            headers: {
                'Accept': 'application/json',
                'Content-Type': 'application/json'
            },
            dataType: 'json',
            url: '/api/Record',
            data: model,

            success: function (result) {
                window.location.href = "/Home/PatientControl?IdentityNumber=" + result;
            }
        })
    } else { alert("Fill in the blank"); }
})