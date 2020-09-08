using System;
using System.Collections.Generic;
using System.Text;
namespace DPRN1_U3_EA_PIVM
{   
    [Serializable()]
    public class Ventas
    {

        private int _idVenta;
        private int _numEvento;
        private DateTime _fecha;
        private int _montoFactura;

        public int IdVenta { get => _idVenta; set => _idVenta = value; }
        public int NumEvento { get => _numEvento; set => _numEvento = value; }
        public DateTime Fecha { get => _fecha; set => _fecha = value; }
        private int MontoFactura { get => _montoFactura; set => _montoFactura = value; }
    }
    
}

