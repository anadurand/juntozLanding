$("#suscribirme").on("click", function () {
    var genderTag = document.getElementsByName("gender");
    var email = $("#email");
    var errorText = $("#errorText");
    var successText = $("#successText");
    var gender = "";
    var regexmail = /^[a-zA-Z0-9._-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,4}$/;

    for (var i = 0; i < genderTag.length; i++) {
        if (genderTag[i].checked) {
            gender = genderTag[i].value;
            break;
        }
    }

    if (gender != "" && email.val() != "") {
        if (email.val().match(regexmail)) {
            email.val(email.attr('placeholder'));
            errorText.hide();
            successText.show();
        }
        
    } else {
        errorText.show();
        successText.hide();
    }


});