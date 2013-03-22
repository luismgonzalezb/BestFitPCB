var deleteLinkObj;

$(document).ready(function () {
    $.ajaxSetup({
        // Disable caching of AJAX responses
        cache: false
    });
    $("#CompanyUserList").hide();

    // delete Link
    $('.deletelink').click(function () {
        deleteLinkObj = $(this);  //for future use
        $('#delete-dialog').dialog('open');
        return false; // prevents the default behaviour
    });

    $('#delete-dialog').dialog({
        autoOpen: false, width: 400, resizable: false, modal: true, //Dialog options
        buttons: {
            "Continue": function () {
                $.post(deleteLinkObj[0].href, function (data) {  //Post to action
                    if (data.success == true) {
                        deleteLinkObj.closest("tr").hide('fast'); //Hide Row
                        //(optional) Display Confirmation
                    }
                    else {
                        //(optional) Display Error
                    }
                });
                $(this).dialog("close");
            },
            "Cancel": function () {
                $(this).dialog("close");
            }
        }
    });
});

function loadUserList(companyId) {
    $("#CompanyUserList").load('/Company/UserList/' + companyId, function () {
        $("#CompanyUserList").show();

        // attach confirmation to delete profile
        $('.deleteprofilelink').click(function () {
            deleteLinkObj = $(this);  //for future use
            $('#delete-dialog').dialog('open');
            return false; // prevents the default behaviour
        });
    });
}

/****************************************************************************/
/* New Profile Form */

function openNewProfileForm(companyId) {
    $("#error-msg").hide();
    $("#profileSettings").load('/CompanyProfile/NewProfile/' + companyId).show('slow');
}

function openEditProfileForm(profileId) {
    $("#error-msg").hide();
    $("#profileSettings").load('/CompanyProfile/EditProfile/' + profileId).show('slow');
}

function submitForm(frm) {
    if (!$(frm).valid()) {
        return false;
    }
    $.post($(frm).attr("action"), $(frm).serialize(), function (data) {
        if (data.success == true) {
            loadProfile(data.companyId);
        } else {
            $("#error-msg").text("The profile already exists").show();
        }
    });
}

/****************************************************************************/
/* New Profile Form */

function openProfileSettings(profileId) {
    $("#error-msg").hide();
    $("#profileSettings").load('/CompanyProfile/ProfileDetails/' + profileId).show('slow');
}

