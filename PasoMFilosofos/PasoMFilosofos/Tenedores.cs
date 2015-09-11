using System.Configuration;
using System.Threading;

namespace PasoMFilosofos
{
	/// <summary>
	/// Clase que representa el recurso compartido
	/// </summary>
    class Tenedores
    {
		//Recurso compartido
        bool[] tenedor = new bool[int.Parse(ConfigurationManager.AppSettings["NumFilosofos"])];

		/// <summary>
		/// Obtiene el recurso compartido
		/// </summary>
		/// <param name="izquierda">Índice del tenedor ubicado la izquierda del filósofo</param>
		/// <param name="derecha">Índice del tenedor ubicado la derecha del filósofo</param>
        public void Obtener(int izquierda, int derecha)
        {
            //El siguiente bloque de instrucciones, ser marca como una sección crítica (acceso a recurso compartido), 
            //	utilizando el bloqueo de exclusión mutua (sentencia 'lock'). El bloque se libera cuando finaliza su ejecución.
            //Si otro subproceso intenta acceder, esperará hasta que el objeto se libere (sincronización)
            lock (this)
            {
                //Espera a que los 2 tenedores estén libres (ambos igual a false)
                while (tenedor[izquierda] || tenedor[derecha])
                    Monitor.Wait(this);

				//Asigna true para especificar que el recurso está ocupado
                tenedor[izquierda] = true;
                tenedor[derecha] = true;
            }
        }

		/// <summary>
		/// Libera el recurso compartido
		/// </summary>
		/// <param name="izquierda">Índice del tenedor ubicado la izquierda del filósofo</param>
		/// <param name="derecha">Índice del tenedor ubicado la derecha del filósofo</param>
        public void Liberar(int izquierda, int derecha)
        {
            lock (this)
            {
				//Asigna false para especificar que el recurso está liberado
                tenedor[izquierda] = false;
                tenedor[derecha] = false;
				//Avisa a los demás procesos el cambio de estatus del recurso compartido
                Monitor.PulseAll(this);
            }
        }
    }
}
