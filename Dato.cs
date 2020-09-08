using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;


namespace DPRN1_U3_EA_PIVM
{
    public class Dato
    {
	    private String ruta;

	    public Dato(String ruta)
	    {
		    this.ruta = ruta;
	    }
        public void serializarEventos(List<Eventos> lista)
        {
            Stream flujo = File.Open(ruta, FileMode.Create);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(flujo, lista);
            flujo.Close();
        }
        public void serializarVentas(List<Ventas> lista)
        {
            Stream flujo = File.Open(ruta, FileMode.Create);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(flujo, lista);
            flujo.Close();
        }
        public void serializarContenido(List<Contenidos> lista)
        {
            Stream flujo = File.Open(ruta, FileMode.Create);
            BinaryFormatter bin = new BinaryFormatter();
            bin.Serialize(flujo, lista);
            flujo.Close();
        }
        public List<Eventos> deserializarEventos()
        {
            Stream flujo = File.Open(ruta, FileMode.Open);
            BinaryFormatter bin = new BinaryFormatter();
            List<Eventos> lista = (List<Eventos>)bin.Deserialize(flujo);
            flujo.Close();
            return lista;
        }
        public List<Ventas> deserializarVentas()
        {
            Stream flujo = File.Open(ruta, FileMode.Open);
            BinaryFormatter bin = new BinaryFormatter();
            List<Ventas> lista = (List<Ventas>)bin.Deserialize(flujo);
            flujo.Close();
            return lista;
        }
        public List<Contenidos> deserializarContenido()
        {
            Stream flujo = File.Open(ruta, FileMode.Open);
            BinaryFormatter bin = new BinaryFormatter();
            List<Contenidos> lista = (List<Contenidos>)bin.Deserialize(flujo);
            flujo.Close();
            return lista;
        }
    }

}
