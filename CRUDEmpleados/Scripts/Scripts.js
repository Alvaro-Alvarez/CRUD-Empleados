function MuestraVistaImagen(cargaImagen, vistaPreviaImagen) {
    if (cargaImagen.files && cargaImagen.files[0]) {
        var reader = new FileReader();
        reader.onload = function (e) {
            $(vistaPreviaImagen).attr('src', e.target.result);
        }
        reader.readAsDataURL(cargaImagen.files[0]);
    }
}

function jQueryAjaxPost(form) {
    $.validator.unobtrusive.parse(form);
    if ($(form).valid()) {
        var ajaxConfig = {
            type: 'POST',
            url: form.action,
            data: new FormData(form),
            success: function (response) {
                if (response.success) {
                    $("#primerEtiqueta").html(response.html);
                    refreshAddNewTab($(form).attr('data-restUrl'), true);
                    $.notify(response.message, "success");
                    //if (typeof activatejQueryTable !== 'undefined' && $.isFunction(activatejQueryTable))
                    //    activatejQueryTable();
                }
                else {
                    $.notify(response.message, "error");
                }
            }
        }
        if ($(form).attr('enctype') == "multipart/form-data") {
            ajaxConfig["contentType"] = false;
            ajaxConfig["processData"] = false;
        }
        $.ajax(ajaxConfig);

    }
    return false;
}

function refreshAddNewTab(resetUrl, showViewTab) {
    $.ajax({
        type: 'GET',
        url: resetUrl,
        success: function (response) {
            $("#segundaEtiqueta").html(response);
            $('ul.nav.nav-tabs a:eq(1)').html('Agregar Nuevo');
            if (showViewTab)
                $('ul.nav.nav-tabs a:eq(0)').tab('show');
        }

    });
}

function Edit(url) {
    $.ajax({
        type: 'GET',
        url: url,
        success: function (response) {
            $("#segundaEtiqueta").html(response);
            $('ul.nav.nav-tabs a:eq(1)').html('Editar');
            $('ul.nav.nav-tabs a:eq(1)').tab('show');
        }

    });
}


function Eliminar(url) {
    if (confirm('¿Esta seguro que desea eliminar este registro?') == true) {
        $.ajax({
            type: 'POST',
            url: url,
            success: function (response) {
                if (response.success) {
                    $("#primerEtiqueta").html(response.html);
                    $.notify(response.message, "warn");
                }
                else {
                    $.notify(response.message, "error");
                }
            }

        });

    }
}