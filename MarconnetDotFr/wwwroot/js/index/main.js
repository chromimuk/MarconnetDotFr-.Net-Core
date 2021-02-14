var App = (function () {

    function init() {
        MapHelper.init(DOMFinder.getMapDiv().id);
        MapHelper.setView();
        setMarkers();
    }

    function setMarkers() {
        // remove all markers on the map
        MapHelper.cleanMarkers();

        // Belfort
        let belfort = new Coordinate(47.6379599, 6.8628942);
        MapHelper.addMarker(belfort, true);

        // Portsmouth
        let portsmouth = new Coordinate(50.8036831, -1.075614);
        MapHelper.addMarker(portsmouth, true);

        // Basel
        let basel = new Coordinate(47.5581077, 7.5878261);
        MapHelper.addMarker(basel, true);

        // Iselin
        let iselin = new Coordinate(40.569334999999995, -74.31511249016258);
        MapHelper.addMarker(iselin, true);

        // Quebec
        let quebec = new Coordinate(46.8259601, -71.2352226);
        MapHelper.addMarker(quebec, true);

        // Geneva
        let geneva = new Coordinate(46.2017559, 6.1466014);
        MapHelper.addMarker(geneva, true);
    }

    return {
        init: init
    };
})();

App.init();