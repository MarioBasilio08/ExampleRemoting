using Servidor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Text;
using System.Threading.Tasks;

namespace Cliente
{
    public class OrderClient
    {
        public static void Main()
        {
            ChannelServices.RegisterChannel(new TcpChannel());

            Pedido remote = (Pedido)Activator.GetObject(
                                  typeof(Pedido), //Tipo de objeto remoto
                                  "tcp://localhost:2255/pedidos.rem"); //URL del objeto remoto

            Console.Write("Cliente: ");
            string cli = Console.ReadLine();
            Console.Write("Producto: ");
            int pro = Int32.Parse(Console.ReadLine());
            Console.Write("Cantidad: ");
            int can = Int32.Parse(Console.ReadLine());
            remote.HazPedido(cli, pro, can);
            Console.WriteLine("Pedido Realizado");
            Console.ReadLine();
        }
    }
}
