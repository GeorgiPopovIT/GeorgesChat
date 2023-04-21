"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/chatHub").build();

//document.getElementById("submit").disabled = true;

connection.on("ReceiveMessage", function (message) {
    var list = document.getElementById('list');

    list.innerHTML += `<li class="clearfix">
							<div class="message-data text-right">
								<span class="message-data-time"></span>
							</div>
							<div class="message other-message float-right">${message}</div>
						</li>`;
});

document.getElementById('submit').addEventListener('click', function () {
    /*event.preventDefault();*/

    console.log('In');

    var message = document.getElementById("messageValue").value;
    var receiver = document.getElementById("receiverId").value;
    var sender = document.getElementById('senderId').value;

    console.log(`${sender}, ${message}, ${receiver}`);

    connection.invoke("SendMessageToReceiver", sender, message, receiver);
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});
