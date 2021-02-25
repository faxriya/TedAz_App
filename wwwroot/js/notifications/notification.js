
"use strict";

var connection = new signalR.HubConnectionBuilder().withUrl("/notificationhub").build();
console.log("check-notif");
////Disable send button until connection is established
//document.getElementById("sendButton").disabled = true;
//console.log("check-notif");
connection.on("ReceiveMessage", function (user) {
    console.log("lalala");
    //$(document).ready(function () {

        $(".content-loader").css("display", "block")

        if (localStorage.getItem("count") != null) {

            let value = +localStorage.getItem("count") + 1;

            localStorage.setItem("count", value);
        }
        else {
            localStorage.setItem("count", 1);
        }
        $(".content-loader span").html(localStorage.getItem("count"));
        localStorage.setItem("count", 0);


    //});
    //var li = document.createElement("li");
    //li.textContent = user;
    //document.getElementById("messagesList").appendChild(li);

});

connection.start().then(function () {
    // document.getElementById("sendButton").disabled = false;
}).catch(function (err) {
    return console.error(err.toString());
});


//document.getElementById("sendButton").addEventListener("click", function (event) {
//    var user = document.getElementById("userInput").value;
//    var message = document.getElementById("messageInput").value;
//    connection.invoke("SendMessage", user, message).catch(function (err) {
//        return console.error(err.toString());
//    });
//    event.preventDefault();
//});