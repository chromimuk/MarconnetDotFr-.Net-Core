var MapHelper = (function () {

    const leafletReference = L;

    let _divMap;
    let _myMap;
    let _markersCurrentlyOnMap = [];

    // init values
    const INIT_LATITUDE = 42;
    const INIT_LONGITUDE = -40;
    const INIT_ZOOM = 4;

    // layer options
    const minZoom = 1;
    const maxZoom = 18;
    const tileLayer = 'https://{s}.basemaps.cartocdn.com/dark_nolabels/{z}/{x}/{y}{r}.png';
    const attribution = '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors &copy; <a href="https://carto.com/attributions">CARTO</a>';


    function init(divMap) {
        _divMap = divMap;
        _myMap = leafletReference.map(_divMap);
        setup();
    }

    function setup() {
        leafletReference.tileLayer(tileLayer, {
            attribution: attribution,
            minZoom: minZoom,
            maxZoom: maxZoom
        }).addTo(_myMap);
    }

    function addMarker(coordinate, isOwnPosition) {

        if (coordinate === undefined)
            return;

        let marker;
        if (isOwnPosition === true) {
            marker = leafletReference.marker(coordinate.getCoordinates(), {
                icon: createRedIcon()
            });
        } else {
            marker = leafletReference.marker(coordinate.getCoordinates());
            marker.bindPopup(coordinate.description);
        }
        _markersCurrentlyOnMap.push(marker.addTo(_myMap));
    }

    function addMarkers(coordinates, shouldHighlight) {
        for (let coordinate of coordinates) {
            addMarker(coordinate, shouldHighlight);
        }
    }

    function createRedIcon() {
        return new L.Icon({
            iconUrl: 'js/lib/leaflet/images/marker-icon-red.png',
            shadowUrl: 'js/lib/leaflet/images/marker-shadow.png',
            iconSize: [12, 20],
            iconAnchor: [6, 20],
            popupAnchor: [1, -34],
            shadowSize: [20, 20]
        });
    }


    function cleanMarkers() {
        for (let marker of _markersCurrentlyOnMap) {
            marker.remove();
        }
        _markersCurrentlyOnMap = [];
    }

    function setView(latitude, longitude, zoom) {
        const lat = latitude || INIT_LATITUDE;
        const lon = longitude || INIT_LONGITUDE;
        const z = zoom || INIT_ZOOM;
        _myMap.setView(leafletReference.latLng(lat, lon), z, {
            animation: true
        });
    }


    return {
        init: init,
        addMarker: addMarker,
        addMarkers: addMarkers,
        cleanMarkers: cleanMarkers,
        setView: setView
    }

})();

var GeoLocTools = (function () {

    function getCoordinatesFromNavigator(callbackSuccess, callbackFail) {
        HtmlHelper.clearLocationInput();
        if (navigator.geolocation) {
            navigator.geolocation.getCurrentPosition(callbackSuccess, callbackFail);
        } else {
            callbackFail();
        }
    }

    function getCoordinatesFromLocation(location, callbackSuccess, callbackFail) {

        const baseURL = 'https://nominatim.openstreetmap.org/search?';
        const args = [
            'format=json', // Output format
            `q=${location}`, // Query string to search for
            'addressdetails=1', // Include a breakdown of the address into elements
            'limit=1' // limit the number of returned results 
        ];
        const url = `${baseURL}${args.join('&')}`;

        fetch(url).then(
            function (response) {
                response.json().then(function (data) {
                    callbackSuccess(data);
                });
            }
        ).catch(function (err) {
            callbackFail(err);
        });
    }

    return {
        getCoordinatesFromNavigator: getCoordinatesFromNavigator,
        getCoordinatesFromLocation: getCoordinatesFromLocation
    };
})();

var DistanceCalcTools = (function () {

    function calculateDistance(pointA, pointB) {
        if (pointA === undefined || pointB === undefined)
            return null;

        return calcCrow(
            pointA.getCoordinates()[0],
            pointA.getCoordinates()[1],
            pointB.getCoordinates()[0],
            pointB.getCoordinates()[1]
        );
    }

    function calculateDistanceCoordinates(lat1, lon1, lat2, lon2) {
        return calcCrow(lat1, lon1, lat2, lon2);
    }

    function calcCrow(lat1, lon1, lat2, lon2) {
        var R = 6371; // km
        var dLat = toRad(lat2 - lat1);
        var dLon = toRad(lon2 - lon1);
        var lat1 = toRad(lat1);
        var lat2 = toRad(lat2);

        var a = Math.sin(dLat / 2) * Math.sin(dLat / 2) +
            Math.sin(dLon / 2) * Math.sin(dLon / 2) * Math.cos(lat1) * Math.cos(lat2);
        var c = 2 * Math.atan2(Math.sqrt(a), Math.sqrt(1 - a));
        var d = R * c;
        return d;
    }

    function toRad(Value) {
        return Value * Math.PI / 180;
    }

    return {
        calculateDistance: calculateDistance,
        calculateDistanceCoordinates: calculateDistanceCoordinates
    };
})();