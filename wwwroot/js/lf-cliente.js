$("#bt-borrar-cliente").click(function () {

    var IdCliente = $("#IdCliente").val();
     

    Swal.fire({
        title: 'Usted esta Seguro?',
        text: "Esta acción sera irreversible!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Si, Borrarlo!'
    }).then((result) => {

        if (result.isConfirmed) {
            $.ajax({
                cache: false,
                async: false,
                type: "POST",
                url: "/Cliente/ClienteValidar", // the action it
                data: { IdCliente: IdCliente}, 
                success: function (response) {
                    if (response.result == true) {
                        Swal.fire(
                            'Borrado!',
                            'El Cliente ' + IdCliente + ' fue eliminado.',
                            'success'
                        )
                    }
                    else {
                        Swal.fire(
                            'Error!',
                            'El Cliente ' + IdCliente + ' no puede ser eliminado:<br/><p style="color:red;">' + response.error + '</p>',
                            'error'
                        );
                        window.location.href = '/Cliente/Index/';

                    }
                }

            })
        }
    })
})

 