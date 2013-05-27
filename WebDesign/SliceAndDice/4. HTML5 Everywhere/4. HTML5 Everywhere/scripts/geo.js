navigator.geolocation.getCurrentPosition(displayCurrentLocation);

function displayCurrentLocation(position) {
    var latitude = position.coords.latitude;
    var longitude = position.coords.longitude;

    $(".geolocation").html("<strong>Latitude:</strong> " + latitude + ", <strong>Longitude:</strong> " + longitude);
    displayMap(position.coords);
}

function displayErrorMessage(error) {
    var errorTypes = {
        0: "Unknown error",
        1: "Permission denied by user",
        2: "Position is not available",
        3: "Request timed out"
    };
    var errorMessage = errorTypes[error.code];

    if (error.code == 0 || error.code == 2) {
        errorMessage = errorMessage + " " + error.message;
    }

    $(".geolocation").html(errorMessage);
}

function displayMap(coords) {
    var googleCoords = new google.maps.LatLng(coords.latitude, coords.longitude);

    var mapOptions = {
        zoom: 15,
        center: googleCoords,
        mapTypeId: google.maps.MapTypeId.ROADMAP
    };

    var mapElement = document.getElementById("map");
    map = new google.maps.Map(mapElement, mapOptions);
    createMarker(map, googleCoords, "Your Location", "You are here: " + coords.latitude + ", " + coords.longitude);
}

function createMarker(map, coords, windowTitle, windowText) {
    var markerOptions = {
        position: coords,
        map: map,
        title: windowTitle,
        clickable: true
    };

    var marker = new google.maps.Marker(markerOptions);

    var infoWindowOptions = {
        content: windowText,
        position: coords
    };

    var infoWindow = new google.maps.InfoWindow(infoWindowOptions);

    google.maps.event.addListener(marker, "click", function() {
        infoWindow.open(map);
    });
}



