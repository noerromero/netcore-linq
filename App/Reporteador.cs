using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;

namespace CoreEscuela.App
{
    public class Reporteador{

    Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;


        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObjEscuela){
            if (dicObjEscuela == null)
                throw new ArgumentException(nameof(dicObjEscuela));

            _diccionario = dicObjEscuela;        
        }
    }

}