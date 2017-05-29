(function () {
    console.log("parent: register listener");
    window.addEventListener('message', function (e) {
        console.log("parent: message received: origin" + e.origin + "msg:" + e.data.msg);
        //location.reload();
    }, false);
})();