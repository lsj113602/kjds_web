using PLKJDS.Data.IRepositories;
using PLKJDS.Data.Repositories;
using PLKJDS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.BLL.SystemManage
{
    public class TrainDataApp
    {
        private ITrainDataRepository service = new TrainDataRepository();

        public int AddTrainSummary(string trainID, string fileID)
        {
            int result = 0;
            TrainData model = new TrainData();
            var filetype = fileID.Split('.');

            model.Create();
            model.FileID = fileID;
            model.TrainID =trainID;
            if (filetype.Count()>1)
            {
                model.TypeID = filetype[1];
            }
            
            model.UploadTime = DateTime.Now;
            model.DeleteMark = false;
            result = service.Insert(model);
            return result;
        }
    }
}
