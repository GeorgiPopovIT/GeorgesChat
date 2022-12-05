"use strict";

const connection = new signalR.HubConnectionBuilder().withUrl("/chat").build();

//Disable the send button until connection is established.
document.getElementById("sendButton").disabled = true;

connection.on("ReceiveMessage", function (user, message) {
    //var li = document.createElement("li");
    //document.getElementById("messagesList").appendChild(li);
    if (user == 'Gosho') {
        document.getElementById('messagesList').innerHTML += `<li class="clearfix">
                                <div class="message-data" style="text-align: right">
                                    <span class="message-data-time">10:10 AM, Today</span>
                                </div>
                                <div class="message other-message float-right"> ${message} </div>
                            </li>`;
    }
    else {
        document.getElementById('messagesList').innerHTML += `<li class="clearfix">
                                <div class="message-data">
                                    <span class="message-data-time">10:12 AM, Today</span>
                                </div>
                                <div class="message my-message">${message}</div>
                            </li>`;
    }
    // We can assign user-supplied strings to an element's textContent because it
    // is not interpreted as markup. If you're assigning in any other way, you
    // should be aware of possible script injection concerns.

    /*li.textContent = `${user} says ${message}`;*/
});

connection.start().then(function () {
    document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});

document.getElementById("sendButton").addEventListener("click", function (event) {
    let user = "Gosho";
    let receiver = "Pesho";
    let message = document.getElementById("messageInput").value;
    connection.invoke("SendMessageToUser", user, receiver, message).catch(function (err) {
        return console.error(err.toString());
    });
    event.preventDefault();
});