var fs = require("fs");
var decode = require('unescape');

fs.readFile("input.txt", "ascii", function(err, data) {

    data = data.slice(3, data.length);
    let escapedAll = data.split("\n").join("");
    
    console.log(escapedAll);
    console.log(escapedAll.length);

    let escapedList = data.split("\r\n");
    let unescapedList = [];

    escapedList.forEach((e) =>{
        unescapedList.push(decode(e.slice(1, e.length-1).toString()));
        console.log(decode(e.slice(1, e.length-1)));
    });

    let unescapedAll = unescapedList.join("");

    console.log(unescapedAll);
    console.log(unescapedAll.length);

    console.log(escapedAll.length - unescapedAll.length);
});
