// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

//var status = document.getElementById('status').innerText;
var card = document.getElementsByClassName("report-card");


var Mine_Option = document.getElementById("Mine");
var Available_Option = document.getElementById("Available");
var All_Option = document.getElementById("all");

//alert(All_Option.innerText);

//-------------

//-------------
navOptions = {
   0: Mine_Option,
   1: Available_Option,
   2: All_Option
}
//function remover(option) { option.classList.remove('activated-focused'); }



Mine_Option.onclick = function () {
    All_Option.classList.remove('activated-focused');
    Mine_Option.classList.add('activated-focused');
    Available_Option.classList.remove('activated-focused');
}
Available_Option.onclick = function () {
    Mine_Option.classList.remove('activated-focused');
    All_Option.classList.remove('activated-focused');
    Available_Option.classList.add('activated-focused');

}
All_Option.onclick = function () {
    Mine_Option.classList.remove('activated-focused');
    All_Option.classList.add('activated-focused');
    Available_Option.classList.remove('activated-focused');
}



function loadCustom() {
    var xhttp = new XMLHttpRequest();
    xhttp.onreadystatechange = function () {
        if (this.readyState == 4 && this.status == 200) {
            document.getElementById("demo").innerHTML = this.responseText;
        }
    };
    xhttp.open("GET", "ajax_info.txt", true);
    xhttp.send();
}
}

//option.classList.add('activated-focused');

/* function selected(links) {
    links.onclick(links.classList.add('activated-focused')); 
  //  links = links.innerText;
   
    if (links == "All Investigations") {



    } else if (links == "Available") {
     
       
    } else if (links == "My Investigations") {
         
    } 
} 

console.log(navOptions);
for (var i = 0; i < navOptions.length; i++) {

    navOptions[i].addEventListener("click", function () {
        navOptions[i].classList.remove('activated-focused');
    })}

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
if (card != null) {
    while (i < card.length) {
        var cardstatus = card[i].getElementsByClassName('status')[0].innerText;
        console.log(cardstatus);
        statuscolor(cardstatus)

    }
}

*/