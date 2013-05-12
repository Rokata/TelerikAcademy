var todoList = document.getElementById("todo");

function addItem() {
    var value = document.getElementById("addItem").value;
    var item = document.createElement("li");
    item.innerHTML = value;
    item.onclick = markItem;
    todoList.appendChild(item);
}

function markItem(ev) {
    if (!ev) ev = window.event;

    var target = ev.srcElement;

    if (target.style.color == "red")
        target.style.color = "black";
    else {
        target.style.color = "red";
    }
}

function removeItems() {
    for (var i = 0; i < todoList.childNodes.length; i++) {
        var current = todoList.childNodes[i];

        if (current.style.color == "red") {
            todoList.removeChild(current);
            i--; // the list resizes after removal
        }
    }
}

function hideSelected() {
    for (var i = 0; i < todoList.childNodes.length; i++) {
        var current = todoList.childNodes[i];

        if (current.style.color == "red") {
            current.style.color = "black";
            current.style.display = "none";
        }
    }
}

function show() {
    for (var i = 0; i < todoList.childNodes.length; i++) {
        var current = todoList.childNodes[i];

        if (current.style.display == "none")
            current.style.display = "block";
    }
}