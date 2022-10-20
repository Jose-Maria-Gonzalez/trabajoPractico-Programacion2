using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Practico1_ConNota_Programacion2
{
    internal class NuestraEmpresa
    {
        public List<Productos> Productos { get; set;}

        public List<Clientes> Clientes { get; set; }

        public NuestraEmpresa()
        {
            this.Productos = new List<Productos>();
            this.Clientes = new List<Clientes>();

            Productos pala = new Productos();
            pala.nombreProducto = "Pala";
            pala.precio = 700;

            Productos monitor = new Productos();
            monitor.nombreProducto = "Monitor";
            monitor.precio = 8000;

            Productos somier = new Productos();
            somier.nombreProducto = "Somier";
            somier.precio = 15000;

            this.Productos.Add(pala);
            this.Productos.Add(monitor);
            this.Productos.Add(somier);

            Clientes juan = new Clientes();
            juan.nombreCliente = "Juan";
            juan.direccion = "30 de Julio, Maldonado";
            juan.telefono = 098522214;
            juan.tipoCliente = "Particular";
            juan.idCliente = 1;

            Clientes pepe = new Clientes();
            pepe.nombreCliente = "Pepe";
            pepe.direccion = "30 de Julio, Montevideo";
            pepe.telefono = 098579554;
            pepe.tipoCliente = "Particular";
            pepe.idCliente = 2;

            Clientes pastitosAndPortland = new Clientes();
            pastitosAndPortland.nombreCliente = "Pastitos & Portland";
            pastitosAndPortland.direccion = "25 de Agosto, Maldonado";
            pastitosAndPortland.telefono = 092987258;
            pastitosAndPortland.tipoCliente = "Empresa";
            pastitosAndPortland.idCliente = 3;

            this.Clientes.Add(juan);
            this.Clientes.Add(pepe);
            this.Clientes.Add(pastitosAndPortland);
        }

        public void menuPrincipal()
        {
            Console.WriteLine("---------MENU PREICIPAL----------\n");
            Console.WriteLine("1 - Enviar catalogo a los clientes");
            Console.WriteLine("2 - Realizar pedido");
            Console.WriteLine("3 - Agregar Producto");
            Console.WriteLine("4 - Cambiar precio de los productos");
            Console.WriteLine("5 - Eliminar Producto");
            Console.WriteLine("6 - Agregar Cliente");
            Console.WriteLine("7 - Eliminar Cliente");
            Console.WriteLine("0 - Salir\n");

            Console.Write("Selccione donde quiere ingresar: ");
        }

        public void listaDeProductosMostrar()
        {
            Console.Clear();
            Console.WriteLine("---------PRODUCTOS---------\n");

            for (int i = 0; i < this.Productos.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {this.Productos[i].getProductos()}");
            }

        }

        public void enviarCatalogoALosClientes()
        {
            Console.WriteLine($"\n1 - Enviar el catalogo a los clientes asociados \n0 - Salir");
            Console.Write("\nSeleccione un valor: ");
            bool salir = false;
            string enviarCatalogo;
            while (salir == false)
            {
                try
                {
                    enviarCatalogo = Console.ReadLine();
                }
                catch (FormatException e)
                {
                    enviarCatalogo = "2";
                }
                switch (enviarCatalogo)
                {
                    case "1":
                        Console.WriteLine("\nSe envio el catalogo a los siguientes clientes:\n");
                        for (int i = 0; i < this.Clientes.Count; i++)
                        {
                            Console.WriteLine($"{this.Clientes[i].getCliente()}");
                        }
                        salir = true;
                        Console.ReadKey();
                        break;

                    case "0":
                        salir = true;
                        break;
                    default:
                        Console.Write("Seleccione un valor valido: ");
                        salir = false;
                        break;
                }
            }
        }

        public void mostrarClientes()
        {
            Console.Clear();
            Console.WriteLine("---------SELECION DEL CLIENTE---------\n");

            for (int i = 0; i < this.Clientes.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {this.Clientes[i].getCliente()}");
            }

            Console.WriteLine("");
            Console.Write("Selccione el cliente que desea realizar el pedido: ");
        }

        public void seleccionarProducto(int cliente)
        {
            Console.Clear();
            Console.WriteLine($"Seleccione los productos que {this.Clientes[cliente].nombreCliente} va a llevar de la siguiente lista\n");
            for (int i = 0; i < this.Productos.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {this.Productos[i].getProductos()}");
            }
            Console.WriteLine("0 - Confirmar pedido\n");
        }

        public void ventaDeProductosClientesParticulares(int cliente)
        {
            List<string> productosComprados = new List<string>() {"nada"};
            int contadorDeProductos = 0;
            int totalAPagar = 0;
            bool salirSeleccionarProductos = false;
            while (salirSeleccionarProductos == false)
            {
                Console.Write("Producto: ");

                int seleccionarProducto;
                try
                {
                    seleccionarProducto = Convert.ToInt32(Console.ReadLine());
                }
                catch (Exception e)
                {
                    seleccionarProducto = Productos.Count + 1;
                }

                for (int i = 0; i < seleccionarProducto; i++)
                {
                    if (i == seleccionarProducto - 1)
                    {
                        productosComprados.Add(this.Productos[i].getProductos());
                        contadorDeProductos++;
                        totalAPagar = totalAPagar + this.Productos[i].precio;
                    }
                    else if (seleccionarProducto > Productos.Count())
                    {
                        Console.WriteLine("Producto no reconosido (Presione enter para volver a intentarlo)");
                        Console.ReadKey();
                        break;
                    }
                }

                if (seleccionarProducto == 0)
                {
                    salirSeleccionarProductos = true;
                }
            }

            this.Clientes[cliente].validarOrdenDePago();

            Console.WriteLine("");
            Console.WriteLine($"Se confirmo el pedido con los siguientes productos y siendo el total a pagar ${totalAPagar}: \n");
            for (int i = 1; i < contadorDeProductos+1; i++)
            {
                Console.WriteLine(productosComprados[i]);
            }

            generarOrdenDePedido();
            Console.WriteLine($"El pedido sera enviado a {this.Clientes[cliente].direccion} por medio de una empresa de mensajeria");

            Console.ReadKey();
        }

        public void generarOrdenDePedido()
        {
            Console.WriteLine("\nSe emitio la orden de pedido correspondiente\n");
        }

        public void seleccionarProducto()
        {
            Console.Clear();
            Console.WriteLine($"Seleccione el producto al cual desea cambiarle el precio\n");
            for (int i = 0; i < this.Productos.Count; i++)
            {
                Console.WriteLine($"{i + 1} - {this.Productos[i].getProductos()}");
            }
        }

        public void cambiarPrecioProducto()
        {
            Console.Write("\nProducto: ");
            int seleccionarProducto;

            try
            {
                seleccionarProducto = Convert.ToInt32(Console.ReadLine());
            }
            catch (Exception e)
            {
                seleccionarProducto = Productos.Count + 1;
            }

            int nuevoPrecio;

            for (int i = 0; i < seleccionarProducto; i++)
            {
                if (i == seleccionarProducto - 1)
                {
                    Console.Write("\nElija el nuevo precio del producto: ");
                    try
                    {
                        nuevoPrecio = Convert.ToInt32(Console.ReadLine());
                    }
                    catch(FormatException e)
                    {
                        Console.WriteLine("\nDado que el formato introducido no es el correcto no se pudo realizar el cambio del precio");
                        nuevoPrecio = this.Productos[i].precio;
                        Console.ReadKey();
                        break;
                    }
                    catch (OverflowException e)
                    {
                        Console.WriteLine("\nDado que el número ingresado es muy grande no se pudo realizar el cambio del precio (se un poco menos tacaño)");
                        nuevoPrecio = this.Productos[i].precio;
                        Console.ReadKey();
                        break;
                    }
                    this.Productos[i].precio = nuevoPrecio;

                    Console.Write($"\nEl nuevo del producto {this.Productos[i].nombreProducto} es {nuevoPrecio}");
                    Console.ReadKey();
                }
                else if (seleccionarProducto > Productos.Count())
                {
                    Console.WriteLine("Producto no reconosido (Presione enter para volver al menu pricipal)");
                    Console.ReadKey();
                    break;
                }
            }
        }

        public int validarProducto(string nombreProducto)
        {
            int encontro = -1;

            for (int i = 0; i < this.Productos.Count; i++)
            {
                if (this.Productos[i].nombreProducto == nombreProducto)
                {
                    encontro++;
                }
            }

            return encontro;
        }
        public void agregarProducto(Productos producto)
        {
            if(validarProducto(producto.nombreProducto) >= 0)
            {
                Console.WriteLine("\n ERROR - Este producto ya a sido agregado al catalogo");
                Console.ReadKey();
            }
            else
            {
                this.Productos.Add(producto);
                Console.WriteLine($"\nSe a agregado el siguiente producto: {producto.getProductos()}");
                Console.ReadKey();
            }
        }

        public void eliminarProducto(string nombreProducto)
        {
            int encontro = this.validarProducto(nombreProducto);

            if(encontro >= 0)
            {
                for (int i = 0; i < this.Productos.Count; i++)
                {
                    if (this.Productos[i].nombreProducto == nombreProducto)
                    {
                        this.Productos.RemoveAt(i);
                        Console.WriteLine($"\nEl siguiente producto se a eliminado: {nombreProducto}");
                    }
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"\nNo se encontro ningun producto con el siguiente nombre: {nombreProducto}");
                Console.ReadKey();
            }
        }

        public int validarCliente(int idCliente)
        {
            int encontro = -1;

            for (int i = 0; i < this.Clientes.Count; i++)
            {
                if (this.Clientes[i].idCliente == idCliente)
                {
                    encontro++;
                }
            }

            return encontro;
        }

        public void agregarCliente(Clientes cliente)
        {
            if (validarCliente(cliente.idCliente) >= 0)
            {
                Console.WriteLine("\n ERROR - Este cliente ya existe en el sistema");
                Console.ReadKey();
            }
            else
            {
                this.Clientes.Add(cliente);
                Console.WriteLine($"\nSe a agregado el siguiente cliente: {cliente.getCliente()}");
                Console.ReadKey();
            }
        }

        public void eliminarCliente(int idCliente)
        {
            int encontro = this.validarCliente(idCliente);

            if (encontro >= 0)
            {
                for (int i = 0; i < this.Clientes.Count; i++)
                {
                    if (this.Clientes[i].idCliente == idCliente)
                    {
                        Console.WriteLine($"\n{this.Clientes[i].nombreCliente} a sido eliminado de la lista de clientes");
                        this.Clientes.RemoveAt(i);
                    }
                }
                Console.ReadKey();
            }
            else
            {
                Console.WriteLine($"\nNo se encontro ningun cliente con el siguiente id: {idCliente}");
                Console.ReadKey();
            }
        }
    }
}
