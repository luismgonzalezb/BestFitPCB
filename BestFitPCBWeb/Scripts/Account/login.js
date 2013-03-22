
$(document).ready(function () {
    $('#login').validate({
        rules: {
            Email: {
                required: true,
                email: true
            },
            Password: {
                minlength: 6,
                required: true
            }
        },
        messages: {
            Email: {
                required:"Please provide email",
                email:"Incorrect email format"
            },
            Password: {
                minlength: "Password at least 6 characters long",
                required: "Please provide password"
            }
        }
    });
});