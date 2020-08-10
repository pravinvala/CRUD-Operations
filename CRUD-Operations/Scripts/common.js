function getAge(dateString) {
    var today = new Date();
    var birthDate = new Date(dateString);
    var age = today.getFullYear() - birthDate.getFullYear();
    var m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
        age--;
    }
    return age;
}

function validateZIP(ZIP) {
    var ZIPFormat = /[0-9]{6}/;
    if (ZIP.match(ZIPFormat)) {
        return true;
    }
    else {
        return false;
    }
}

function isNumberWithDecimalKey(evt) {
    var charCode = (evt.which) ? evt.which : evt.keyCode;
    if (charCode != 46 && charCode > 31
        && (charCode < 48 || charCode > 57))
        return false;

    return true;
}

function validateEmail(mail) {
    var mailFormat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,5})+$/;
    if (mail.match(mailFormat)) {
        return true;
    }
    else {
        return false;
    }
}

function validatePassword(password) {
    var PassFormat = /^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,16}$/;
    if (password.match(PassFormat)) {
        return true;
    }
    else {
        return false;
    }
}