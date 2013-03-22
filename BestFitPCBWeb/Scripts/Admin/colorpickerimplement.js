var currentPicker;

$(document).ready(function () {

    $('#colorSelector').ColorPicker({
        color: '#0000ff',
        onShow: function (colpkr) {
            $(colpkr).css('z-index', 1000);
            $(colpkr).fadeIn(500);
            return false;
        },
        onHide: function (colpkr) {
            $(colpkr).fadeOut(500);
            return false;
        },
        onChange: function (hsb, hex, rgb) {
            $('#colorSelector div').css('backgroundColor', '#' + hex);
            $("input[type=hidden][name=color]").val(hex);
        },
        onBeforeShow: function () {
            var currentColor = $("input[type=hidden][name=color]").val();
            $(this).ColorPickerSetColor(currentColor);
        }
    });
    
    $('#backgroundSelector, #profileSelector, #panelSelector, #pcbSelector, #marginSelector, #toolingSelector').ColorPicker({
        color: '#0000ff',
        onShow: function (colpkr) {
            $(colpkr).css('z-index', 1000);
            $(colpkr).fadeIn(500);
            return false;
        },
        onHide: function (colpkr) {
            $(colpkr).fadeOut(500);
            return false;
        },
        onChange: function (hsb, hex, rgb) {
            $(currentPicker).find('.pickerBg').css('backgroundColor', '#' + hex);
            $(currentPicker).children('input[type=hidden]').val(hex);
        },
        onBeforeShow: function () {
            currentPicker = this.parentElement;
            var currentColor = $(currentPicker).children('input[type=hidden]').val();
            $(this).ColorPickerSetColor(currentColor);
        }
    });
    

});