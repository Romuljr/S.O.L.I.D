using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ex004.Repositories
{
    public class BaseRepository
    {
        protected readonly string connectionString;

        public BaseRepository()
        {
            connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=BD004;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
        }
    }
}
