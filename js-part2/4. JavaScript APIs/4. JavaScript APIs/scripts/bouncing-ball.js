var directionX = 1;
var directionY = 1;
var currentX = 30;
var currentY = 30;
var ballRadius = 10;
var canvasWidth = document.getElementsByTagName('canvas')[0].width;
var canvasHeight = document.getElementsByTagName('canvas')[0].height;

function drawBall() {
    var canvas = document.getElementById("ball-canvas");
    var ctx = canvas.getContext("2d");
    ctx.fillStyle = "white";
    ctx.fillRect(0, 0, ctx.canvas.width, ctx.canvas.height);
    ctx.fillStyle = "black";
    ctx.beginPath();
    ctx.arc(currentX, currentY, ballRadius, 0, 2 * Math.PI, false);
    ctx.fill();
    ctx.stroke();
}

setInterval(function () {
    if (currentX > canvasWidth - ballRadius || currentY > canvasHeight - ballRadius ||
        currentX <= ballRadius || currentY <= ballRadius) {
        if (directionX == 1 && directionY == 1) {
            directionY = -1;
        }
        else if (directionX == 1 && directionY == -1) {
            directionX = -1;
        }
        else if (directionX == -1 && directionY == -1) {
            directionY = 1;
        }
        else {
            directionX = 1;
        }
    }

    currentX += directionX;
    currentY += directionY;
    drawBall();
}, 10);

