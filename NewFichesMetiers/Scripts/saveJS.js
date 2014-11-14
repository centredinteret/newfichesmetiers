/******************************************************/
/******************** savefiche ***********************/
/*********** Pour écrire les modifications   **********/
/******************* d'une fiche **********************/
/******************************************************/
/****  APPELE PAR JQUERY :'.boutonSave', 'click',  ****/
/****  PARAMETRES : 
/*** IN : id : id de la fiche *************/
function savefiche(id) {
    var nom = $("#divNom-" + id).html();
    // On vérifie si on doit sauvegarder le textarea ou la div
    if ($('#textarea-' + id).css("display") === "none") {
        var texte = $("#div-" + id).html();
    }
    else {
        var texte = $("#textarea-" + id).val();
    }
    // Click ou pas sur CheckBox Publier
    var publier = $("#chk-" + id).is(':checked');   //NE PAS UTILISER .val();

    var param = {
        param0: publier
        , param1: id
        , param2: nom
        , param3: texte
    };
    $.ajax
    ({
        type: "POST",
        url: '../../Ajax/SaveFicheAjax',
        data: JSON.stringify(param),
        contentType: 'application/json;',
        cache: false,
        success: function (data) {
            $("#texteRetour").text(data);
            if (data = "Add") {
                message = "La fiche " + id + " vient d'être créée"
            }
            if (data = "Update") {
                message = "La mise à jour de la fiche " + nom + " s'est bien effectuée"
            }
            alert(message);
            $("#buttonSave-" + id).hide();
        },
        error: function (data) {
            $("#texteRetour").text("ERREUR");
        }
    });
}

/******************************************************/
/******************** savefiche ***********************/
/*********** Pour écrire les modifications   **********/
/******************* d'une fiche **********************/
/******************************************************/
/****  APPELE PAR JQUERY :'.boutonSaveModif', 'click',  ****/
/****  PARAMETRES : 
/*** IN : id : id de la fiche *************/
function saveficheModif(id) {
    var nom = $("#divNom-" + id).html();
    // On vérifie si on doit sauvegarder le textarea ou la div
    var texte = $("#textarea-" + id).val();
    // Click ou pas sur CheckBox Publier
    var publier = $("#chk-" + id).is(':checked');
//alert(texte);
    var param = {
        param0: publier
        , param1: id
        , param2: nom
        , param3: texte
    };
    $.ajax
    ({
        type: "POST",
        url: '../../Ajax/SaveFicheAjax',
        data: JSON.stringify(param),
        contentType: 'application/json;',
        cache: false,
        success: function (data) {
            $("#texteRetour").text(data);
            message = "La mise à jour de la fiche " + nom + " s'est bien effectuée"
            alert(message);
        },
        error: function (data) {
            $("#texteRetour").text("ERREUR");
        }
    });
}