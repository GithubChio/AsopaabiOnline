


document.addEventListener( //Cuando se cargó la página
    'DOMContentLoaded',
    function (evt) {
        //var btnValidar = document.getElementById('guardar');

        var btnTipoDeDni = document.getElementById('tipoDeDni');
        btnTipoDeDni.addEventListener('click', ValidarDNI);
    }
);



//function ValidarDNI(evt) {
   
//    $("#tipoDeDni").change(function () {
//        var opcion = "",
//            mostrar = "";
//        $("#tipoDeDni option:selected").each(function () {
//            opcion += $(this).text() + " "
//        });
//        mostrar = "la opcion es:" + opcion;
          
           
            
//        $("#mostrar").text(mostrar); }).trigger("change");

//}
function ValidarDNI(evt) {
    var numeroDeCedula = document.getElementById('Dni').value,
        imprimir = document.getElementById('elResultado'),
        cedulaFisicaValida = /^[1-9]-\d{3}-\d{3}$/,
        cedulaJuridicaValida = /^[1-9]-\d{3}-\d{6}$/;

    $("#tipoDeDni").click(function (evento) {
        var elResultado = '';
        for (var recorrer = 1; recorrer <= $(this).val(); recorrer++) {
            elResultado += crear(recorrer);
        }
        $("#mostrar").elResultado(elResultado);
    });

    var crear = function (num) {


      
        if (num = 1) {


                if (cedulaFisicaValida.test(numeroDeCedula)) {

                } else  { imprimir.innerText = ' La Cédula: ' + numeroDeCedula + ' es inválida, Formato: 5-255-668'; }

            } else if (num = 2) {
               if (cedulaJuridicaValida.test(numeroDeCedula)) {

                } else {
                    imprimir.innerText = ' La Cédula: ' + numeroDeCedula + ' es inválida, Formato: 5-255-618266';
                }

            }
        
            

    };

}