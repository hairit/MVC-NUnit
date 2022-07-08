function checkForm(idElement) { 
    var cansubmit = true;
    if (document.getElementById('email-input').value.length == 0) cansubmit = false;
    if (document.getElementById('name-input').value.length == 0) cansubmit = false;
    if (cansubmit) {
        document.getElementById('handle-submit').disabled = false;
    } else
        document.getElementById('handle-submit').disabled = true;
}