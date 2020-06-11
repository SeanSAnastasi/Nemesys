
//var status = document.getElementById('status').innerText;
var card = document.getElementsByClassName("report-card");


//var Mine_Option = document.getElementById("Mine");
//var Available_Option = document.getElementById("Available");
//var All_Option = document.getElementById("all");

//alert(All_Option.innerText);

//-------------

//-------------
//navOptions = {
//   0: Mine_Option,
//   1: Available_Option,
//   2: All_Option
//}
////function remover(option) { option.classList.remove('activated-focused'); }



//Mine_Option.onclick = function () {
//    All_Option.classList.remove('activated-focused');
//    Mine_Option.classList.add('activated-focused');
//    Available_Option.classList.remove('activated-focused');
//}
//Available_Option.onclick = function () {
//    Mine_Option.classList.remove('activated-focused');
//    All_Option.classList.remove('activated-focused');
//    Available_Option.classList.add('activated-focused');

//}
//All_Option.onclick = function () {
//    Mine_Option.classList.remove('activated-focused');
//    All_Option.classList.add('activated-focused');
//    Available_Option.classList.remove('activated-focused');
//}



//function loadCustom() {
//    var xhttp = new XMLHttpRequest();
//    xhttp.onreadystatechange = function () {
//        if (this.readyState == 4 && this.status == 200) {
//            document.getElementById("demo").innerHTML = this.responseText;
//        }
//    };
//    xhttp.open("GET", "ajax_info.txt", true);
//    xhttp.send();
//}
}

//option.classList.add('activated-focused');

//function selected(links) {
//    links.onclick(links.classlist.add('activated-focused'));
//    links = links.innertext;

//    if (links == "all investigations") {



//    } else if (links == "available") {


//    } else if (links == "my investigations") {

//    }
//}

//console.log(navoptions);
//for (var i = 0; i < navoptions.length; i++) {

//    navoptions[i].addeventlistener("click", function () {
//        navoptions[i].classlist.remove('activated-focused');
//    })
//}

var i = 0;
function statuscolor(statustext) {

    if (statustext == 'available') {

        card[i].setattribute("id", "open-rep");
        i++;
        change color to green
    } else if (statustext == 'in progress') {
        card[i].setattribute("id", "prog-rep");
        i++;
        change color to orange
    } else {
        card[i].setattribute("id", "done-rep");
        i++;
        change color to red
    }
}
if (card != null) {
    while (i < card.length) {
        var cardstatus = card[i].getelementsbyclassname('status')[0].innertext;
        console.log(cardstatus);
        statuscolor(cardstatus)

    }
}
