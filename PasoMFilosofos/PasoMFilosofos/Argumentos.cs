namespace PasoMFilosofos
{
	/// <summary>
	/// Clase que identifica al proceso (o filósofo) que lanza un evento,
	///		para notificar su cambio de estado
	/// </summary>
    class Argumentos
    {
        public int IdProceso { get; set; }
        public Filosofo.Estado Estado { get; set; }
    }
}
