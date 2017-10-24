using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using PLKJDS.Common;
using PLKJDS.BLL;
using PLKJDS.Entity;
using PLKJDS.Common.Enums;

namespace PLKJDS.Admin.Controllers
{
    //[HandlerLogin]
    public class ClientsDataController : Controller
    {
        [HttpGet]
        [HandlerAjaxOnly]
        public ActionResult GetClientsDataJson()
        {
            var data = new
            {
            //dataItems = this.GetDataItemList(),
            organize = this.GetOrganizeList(),
            role = this.GetRoleList(),
            //duty = this.GetDutyList(),
            //user = "",
            authorizeMenu = this.GetMenuList(),
            authorizeButton = this.GetMenuButtonList(),
            };
            return Content(data.ToJson());
        }
        private object GetDataItemList()
        {
            //var itemdata = new ItemsDetailApp().GetList();
            //Dictionary<string, object> dictionaryItem = new Dictionary<string, object>();
            //foreach (var item in new ItemsApp().GetList())
            //{
            //    var dataItemList = itemdata.FindAll(t => t.F_ItemId.Equals(item.F_Id));
            //    Dictionary<string, string> dictionaryItemList = new Dictionary<string, string>();
            //    foreach (var itemList in dataItemList)
            //    {
            //        dictionaryItemList.Add(itemList.F_ItemCode, itemList.F_ItemName);
            //    }
            //    dictionaryItem.Add(item.F_EnCode, dictionaryItemList);
            //}
            //return dictionaryItem;
            return null;
        }
        private object GetOrganizeList()
        {
            OrganizeApp organizeApp = new OrganizeApp();
            var data = organizeApp.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (Organize item in data)
            {
                var fieldItem = new
                {
                    encode = item.ID,
                    fullname = item.OrgName
                };
                dictionary.Add(item.ID, fieldItem);
            }
            return dictionary;
        }
        private object GetRoleList()
        {
            RoleApp roleApp = new RoleApp();
            var data = roleApp.GetList();
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (var item in data)
            {
                var fieldItem = new
                {
                    encode = item.ID,
                    fullname = item.RoleName
                };
                dictionary.Add(item.ID, fieldItem);
            }
            return dictionary;
        }
        private object GetDutyList()
        {
            //DutyApp dutyApp = new DutyApp();
            //var data = dutyApp.GetList();
            //Dictionary<string, object> dictionary = new Dictionary<string, object>();
            //foreach (RoleEntity item in data)
            //{
            //    var fieldItem = new
            //    {
            //        encode = item.F_EnCode,
            //        fullname = item.F_FullName
            //    };
            //    dictionary.Add(item.F_Id, fieldItem);
            //}
            //return dictionary;
            return null;
        }
        private string GetMenuList()
        {
            string roleId = "fc2d01c3-7c56-44a0-948d-cb263c42c0b2";
            //var roleId = OperatorProvider.Provider.GetCurrent().RoleId;
            return ToMenuJson(new RoleAuthorizeApp().GetAuthorizeList(roleId,AuthorizeType.Menu), "0");
        }
        private string ToMenuJson(List<Authorize> data, string parentId)
        {
            StringBuilder sbJson = new StringBuilder();
            sbJson.Append("[");
            List<Authorize> entitys = data.FindAll(t => t.PID == parentId);
            if (entitys.Count > 0)
            {
                foreach (var item in entitys)
                {
                    string strJson = item.ToJson();
                    strJson = strJson.Insert(strJson.Length - 1, ",\"ChildNodes\":" + ToMenuJson(data, item.ID) + "");
                    sbJson.Append(strJson + ",");
                }
                sbJson = sbJson.Remove(sbJson.Length - 1, 1);
            }
            sbJson.Append("]");
            return sbJson.ToString();
        }
        private object GetMenuButtonList()
        {
            string roleId = "fc2d01c3-7c56-44a0-948d-cb263c42c0b2";
            //var roleId = OperatorProvider.Provider.GetCurrent().RoleId;
            var data = new RoleAuthorizeApp().GetAuthorizeList(roleId, AuthorizeType.Button);
            var dataModuleId = data.Distinct(new ExtList<Authorize>("PID"));
            Dictionary<string, object> dictionary = new Dictionary<string, object>();
            foreach (Authorize item in dataModuleId)
            {
                var buttonList = data.Where(t => t.PID.Equals(item.PID));
                dictionary.Add(item.PID, buttonList);
            }
            return dictionary;
        }
    }
}
