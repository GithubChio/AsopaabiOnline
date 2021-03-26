using AsopaabiOnline.Modelo;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace AsopaabiOnline.AccesoADatos
{
    public class GestorDeDistritos
    {

        //--------------------------Distritos de la provincia de san jose----------------------------------------------------------------------

        //Se obtienen los distritos del canton de San Jose 
        public List<Distrito> ObtenerDistritosDelCantonDeSanJose()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 1
                              select elDistrito;
            return elResultado.ToList();
        }

        //Se obtienen los distritos del canton de Escazu
        public List<Distrito> ObtenerDistritosDelCantonDeEscazu()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 1
                              select elDistrito;
            return elResultado.ToList();
        }

        //Se obtienen los distritos del canton de Desamparados
        public List<Distrito> ObtenerDistritosDelCantonDeDesamparados()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 3
                              select elDistrito;
            return elResultado.ToList();
        }

        //Se obtienen los distritos del canton de Puriscal
        public List<Distrito> ObtenerDistritosDelCantonDePuriscal()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 4
                              select elDistrito;
            return elResultado.ToList();
        }

        //Se obtienen los distritos del canton de Tarrazu
        public List<Distrito> ObtenerDistritosDelCantonDeTarrazu()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 5
                              select elDistrito;
            return elResultado.ToList();
        }

        //Se obtienen los distritos del canton de Aserri
        public List<Distrito> ObtenerDistritosDelCantonDeAserri()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 6
                              select elDistrito;
            return elResultado.ToList();
        }
        //Se obtienen los distritos del canton de  Mora
        public List<Distrito> ObtenerDistritosDelCantonDeMora()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 7
                              select elDistrito;
            return elResultado.ToList();
        }
        //Se obtienen los distritos del canton de Goicoechea
        public List<Distrito> ObtenerDistritosDelCantonDeGoicoechea()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 8
                              select elDistrito;
            return elResultado.ToList();
        }

        //Se obtienen los distritos del canton de Santa Ana
        public List<Distrito> ObtenerDistritosDelCantonDeSantaAna()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 9
                              select elDistrito;
            return elResultado.ToList();
        }

        //Se obtienen los distritos del canton de  Alajuelita
        public List<Distrito> ObtenerDistritosDelCantonDeAlajuelita()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 10
                              select elDistrito;
            return elResultado.ToList();
        }
        //Se obtienen los distritos del canton de  Vazquez de Colorado
        public List<Distrito> ObtenerDistritosDelCantonDeVazquezDeCoronado()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 11
                              select elDistrito;
            return elResultado.ToList();
        }
        //Se obtienen los distritos del canton de  Acosta
        public List<Distrito> ObtenerDistritosDelCantonDeAcosta()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 12
                              select elDistrito;
            return elResultado.ToList();
        }
        //Se obtienen los distritos del canton de Tibas
        public List<Distrito> ObtenerDistritosDelCantonDeTibas()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 13
                              select elDistrito;
            return elResultado.ToList();
        }
        //Se obtienen los distritos del canton de Moravia
        public List<Distrito> ObtenerDistritosDelCantonDeMoravia()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 14
                              select elDistrito;
            return elResultado.ToList();
        }
        //Se obtienen los distritos del canton de Montes de Oca
        public List<Distrito> ObtenerDistritosDelCantonDeMontesDeOca()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 15
                              select elDistrito;
            return elResultado.ToList();
        }
        //Se obtienen los distritos del canton de Turrucabares
        public List<Distrito> ObtenerDistritosDelCantonDeTurrubares()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 16
                              select elDistrito;
            return elResultado.ToList();
        }
        //Se obtienen los distritos del canton de Dota
        public List<Distrito> ObtenerDistritosDelCantonDeDota()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 17
                              select elDistrito;
            return elResultado.ToList();
        }
        //Se obtienen los distritos del canton de Curridabat
        public List<Distrito> ObtenerDistritosDelCantonDeCurridabat()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 18
                              select elDistrito;
            return elResultado.ToList();
        }
        //Se obtienen los distritos del canton de Perez Zeledon 

        public List<Distrito> ObtenerDistritosDelCantonDePerezZeledon()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 19
                              select elDistrito;
            return elResultado.ToList();
        }
        //Se obtienen los distritos del canton de Leon Cortes Castro
        public List<Distrito> ObtenerDistritosDelCantonDeLeonCortesCastro()
        {
            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 20
                              select elDistrito;
            return elResultado.ToList();
        }




        //-----------------------------Distritos de la provincia de Alajuela-------------------------------------------------------------------

        //Se obtienen los distritos del canton de Alajuela
        public List<Distrito> ObtenerDistritosDelCantonDeAlajuela()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 21
                              select elDistrito;
            return elResultado.ToList();
        }

        //Se obtienen los distritos del canton de San Ramon
        public List<Distrito> ObtenerDistritosDelCantonDeSanRamon()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 22
                              select elDistrito;
            return elResultado.ToList();
        }

        //Se obtienen los distritos del canton de Grecia
        public List<Distrito> ObtenerDistritosDelCantonDeGrecia()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 23
                              select elDistrito;
            return elResultado.ToList();
        }

        //Se obtienen los distritos del canton de San Mateo
        public List<Distrito> ObtenerDistritosDelCantonDeSanMateo()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 24
                              select elDistrito;
            return elResultado.ToList();
        }
        //Se obtienen los distritos del canton de Atenas
        public List<Distrito> ObtenerDistritosDelCantonDeAtenas()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 25
                              select elDistrito;
            return elResultado.ToList();
        }

        //Se obtienen los distritos del canton de Naranjo
        public List<Distrito> ObtenerDistritosDelCantonDeNaranjo()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 26
                              select elDistrito;
            return elResultado.ToList();
        }
        //Se obtienen los distritos del canton de Palmares
        public List<Distrito> ObtenerDistritosDelCantonDePalmares()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 27
                              select elDistrito;
            return elResultado.ToList();
        }
        //Se obtienen los distritos del canton de Poas
        public List<Distrito> ObtenerDistritosDelCantonDePoas()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 28
                              select elDistrito;
            return elResultado.ToList();
        }
        //Se obtienen los distritos del canton de Orotina
        public List<Distrito> ObtenerDistritosDelCantonDeOrotina()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 29
                              select elDistrito;
            return elResultado.ToList();
        }

        //Se obtienen los distritos del canton de San Carlos
        public List<Distrito> ObtenerDistritosDelCantonDeSanCarlos()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 210
                              select elDistrito;
            return elResultado.ToList();
        }
        //Se obtienen los distritos del canton de Zarcero
        public List<Distrito> ObtenerDistritosDelCantonDeZarcero()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 211
                              select elDistrito;
            return elResultado.ToList();
        }

        //Se obtienen los distritos del canton de Valdeverde Vega
        public List<Distrito> ObtenerDistritosDelCantonDeValverdeVega()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 212
                              select elDistrito;
            return elResultado.ToList();
        }
        //Se obtienen los distritos del canton de Upala
        public List<Distrito> ObtenerDistritosDelCantonDeUpala()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 213
                              select elDistrito;
            return elResultado.ToList();
        }
        //Se obtienen los distritos del canton de Los Chiles
        public List<Distrito> ObtenerDistritosDelCantonDeLosChiles()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 214
                              select elDistrito;
            return elResultado.ToList();
        }
        //Se obtienen los distritos del canton de Guatuso
        public List<Distrito> ObtenerDistritosDelCantonDeGuatuso()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 215
                              select elDistrito;
            return elResultado.ToList();
        }




        //-------------------------------------------Distritos de la provincia de Cartago------------------------------------------------------

        //Se obtienen los distritos del canton de Cartago
        public List<Distrito> ObtenerDistritosDelCantonDeCartago()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 31
                              select elDistrito;
            return elResultado.ToList();
        }

        //Se obtienen los distritos del canton de Paraiso
        public List<Distrito> ObtenerDistritosDelCantonDeParaiso()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 32
                              select elDistrito;
            return elResultado.ToList();
        }
        //Se obtienen los distritos del canton de La Union
        public List<Distrito> ObtenerDistritosDelCantonDeLaUnion()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 33
                              select elDistrito;
            return elResultado.ToList();
        }

        //Se obtienen los distritos del canton de Jimenez
        public List<Distrito> ObtenerDistritosDelCantonDeJimenez()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 34
                              select elDistrito;
            return elResultado.ToList();
        }
        //Se obtienen los distritos del canton de Turrialba
        public List<Distrito> ObtenerDistritosDelCantonDeTurrialba()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 35
                              select elDistrito;
            return elResultado.ToList();
        }
        //Se obtienen los distritos del canton de Alvarado
        public List<Distrito> ObtenerDistritosDelCantonDeAlvarado()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 36
                              select elDistrito;
            return elResultado.ToList();
        }
        //Se obtienen los distritos del canton de Oreamuno
        public List<Distrito> ObtenerDistritosDelCantonDeOreamuno()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 37
                              select elDistrito;
            return elResultado.ToList();
        }
        //Se obtienen los distritos del canton de El Guarco
        public List<Distrito> ObtenerDistritosDelCantonDeElGuarco()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 38
                              select elDistrito;
            return elResultado.ToList();
        }
       

        //-----------------------------------------Distritos de la provincia de Heredia---------------------------------------------------------------------


        public List<Distrito> ObtenerDistritosDelCantonDeHeredia()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 41
                              select elDistrito;
            return elResultado.ToList();
        }
        public List<Distrito> ObtenerDistritosDelCantonDeBarva()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 42
                              select elDistrito;
            return elResultado.ToList();
        }
        public List<Distrito> ObtenerDistritosDelCantonDeSantoDomingo()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 43
                              select elDistrito;
            return elResultado.ToList();
        }
        public List<Distrito> ObtenerDistritosDelCantonDeSantaBarbara()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 44
                              select elDistrito;
            return elResultado.ToList();
        }
        public List<Distrito> ObtenerDistritosDelCantonDeSanRafael()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 45
                              select elDistrito;
            return elResultado.ToList();
        }
        public List<Distrito> ObtenerDistritosDelCantonDeSanIsidro()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 46
                              select elDistrito;
            return elResultado.ToList();
        }
        public List<Distrito> ObtenerDistritosDelCantonDeBelen()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 47
                              select elDistrito;
            return elResultado.ToList();
        }
        public List<Distrito> ObtenerDistritosDelCantonDeFlores()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 48
                              select elDistrito;
            return elResultado.ToList();
        }
        public List<Distrito> ObtenerDistritosDelCantonDeSanPablo()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 49
                              select elDistrito;
            return elResultado.ToList();
        }

        public List<Distrito> ObtenerDistritosDelCantonDeSarapiqui()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 410
                              select elDistrito;
            return elResultado.ToList();
        }

        //------------------------------------------------------------------------------------------------------------------------
        public List<Distrito> ObtenerDistritosDelCantonDeLiberia()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 51
                              select elDistrito;
            return elResultado.ToList();
        }
        public List<Distrito> ObtenerDistritosDelCantonDeNicoya()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 52
                              select elDistrito;
            return elResultado.ToList();
        }

        public List<Distrito> ObtenerDistritosDelCantonDeSantaCruz()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 53
                              select elDistrito;
            return elResultado.ToList();
        }
        public List<Distrito> ObtenerDistritosDelCantonDeBagaces()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 54
                              select elDistrito;
            return elResultado.ToList();
        }
        public List<Distrito> ObtenerDistritosDelCantonDeCarrillo()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 55
                              select elDistrito;
            return elResultado.ToList();
        }
        public List<Distrito> ObtenerDistritosDelCantonDeCañas()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 56
                              select elDistrito;
            return elResultado.ToList();
        }
        public List<Distrito> ObtenerDistritosDelCantonDeAbangares()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 57
                              select elDistrito;
            return elResultado.ToList();
        }
        public List<Distrito> ObtenerDistritosDelCantonDeTilaran()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 58
                              select elDistrito;
            return elResultado.ToList();
        }
        public List<Distrito> ObtenerDistritosDelCantonDeNandayure()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 59
                              select elDistrito;
            return elResultado.ToList();
        }

        public List<Distrito> ObtenerDistritosDelCantonDeLaCruz()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 510
                              select elDistrito;
            return elResultado.ToList();
        }

        public List<Distrito> ObtenerDistritosDelCantonDeHojancha()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 511
                              select elDistrito;
            return elResultado.ToList();
        }


        //---------------------------------------------------------------------------------------------------------------------------
        public List<Distrito> ObtenerDistritosDelCantonDePuntarenas()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 61
                              select elDistrito;
            return elResultado.ToList();
        }

        public List<Distrito> ObtenerDistritosDelCantonDeEsparza()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 62
                              select elDistrito;
            return elResultado.ToList();
        }

        public List<Distrito> ObtenerDistritosDelCantonDeBuenosAires()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 63
                              select elDistrito;
            return elResultado.ToList();
        }
        public List<Distrito> ObtenerDistritosDelCantonDeMontesDeOro()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 64
                              select elDistrito;
            return elResultado.ToList();
        }
        public List<Distrito> ObtenerDistritosDelCantonDeOsa()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 65
                              select elDistrito;
            return elResultado.ToList();
        }

        public List<Distrito> ObtenerDistritosDelCantonDeAguirre()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 66
                              select elDistrito;
            return elResultado.ToList();
        }
        public List<Distrito> ObtenerDistritosDelCantonDeGolfito()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 67
                              select elDistrito;
            return elResultado.ToList();
        }
        public List<Distrito> ObtenerDistritosDelCantonDeCotoBrus()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 68
                              select elDistrito;
            return elResultado.ToList();
        }
        public List<Distrito> ObtenerDistritosDelCantonDeParrita()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 69
                              select elDistrito;
            return elResultado.ToList();
        }

        public List<Distrito> ObtenerDistritosDelCantonDeCorredores()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 610
                              select elDistrito;
            return elResultado.ToList();
        }
        public List<Distrito> ObtenerDistritosDelCantonDeGarabito()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 611
                              select elDistrito;
            return elResultado.ToList();
        }
        //------------------------------------------------------------------------------------------------------------------------------
        public List<Distrito> ObtenerDistritosDelCantonDeLimon()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 71
                              select elDistrito;
            return elResultado.ToList();
        }

        public List<Distrito> ObtenerDistritosDelCantonDePococi()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 72
                              select elDistrito;
            return elResultado.ToList();
        }
        public List<Distrito> ObtenerDistritosDelCantonDeSiquirres()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 73
                              select elDistrito;
            return elResultado.ToList();
        }

        public List<Distrito> ObtenerDistritosDelCantonDeTalamanca()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 74
                              select elDistrito;
            return elResultado.ToList();
        }
        public List<Distrito> ObtenerDistritosDelCantonDeMatina()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 75
                              select elDistrito;
            return elResultado.ToList();
        }

        public List<Distrito> ObtenerDistritosDelCantonDeGuacimo()
        {

            var laBaseDeDatos = new Contexto();
            var elResultado = from elDistrito in laBaseDeDatos.Distrito
                              where elDistrito.IdCanton == 76
                              select elDistrito;
            return elResultado.ToList();
        }
       
        

    }
}
