using System;
using System.Collections.Generic;
using System.Text;

namespace DPRN1_U3_EA_PIVM
{   

 [Serializable()]
    public class Contenidos
    {
	           	   
        private int _idVenta;
        private int _cantidad;
        private int _idevento;
        private string _descripcion;
        private int _costo;

        public int IdVenta { get => _idVenta; set => _idVenta = value; }
        public int Cantidad { get => _cantidad; set => _cantidad = value; }
        public int IdEvento { get => _idevento;  set => _idevento = value; }
        public string Descripcion{ get => _descripcion; set => _descripcion = value; }
        public int Costo { get => _costo; set => _costo = value; }
        
    }
}

