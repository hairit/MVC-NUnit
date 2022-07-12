function sendEmail() {
    var email = document.getElementById('email-address-input').value.toString();
    var subject = document.getElementById('subject-input').value.toString();
    var message = document.getElementById('message-input').value.toString();
    window.location.href = "mailto:" + email + "?subject=" + subject + "&body=" + message;
}