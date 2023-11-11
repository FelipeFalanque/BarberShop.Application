// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.

/* Máscaras ER */
function mascara(o, f) {
    v_obj = o
    v_fun = f
    setTimeout("execmascara()", 1)
}
function execmascara() {
    v_obj.value = v_fun(v_obj.value)
}
function mtel(v) {
    v = v.replace(/\D/g, ""); //Remove tudo o que não é dígito
    v = v.replace(/^(\d{2})(\d)/g, "($1) $2"); //Coloca parênteses em volta dos dois primeiros dígitos
    v = v.replace(/(\d)(\d{4})$/, "$1-$2"); //Coloca hífen entre o quarto e o quinto dígitos
    return v;
}
function id(el) {
    return document.getElementById(el);
}
window.onload = function () {
    const collectionPhone = document.getElementsByClassName("phone");
    if (collectionPhone[0]) { 
        collectionPhone[0].onkeyup = function () {
            mascara(this, mtel);
        }
    }

    const collectionYear = document.getElementsByClassName("year");
    if (collectionYear[0]) { 
        collectionYear[0].onkeyup = function () {
            mascaraYear(this, mtelYear);
        }
    }
}

//---------------------------------------------------------------------

function mascaraYear(o, f) {
    v_obj = o
    v_fun = f
    setTimeout("execMascaraYear()", 1)
}
function execMascaraYear() {
    v_obj.value = v_fun(v_obj.value)
}
function mtelYear(v) {
    v = v.replace(/\D/g, ""); //Remove tudo o que não é dígito
    return v;
}

//---------------------------------------------------------------------
