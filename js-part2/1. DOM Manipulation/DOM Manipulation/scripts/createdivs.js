window.onload = createDivElements;

function createDivElements() {
    var count = 5;
    var divsFragment = document.createDocumentFragment();

    for (var i = 0; i < count; i++) {
        var div = document.createElement("div");
        div.style.position = "absolute";
        div.style.top = randomBetween(0, screen.height);
        div.style.left = randomBetween(0, screen.width - 20);
        div.style.width = randomBetween(20, 100);
        div.style.height = randomBetween(20, 100);
        div.style.backgroundColor = getRandomColor();
        div.style.color = getRandomColor();
        div.style.borderRadius = randomBetween(1, 15);
        div.style.borderWidth = randomBetween(1, 20);
        div.style.borderColor = getRandomColor();
        var strong = document.createElement("strong");
        strong.innerText = "div";
        div.appendChild(strong);
        document.body.appendChild(div);
    }
}

function removePreviousDivs() {
    var divs = document.body.getElementsByTagName("div");

    for (var i = 0; i < divs.length; i++)
        document.body.removeChild(divs[i]);
}

function getRandomColor() {
    var letters = '0123456789ABCDEF'.split('');
    var color = '#';

    for (var i = 0; i < 6; i++)
        color += letters[Math.round(Math.random() * 15)];

    return color;
}

function randomBetween(min, max) {
    var randomValue = Math.floor(min + Math.random() * max);
    return parseInt(randomValue);
}
 