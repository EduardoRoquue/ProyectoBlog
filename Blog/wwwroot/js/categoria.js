var dataTable;

//Llamada a JQuery
$(document).ready(function () {
    cargarDataTable();
});

//#tblCategorias se encuentra en Areas/Admin/Views/Categorias
function cargarDataTable() {
    dataTable = $("#tblCategorias").DataTable({
        "ajax": {
            "url": "/admin/categorias/GetAll",
            "type": "GET",
            "datatype": "json"
        },
        //Campos de la tabla
        "columns": [
            { "data": "id", "width": "5%" },
            { "data": "nombre", "width": "50%" },
            { "data": "orden", "width": "20%" },
            {
                "data": "id",
                "render": function (data) {
                    return `<div class="text-center">
                            <a href='/Admin/Categorias/Edit/${data}' class='btn btn-outline-success text-black' style='cursor:pointer; width:100px;'>
                            <i class='fas fa-edit'></i>Editar
                            </a>
                                &nbsp;
                            <a onclick=Delete("/Admin/Categorias/Delete/${data}")
                            class='btn btn-outline-danger text-black' style = 'cursor:pointer; width:100px;' >
                            <i class='fas fa-trash-alt'></i> Borrar
                            </a>
                            `;
                }, "width": "30%"
            }
        ],
        "language": {
            "emptyTable": "No hay registros"
        },
        "width": "100%"
    });
}
//Boton de borrar de swwet alert
function Delete(url) {
    swal({
        title: "Esta seguro de borrar?",
        text: "Este contenido no se puede recuperar!",
        type: "warning",
        showCancelButton: true,
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Si, borrar!",
        closeOnconfirm: true
    }, function () {
        $.ajax({
            type: 'DELETE',
            url: url,
            success: function (data) {
                if (data.success) {
                    toastr.success(data.message);
                    dataTable.ajax.reload();
                }
                else {
                    toastr.error(data.message);
                }
            }
        });
    });
}