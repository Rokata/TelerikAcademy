var tags = ["cms", "javascript", "js", "ASP.NET MVC", ".net", ".net", "css", "wordpress", "xaml", "xaml", "js",
            "http", "web", ".net", ".net", "asp.net", "asp.net MVC", "ASP.NET MVC", "wp", "javascript", "javascript", "javascript", "js", "cms", "cms", "html",
            "javascript", "http", "http", "CMS"];
var cloud = document.getElementsByClassName("tags-cloud")[0];
var cloudWidth = parseInt(cloud.style.width);
var cloudHeight = parseInt(cloud.style.height);

generateTagCloud(tags, 17, 42);

function generateTagCloud(tags, minFontSize, maxFontSize) {
    var terms = createSortedDictionaryWithTerms(tags);
    var currentFontSize = maxFontSize;
    var prevValue = terms[0].value;
    var differentValuesCount = getDifferentValuesCount(terms);
    var fontSizeDifference = Math.floor((maxFontSize - minFontSize) / differentValuesCount);

    for (var i = 0; i < terms.length; i++) {
        var cloudItem;

        if (prevValue != terms[i].value) {
            currentFontSize -= fontSizeDifference;
            prevValue = terms[i].value;
        }

        if (i == terms.length - 1 || terms[i].value == terms[terms.length - 1].value)
            cloudItem = createCloudEntry(terms[i].key, minFontSize);
        else
            cloudItem = createCloudEntry(terms[i].key, currentFontSize);

        cloud.appendChild(cloudItem);
    }
}

function createCloudEntry(termName, fontSize) {
    var div = document.createElement("div");
    div.innerText = termName;
    div.style.fontSize = fontSize + "px";
    div.style.position = "absolute";
    div.style.display = "inline-block";
    div.style.top = getRandomPosition(0, cloudHeight - 40) + 'px';
    div.style.left = getRandomPosition(0, cloudWidth - 150) + 'px';

    //document.write("Left: " + getRandomPosition(0, parseInt(cloudHeight)) + ", Top: " + getRandomPosition(0, parseInt(cloudWidth)) + "<br/>");
    //document.write(div.style.width + " | " + div.style.height + "<br/>");

    return div;
}

function getRandomPosition(min, max) {
    var randomValue = Math.floor(min + Math.random() * max);
    return parseInt(randomValue);
}

function getDifferentValuesCount(dictionary) {
    var prev = dictionary[0].value;
    var count = 1;

    for (var i = 0; i < dictionary.length; i++) {
        if (prev != dictionary[i].value) { // checks if there's a new different value
            count++;
            prev = dictionary[i].value;
        }
    }

    return count;
}

function createSortedDictionaryWithTerms(tags) {
    var dictionary = new Array();

    dictionary.contains = function (key) {
        for (var i = 0; i < dictionary.length; i++) {
            if (this[i].key == key)
                return i;
        }
        return -1;
    }

    for (var i in tags) {
        var index = dictionary.contains(tags[i].toLowerCase());

        if (index == -1)
            dictionary.push({ key: tags[i].toLowerCase(), value: 1 });
        else
            dictionary[index].value++;
    }

    sortDictionary(dictionary);
    return dictionary;
}

function sortDictionary(dictionary) {
    for (var i = 0; i < dictionary.length - 1; i++)
        for (var j = i + 1; j < dictionary.length; j++) {
            if (dictionary[j].value > dictionary[i].value) {
                var temp = dictionary[j];
                dictionary[j] = dictionary[i];
                dictionary[i] = temp;
            }
        }
}

function printDictionary(dictionary) {
    for (var i = 0; i < dictionary.length; i++) {
        document.write(dictionary[i].key + " " + dictionary[i].value + "<br/>");
    }
}