$(document).ready(function () {
        $("#TabFichesMetiers tbody tr:odd").css({ 'background-color': '#CEF6D8' });
        $("#TabFichesMetiers tbody tr:even").css({ 'background-color': '#F8E0E6' });

        $('input:checked').each(function () {
            $(this).attr("value");
        });

        /***********************************************/
        /****************  DATATABLE *******************/
        /***********************************************/
        var oldStart = 0;
        var table = $('#TabFichesMetiers').dataTable({
            "bSort": true,
            //"sPaginationType": "bootstrap",
            "sPaginationType": "full_numbers",
            "iDisplayLength": 10, // pour mettre le nombre de lignes affichées par défaut
            "aoColumns": [
              { "bSearchable": true, "bSortable": true },  // id
              { "bSearchable": false, "bSortable": false },  // Publier
              { "bSearchable": true, "bSortable": true },  // Nom
              { "bSearchable": false, "Width": "80%", "bSortable": false }, // Texte
              { "bSearchable": false, "bSortable": false }, // boutons
              { "bSearchable": true, "bSortable": false }, // ecoles
              { "bSearchable": false, "bSortable": false }, // categories
              { "bSearchable": false, "bSortable": false }, // editer la fiche
            ],
            // Pour faire remonter lorsqu'on change de page
            "fnDrawCallback": function (o) {
                if (o._iDisplayStart != oldStart) {
                    var targetOffset = $('#TabFichesMetiers').offset().top;
                    $('html,body').animate({ scrollTop: targetOffset }, 500);
                    oldStart = o._iDisplayStart;
                }
            },
            "oLanguage": {
                "sSearch": "Rechercher :",
                "sInfoFiltered": " (filtre sur _MAX_ lignes)",
                "sProcessing": "Traitement des données en cours ...",
                "sLengthMenu": 'Affichage <select>' +
                    '<option value="10">10</option>' +
                    '<option value="20">20</option>' +
                    '<option value="50">50</option>' +
                    '<option value="-1">All</option>' +
                    '</select> fiches',
                "sInfoEmpty": "Aucun résultat",
                "sInfo": "_TOTAL_ fiches au total",
                "oPaginate": {
                    "sNext": "Suivant",
                    "sPrevious": "Précédent",
                    "sLengthMenu": "Afficher _MENU_ résultats"
                }
            }

        });

        /***********************************************/
        /**************  DELEGATE JQUERY ***************/
        /***********************************************/
        // On clique sur le bouton toggle "Code <-> Design"
        $('body').delegate('.boutonCode', 'click', function () {
            var buttonid = $(this).attr("id"); // id du bouton choisi button-52
            var id = buttonid.split("-");
            toggleEditor(id[1]);
        })
        // On fait apparaître le bouton "Save"
        $('body').delegate('textarea, .divNom, .divText, .checkbox', 'focus', function () {
            var buttonid = $(this).attr("id"); // id du bouton choisi button-52
            var id = buttonid.split("-");
            $("#buttonSave-" + id[1]).show();
        });
        // On sauvegarde la fiche lorsqu'on clique sur "Save"
        $('body').delegate('.boutonSave', 'click', function () {
            var buttonid = $(this).attr("id"); // id du bouton choisi button-52
            var id = buttonid.split("-");
//alert(id[1]);
            savefiche(id[1]);
        })
        // On sauvegarde la fiche lorsqu'on clique sur "Enregistrer la fiche" 
        $('body').delegate('.boutonSaveModif', 'click', function () {
            var buttonid = $(this).attr("id"); // id du bouton choisi button-52
            var id = buttonid.split("-");
//alert(id[1]);
            saveficheModif(id[1]);
        })
        $('body').delegate('#OK', 'click', function () {
            var id = $("#ajoutEcole").find(":selected").val();
            addEcoleFiche(id);
        });
        $('body').delegate('#OKCat', 'click', function () {
            var id = $("#ajoutCategorie").find(":selected").val();
            addCategorieFiche(id);
        });
});




