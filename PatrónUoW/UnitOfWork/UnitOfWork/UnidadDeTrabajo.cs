using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UnitOfWork
{
    internal class UnidadDeTrabajo
    {
        List<cBase> objetosNuevos;
        List<cBase> objetosModificados;
        List<cBase> objetosEliminados;
        
        public UnidadDeTrabajo()
        {
            objetosNuevos = new List<cBase>();
            objetosModificados = new List<cBase>();
            objetosEliminados = new List<cBase>();
        }
        
        public void Añadir(cBase newObj)
        {

        }
        
        public void Eliminar(cBase delObj)
        {
        
        }
        
        public void Modificar(cBase modObj)
        {
        
        }
        
        public void Confirmar()
        {
        
        }
        
        private void Limpiar()
        {
            objetosNuevos.Clear();
            objetosModificados.Clear();
            objetosEliminados.Clear();
        }
    }
}


