using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Threading;

namespace PasoMFilosofos
{
    class Filosofo
    {
        int derecha;
        int izquierda;
        int id;
        Tenedores tenedores;
        internal event EventHandler ManejadorEstado;
        internal enum Estado { Pensando, Esperando, Comiendo };

        public Filosofo(int id, Tenedores tenedores, EventHandler manejadorEstado)
        {
            int numFilosofos = int.Parse(ConfigurationManager.AppSettings["NumFilosofos"]);

            this.tenedores = tenedores;
            this.id = id;
            ManejadorEstado = manejadorEstado;
            izquierda = id == 0 ? numFilosofos - 1 : id - 1;
            derecha = id;

            //Inicia la ejecucion del proceso
            Thread proceso = new Thread(new ThreadStart(Iniciar));

            proceso.Start();
        }

        public void Iniciar()
        {
            Random aleatorio = new Random();
            int tiempoMaxPensar = int.Parse(ConfigurationManager.AppSettings["TiempoMaxSegPensar"]) * 1000;
            int tiempoMaxComer = int.Parse(ConfigurationManager.AppSettings["TiempoMaxSegComer"]) * 1000;
            int tiempo = 0;

            while (true)
            {
                try
                {

                    if (ManejadorEstado != null)
                        ManejadorEstado(new Argumentos() { Estado = Estado.Pensando, IdProceso = id }, new EventArgs());

                    tiempo = aleatorio.Next(1000, tiempoMaxPensar);
                    Thread.Sleep(tiempo);

                    if (ManejadorEstado != null)
                        ManejadorEstado(new Argumentos() { Estado = Estado.Esperando, IdProceso = id }, new EventArgs());

                    tenedores.Obtener(izquierda, derecha);

                    if (ManejadorEstado != null)
                        ManejadorEstado(new Argumentos() { Estado = Estado.Comiendo, IdProceso = id }, new EventArgs());

                    tiempo = aleatorio.Next(1000, tiempoMaxComer);
                    Thread.Sleep(tiempo);
                    tenedores.Liberar(izquierda, derecha);
                }
                catch (Exception e)
                {
                    Console.WriteLine("Filósofo " + id + " error!");
                    Console.WriteLine("Mensaje: " + e.Message);
                }
            }
        }
    }
}
