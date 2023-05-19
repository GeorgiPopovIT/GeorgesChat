"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

connection.on("OnlineUsers", function () {
   // alert('User is online.');
});

connection.on('ReceiveMessage', function (message) {
    var messageList = document.getElementById('list');

    
        messageList.innerHTML += `<li class="clearfix">
            <div class="message-data">
            </div>
            <div class="message my-message">${message}</div>
        </li>`;
    return;
});

connection.on('ReceiveMessageSender', function (message) {
    var messageList = document.getElementById('list');


    messageList.innerHTML += `<li class="clearfix">
							<div class="message other-message float-right">${message}</div>
						</li>`;

    document.getElementById("messageValue").value = '';

    return;
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {


    var message = document.getElementById("messageValue").value;
    var receiver = document.getElementById("receiverId").value;
    var sender = document.getElementById("senderId").value;


    connection.invoke("SendMessageToReceiver", sender, message, receiver).catch(function (err) {
        return console.error(err.toString());
    });

    event.preventDefault();

});


