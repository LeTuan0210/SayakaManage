// wwwroot/js/geoLocation.js
window.getGeoLocation = function () {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(successCallback, errorCallback);
    } else {
        console.error("Geolocation is not supported by this browser.");
    }
};

function successCallback(position) {
    DotNet.invokeMethodAsync('BusinessServices', 'ReceiveGeoLocation', position.coords.latitude, position.coords.longitude);
}

function errorCallback(error) {
    console.error(`Geolocation error: ${error.message}`);
}
