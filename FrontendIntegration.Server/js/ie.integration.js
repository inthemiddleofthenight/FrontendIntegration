var IntegrationObject = IntegrationObject || {};

window.IntegrationObject = IntegrationObject;

IntegrationObject.call = function (json) {
    window.external.call(json);
}

IntegrationObject.reverseCall = function (json) {
    var d = document.createElement('div');
    d.innerHTML = '<div>' + json + '</div>';
    document.getElementById('log').appendChild(d);
}

function reverseCall(json) {
    IntegrationObject.reverseCall(json);
}


document.getElementById('invoke').addEventListener('click', function () {
    IntegrationObject.call(JSON.stringify({
        dt: new Date(),
        str: 'test',
        name: 'ie front integration',
        type: 'front-to-host'
    }));
})