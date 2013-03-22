$(document).ready(function () {
    // attach confirmation to delete profile
    $('.deleteprofiledetlink').click(function () {
        deleteLinkObj = $(this);  //for future use
        $('#delete-dialog').dialog('open');
        return false; // prevents the default behaviour
    });
});

function openProfileDetailWindow(profileId, action, element) {
    $("#modalWindow").load('/CompanyProfile/' + action + element + '/' + profileId, function () {
        $("#modalWindow").modal({
            closeHTML: "<a href='#' title='Close' class='modal-close'>x</a>",
            position: ["15%", ],
            overlayId: 'modalWindow-overlay',
            containerId: 'modalWindow-content',
            onOpen: function (dialog) {
                dialog.overlay.fadeIn('slow', function () {
                    dialog.data.hide();
                    dialog.container.fadeIn('slow', function () {
                        dialog.data.slideDown('slow');
                        $("#error-msg-det").hide();
                    });
                });
            },
            onClose: function (dialog) {
                dialog.data.fadeOut('slow', function () {
                    $.modal.close(); // must call this!
                    $("#modalWindow").hide();
                });
            }
        });
    });
}

function closePopup() {
    $.modal.close();
}

function submitDetailsForm(frm) {
    if (!$(frm).valid()) {
        return false;
    }
    $.post($(frm).attr("action"), $(frm).serialize(), function (data) {
        if (data.success == true) {
            openProfileSettings(data.profileId);
            $.modal.close();
        } else {
            $("#error-msg-det").text("There was an issue saving the seetings please try again latter").show('fast');
        }
    });
}

function setDefaultPanelSize(id) {
    $.post('/CompanyProfile/SetDefaultPanelSizeAjax/' + id, function (data) {  //Post to action
        if (data.success == true) {
            openProfileSettings(data.profileId);
        }
    });
}