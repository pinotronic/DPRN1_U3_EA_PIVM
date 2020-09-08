using System;
using System.Collections.Generic;
using System.Text;

namespace DPRN1_U3_EA_PIVM
{
    [Serializable()]
    public class Eventos
    {
	    
        private int _idEvento;
        private string _descripcion;
        private int _costo;

        public int IdEvento { get => _idEvento; set => _idEvento = value; }
        public string Descripcion { get => _descripcion; set => _descripcion = value; }
        public int Costo { get => _costo; set => _costo = value; }
    }


}
