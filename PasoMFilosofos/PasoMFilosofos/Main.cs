using System;
using System.Drawing;
using System.Windows.Forms;

namespace PasoMFilosofos
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            //Una sóla instancia del recurso compartido
			//	que se comparte entre los procesos
            Tenedores tenedores = new Tenedores();

            //Se crean las instancias de los filosofos
            Filosofo filosofo0 = new Filosofo(0, tenedores, evento_CambioEstado);
            Filosofo filosofo1 = new Filosofo(1, tenedores, evento_CambioEstado);
            Filosofo filosofo2 = new Filosofo(2, tenedores, evento_CambioEstado);
            Filosofo filosofo3 = new Filosofo(3, tenedores, evento_CambioEstado);
            Filosofo filosofo4 = new Filosofo(4, tenedores, evento_CambioEstado);
        }

		private void Main_FormClosed(object sender, FormClosedEventArgs e)
		{
			Environment.Exit(0);
		}

		/// <summary>
		/// Manejador de evento para cambio de estado de un proceso
		/// </summary>
		/// <param name="sender">Objeto que identifica al proceso que lanza el evento para notificar su cambio de estado</param>
		/// <param name="e"></param>
        private void evento_CambioEstado(object sender, EventArgs e)
        {
            Argumentos proceso = (Argumentos)sender;

          	//Escribe en la consola para identificar al proceso y su estado
            consola.Items.Add("Filosofo " + proceso.IdProceso + ": " + proceso.Estado);
			//Actualiza el gráfico del estado del proceso
			EstablecerEstado(proceso);
        }

		/// <summary>
		/// Actualiza el gráfico de estado de un proceso: Pensando (VERDE), Esperando (AMARILLO), Comiendo (ROJO)
		/// </summary>
		/// <param name="proceso">Clase que identifica al proceso que lanza el evento para notificar su cambio de estado</param>
		private void EstablecerEstado(Argumentos proceso)
		{
			switch(proceso.IdProceso)
			{
				case 0:
					estadoViejo.Image = (Image)global::PasoMFilosofos.Properties.Resources.ResourceManager.GetObject(proceso.Estado.ToString());
					break;
				case 1:
					estadoLemus.Image = (Image)global::PasoMFilosofos.Properties.Resources.ResourceManager.GetObject(proceso.Estado.ToString());
					break;
				case 2:
					estadoPepe.Image = (Image)global::PasoMFilosofos.Properties.Resources.ResourceManager.GetObject(proceso.Estado.ToString());
					break;
				case 3:
					estadoHugo.Image = (Image)global::PasoMFilosofos.Properties.Resources.ResourceManager.GetObject(proceso.Estado.ToString());
					break;
				case 4:
					estadoArturo.Image = (Image)global::PasoMFilosofos.Properties.Resources.ResourceManager.GetObject(proceso.Estado.ToString());
					break;
				default:
					break;
			}
		}
    }
}
