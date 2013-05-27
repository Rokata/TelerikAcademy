var initialLeft = parseInt(screen.width / 2);
var initialTop = 150;
var divsCount = 5;
var currentAngle = 0;
var angleOffset = 5;
var radius = 150;
var rotationTimer;
var divs = document.getElementsByTagName("div");
var startButton = document.getElementsByClassName("button-start")[0];

initDivs();

function initDivs() {
    for (var i = 0; i < divsCount; i++) {
        var div = document.createElement("div");
        div.style.position = "absolute";
        div.style.backgroundColor = "red";
        div.style.borderRadius = "40px";
        div.style.width = "50px";
        div.style.height = "50px";
        changeDivPosition(div);
        document.body.appendChild(div);
    }
}

function changeDivPosition(div) {
    currentAngle += angleOffset;
    var top = initialTop + Math.cos(currentAngle) * radius;
    var left = initialLeft + Math.sin(currentAngle) * radius;
    div.style.left = left + 'px';
    div.style.top = top + 'px';
}

function onStartButtonClick(e) {
    if (e.preventDefault)
        e.preventDefault();

    if (startButton.classList.contains("notClicked")) {
        startButton.className = "button-start clicked";
    }
    else {
        return false;
    }

    rotationTimer = setInterval(function () {
        for (var i = 0; i < divs.length; i++) {
            changeDivPosition(divs[i]);
        }
    }, 100);

    return false;
}

function onStopButtonClick(e) {
    if (e.preventDefault)
        e.preventDefault();

    startButton.className = "button-start notClicked";

    clearInterval(rotationTimer);
    return false;
}
