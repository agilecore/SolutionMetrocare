



function edit(id) {      
    Metrocare.startPageLoading();   
    var pageContent = $('#page-content');
    var url = "/Prestador/Add/" + id; 
    $.ajax({
        type: "GET",
        cache: false,
        url: url,
        dataType: "html",
        success: function (res) {  
            Metrocare.stopPageLoading();
            pageContent.html(res);
        },
        error: function (xhr, ajaxOptions, thrownError) {       
            Metrocare.stopPageLoading();
            pageContent.html('<h4>Não foi possível carregar o conteúdo solicitado.</h4>');  
        }
    });
}


$(document).ready(function () { iniDataTable(); });


function iniDataTable() {
    $('#grid').DataTable({  
        "language": {
            url: '//cdn.datatables.net/plug-ins/3cfcc339e89/i18n/Portuguese.json'
        },
        "bStateSave": false,
        "columns":
        [
            { "orderable": false },
            { "orderable": true },
            { "orderable": true },
            { "orderable": true },
            { "orderable": false }

        ],
        "pageLength": 25,
        "pagingType": "bootstrap_full_number",
        "order": [
            [1, "asc"]
        ] 
    });
}