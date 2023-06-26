using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting.Channels.Tcp;

namespace Servidor
{
    public class Pedido : MarshalByRefObject
    {
        public void HazPedido(string cli, int pro, int can)
        {
            DateTime dt = DateTime.Now;
            string today = dt.ToString("dd-MMM-yyyy");
            string record = today + "|" + cli + "|" + pro + "|" + can;
            StreamWriter sw = new StreamWriter("\\pedidos.txt", true);
            sw.WriteLine(record);
            sw.Close();
        }

    }



    public class PedidoServidor
    {
        public static void Start()
        {
            ChannelServices.RegisterChannel(new TcpChannel(2255));
            RemotingConfiguration.RegisterWellKnownServiceType(
                                    typeof(Pedido),
                                    "pedidos.rem",
                                    WellKnownObjectMode.SingleCall);
        }
        public static void Main()
        {
            Start();
            Console.WriteLine("pedido.rem Servicio Iniciado, pulse una tecla para terminar");
            Console.ReadLine();
        }
    }
}
