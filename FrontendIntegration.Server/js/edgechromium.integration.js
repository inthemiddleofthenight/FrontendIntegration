var IntegrationObject = IntegrationObject || {};

window.IntegrationObject = IntegrationObject;

IntegrationObject.call = function (json) {
    window.chrome.webview.postMessage(json);
}

IntegrationObject.call2 = async function (json) {
    await chrome.webview.hostObjects.integrationInterface.call(json);
}

IntegrationObject.reverseCall = function (json) {
    var d = document.createElement('div');
    d.innerHTML = '<div>' + JSON.stringify(json) + '</div>';
    document.getElementById('log').appendChild(d);
}

function reverseCall(json) {
    IntegrationObject.reverseCall(json);
}

document.getElementById('invoke').addEventListener('click', function () {
    IntegrationObject.call(JSON.stringify({
        dt: new Date(),
        str: 'test',
        name: 'edge chromium front integration',
        type: 'front-to-host'
    }));
})

document.getElementById('invoke2').addEventListener('click', async function () {
    await IntegrationObject.call2(JSON.stringify({
        dt: new Date(),
        str: 'test - 2',
        name: 'edge chromium front integration',
        type: 'front-to-host'
    }));
})