﻿using System;
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
                        listContenido= datoContenido.deserializarContenido();
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
                        menu.Menu2();
                        MostrarEventos();
                        Console.ReadKey();
                        Console.Clear();
                        break;
                    case 3:
                        // Caja
                        Console.Clear();
                        Ventanilla();
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
            evento.IdEvento = id;
            Console.Write("Descripcion: ");
            evento.Descripcion = Console.ReadLine();
            Console.WriteLine("\nPrecio: ");
            evento.Costo = int.Parse(Console.ReadLine());

            listEventos.Add(evento);
            datoEventos.serializarEventos(listEventos);

            Console.WriteLine("\n Los datos fueron Guardados");
            Console.WriteLine("Presione una tecla");
            Console.ReadKey();
        }
        public int ContadorEventos()
        {
            int ContadorEventos = 0;
            foreach (Eventos b in listEventos)
            {
                ContadorEventos++;

            }
            return ContadorEventos;
        }
        public void MostrarEventos()
        {
            
            Console.WriteLine("\nListado de Articulos");
            foreach (Eventos b in listEventos)
            {
                Console.WriteLine("Id: " + b.IdEvento+ " Descripcion: " + b.Descripcion + " Precio $" + b.Costo);

            }
        }
        public void Ventanilla()
        {
            Ventas venta = new Ventas();
            Contenidos contenido = new Contenidos();
            int folio = 0;
            int subtotal = 0;
            venta.IdVenta = folio;
            folio = ContadorVenta() + 1;
            Console.WriteLine("Folio: " + folio);
            menu.Menu2();

            Console.WriteLine("                                           *** Ticketmaster ***");
            // Mostrar Eventos
            MostrarEventos();

            //Seleccion de Evento
            Console.WriteLine("\nSeleccione el Id. de un articulo:");
            int idEvento = int.Parse(Console.ReadLine());

            Console.WriteLine("Cantidad");
            int cantidad = int.Parse(Console.ReadLine());

            (string DescripcionArticulo, int costo) = BuscandoEventos(idEvento);

            int costoSuma = costo * cantidad;

            Console.WriteLine("Id.  Descripcion                   Cantidad       Costo.");
            Console.WriteLine(idEvento + " " + DescripcionArticulo + "                        " + cantidad + "         " + costoSuma);

            contenido.IdVenta = folio;
            contenido.IdEvento = idEvento;
            contenido.Descripcion = DescripcionArticulo;
            contenido.Costo = costoSuma;
            contenido.Cantidad = cantidad;

            //Seleccion 
            Console.WriteLine("\nPara Agregar al carrito Precione 1 o 2");
            int opcion = int.Parse(Console.ReadLine());

            do
            {
                if (opcion == 1)
                {
                    listContenido.Add(contenido);
                    subtotal = subtotal + costo;
                    datoContenido.serializarContenido(listContenido);
                    Console.WriteLine("\n Los datos fueron Guardados");
                }
            } while (opcion < 1 || opcion > 2);
            Console.WriteLine("Presione una tecla");
            Console.ReadKey();
            Console.Clear();

            Console.WriteLine("Id.   Descripcion                       Cantidad         Costo.");
            int contador = 0;

            (DescripcionArticulo, cantidad, costo, idEvento, subtotal, contador) = BuscandoContenido(folio);
            //Costos
            Console.WriteLine("\nPara cobrar Selecciona  1 o 2");
            opcion = int.Parse(Console.ReadLine());

            do
            {
                if (opcion == 1)
                {
                    Calulando(subtotal);
                    venta.NumEvento = contador;
                    listVentas.Add(ventas);
                    subtotal = subtotal + costo;
                    datoVentas.serializarVentas(listVentas);
                    Console.WriteLine("\n Los datos fueron Guardados");
                }
                else
                {
                    Console.Clear();
                    Ventanilla();
                }
            } while (opcion < 1 || opcion > 2);
        }

        public int ContadorVenta()
        {
            int ContadorVenta = 0;
            foreach (Ventas b in listVentas)
            {
                ContadorVenta++;
            }
            return ContadorVenta;
        }

        public Tuple<string, int> BuscandoEventos(int idEvento)
        {

            String Descripcion = "";
            int Costo = 0;

            foreach (Eventos b in listEventos)
            {

                if (b.IdEvento == idEvento)
                {
                    Descripcion = b.Descripcion;
                    Costo = b.Costo;
                }
            }
            return new Tuple<string, int>(Descripcion, Costo);
        }
        public Tuple<string, int, int, int, int, int> BuscandoContenido(int idVenta)
        {
            String Descripcion = "";
            int Cantidad = 0;
            int Costo = 0;
            int IdEvento = 0;
            int SubTotal = 0;
            int Contador = 0;

            foreach (Contenidos b in listContenido)
            {

                if (b.IdVenta == idVenta)
                {
                    Descripcion = b.Descripcion;
                    Cantidad = b.Cantidad;
                    Costo = b.Costo;
                    IdEvento = b.IdEvento;
                    Console.WriteLine(idVenta + "  " + Descripcion + "                    " + Cantidad + "      " + Costo);
                    SubTotal = SubTotal + Costo;
                    Contador = Contador + 1;
                }
            }
            return new Tuple<string, int, int, int, int, int>(Descripcion, Cantidad, Costo, IdEvento, SubTotal, Contador);
        }
        public void Calulando(int Subtotal)
        {

        }
        // PRESENTAR MENU DE BIENVENIDA

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
