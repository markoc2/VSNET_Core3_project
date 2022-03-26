$(document).ready(function () {
    $('#pagos-table').DataTable({
        "language": {
            "url": "/lib/DataTables/es-MX.json"
        }
    } );


    pagar_item = function (IdPago, IdPrestamo, that) {
         
             
            $.ajax({
                cache: false,
                async: false,
                type: "POST",
                url: "/Pago/Pagar", // the action it
                data: { IdPago: IdPago, IdPrestamo: IdPrestamo },
                success: function (response) {
                    if (response.result == true) {
                        Swal.fire(
                            'Pagado!',
                            'El pago realizado.',
                            'success'
                        )
                        window.setTimeout(function () {
                            window.location.href = '/Pago/List/' + IdPrestamo;
                        }, 2000);
                    }
                    else {
                        Swal.fire(
                            'Error!',
                            'El pago no puede ser realizado:<br/><p style="color:red;">' + response.error + '</p>',
                            'error'
                        );
                        window.location.href = '/Pago/List/' + IdPrestamo;

                    }
                }

            })
        

    };
});