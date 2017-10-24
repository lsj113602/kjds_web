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
    public class FileApp
    {
        IFileRepository fileService = new FileRepository();


        public File GetForm(string keyValue)
        {
            return fileService.FindEntity(keyValue);
        }

        public File AddFile(File file)
        {
            file.Create();
            var ret = fileService.Insert(file);
            if (ret == 1)
            {
                return file;
            }
            return null;
        }
    }
}
