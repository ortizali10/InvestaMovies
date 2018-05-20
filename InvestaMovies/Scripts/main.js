$(document).ready(function () {
    initMovieTable(); // initialize data table upon page load
    initAddMovie(); // initialize Add panel
});

function initMovieTable() {
    var $dataTable = $('#moviesTable');
    var table = $dataTable.DataTable({
        "pagingType": "full_numbers",
        "lengthChange": true,
        "responsive": true,
        "ordering": true,
        "searching": false,
        "paging": true,
        "destory": true,
        "ajax": {
            "url": "/home/getmovies",
            "type": "POST",
            "dataSrc": "",
            "contentType": "application/json; charset=utf-8"
        },
        "columns": [
            { "data": "Title", "searchable": false, width: "30%", className: "desktop, tablet", render: $.fn.dataTable.render.text() },
            { "data": "YearReleased", "searchable": false, width: "25%", className: "desktop, tablet", render: $.fn.dataTable.render.text() },
            { "data": "Rating", "searchable": false, width: "25%", className: "desktop, tablet", render: $.fn.dataTable.render.text() },
            {
                "data": "Id", width: "30%", className: "desktop, tablet",
                "render": function (data, type, full, meta) {
                    var str = '<div class="button-wrapper">';
                    str += '<a role="button" class="btn btn-warning btn-xs" onclick="initUpdateMovie(\''  + data +'\');"><i class="fa fa-pencil fa-fw" data-toggle="tooltip" title="edit"></i></a>';
                    str += '&nbsp;';
                    str += '<a role="button" class="btn btn-danger btn-xs" onclick="initDeleteMovie(\'' + data +'\');"><i class="fa fa-trash fa-fw" data-toggle="tooltip" title="delete"></i></button>';
                    str += '&nbsp;</div>';
                    return str;
                }

            }
        ],
        "initComplete": function (settings, json) {
        }
    });
}

function initAddMovie() {
    $.get("/home/addmovie", function (data) {
        $("#addMoviePanel").empty();
        $("#addMoviePanel").html(data);
    });
}

function initUpdateMovie(id) {
    $.get("/home/updatemovie/" + id, function (data) {
        $("#addMoviePanel").empty();
        $("#addMoviePanel").html(data);
    });
}

function initDeleteMovie(id) {
    var response = confirm("Are you sure you want to delete?");
    if (response == true) {
        $.ajax({
            type: "Delete",
            url: "/home/DeleteMovie/" + id, 
            success: function (data) {
                if (data.Success == true) {
                    alert(data.Message);
                    $('#moviesTable').dataTable().fnDestroy();
                    initMovieTable();
                }
                else {
                    alert("Something went wrong while deleting movie");
                }
            }
        });
    }
}

