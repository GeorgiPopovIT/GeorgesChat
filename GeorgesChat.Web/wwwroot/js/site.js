﻿// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

function success() {
    if (document.getElementById("messageValue").value === "") {
        document.getElementById('sendButton').disabled = true;
    } else {
        document.getElementById('sendButton').disabled = false;
    }
}
