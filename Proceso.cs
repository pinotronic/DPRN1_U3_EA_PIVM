using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace DPRN1_U3_EA_PIVM
{
    class Proceso
    {
        Menu menu = new Menu();

        private List<Eventos> listEventos;
        private List<Ventas> listVentas;
        private List<Contenidos> listContenido;

        private Eventos eventos;
        private Ventas ventas;
        private Contenidos contenidoTransaccion;
        private Dato datoEventos;
        private Dato datoVentas;
        private Dato datoContenido;

        public void SolicitarOpciones()
        {
            listVentas = new List<Ventas>();
            listEventos = new List<Eventos>();
            listContenido = new List<Contenidos>();

            int opcion;

            datoVentas = new Dato("Ventas.bd");
            datoEventos = new Dato("Eventos.bd");
            datoContenido = new Dato("Contenido.db");

            do
            {
                do
                {
                    if (File.Exists("Ventas.bd"))
                    {
                        listVentas = datoVentas.deserializarVentas();
                        Console.WriteLine("Hay AVenta ");
                    }
                    if (File.Exists("Eventos.bd"))
                    {
                        listEventos = datoEventos.deserializarEventos();
                        Console.WriteLine("Hay Evento ");
                    }
                    if (File.Exists("Contenido.db"))
                    {
                        listContenidoTransaccion = datoContenidoTransaccion.deserializarContenidoTransaccion();
                        Console.WriteLine("Hay Contenido ");
                    }

                    menu.Menu1();
                    Console.WriteLine("Ingresa opcion valida [1 -5]");
                    opcion = int.Parse(Console.ReadLine());
                    Console.Clear();

                    if (opcion < 1 || opcion > 5)
                    {
                        Console.WriteLine("Ingresa opcion valida [1 -5]");
                    }
                } while (opcion < 1 || opcion > 6);

                switch (opcion)
                {
                    case 1:
                        // Registro de Eventos
                        RegistroEventos();

                        break;
                    case 2:
                        // Mostrar Eventos
                        MostrarEventos();

                        break;
                    case 3:
                        // Caja
                        Console.Clear();
                        Caja();
                        menu.Menu2();
                        break;
                    case 4:
                        // Mostrar Ventas
                        break;
                    case 5:
                        // Salir
                        Console.WriteLine(" Gracias por su Compra");
                        Environment.Exit(0);
                        break;
                }

            } while (opcion != 5);
        }

        public void RegistroEventos()
        {
            menu.Menu2();
            
            Eventos evento = new Eventos();

            int id = ContadorEventos() + 1;
            Console.WriteLine("id: " + id);
            articulo.IdEvento = id;
            Console.Write("Descripcion: ");
            evento.Descripcion = Console.ReadLine();
            Console.WriteLine("\nPrecio: ");
            evento.Costo = int.Parse(Console.ReadLine());

            listeventos.Add(evento);
            datoEvento.serializarEventos(listEventos);

            Console.WriteLine("\n Los datos fueron Guardados");
            Console.WriteLine("Presione una tecla");
            Console.ReadKey();
        }
        // PRESENTAR MENU DE BIENBENIDA

        /*Una empresa dedicada a la venta de localidades por teléfono e internet maneja cinco tipos de localidades 
         * para un concierto que se llevará en el Auditorio Nacional de la Ciudad de México. */
/*Los precios de cada localidad y los datos referentes a la venta de boletos para la próxima función se 
* manejan de la siguiente forma:*/

/*Tener activo el programa y solicitar al usuario, si desea realizar una compra:

Si la respuesta es “si”: solicitar la localidad y el número de boletos para calcular el monto de la compra 
(punto 1) y mostrar los datos introducidos y el monto a pagar. 

Una vez que oprima una tecla para continuar, regresar nuevamente a solicitar una compra.

Si la respuesta es “no”: mostrar los datos que se te piden calcular punto 2 y 3, terminar el programa.

Analiza la problemática que se te expone e identifica las clases, objetos y estructuras de control
selectivas y cíclicas requeridas para su resolución.

*/

        //CALCULOS
        /*1. El monto correspondiente de cada venta.
        2. Obtenga el número de boletos vendidos y total para cada una de las localidades.
        3. Obtenga la recaudación total.*/
}
}
