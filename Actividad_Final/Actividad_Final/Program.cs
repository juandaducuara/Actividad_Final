using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Actividad_Final
{
    class Program
    {
        static List<Estudiante> ListaEstudiante = new List<Estudiante>();
        static Vallidaciones Validar = new Vallidaciones();
        static pantallas pantalla = new pantallas();
        
        static void Main(string[] args)
        {
            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            int OpcionMenu;
            string temporal;
            bool EntradaValida = false;

            do
            {
                Console.Clear();
                
                pantalla.pantallaprincipal();
                
                Console.SetCursorPosition(50, 2); Console.WriteLine("HAPPY NOTE");
                Console.SetCursorPosition(46, 6); Console.WriteLine("1. Agregar Estudiante");
                Console.SetCursorPosition(46, 8); Console.WriteLine("2. Listar Estudiante");
                Console.SetCursorPosition(46, 10); Console.WriteLine("3. Buscar Estudiante");
                Console.SetCursorPosition(42, 14); Console.WriteLine("4. Guardar Archivo de Estudiantes");
                Console.SetCursorPosition(42, 16); Console.WriteLine("5. Cargar Archivo de Estudiantes");
                Console.SetCursorPosition(46, 27); Console.WriteLine("0. Salir del Sistema");
                


                do
                {
                    Console.SetCursorPosition(48, 22);Console.WriteLine("Digite una opcion");
                    Console.SetCursorPosition(55, 20); temporal = Console.ReadLine();
                    if (!Validar.Vacio(temporal))
                        if (Validar.TipoNumero(temporal))
                            EntradaValida = true;

                } while (!EntradaValida);



                OpcionMenu = Convert.ToInt32(temporal);


                switch (OpcionMenu)
                {
                    case 1:
                        CrearEstudiante();
                        break;
                    case 2:
                        Console.Clear();
                        ListarEmpleados();
                        break;
                    case 3:
                        BuscarEstudiante();
                        break;
                    case 0:
                        Console.SetCursorPosition(43, 23); Console.WriteLine(" Saliendo de la Aplicacion ");
                        break;
                    case 4:
                        EscribirXml();
                        break;
                    case 5:
                        LeerXml();
                        break;
                    default:
                        Console.SetCursorPosition(49, 23); Console.WriteLine("Opcion No Valida");
                        break;
                }
                Console.SetCursorPosition(43, 24); Console.WriteLine("Presione Enter Para Continuar");
                Console.SetCursorPosition(73, 24); Console.ReadKey();
            } while (OpcionMenu != 0);

            static void CrearEstudiante()
            {
                string cod, nom, corr, n1, n2, n3;
                
                double nf1, nf2, nf3,nf;

                bool CodigoValido = false;
                bool NombreValido = false;
                bool CorreoValido = false;
                bool Nota1Valido = false;
                bool Nota2Valido = false;
                bool Nota3Valido = false;



                Console.Clear();
                pantalla.pantalladatos();
                

                do
                {
                    Console.Clear();
                    pantalla.pantalladatos();
                    Console.SetCursorPosition(43, 13); Console.Write(" Digite Codigo Estudiante: ");
                    Console.SetCursorPosition(52, 18); cod = Console.ReadLine();
                    if (!Validar.Vacio(cod))
                        if (Validar.TipoCodigo(cod))
                            CodigoValido = true;
                } while (!CodigoValido);

                if (Existe(Convert.ToInt32(cod)))
                    Console.WriteLine("El usuario " + cod + " Ya existe en el sistema");
                else
                {
                    do
                    {
                        Console.Clear();
                        pantalla.pantalladatos();
                        Console.SetCursorPosition(43, 13); Console.Write("Digite Nombre Estudiante:");
                        Console.SetCursorPosition(45, 18); nom = Console.ReadLine();
                        if (!Validar.Vacio(nom))
                            if (Validar.TipoTexto(nom))
                                NombreValido = true;
                    } while (!NombreValido);

                    do
                    {
                        Console.Clear();
                        pantalla.pantalladatos();
                        Console.SetCursorPosition(43, 13); Console.Write("Digite Correo del Estudiante:");
                        Console.SetCursorPosition(45, 18); corr = Console.ReadLine();
                        if (!Validar.Vacio(corr))
                            if (Validar.TipoCorreo(corr))
                                CorreoValido = true;
                    } while (!CorreoValido);


                    do
                    {
                        Console.Clear();
                        pantalla.pantalladatos();
                        Console.SetCursorPosition(43, 13); Console.Write("Digite la primera nota ");
                        Console.SetCursorPosition(50, 18); n1 = Console.ReadLine();
                        if (!Validar.Vacio(n1))
                            if (Validar.TipoNumero(n1))
                                Nota1Valido = true;
                    } while (!Nota1Valido);
                    nf1 = double.Parse(n1);
                    do
                    {
                        Console.Clear();
                        pantalla.pantalladatos();
                        Console.SetCursorPosition(43, 13); Console.Write("Digite la segunda nota ");
                        Console.SetCursorPosition(50, 18); n2 = Console.ReadLine();
                        if (!Validar.Vacio(n2))
                            if (Validar.TipoNumero(n2))
                                Nota2Valido = true;
                    } while (!Nota2Valido);
                    nf2 = double.Parse(n2);

                    do
                    {
                        Console.Clear();
                         pantalla.pantalladatos();
                        Console.SetCursorPosition(43, 13); Console.Write("Digite la tercera nota ");
                        Console.SetCursorPosition(50, 18); n3 = Console.ReadLine();
                        if (!Validar.Vacio(n3))
                            if (Validar.TipoNumero(n3))
                                Nota3Valido = true;
                    } while (!Nota3Valido);
                    nf3 = double.Parse(n3);



                    nf = (nf1 + nf2 + nf3) / 3;


                    Estudiante myEstudiante = new Estudiante();
                    myEstudiante.Codigo = Convert.ToInt32(cod);
                    myEstudiante.Nombre = nom;
                    myEstudiante.Correo = corr;
                    myEstudiante.Nota1 = Convert.ToDouble(n1);
                    myEstudiante.Nota2 = Convert.ToDouble(n2);
                    myEstudiante.Nota3 = Convert.ToDouble(n3);
                    
                    myEstudiante.NotaFin = Math.Round(nf,1);

                    if (Convert.ToDouble(nf) > 3.5)
                        myEstudiante.Aprobado = true;
                    else
                        myEstudiante.Aprobado = false;


                    //---------------------------------

                    ListaEstudiante.Add(myEstudiante);

                    // -----------------------------------------------  termina el else
                }

            }
        }
        static void ListarEmpleados()
        {
            int y = 6;

            pantalla.pantallatablas();
            Console.SetCursorPosition(50, 2); Console.WriteLine("Lista Estudiantes");

            Console.SetCursorPosition(2, 5); Console.Write("Codigo");
            Console.SetCursorPosition(11, 5); Console.Write("Nombre");
            Console.SetCursorPosition(38, 5); Console.Write("Correo");
            Console.SetCursorPosition(61, 5); Console.Write("Nota 1");
            Console.SetCursorPosition(70, 5); Console.Write("Nota 2");
            Console.SetCursorPosition(79, 5); Console.Write("Nota 3");
            Console.SetCursorPosition(88, 5); Console.Write("Nota Final");
            Console.SetCursorPosition(101,5); Console.Write("Aprobado");
            Console.Write("\n");


            foreach (Estudiante itemEstudiante in ListaEstudiante)
            {
                y++;
                               
                Console.SetCursorPosition(3, y); Console.Write(itemEstudiante.Codigo);
                Console.SetCursorPosition(10, y); Console.Write(itemEstudiante.Nombre);
                Console.SetCursorPosition(37, y); Console.Write(itemEstudiante.Correo);
                Console.SetCursorPosition(63, y); Console.Write(itemEstudiante.Nota1);
                Console.SetCursorPosition(72, y); Console.Write(itemEstudiante.Nota2);
                Console.SetCursorPosition(81, y); Console.Write(itemEstudiante.Nota3);
                Console.SetCursorPosition(91, y); Console.Write(itemEstudiante.NotaFin);
                Console.SetCursorPosition(102, y); Console.Write(itemEstudiante.Aprobado);
            }
            Console.Write("\n");

        }
        static void BuscarEstudiante()
        {
            string cod;
            bool CodigoValido = false;

            Console.Clear();
            pantalla.pantallabuscar();
            
            
            do
            {
                Console.SetCursorPosition(37, 13); Console.Write("Digite Codigo Empleado que desea buscar: ");
                Console.SetCursorPosition(55, 18); cod = Console.ReadLine();
                if (!Validar.Vacio(cod))
                    if (Validar.TipoNumero(cod))
                        CodigoValido = true;
            } while (!CodigoValido);
            
            int y = 6;
            
            if (Existe(Convert.ToInt32(cod)))
            {
                Console.Clear();
                pantalla.pantallatablas();
                Console.SetCursorPosition(50, 2); Console.WriteLine("Datos Encontrados");

                Console.SetCursorPosition(2, 5); Console.Write("Codigo");
                Console.SetCursorPosition(11, 5); Console.Write("Nombre");
                Console.SetCursorPosition(38, 5); Console.Write("Correo");
                Console.SetCursorPosition(61, 5); Console.Write("Nota 1");
                Console.SetCursorPosition(70, 5); Console.Write("Nota 2");
                Console.SetCursorPosition(79, 5); Console.Write("Nota 3");
                Console.SetCursorPosition(88, 5); Console.Write("Nota Final");
                Console.SetCursorPosition(101, 5); Console.Write("Aprobado");
                Console.Write("\n");
                
                foreach (Estudiante itemEstudiante in ListaEstudiante)
                {
                    y++;
                    Estudiante myEstudiante = ObtenerDatos(Convert.ToInt32(cod));
                    Console.SetCursorPosition(3, y); Console.Write(itemEstudiante.Codigo);
                    Console.SetCursorPosition(10, y); Console.Write(itemEstudiante.Nombre);
                    Console.SetCursorPosition(37, y); Console.Write(itemEstudiante.Correo);
                    Console.SetCursorPosition(63, y); Console.Write(itemEstudiante.Nota1);
                    Console.SetCursorPosition(72, y); Console.Write(itemEstudiante.Nota2);
                    Console.SetCursorPosition(81, y); Console.Write(itemEstudiante.Nota3);
                    Console.SetCursorPosition(91, y); Console.Write(itemEstudiante.NotaFin);
                    Console.SetCursorPosition(102, y); Console.Write(itemEstudiante.Aprobado);
                }
                Console.Write("\n");
            }
            else { 
                Console.SetCursorPosition(37, 20); Console.WriteLine(" El Usuario " + cod + " NO existe en el sistema");
            }

        }

            static bool Existe(int cod)
            {
                bool aux = false;
                foreach (Estudiante objetoEmpleado in ListaEstudiante)
                {
                    if (objetoEmpleado.Codigo == cod)
                        aux = true;
                }
                return aux;
            }

            static Estudiante ObtenerDatos(int cod)
            {
                foreach (Estudiante objetoEmpleado in ListaEstudiante)
                {
                    if (objetoEmpleado.Codigo == cod)
                        return objetoEmpleado;
                }
                return null;
            }




            static void EscribirXml()
            {
                XmlSerializer codificador = new XmlSerializer(typeof(List<Estudiante>));
                TextWriter escribirXml = new StreamWriter("E:/net/listaEmpleados.xml");
                codificador.Serialize(escribirXml, ListaEstudiante);
                escribirXml.Close();

                Console.SetCursorPosition(49, 23); Console.WriteLine("Archivo Guardado");
            }

            static void LeerXml()
            {
                ListaEstudiante.Clear();
                if (File.Exists("C:/datosnet/listaEmpleados.xml"))
                {
                    XmlSerializer codificador = new XmlSerializer(typeof(List<Estudiante>));
                    FileStream leerXml = File.OpenRead("E:/net/listaEmpleados.xml");
                    ListaEstudiante = (List<Estudiante>)codificador.Deserialize(leerXml);
                    leerXml.Close();
                }
                Console.SetCursorPosition(49, 23); Console.WriteLine("Archivo Cargado");
            }

        }

    }

