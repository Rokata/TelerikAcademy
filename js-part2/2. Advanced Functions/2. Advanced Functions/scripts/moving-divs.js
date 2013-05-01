var movingShapes = function () {
    var initialLeftForRotation = parseInt(screen.width / 4);
    var initialTopForRotation = 150;
    var initialLeftForRectangular = parseInt(screen.width / 2);
    var initialTopForRectangular = 150;
    var rectangleWidth = 500;
    var rectangleHeight = 200;
    var angleOffset = 0.05;
    var rotationRadius = 150;
    var rotatingDivs = [];
    var rectangularMovingDivs = [];
    var rectangularSpeed = 5;
    var maxLeft = initialLeftForRectangular + rectangleWidth;
    var maxTop = initialTopForRectangular + rectangleHeight;

    var rotationTimer = setInterval(function () {
        for (var i = 0; i < rotatingDivs.length; i++) {
            changeRotatingDivPosition(rotatingDivs[i]);
        }

        for (var i = 0; i < rectangularMovingDivs.length; i++) {
            changeRectangularMovingDivPosition(rectangularMovingDivs[i]);
        }
    }, 25);

    function add(shape) {
        var div = document.createElement("div");
        div.style.position = "absolute";
        div.style.backgroundColor = getRandomColor();
        div.style.borderRadius = "40px";
        div.style.width = "50px";
        div.style.height = "50px";
        div.style.textAlign = "center";
        div.innerHTML = "div";
        div.style.color = getRandomColor();
        div.style.border = "2px solid " + getRandomColor();
        document.body.appendChild(div);

        if (shape == "ellipse") {
            rotatingDivs.push({ element: div, currentAngle: 0 });
            changeRotatingDivPosition(div);
        }
        else {
            div.style.top = initialTopForRectangular + 'px';
            div.style.left = initialLeftForRectangular + 'px';
            rectangularMovingDivs.push(div);
            changeRectangularMovingDivPosition(div);
        }
    }

    function changeRotatingDivPosition(div) {
        div.currentAngle += angleOffset;
        var top = initialTopForRotation + Math.cos(div.currentAngle) * rotationRadius;
        var left = initialLeftForRotation + Math.sin(div.currentAngle) * rotationRadius;
        div.element.style.left = left + 'px';
        div.element.style.top = top + 'px';
    }

    function changeRectangularMovingDivPosition(div) {
        var left = parseInt(div.style.left);
        var top = parseInt(div.style.top);

        if (top == initialTopForRectangular && left >= initialLeftForRectangular &&
            left < maxLeft) {
            div.style.left = (left + rectangularSpeed) + 'px';
        }
        else if (left == maxLeft && top >= initialTopForRectangular &&
            top < maxTop) {
            div.style.top = (top + rectangularSpeed) + 'px';
        }
        else if (top == maxTop && left <= maxLeft &&
            left > initialLeftForRectangular) {
            div.style.left = (left - rectangularSpeed) + 'px';
        }
        else {
            div.style.top = (top - rectangularSpeed) + 'px';
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
        add: add
    }
}();
