using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Practico1_ConNota_Programacion2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            NuestraEmpresa nuestraEmpresa = new NuestraEmpresa();
            
            
            bool salirMenu = false;
            int ingresoMenu;

            while (salirMenu == false)
            {
                nuestraEmpresa.menuPrincipal();
                try 
                { 
                    ingresoMenu = Convert.ToInt32(Console.ReadLine()); 
                }
                catch (FormatException e)
                {
                    ingresoMenu = 10;
                }

                switch (ingresoMenu)
                {
                    case 1:

                        nuestraEmpresa.listaDeProductosMostrar();
                        nuestraEmpresa.enviarCatalogoALosClientes();
                        break;

                    case 2:

                        nuestraEmpresa.mostrarClientes();

                        int ingresoCliente;
                        try
                        {
                            ingresoCliente = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (Exception e)
                        {
                            ingresoCliente = nuestraEmpresa.Clientes.Count() + 1;
                        }

                        for (int i = 0; i < ingresoCliente; i++)
                        {
                            if (i == ingresoCliente - 1)
                            {
                                nuestraEmpresa.seleccionarProducto(i);

                                nuestraEmpresa.ventaDeProductosClientesParticulares(i);
                            }
                            else if (ingresoCliente > nuestraEmpresa.Clientes.Count())
                            {
                                Console.WriteLine("Cliente no reconosido (Presione enter para volver al menu pricipal)");
                                Console.ReadKey();
                                break;
                            }
                        }
                        break;

                    case 3:
                        Console.Clear();
                        Console.WriteLine("---------AGREGAR PRODUCTO----------\n");

                        Productos producto = new Productos();

                        Console.Write("Nombre del Producto: ");
                        try
                        {
                            producto.nombreProducto = Console.ReadLine();
                        }
                        catch(FormatException e)
                        {
                            Console.WriteLine("El valor introducido no corresponde con el campo");
                            Console.ReadKey();
                            break;
                        }
                        catch (OverflowException e)
                        {
                            Console.WriteLine("El valor introducido es demasiado grande");
                            Console.ReadKey();
                        }


                        Console.Write("Precio del Producto: ");
                        try
                        {
                            producto.precio = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("El valor introducido no corresponde con el campo");
                            Console.ReadKey();
                            break;
                        }
                        catch(OverflowException e)
                        {
                            Console.WriteLine("El valor introducido es demasiado grande");
                            Console.ReadKey();
                        }

                        nuestraEmpresa.agregarProducto(producto);
                        
                        break;

                    case 4:
                        Console.Clear();
                        Console.WriteLine("---------CAMBIAR PRECIOS----------\n");

                        nuestraEmpresa.seleccionarProducto();

                        nuestraEmpresa.cambiarPrecioProducto();

                        break;

                    case 5:
                        
                        Console.Clear();
                        Console.WriteLine("---------ELIMINAR PRODUCTO----------\n");

                        string eliminarProducto;
                        Console.Write("Introdusca el nombre del producto que desea eliminar: ");
                        try
                        {
                            eliminarProducto = Console.ReadLine();
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("El valor introducido no corresponde con el campo");
                            Console.ReadKey();
                            break;
                        }
                        catch (OverflowException e)
                        {
                            Console.WriteLine("El valor introducido es demasiado grande");
                            Console.ReadKey();
                            break;
                        }

                        nuestraEmpresa.eliminarProducto(eliminarProducto);

                        break;
                    case 6:
                        Console.Clear();
                        Console.WriteLine("---------AGREGAR CLIENTE----------\n");

                        Clientes cliente = new Clientes();

                        Console.Write("Nombre del Cliente: ");
                        try
                        {
                            cliente.nombreCliente = Console.ReadLine();
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine(e.Message);
                            Console.ReadKey();
                            break;
                        }

                        Console.Write("Direccion del Cliente: ");
                        try
                        {
                            cliente.direccion = Console.ReadLine();
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("El valor introducido no corresponde con el campo");
                            Console.ReadKey();
                            break;
                        }

                        Console.Write("Telefono del Cliente: ");
                        try
                        {
                            cliente.telefono = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("El valor introducido no corresponde con el campo");
                            Console.ReadKey();
                            break;
                        }
                        catch (OverflowException e)
                        {
                            Console.WriteLine("El valor introducido es demasiado grande");
                            Console.ReadKey();
                        }
                        
                        Console.Write("Tipo de Cliente: ");
                        try
                        {
                            cliente.tipoCliente = Console.ReadLine();
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("El valor introducido no corresponde con el campo");
                            Console.ReadKey();
                            break;
                        }
                        catch (OverflowException e)
                        {
                            Console.WriteLine("El valor introducido es demasiado grande");
                            Console.ReadKey();
                        }
                        
                        Console.Write("ID del Cliente: ");
                        try
                        {
                            cliente.idCliente = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException e)
                        {
                            Console.WriteLine("El valor introducido no corresponde con el campo");
                            Console.ReadKey();
                            break;
                        }
                        catch (OverflowException e)
                        {
                            Console.WriteLine("El valor introducido es demasiado grande");
                            Console.ReadKey();
                        }

                        nuestraEmpresa.agregarCliente(cliente);

                        break;
                    case 7:
                        Console.Clear();
                        Console.WriteLine("---------ELIMINAR CLIENTE----------\n");
                        
                        int eliminarCliente;
                        Console.Write("Introduzca el id del cliente que desea eliminar: ");
                        try
                        {
                            eliminarCliente = Convert.ToInt32(Console.ReadLine());
                        }
                        catch (FormatException e)
                        {
                            Console.Write("\nEl id introducido es invalido");
                            Console.ReadKey();
                            break;
                        }

                        nuestraEmpresa.eliminarCliente(eliminarCliente);

                        break;
                    case 0:
                        salirMenu = true;
                        break;
                    default:
                        Console.WriteLine("Elija una de estas opciones por favor (Presione enter para intentarlo de nuevo)");
                        Console.ReadKey();
                        break;
                }
                Console.Clear();
            }
        }
    }
}
