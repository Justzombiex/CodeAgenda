using CodeAgenda.DataAccess.Concrete;
using Microsoft.EntityFrameworkCore;

namespace CodeAgenda.ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            // Creando un contexto para interactuar con la Base de datos.
            ApplicationContext appContext = new ApplicationContext("Host=localhost;Database=CodeAgendaDB;Username=postgres;Password=LACONTRASEÑA");
            // Verificando si la BD no existe
            if (!appContext.Database.CanConnect())
            {
                // Migrando base de datos. Este paso genera la BD con las tablas configuradas en su migración.
                appContext.Database.Migrate();
            }
            else { Console.WriteLine("Can not connect"); }

            Console.WriteLine("Pasó el if");
        }
    }
}
