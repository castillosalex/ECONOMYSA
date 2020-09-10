listar();

function listar() {

    $.get("Cliente/ListadoCliente", function (data) {

        crearListado(["Id Cliente", "Nombre", "Apellido Paterno",
            "Apellido Materno", "Celular", "E-Mail", "Direccion", "Numero de Documento"
        ], data

        )
    });

}

function crearListado(arrayColumnas, data) {
    var contenido = "";
    contenido += "<table id='tablas'  class='table' >";
    contenido += "<thead>";
    contenido += "<tr>";
    for (var i = 0; i < arrayColumnas.length; i++) {
        contenido += "<td>";
        contenido += arrayColumnas[i];
        contenido += "</td>";

    }
    contenido += "<td>Operaciones</td>";
    contenido += "</tr>";
    contenido += "</thead>";
    var llaves = Object.keys(data[0]);
    contenido += "<tbody>";
    for (var i = 0; i < data.length; i++) {
        contenido += "<tr>";
        for (var j = 0; j < llaves.length; j++) {
            var valorLLaves = llaves[j];
            contenido += "<td>";
            contenido += data[i][valorLLaves];
            contenido += "</td>";

        }
        var llaveId = llaves[0];
        contenido += "<td>";
        contenido += "<button class='btn btn-primary' onclick='abrirModal(" + data[i][llaveId] + ")' data-toggle='modal' data-target='#myModal'><i class='glyphicon glyphicon-edit'></i></button> "
        contenido += "<button class='btn btn-danger' onclick='eliminar(" + data[i][llaveId] + ")' ><i class='glyphicon glyphicon-trash'></i></button>"
        contenido += "</td>"

        contenido += "</tr>";
    }
    contenido += "</tbody>";
    contenido += "</table>";
    document.getElementById("tabla").innerHTML = contenido;
    $("#tablas").dataTable(
        {
            searching: false
        }

    );
}
function eliminar(id) {

    if (confirm("Desea eliminar?") == 1) {

        $.get("Cliente/EliminarCliente/?id=" + id, function (data) {
            if (data == -1) {
                alert("Ya existe el cliente");
            } else
                if (data == 0) {
                    alert("Ocurrio un error");
                } else {
                    alert("Se elimino correctamente");
                    listar();
                }
        })
    }
}
function datosObligarios() {
    var exito = true;
    var controlesObligatorio = document.getElementsByClassName("obligatorio");
    var ncontroles = controlesObligatorio.length;
    for (var i = 0; i < ncontroles; i++) {
        if (controlesObligatorio[i].value == "") {
            exito = false;
            controlesObligatorio[i].parentNode.classList.add("error");
        }
        else {
            controlesObligatorio[i].parentNode.classList.remove("error");
        }
    }

    return exito;
}
function Agregar() {

    if (datosObligarios() == true) {

        if (confirm("Desea realiar los cambios?") == 1) {

            var empObj = {
                nombre: $('#txtnombre').val(),
                ap_Paterno: $('#txtapPaterno').val(),
                ap_Materno: $('#txtapMaterno').val(),
                celular: $('#txtCelular').val(),
                correo: $('#txtcorreo').val(),
                direccion: $('#txtdireccion').val(),
                documento_Ident: $('#txtnumeroDocumento').val(),
            };

            $.ajax({
                url: "/Cliente/RegistrarCliente",
                data: JSON.stringify(empObj),
                type: "POST",
                contentType: "application/json;charset=utf-8",
                dataType: "json",
                success: function (result) {
                    alert("Se ejecuto correctamente");
                    listar();
                    document.getElementById("btnCancelar").click();
                },
                error: function (errormessage) {
                    alert(errormessage.responseText);
                }
            })



        }

    }


}

function borrarDatos() {
    var controles = document.getElementsByClassName("borrar");
    var ncontroles = controles.length;
    for (var i = 0; i < ncontroles; i++) {
        controles[i].value = "";
    }

}

function abrirModal(id) {

    var controlesObligatorio = document.getElementsByClassName("obligatorio");
    var ncontroles = controlesObligatorio.length;
    for (var i = 0; i < ncontroles; i++) {
        controlesObligatorio[i].parentNode.classList.remove("error");
    }
    if (id == 0) {
        borrarDatos();
        document.getElementById("lblTitulo").innerHTML = "Registrar Cliente";
        $('#btnRegistrar').show();
        $('#btnActualizar').hide();
    } else {
        
        document.getElementById("lblTitulo").innerHTML = "Actualizar Cliente";
        $.get("Cliente/ObtenerCliente/?id=" + id, function (data) {
            $('#txtid').val(data.id_Cliente);
            $('#txtnombre').val(data.nombre);
            $('#txtapPaterno').val(data.ap_Paterno);
            $('#txtapMaterno').val(data.ap_Materno);
            $('#txtCelular').val(data.celular);
            $('#txtcorreo').val(data.correo);
            $('#txtdireccion').val(data.direccion);
            $('#txtnumeroDocumento').val(data.documento_Ident);
            $('#btnActualizar').show();
            $('#btnRegistrar').hide();

        });

    }
}

function Actualizar() {
    if (datosObligarios() == true) {

        if (confirm("Desea realiar los cambios?") == 1) {
    var empObj = {
        id_Cliente: $('#txtid').val(),
        nombre: $('#txtnombre').val(),
        ap_Paterno: $('#txtapPaterno').val(),
        ap_Materno: $('#txtapMaterno').val(),
        celular: $('#txtCelular').val(),
        correo: $('#txtcorreo').val(),
        direccion: $('#txtdireccion').val(),
        documento_Ident: $('#txtnumeroDocumento').val(),
    };
    $.ajax({
        url: "/Cliente/ActualizarCliente",
        data: JSON.stringify(empObj),
        type: "POST",
        contentType: "application/json;charset=utf-8",
        dataType: "json",
        success: function (result) {
            alert("Se ejecuto correctamente");
            listar();
            document.getElementById("btnCancelar").click();
        },
        error: function (errormessage) {
            alert(errormessage.responseText);
        }
    });
        }
    }
}


