/******************************************************/
/***************** toggleEditor ***********************/
/*********** Passage de Code <-> Design  **************/
/******************************************************/
/****  APPELE PAR JQUERY :'.boutonCode', 'click',  ****/
/****  PARAMETRES : ***/
/*** IN : id : id de la fiche *************/
function toggleEditor(id) {
//alert(id);
    if ($('#textarea-' + id).css("display") === "none") {
        //on est en design view, on passe en code view
        $('#textarea-' + id).css("display", "block");
        $('#div-' + id).css("display", "none");
        $('#textarea-' + id).val($('#div-' + id).html());
    }
    else {
        //on est en code view, on passe en design view
        $('#textarea-' + id).css("display", "none");
        $('#div-' + id).css("display", "block");
        $('#div-' + id).html($('#textarea-' + id).val());
    }
}

