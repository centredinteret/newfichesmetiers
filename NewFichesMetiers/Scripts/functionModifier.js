/*******************************************************/
/***************** addEcoleFiche ***********************/
/******* Ajouter une école dans une fiche **************/
/*******************************************************/
/****  APPELE PAR JQUERY : '#OK', 'click' ***/
/****  PARAMETRES : ***/
/*** IN : idEcole : id de l'école *************/
/*** OUT : Reload de la page ****/
function addEcoleFiche(idEcole) {
    var ficheG = parseInt(ficheGlobale);
    var param = {
        param0: parseInt(ficheG)
        , param1: idEcole
    };

//alert(ficheG);
    $.ajax
    ({
        type: "POST",
        //url: '../Ajax/SaveFicheEcoleAjax',
        url: '../../Ajax/SaveFicheEcoleAjax',
        data: JSON.stringify(param),
        contentType: 'application/json',
        cache: false,
        success: function (data) {
            location.reload(true);
        },
        error: function (data) {
            $("#test").text("ERREUR Ajout Ecole");
        }
    });
}

/***********************************************************/
/***************** addCategorieFiche ***********************/
/******* Ajouter une categorie dans une fiche **************/
/***********************************************************/
/****  APPELE PAR JQUERY : '#OKCat', 'click' ***/
/****  PARAMETRES : ***/
/*** IN : idEcole : id de l'école *************/
/*** OUT : Reload de la page ****/
function addCategorieFiche(idFiche) {
    var ficheG = parseInt(ficheGlobale);
    var param = {
        param0:  parseInt(ficheG)
        , param1: idFiche
    };
    $.ajax
    ({
        type: "POST",
        //url: 'Ajax/SaveFicheCategorieAjax',
        url: '../../Ajax/SaveFicheCategorieAjax',
        data: JSON.stringify(param),
        contentType: 'application/json',
        cache: false,
        success: function (data) {
            location.reload(true);
        },
        error: function (data) {
            $("#test").text("ERREUR Ajout Catégorie");
        }
    });
}

/************************************************************/
/***************** supprimerEcoleFiche **********************/
/************* Supprimer une école d'une fiche **************/
/************************************************************/
/****  APPELE PAR Modifier.cshtml :  Html.ActionLink("Supprimer"... ***/
/****  PARAMETRES : ***/
/*** IN : idFiche : id de la fiche *************/
/*** IN : idEcole : id de l'école *************/
/*** OUT : Reload de la page ****/
function supprimerEcoleFiche(idFiche, idEcole) {
    if (confirm('Etes-vous sur de vouloir supprimer cette école de cette fiche ?')) {

        var param = {
            param0: idFiche
            , param1: idEcole
        };

        $.ajax
        ({
            type: "POST",
            url: '../../Ajax/SupprimerEcoleFicheAjax/',
            data: JSON.stringify(param),
            contentType: 'application/json',
            cache: false,
            success: function (data) {
                location.reload(true);
            },
            error: function (data) {
                $("#test").text("ERREUR Suppression Ecole");
            }
        });
    }
}

/************************************************************/
/******************* supprimerCatFiche **********************/
/************* Supprimer une catégorie d'une fiche **********/
/************************************************************/
/****  APPELE PAR Modifier.cshtml :  Html.ActionLink(..."SupprimerCat"... ***/
/****  PARAMETRES : ***/
/*** IN : idFiche : id de la fiche *************/
/*** IN : idCat : id de la catégorie ***********/
/*** OUT : Reload de la page ****/
function supprimerCatFiche(idFiche, idCat) {
    if (confirm('Etes-vous sur de vouloir supprimer cette catégorie de cette fiche ?')) {

        var param = {
            param0: idFiche
            , param1: idCat
        };

        $.ajax
        ({
            type: "POST",
            url: '../../Ajax/SupprimerCatFicheAjax',
            data: JSON.stringify(param),
            contentType: 'application/json',
            cache: false,
            success: function (data) {
                location.reload(true);
            },
            error: function (data) {
                $("#test").text("ERREUR Suppression Catégorie");
            }
        });
    }
}