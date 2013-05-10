var trashcan = document.getElementById("trashcan");
generateTrashItems();

trashcan.ondragleave = function () {
    this.setAttribute('src', 'images/trashcan_closed.jpg');
}

trashcan.ondragenter = function () {
    this.setAttribute('src', 'images/trashcan_opened.jpg');
}

function generateTrashItems() {
    var trashHeight = 64;
    var trashWidth = 64;
    var fragment = document.createDocumentFragment();
    var trashcanWidth = parseInt(trashcan.clientWidth);
    var dragArea = document.getElementById("drag-area");
    var screenWidth = parseInt(dragArea.style.width);
    var screenHeight = parseInt(dragArea.style.height);

    for (var i = 0; i < 10; i++) {
        var trashItem = new Image(trashHeight, trashWidth);
        trashItem.src = "images/junk.png";
        trashItem.style.position = "absolute";
        trashItem.className = "trash-item";
        trashItem.draggable = true;
        trashItem.ondragstart = drag;

        if (trashItem.addEventListener) {
            trashItem.addEventListener("dragstart", drag, false);
        }
        else {
            trashItem.attachEvent("ondragstart", drag);
        }

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
    var data = ev.dataTransfer.getData("dragged-id");
    var dragged = document.getElementById(data);
    dragged.parentNode.removeChild(dragged);
}

function getRandomPosition(min, max) {
    var randomValue = Math.floor(min + Math.random() * (max - min));
    return parseInt(randomValue);
}