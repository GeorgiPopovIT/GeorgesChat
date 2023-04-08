"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

document.getElementById("message").disabled = true;

connection.on("ReceiveMessage", function (message) {
    var list = document.getElementById('list');

    list.innerHTML += `<li class="clearfix">
							<div class="message-data text-right">
								<span class="message-data-time"></span>
							</div>
							<div class="message other-message float-right">${message}</div>
						</li>`;
});

document.getElementById('message').addEventListener('click', function (event) {
    event.preventDefault();

    var message = document.getElementById("message").value;
    var receiver = document.getElementById("receiverId").value;
    var sender = document.getElementById('senderId').value;

    console.log(`${sender}, ${message}, ${receiver}`);

    connection.invoke("SendMessageToReceiver", sender, message, receiver);
//    event.preventDefault();
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});
