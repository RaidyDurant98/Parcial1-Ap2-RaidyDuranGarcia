/*Modal Eliminar*/
function showModalEliminar() {
    $("#ModalEliminar").modal('show');
}

$(function () {
    $("#EnviarAlModalEliminar").click(function () {
        showModalEliminar();
    });
});