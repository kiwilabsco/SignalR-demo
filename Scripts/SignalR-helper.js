// Global definitions
var minValue = 0, maxValue = 100;

(function () {
    $.connection.hub.start()
        .done(function () {
            console.log("SignalR Hub connection successfully established.");

            // Let's trigger the Hub's function which locates in SignalRHub.cs file.
            $.connection.signalRHub.server.generateRandomNumbers(minValue, maxValue);
        })
        .fail(function () {
            console.log("fail");
        });
})()

$.connection.signalRHub.client.updateRandomValue = function (randomValue) {
    document.getElementById("randomNumber_byTime").innerHTML = randomValue;
}

$.connection.signalRHub.client.sendRandValue = function (randomValue) {
    document.getElementById("randomNumber_byClick").innerHTML = randomValue;
}



function getRandValue() {
    $.connection.signalRHub.server.generateRandomNumber();
}