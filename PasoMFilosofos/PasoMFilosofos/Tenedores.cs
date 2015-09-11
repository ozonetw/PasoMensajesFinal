using System.Configuration;
using System.Threading;

namespace PasoMFilosofos
{
    class Tenedores
    {
        bool[] tenedor = new bool[int.Parse(ConfigurationManager.AppSettings["NumFilosofos"])];

        public void Obtener(int izquierda, int derecha)
        {
            //Marca el siguiente bloque de instrucciones como una sección crítica (acceso a recurso compartido), 
            //utilizando el bloqueo de exclusión mutua. El bloque se libera cuando finaliza su ejecución
            //Si otro subproceso intenta acceder, esperará hasta que el objeto se libere (sincronización)
            lock (this)
            {
                //Espera a que los 2 tenedores estén libres (FALSE)
                while (tenedor[izquierda] || tenedor[derecha])
                    Monitor.Wait(this);

                tenedor[izquierda] = true;
                tenedor[derecha] = true;
            }
        }

        public void Liberar(int izquierda, int derecha)
        {
            lock (this)
            {
                tenedor[izquierda] = false;
                tenedor[derecha] = false;
                Monitor.PulseAll(this);
            }
        }
    }
}
