const DOMFinder = (function () {

    function getMapDiv() {
        return document.getElementById("mapid");
    }

    return {
        getMapDiv: getMapDiv
    }
})();
