var trashcan = document.getElementById("trashcan");
var trashes = 5;
var startTime = new Date().getSeconds();
generateTrashItems();
viewScores();

function generateTrashItems() {
    var trashHeight = 64;
    var trashWidth = 64;
    var fragment = document.createDocumentFragment();
    var trashcanWidth = parseInt(trashcan.clientWidth);
    var dragArea = document.getElementById("drag-area");
    var screenWidth = parseInt(dragArea.style.width);
    var screenHeight = parseInt(dragArea.style.height);

    for (var i = 0; i < trashes; i++) {
        var trashItem = new Image(trashHeight, trashWidth);
        trashItem.src = "images/junk.png";
        trashItem.style.position = "absolute";
        trashItem.id = "img" + (i + 1);
        trashItem.draggable = true;
        trashItem.ondragstart = drag;
        trashItem.style.top = getRandomPosition(0, screenHeight) + 'px';
        trashItem.style.left = getRandomPosition(trashcanWidth, screenWidth - trashWidth) + 'px';
        fragment.appendChild(trashItem);
    }

    dragArea.appendChild(fragment);
}

function drag(ev) {
    ev.dataTransfer.setData("dragged-id", ev.target.id);
}

function allowDrop(ev) {
    ev.preventDefault();
}

function drop(ev) {
    ev.preventDefault();
    trashcan.setAttribute('src', 'images/trashcan_closed.jpg');

    if (--trashes == 0) enterScore();

    var data = ev.dataTransfer.getData("dragged-id");
    var dragged = document.getElementById(data);
    dragged.parentNode.removeChild(dragged);
}

function enterScore() {
    var endTime = new Date().getSeconds();
    var time = endTime - startTime;
    var nick = prompt("You completed the game in " + time + " seconds.\n\nEnter your nickname: ");

    var previousTime = localStorage.getItem(nick) | 0;

    if (isNaN(previousTime)) {
        localStorage.setItem(nick, time);
    }
    else if (previousTime > time) {
        localStorage.setItem(nick, time);
    }
}

function viewScores() {
    var highscoreBoard = document.getElementById("highscores");
    var highscores = [];

    for (var name in localStorage) {
        highscores.push({ nick: name, time: localStorage[name] | 0 });
    }
    sortScores(highscores);

    var count = (highscores.length < 5) ? highscores.length : 5;
    
    for (var i = 0; i < count; i++) {
        var scoreRow = document.createElement("tr");
        var nickCell = document.createElement("td");
        nickCell.innerHTML = highscores[i].nick;
        var scoreCell = document.createElement("td");
        scoreCell.innerHTML = highscores[i].time + " sec.";
        scoreRow.appendChild(nickCell);
        scoreRow.appendChild(scoreCell);
        highscoreBoard.appendChild(scoreRow);
    }
}

function sortScores(scores) {
    for (var i = 0; i < scores.length - 1; i++) {
        for (var j = i + 1; j < scores.length; j++) {
            if (scores[i].time > scores[j].time) {
                var temp = scores[j];
                scores[j] = scores[i];
                scores[i] = temp;
            }
        }
    }
}

function getRandomPosition(min, max) {
    var randomValue = Math.floor(min + Math.random() * (max - min));
    return parseInt(randomValue);
}

trashcan.ondragleave = function () {
    this.setAttribute('src', 'images/trashcan_closed.jpg');
}

trashcan.ondragenter = function () {
    this.setAttribute('src', 'images/trashcan_opened.jpg');
}