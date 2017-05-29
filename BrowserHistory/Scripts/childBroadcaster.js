(function () {
    console.log("child: message posted: reload");
    window.parent.postMessage({
        'msg': 'reload'
    }, "*");
})();