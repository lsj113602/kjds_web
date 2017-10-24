using PLKJDS.Data.IRepositories;
using PLKJDS.Data.Repositories;
using PLKJDS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.BLL
{
    public class FileApp
    {
        IFileRepository fileService = new FileRepository();


        public File GetForm(string keyValue)
        {
            return fileService.FindEntity(keyValue);
        }
    }
}
