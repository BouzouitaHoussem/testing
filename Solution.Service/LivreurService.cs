using Service.Pattern;
using Solution.Data.Infrastructure;
using Solution.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Service
{
    public class LivreurService : Service<Livreur>, ILivreurService
    {
        static IDataBaseFactory Factory = new DataBaseFactory();
        static IUnitOfWork utk = new UnitOfWork(Factory);
        public LivreurService() : base(utk)
        {

        }

        public Livreur getLivreurByLastName(string name)
        {
            return Get(f => f.LastName.Equals(name));
        }
    }
}
