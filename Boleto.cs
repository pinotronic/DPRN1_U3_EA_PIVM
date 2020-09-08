using System;
using System.Collections.Generic;
using System.Text;

namespace DPRN1_U3_EA_PIVM
{
    class Boleto
    {

        private string _localidad;
        private int _precio;
        private int _NoBoleto;

        public string Localidad { get => _localidad; set => _localidad = value; }
        public int Precio { get => _precio; set => _precio = value; }
        public int NoBoleto { get => _NoBoleto; set => _NoBoleto = value; }

    }
}
}
