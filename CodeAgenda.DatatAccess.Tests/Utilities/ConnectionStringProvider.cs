using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeAgenda.DatatAccess.Tests.Utilities
{
    /// <summary>
    /// Proveedor de cadenas de conexión.
    /// </summary>
    public static class ConnectionStringProvider
    {
        /// <summary>
        /// It obtains the connection string to be used in the tests.
        /// </summary>
        /// <returns></returns>
        public static string GetConnectionString() => "Host=localhost;Database=CodeAgendaDB;Username=postgres;Password=1234";

    }

}
