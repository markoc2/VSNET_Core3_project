
$('#editform').submit(function (e) {
    e.preventDefault();
    var $form = $(this);

    // check if the input is valid using a 'valid' property
    if (!$form.valid) return false;


    $.ajax({
        type: 'POST',
        url: 'Edit',
        data: $('#editform').serialize(),
        success: function (response) {

            if (response.result == true) {
                Swal.fire(
                    'Guardado!',
                    'El registro se ha guardado Existosamente.',
                    'success'
                ) 
                window.setTimeout(function () {
                    window.location.href = '/Prestamo/Index/';
                }, 1000);
            }
            else {
                Swal.fire(
                    'Error!',
                    'El Prestamo presento un error al guardarse:<br/><p style="color:red;">' + response.error + '</p>',
                    'error'
                );


             }

        },
    });
});
  

$("#bt-borrar-prestamo").click(function () {

    var IdPrestamo = $("#IdPrestamo").val();


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

})
$("#bt-aprobar-prestamo").click(function () {

    var IdPrestamo = $("#IdPrestamo").val();  
    /*console.log(IdPrestamo) */

    $.ajax({
        cache: false,
        async: false,
        type: "POST",
        url: "/Prestamo/PrestamoAprobar", // the action it
        data: { IdPrestamo: IdPrestamo },
        success: function (response) {
            if (response.result == true) {
                Swal.fire(
                    'Aprobado!',
                    'El Prestamo fue aprobado.',
                    'success'
                )
                window.setTimeout(function () {
                    window.location.href = '/Prestamo/Index/';
                }, 2000);
            }
            else {
                Swal.fire(
                    'Error!',
                    'El Prestamo  no puede ser eliminado:<br/><p style="color:red;">' + response.error + '</p>',
                    'error'
                );
                window.location.href = '/Prestamo/Index/';

            }
        }

    })



})
