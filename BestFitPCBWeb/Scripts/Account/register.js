
$(document).ready(function () {
    $('#login').validate({
        rules: {
            UserName: {
                minlength: 6,
                required: true
            },
            Email: {
                required: true,
                email: true
            },
            Password: {
                minlength: 6,
                required: true
            },
            ConfirmPassword: {
                minlength: 6,
                required: true,
                equalTo: "#Password"
            },
        },
        messages: {
            UserName: {
                minlength: "User Name at least 6 characters long",
                required: "Please provide User Name"
            },
            Email: {
                required: "Please provide email",
                email: "Incorrect email format"
            },
            Password: {
                minlength: "Password at least 6 characters long",
                required: "Please provide password"
            },
            ConfirmPassword: {
                minlength: "Password at least 6 characters long",
                required: "Please provide password",
                equalTo: "Passwords do not match"
            }
        }
    });
});