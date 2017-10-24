using PLKJDS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.Data.IRepositories
{
    public partial interface IRoleRepository
    {
        int SubmitForm(Role role, string[] permissionIds, string keyValue);
    }
}
