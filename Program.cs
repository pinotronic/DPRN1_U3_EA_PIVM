using System;

namespace DPRN1_U3_EA_PIVM
{
    class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();
            Proceso proceso =new Proceso();
            proceso.SolicitarOpciones();
        }
    }
}
