var specialConsole = function () {
    function writeLine() {
        if (arguments.length == 0) {
            console.log("");
            return;
        }

        console.log(getOutput(arguments));
    }

    function writeError() {
        if (arguments.length == 0) {
            console.error("");
            return;
        }

        console.error(getOutput(arguments));
    }

    function getOutput(args) {
        var output = args[0];

        for (var i = 1; i < args.length; i++)
            output = output.replace(new RegExp('\\{' + (i - 1) + '\\}', "g"), args[i].toString());

        return output;
    }

    return {
        writeLine: writeLine,
        writeError: writeError
    }
}();

specialConsole.writeError("sdasokds");
specialConsole.writeLine("My name is {0} {1} and I'm from {2}", "Jack", "Johnson", "London");
specialConsole.writeLine();
specialConsole.writeLine("The html element {0} has {1} toString() output", "document", document);