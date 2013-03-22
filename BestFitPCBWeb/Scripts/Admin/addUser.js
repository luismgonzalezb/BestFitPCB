
function addUser(path, companyId) {
    var userId = "";
    userId = $("#userId").val();
    if (userId != "" && userId != null && userId != undefined) {
        $.post(path, { usrId: userId, cmpId: companyId }, function (data) {
            if (data.success == true) {
                loadUserList(companyId);
            } else {
                $("#user-error-msg-det").text("There was an issue saving the seetings please try again latter").show('fast');
            }
        });
    } else {
        $("#user-error-msg-det").text("Please Select a user").show('fast');
    }
    return false;
}

function setAdministrator(path, userId, companyId ) {
    $.post(path, { usrId: userId, cmpId: companyId }, function (data) {
        if (data.success == true) {
            loadUserList(companyId);
        } else {
            $("#user-error-msg-det").text("There was an issue saving the seetings please try again latter").show('fast');
        }
    });
    return false;
}