using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PasoMFilosofos
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            Form.CheckForIllegalCrossThreadCalls = false;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Instancia del recurso compartido
            Tenedores tenedores = new Tenedores();

            //Instancias de los filosofos
            Filosofo filosofo0 = new Filosofo(0, tenedores, evento_CambioEstado);
            Filosofo filosofo1 = new Filosofo(1, tenedores, evento_CambioEstado);
            Filosofo filosofo2 = new Filosofo(2, tenedores, evento_CambioEstado);
            Filosofo filosofo3 = new Filosofo(3, tenedores, evento_CambioEstado);
            Filosofo filosofo4 = new Filosofo(4, tenedores, evento_CambioEstado);

        }

        private void evento_CambioEstado(object sender, EventArgs e)
        {
            Argumentos proceso = (Argumentos)sender;
          

            tAConsole.Items.Add("Filosofo " + proceso.IdProceso + ": " + proceso.Estado);

            switch (proceso.Estado)
            {
                case Filosofo.Estado.Pensando:
                    //Cambiar imagen a color amarillo
                    if (proceso.IdProceso == 0)
                    {
                        stateLemus.Image = Image.FromFile("c:/users/edata/documents/visual studio 2013/Projects/PasoMFilosofos/PasoMFilosofos/Resources/Hambre.png");

                    }
                    else if (proceso.IdProceso == 1)
                    {
                        statePepe.Image = Image.FromFile("c:/users/edata/documents/visual studio 2013/Projects/PasoMFilosofos/PasoMFilosofos/Resources/Hambre.png");
                    }
                    else if (proceso.IdProceso == 2)
                    {
                        stateHugo.Image = Image.FromFile("c:/users/edata/documents/visual studio 2013/Projects/PasoMFilosofos/PasoMFilosofos/Resources/Hambre.png");
                    }
                    else if (proceso.IdProceso == 3)
                    {
                        stateArturo.Image = Image.FromFile("c:/users/edata/documents/visual studio 2013/Projects/PasoMFilosofos/PasoMFilosofos/Resources/Hambre.png");
                    }
                    else if (proceso.IdProceso == 4)
                    {
                        stateViejo.Image = Image.FromFile("c:/users/edata/documents/visual studio 2013/Projects/PasoMFilosofos/PasoMFilosofos/Resources/Hambre.png");
                    }   
                    break;
                case Filosofo.Estado.Esperando:
                    //Cambiar imagen a color rojo
                    if (proceso.IdProceso == 0)
                    {
                        stateLemus.Image = Image.FromFile("c:/users/edata/documents/visual studio 2013/Projects/PasoMFilosofos/PasoMFilosofos/Resources/Comiendo.png");

                    }
                    else if (proceso.IdProceso == 1)
                    {
                        statePepe.Image = Image.FromFile("c:/users/edata/documents/visual studio 2013/Projects/PasoMFilosofos/PasoMFilosofos/Resources/Comiendo.png");
                    }
                    else if (proceso.IdProceso == 2)
                    {
                        stateHugo.Image = Image.FromFile("c:/users/edata/documents/visual studio 2013/Projects/PasoMFilosofos/PasoMFilosofos/Resources/Comiendo.png");
                    }
                    else if (proceso.IdProceso == 3)
                    {
                        stateArturo.Image = Image.FromFile("c:/users/edata/documents/visual studio 2013/Projects/PasoMFilosofos/PasoMFilosofos/Resources/Comiendo.png");
                    }
                    else if (proceso.IdProceso == 4)
                    {
                        stateViejo.Image = Image.FromFile("c:/users/edata/documents/visual studio 2013/Projects/PasoMFilosofos/PasoMFilosofos/Resources/Comiendo.png");
                    }
                    break;
                case Filosofo.Estado.Comiendo:
                    //Cambiar imagen a color verde
                    if (proceso.IdProceso == 0)
                    {
                        stateLemus.Image = Image.FromFile("c:/users/edata/documents/visual studio 2013/Projects/PasoMFilosofos/PasoMFilosofos/Resources/thinking.png");

                    }
                    else if (proceso.IdProceso == 1)
                    {
                        statePepe.Image = Image.FromFile("c:/users/edata/documents/visual studio 2013/Projects/PasoMFilosofos/PasoMFilosofos/Resources/thinking.png");
                    }
                    else if (proceso.IdProceso == 2)
                    {
                        stateHugo.Image = Image.FromFile("c:/users/edata/documents/visual studio 2013/Projects/PasoMFilosofos/PasoMFilosofos/Resources/thinking.png");
                    }
                    else if (proceso.IdProceso == 3)
                    {
                        stateArturo.Image = Image.FromFile("c:/users/edata/documents/visual studio 2013/Projects/PasoMFilosofos/PasoMFilosofos/Resources/thinking.png");
                    }
                    else if (proceso.IdProceso == 4)
                    {
                        stateViejo.Image = Image.FromFile("c:/users/edata/documents/visual studio 2013/Projects/PasoMFilosofos/PasoMFilosofos/Resources/thinking.png");
                    }
                    break;
            }
        }
    }
}
