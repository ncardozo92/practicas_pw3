$(function () {

    $(".cancelar-reserva").click(function () {

        var Item = $(this).parent().parent();
        var IdItem = $(this).attr("data-value");
        
        $.ajax({
            url: "/Paquetes/CancelarReserva",
            type: "POST",
            dataType: "json",
            data: { Id: IdItem },
            success: function (data) {

                if (data.eliminado == true) {
                    Item.fadeOut();
                }
                else {
                    alert("hubo un error al procesar la operación, por favor vuelva a intentarlo.");
                }
            },
            error: function (error) {

                alert("Error interno en el servidor, por favor intentelo más tarde.");
            }
        });
    });
});