var domModule = function () {
    var buffer = [];

    function appendChild(element, parentSelector) {
        var parents = document.querySelectorAll(parentSelector);

        for (var i = 0; i < parents.length; i++)
            parents[i].appendChild(element.cloneNode(true));
    }

    function removeChild(targetSelector, toRemoveSelector) {
        var parentTargets = document.querySelectorAll(targetSelector);

        for (var i = 0; i < parentTargets.length; i++) {
            var removeTargets = parentTargets[i].querySelectorAll(toRemoveSelector);

            for (var j = 0; j < removeTargets.length; j++)
                parentTargets[i].removeChild(removeTargets[j]);
        }
    }

    function addHandler(targetSelector, action, handler) {
        var targets = document.querySelectorAll(targetSelector);

        for (var i = 0; i < targets.length; i++)
            targets[i].addEventListener(action, handler, false);
    }

    function getElementsBySelector(selector) {
        return document.querySelectorAll(selector);
    }

    function appendToBuffer(selector, child) {
        buffer.push({ selector: selector, child: child });

        if (buffer.length == 100) {
            for (var i = 0; i < buffer.length; i++)
                appendChild(buffer[i].child, buffer[i].selector);

            buffer = [];
        }      
    }

    return {
        appendChild: appendChild,
        removeChild: removeChild,
        addHandler: addHandler,
        getElementsBySelector: getElementsBySelector,
        appendToBuffer: appendToBuffer
    }
}();

domModule.addHandler("a.button", "mouseover", function () { alert("You hovered!"); });
domModule.removeChild("ul", "li:first-child");

var li = document.createElement("li");
li.innerText = "new li";

domModule.appendChild(li, "ul");
domModule.appendChild(li, "ul.first");

