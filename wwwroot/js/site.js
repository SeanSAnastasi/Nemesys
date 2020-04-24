// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//var status = document.getElementById('status').innerText;
var card = document.getElementsByClassName("report-card");

var i = 0;
function statuscolor(statustext ){
                 
    if (statustext == 'AVAILABLE') {
        
        card[i].setAttribute("id", "open-rep");
        i++;
        // Change color to green
    } else if (statustext == 'IN PROGRESS') {
        card[i].setAttribute("id", "prog-rep");
        i++;
        // Change color to orange
    } else {
        card[i].setAttribute("id", "done-rep");
        i++;
        // Change color to Red 
    }
}
while (i < card.length) {
    var cardstatus = card[i].getElementsByClassName('status')[0].innerText;
    console.log(cardstatus);
    statuscolor(cardstatus)
    
}

