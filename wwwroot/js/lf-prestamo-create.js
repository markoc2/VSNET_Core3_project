
$(document).ready(function () {

$('#newform').submit(function (e) {
    e.preventDefault();
    var $form = $(this);

    // check if the input is valid using a 'valid' property
    if (!$form.valid) return false;

    alert(!$form.valid)

    $.ajax({
        type: 'POST',
        url: 'Create',
        data: $('#newform').serialize(),
        success: function (response) {

            if (response.result == true) {
                Swal.fire(
                    'Guardado!',
                    'El registro se ha guardado Existosamente.',
                    'success'
                )

                window.setTimeout(function () {
                    window.location.href = '/Prestamo/Index/';
                }, 5000);
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

})
