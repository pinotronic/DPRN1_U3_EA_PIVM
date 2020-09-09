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
        private List<Boleto> listBoleto;

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
            listBoleto = new List<Boleto>();

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
                        listContenido = datoContenido.deserializarContenido();
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
                        Console.Clear();
                        MostrarVentas();
                        menu.Menu2();
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
                Console.WriteLine("Id: " + b.IdEvento + " Descripcion: " + b.Descripcion);

            }
        }
        public void Ventanilla()
        {

            Ventas venta = new Ventas();


            string Localidad = "Preferente";
            int PrecioBoleto = 2000;
            int NoBoleto = 2000;
            creacionBoleto(Localidad, PrecioBoleto, NoBoleto);

            Localidad = "Cresta";
            PrecioBoleto = 1500;
            NoBoleto = 3000;
            creacionBoleto(Localidad, PrecioBoleto, NoBoleto);

            Localidad = "Luneta";
            PrecioBoleto = 1200;
            NoBoleto = 5000;
            creacionBoleto(Localidad, PrecioBoleto, NoBoleto);

            Localidad = "Balcon";
            PrecioBoleto = 900;
            NoBoleto = 4000;
            creacionBoleto(Localidad, PrecioBoleto, NoBoleto);

            Localidad = "PrimerPiso";
            PrecioBoleto = 700;
            NoBoleto = 8000;
            creacionBoleto(Localidad, PrecioBoleto, NoBoleto);

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
            Console.WriteLine("\nSeleccione el Id. de un Evento:");
            int idEvento = int.Parse(Console.ReadLine());

            Console.WriteLine("Cantidad");
            int cantidad = int.Parse(Console.ReadLine());

            Console.WriteLine("Tipo de Boleto 1. Preferente, 2. Cresta, 3. Luneta, 4. Balcon, 5. Primer Piso");

            int tipoBoleto = int.Parse(Console.ReadLine());

            (int Precio, int NomeroBoletos) = BuscarCostoBoleto(tipoBoleto);

            (string DescripcionArticulo, int costo) = BuscandoEventos(idEvento);

            int costoSuma = Precio * cantidad;

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
                    venta.NumEvento = costoSuma;
                    subtotal = subtotal + costo;
                    venta.MontoFactura = subtotal;

                    listVentas.Add(ventas);
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

            Console.WriteLine("\n               Subtotal: " + Subtotal);
            Console.WriteLine("                          ---------------");
            Console.WriteLine("                       Total: " + Subtotal);

            Console.WriteLine("\n Gracias por su compra");
            Console.ReadKey();
        }
        public Tuple<int, int> BuscarCostoBoleto(int TipoBoleto)
        {
            int CostoBoleto = 0;
            int NumBoletos = 0;
            String Tipo = "";
            switch (TipoBoleto)
            {
                case 1:
                    Tipo = "Preferente";
                    break;
                case 2:
                    Tipo = "Cresta";
                    break;
                case 3:
                    Tipo = "Luneta";
                    break;
                case 4:
                    Tipo = "Balcon";
                    break;
                case 5:
                    Tipo = "PrimerPiso";
                    break;
            }


            foreach (Boleto b in listBoleto)
            {
                if (b.Localidad == Tipo)
                {
                    CostoBoleto = b.Precio;
                    NumBoletos = b.NoBoleto;
                }
            }
            return new Tuple<int, int>(CostoBoleto, NumBoletos);
        }
        public void creacionBoleto(String Localidad, int Precio, int NoBoleto)
        {
            Boleto boleto = new Boleto();
            boleto.Localidad = Localidad;
            boleto.Precio = Precio;
            boleto.NoBoleto = NoBoleto;
            listBoleto.Add(boleto);
        }
        public void MostrarVentas()
        {
            Console.WriteLine("\nListado de Ventas");
            foreach (Ventas b in listVentas)
            {
                Console.WriteLine("Id: " + b.IdVenta + " Descripcion: " + b.NumEvento + " Ventas" + b.Fecha);

            }
            Console.ReadKey();
        }
    }
}
