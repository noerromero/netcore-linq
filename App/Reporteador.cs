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

        public IEnumerable<Evaluación> GetListaEvaluaciones()
            {
                if ( _diccionario.TryGetValue(LlaveDiccionario.Evaluación,out IEnumerable<ObjetoEscuelaBase> lista))
                    return lista.Cast<Evaluación>();
                else
                    return new List<Evaluación>();
                
            }

        public IEnumerable<String> GetListaAsignaturas(){
            return GetListaAsignaturas(out var dummy);
        }

        public IEnumerable<String> GetListaAsignaturas(out IEnumerable<Evaluación> lstEvaluaciones){
            lstEvaluaciones = GetListaEvaluaciones();
            return (from Evaluación ev in lstEvaluaciones
                    select ev.Asignatura.Nombre).Distinct();
        }

        public Dictionary<string,IEnumerable<Evaluación>> GetDicEvaxAsig(){
            var dicEvaxAsig = new Dictionary<string,IEnumerable<Evaluación>>();
            var lstAsignaturas = GetListaAsignaturas(out var lstEvaluaciones);

            foreach(var asig in lstAsignaturas){
                var lstEva = from eva in lstEvaluaciones
                                where eva.Asignatura.Nombre==asig
                                select eva; 
                dicEvaxAsig.Add(asig,lstEva);
            }
            return dicEvaxAsig;
        }

        public Dictionary<string,IEnumerable<object>> GetDicPromxAsignatura(){
            var rpta = new Dictionary<string,IEnumerable<object>>();
            var EvaxAsignatura = GetDicEvaxAsig();
            
            foreach(var evaxasig in EvaxAsignatura){
                var obj = from eva in evaxasig.Value
                            group 
                            select new {
                                eva.Alumno.UniqueId,
                                eva.Alumno.Nombre,
                                eva.Nota
                            };
            }

            return rpta;
        }

    }

}
