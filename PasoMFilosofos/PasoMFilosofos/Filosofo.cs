using System;
using System.Configuration;
using System.Threading;

namespace PasoMFilosofos
{
	/// <summary>
	/// Clase que representa un proceso (o filósofo) que intenta obtener el recurso compartido
	/// </summary>
    class Filosofo
    {
        int derecha;
        int izquierda;
        int id;
        Tenedores tenedores;
        internal event EventHandler ManejadorEstado;
        internal enum Estado { Pensando, Esperando, Comiendo };

		/// <summary>
		/// Constructor de la clase filósofo
		/// </summary>
		/// <param name="id">Identificador del proceso</param>
		/// <param name="tenedores">Recurso compartido</param>
		/// <param name="manejadorEstado">Manejador de evento para notificar un cambio de estado: Pensando, Esperando, Comiendo</param>
        public Filosofo(int id, Tenedores tenedores, EventHandler manejadorEstado)
        {
            int numFilosofos = int.Parse(ConfigurationManager.AppSettings["NumFilosofos"]);

            this.tenedores = tenedores;
            this.id = id;
            ManejadorEstado = manejadorEstado;
			//Asigna los índices de los tenedores que le corresponden al filósofo
            izquierda = id == 0 ? numFilosofos - 1 : id - 1;
            derecha = id;

            //Inicia la ejecucion del proceso en un hilo independiente
            Thread proceso = new Thread(new ThreadStart(Iniciar));

            proceso.Start();
        }

		/// <summary>
		/// Bloque de ejecución del proceso (o filósofo)
		/// </summary>
        public void Iniciar()
        {
            Random aleatorio = new Random();
            int tiempoMaxPensar = int.Parse(ConfigurationManager.AppSettings["TiempoMaxSegPensar"]) * 1000;
            int tiempoMaxComer = int.Parse(ConfigurationManager.AppSettings["TiempoMaxSegComer"]) * 1000;
            int tiempo = 0;

            while (true)
            {
				//Notifica que el filósofo cambio su estado a: Pensando
                if (ManejadorEstado != null)
                    ManejadorEstado(new Argumentos() { Estado = Estado.Pensando, IdProceso = id }, new EventArgs());

				//Espera un tiempo aleatorio
                tiempo = aleatorio.Next(1000, tiempoMaxPensar);
                Thread.Sleep(tiempo);

				//Notifica que el filósofo cambio su estado a: Esperando
                if (ManejadorEstado != null)
                    ManejadorEstado(new Argumentos() { Estado = Estado.Esperando, IdProceso = id }, new EventArgs());
				
				//Intenta obtener el recurso compartido,
				//	si ya está ocupado, espera a que el recurso se libere
                tenedores.Obtener(izquierda, derecha);

				//Notifica que el filósofo cambio su estado a: Comiendo
                if (ManejadorEstado != null)
                    ManejadorEstado(new Argumentos() { Estado = Estado.Comiendo, IdProceso = id }, new EventArgs());

				//Espera un tiempo aleatorio
                tiempo = aleatorio.Next(1000, tiempoMaxComer);
                Thread.Sleep(tiempo);
				//Libera el recurso compartido
                tenedores.Liberar(izquierda, derecha);
            }
        }
    }
}
