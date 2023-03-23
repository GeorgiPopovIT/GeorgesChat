"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

document.getElementById("sendButton").disabled = true;

document.getElementById('sendButon').addEventListener('click', function (event) {
    var sender = document.getElementById("senderEmail").value;
    var message = document.getElementById("message").value;
    var receiver = document.getElementById("receiverEmail").value;

    connectionChat.send("SendMessageToReceiver", sender, receiver, message);
    event.preventDefault();
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});
