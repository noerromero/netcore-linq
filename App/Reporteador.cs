using System;
using System.Collections.Generic;
using CoreEscuela.Entidades;
using System.Linq;

namespace CoreEscuela.App
{
    public class Reporteador{

    Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> _diccionario;


        public Reporteador(Dictionary<LlaveDiccionario, IEnumerable<ObjetoEscuelaBase>> dicObjEscuela){
            if (dicObjEscuela == null)
                throw new ArgumentException(nameof(dicObjEscuela));

            _diccionario = dicObjEscuela;        
        }

        public IEnumerable<Escuela> GetListaEvaluaciones()
            {
                IEnumerable<Escuela> rpta;
                if ( _diccionario.TryGetValue(LlaveDiccionario.Escuela,out IEnumerable<ObjetoEscuelaBase> lista))
                    rpta = lista.Cast<Escuela>();
                else
                    rpta = null;

                return lista.Cast<Escuela>();
                
            }

    }

    

}
