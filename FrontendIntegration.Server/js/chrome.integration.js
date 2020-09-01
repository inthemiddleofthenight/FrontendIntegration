(async function () {
    CefSharp.BindObjectAsync('IntegrationObject');
})();

document.getElementById('invoke').addEventListener('click', function () {
    IntegrationObject.call(JSON.stringify({
        dt: new Date(),
        str: 'test',
        name: 'chrome front integration',
        type: 'front-to-host'
    }));
})


function reverseCall(json) {
    var d = document.createElement('div');
    d.innerHTML = '<div>' + json + '</div>';
    document.getElementById('log').appendChild(d);
}


