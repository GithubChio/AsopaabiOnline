


document.addEventListener( //Cuando se cargó la página
    'DOMContentLoaded',
    function (evt) {
        //var btnValidar = document.getElementById('guardar');

        var btnTipoDeDni = document.getElementById('tipoDeDni');
        btnTipoDeDni.addEventListener('mousemove', ValidarDNI);
    }
);



function ValidarDNI(evt) {
   
    $("#tipoDeDni").change(function () {
        var opcion = "",
            laOpcionGuardada = "",
            mostrar = "";
        $("#tipoDeDni option:selected").each(function () {
            opcion += $(this).text() + " "
        });

                laOpcionGuardada = opcion;
                mostrar = laOpcionGuardada + "aqui";
          
           
            
        $("#mostrar").text(mostrar);



        })
        .trigger("change");

}

function validarCedulaFisica(evt) {
    var numeroDeCedula = document.getElementById('Dni').value,
        elResultado = document.getElementById('elResultado'),
        cedulaValida = /^[1-9]-\d{3}-\d{3}$/;

    
   if (cedulaValida.test(numeroDeCedula)) {
     
    } else {
       elResultado.innerText = ' La Cédula: ' + numeroDeCedula + ' es inválida, Formato: 5-255-668';
    }
}

function validarCedulaJuridica(evt) {
    var numeroDeCedula = document.getElementById('Dni').value,
        elResultado = document.getElementById('elResultado'),
        cedulaValida = /^[1-9]-\d{3}-\d{6}$/;


    if (cedulaValida.test(numeroDeCedula)) {

    } else {
        elResultado.innerText = ' La Cédula: ' + numeroDeCedula + ' es inválida, Formato: 2-255-645868';
    }
}


//$('select[]')


////var elTipoDeDniSeleccionado = document.getElementById('#tipoDeDni').value;
////var elDni = document.getElementById('Dni').value;
////var DniFisica = /^[1-9]-\d{3}-\d{3}$/;
////var DniJuridica = /^[1-9]-\d{3}-\d{6}$/
////if (elTipoDeDniSeleccionado !== "") {

////}
