var movingShapes = function () {
    var currentAngle = 0;
    var angleOffset = 5;
    var radius = 150;
    var rotationTimer = setInterval(function () {
        for (var i = 0; i < divs.length; i++) {
            changeRotatingDivPosition(divs[i]);
        }
    }, 100);
    var initialLeft = parseInt(screen.width / 2);
    var initialTop = 150;
    var divs = [];

    function initDiv() {
        var div = document.createElement("div");
        div.style.position = "absolute";
        div.style.backgroundColor = getRandomColor();
        div.style.borderRadius = "40px";
        div.style.width = "50px";
        div.style.height = "50px";
        div.style.border = "2px solid " + getRandomColor();
        divs.push(div);
        document.body.appendChild(div);
        changeRotatingDivPosition(div);
    }

    function changeRotatingDivPosition(div) {
        currentAngle += angleOffset;
        var top = initialTop + Math.cos(currentAngle) * radius;
        var left = initialLeft + Math.sin(currentAngle) * radius;
        div.style.left = left + 'px';
        div.style.top = top + 'px';
    }

    function add(shape) {
        if (shape == "ellipse") {

        }
        else {

        }
    }

    function getRandomColor() {
        var letters = '0123456789ABCDEF'.split('');
        var color = '#';

        for (var i = 0; i < 6; i++)
            color += letters[Math.round(Math.random() * 15)];

        return color;
    }

    return {
        initDiv: initDiv
    }
}();
