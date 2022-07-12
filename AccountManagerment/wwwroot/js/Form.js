function checkForm() {
    var cansubmit = true;
    console.log('123');
    if (document.getElementById('email-input').value.length == 0) cansubmit = false;
    if (document.getElementById('name-input').value.length == 0) cansubmit = false;
    if (document.getElementById('name-input').value.toString().charAt(0) == '1') console.log(1);
    if (cansubmit) {
        document.getElementById('handle-submit').disabled = false;
    } else
        document.getElementById('handle-submit').disabled = true;
}

function checkEmailForm() {
    var cansubmit = true;
    if (document.getElementById('message-input').value.length == 0) cansubmit = false;
    if (document.getElementById('subject-input').value.length == 0) cansubmit = false;
    if (cansubmit) {
        document.getElementById('handle-send-email').disabled = false;
    } else
        document.getElementById('handle-send-email').disabled = true;
}