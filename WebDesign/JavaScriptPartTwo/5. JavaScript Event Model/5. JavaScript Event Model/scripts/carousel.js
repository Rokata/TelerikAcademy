window.onload = function () {
    var imgSources = ["images/img1.jpg", "images/img2.jpg", "images/img3.jpg"];
    var prev = document.getElementById("arrow-back");
    var next = document.getElementById("arrow-next");
    var current = document.getElementById("current");
    var currentIndex = 0;

    prev.onclick = prevOnClick;
    next.onclick = nextOnClick;

    function prevOnClick() {
        if (currentIndex == 0) {
            currentIndex = imgSources.length - 1;
        }
        else {
            currentIndex--;
        }

        current.setAttribute('src', imgSources[currentIndex]);
    }

    function nextOnClick() {
        if (currentIndex == imgSources.length - 1) {
            currentIndex = 0;
        }
        else {
            currentIndex++;
        }

        current.setAttribute('src', imgSources[currentIndex]);
    }
}