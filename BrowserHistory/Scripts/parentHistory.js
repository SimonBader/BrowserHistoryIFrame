(function () {
    var url = 'http://localhost:1800/home/about';
    var element = window.document.getElementById('foo');
    element.contentWindow.onload = function () {
        element.contentWindow.onbeforeunload = function () {
            console.log('onbeforeunload: before:' + element.contentWindow.location.href);
            var stateObj = { foo: "bar" };
            //element.contentWindow.history.replaceState(stateObj, "NEWLY_CREATED", url);
            console.log('onbeforeunload: after:' + element.contentWindow.location.href);
        };
    };
})();