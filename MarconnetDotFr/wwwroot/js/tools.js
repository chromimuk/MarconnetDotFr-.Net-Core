var Tools = (function () {
    function isInteger(element) {
        return /^-?[0-9]+$/.test(element);
    }

    return {
        isInteger: isInteger
    };
})();

var LazyLoadingTools = (function () {

    let scriptsLoaded = [];
    let competitionsCount;
    let onCompetitionScriptsLoadedCallback;

    function loadScript(url) {

        if (scriptsLoaded.indexOf(url) > -1) {
            scriptLoaded();
            return;
        }

        const head = document.getElementsByTagName('head')[0];
        let script = document.createElement("script");
        script.src = url;
        script.onload = scriptLoaded;
        script.onreadystatechange = function () {
            if (this.readyState == 'complete') {
                scriptLoaded();
            }
        };

        head.appendChild(script);
        scriptsLoaded.push(url);
    }

    function scriptLoaded() {
        competitionsCount--;
        if (competitionsCount === 0)
            onCompetitionScriptsLoadedCallback();
    }

    function setCompetitionsCount(count) {
        competitionsCount = count;
    }

    function setOnCompetitionScriptsLoadedCallback(callback) {
        onCompetitionScriptsLoadedCallback = callback;
    }

    return {
        loadScript: loadScript,
        setCompetitionsCount: setCompetitionsCount,
        setOnCompetitionScriptsLoadedCallback: setOnCompetitionScriptsLoadedCallback
    };
})();