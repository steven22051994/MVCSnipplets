console.log("Hello - we run javascript inside the Javascript/Index.cshtml View !!");


// Access by referencing to the ID:

var messagesection = document.getElementById("message");
var oliverbutton = document.getElementById("Oliver");
var peterbutton = document.getElementById("Peter");

oliverbutton.addEventListener("mouseenter", function (event) {
    messagetxt("Oliver has been focussed!");
}, false);

peterbutton.addEventListener("mouseenter", function (event) {
    messagetxt("Peter has been focussed!");
}, false);



function messagetxt(txt) {
    messagesection.innerHTML = txt;

};

function messageclear() {
    messagesection.innerHTML = "";

};

function gotoDome() {
    messagesection.innerHTML = "Dome has been double clicked!";
    domepage();
};


function domepage() {
    // call toastr homepage in seperate tab
    var win = window.open('https://www.w3schools.com/js/js_events_examples.asp', '_oliver2');
    // win.focus();
}


