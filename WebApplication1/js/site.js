function mensaje(success, mensaje) {

    if (success == 'True') {
        swal({
            title: "",
            text: mensaje,
            type: "success",
            showCancelButton: false,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Aceptar',
            cancelButtonText: ""
        });
    }
    else {
        swal({
            title: "Ups!",
            text: mensaje,
            type: "error",
            showCancelButton: false,
            confirmButtonColor: '#3085d6',
            cancelButtonColor: '#d33',
            confirmButtonText: 'Aceptar',
            cancelButtonText: ""
        });
    }
}
