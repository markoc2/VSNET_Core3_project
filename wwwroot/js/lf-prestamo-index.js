$(document).ready(function () {
    $('#prestamos-table').DataTable();


    delete_item = function (IdPrestamo, that) {
           
        Swal.fire({
            title: 'Usted esta Seguro?',
            text: "Esta acción suspedera el prestamo!",
            icon: 'warning',
            showCancelButton: true,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Si, Borrarlo!'
        }).then((result) => {
             
            $.ajax({
                cache: false,
                async: false,
                type: "POST",
                url: "/Prestamo/Delete", // the action it
                data: { IdPrestamo: IdPrestamo },
                success: function (response) {
                    if (response.result == true) {
                        Swal.fire(
                            'Suspendido!',
                            'El Prestamo fue suspendido.',
                            'success'
                        )
                        window.setTimeout(function () {
                            window.location.href = '/Prestamo/Index/';
                        }, 2000);
                    }
                    else {
                        Swal.fire(
                            'Error!',
                            'El Prestamo no puede ser suspendido:<br/><p style="color:red;">' + response.error + '</p>',
                            'error'
                        );
                        window.location.href = '/Prestamo/Index/';

                    }
                }

            })
        })

         

    };
});