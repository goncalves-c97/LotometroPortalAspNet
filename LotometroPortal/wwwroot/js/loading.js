var boxContent = $("#box-content");
var boxLoading = $("#box-load");

if (boxContent == null)
    console.log("Content não encontrado");
else
    $(boxContent).css("display", "block");

if (boxLoading == null)
    console.log("Loading não encontrado");
else
    $(boxLoading).css("display", "none");


function ShowLoading() {
    if (boxLoading == null)
        console.log("Loading não encontrado");
    else
    {
        console.log("Solicitando abertura do loading");
        $(boxLoading).css("display", "flex");
        $(boxLoading).slideDown(100, AfterShowLoading);        
    }        
}

function HideLoading() {
    if (boxLoading == null)
        console.log("Loading não encontrado");
    else {
        console.log("Solicitando fechamento do loading");
        $(boxLoading).slideUp(300, AfterHideLoading);
    }   
}

function AfterShowLoading() {
    console.log("Fim do Show");
    $(boxContent).css("display", "none");
}

function AfterHideLoading() {
    console.log("Fim do Hide");
    $(boxContent).css("display", "block");
    $(boxLoading).css("display", "none");
}

$(document).ready(function () {
    HideLoading();
});