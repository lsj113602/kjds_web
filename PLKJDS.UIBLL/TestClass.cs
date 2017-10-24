using PLKJDS.Data.IRepositories;
using PLKJDS.Data.Repositories;
using PLKJDS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.UIBLL
{
    public class TestClass
    {
        IEmployPositionRepository employPosition = new EmployPositionRepository();

        public List<EmployPosition> GetEmployPositionList()
        {
            return employPosition.IQueryable().ToList();
        }
    }
}
