using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLKJDS.Admin.Areas.SysManage.Controllers;
using PLKJDS.Common;
using PLKJDS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace PLKJDS.Admin.Areas.SysManage.Controllers.Tests
{
    [TestClass()]
    public class AccountTypeControllerTests
    {
        AccountTypeController accountType = new AccountTypeController();
        [TestMethod()]
        public void AddAccountTypeTest()
        {
            //Case 1
            //当TypeName为空的时候
            //Error("添加失败。");
            var retTarget = new AjaxResult
            {
                state = ResultType.error.ToString(),
                message = "添加失败。"
            }.ToJson();
            AccountType ac = new AccountType();
            var ret = (accountType.AddAccountType(ac) as ContentResult).Content;
            Assert.AreEqual(ret, retTarget);
        }

        [TestMethod()]
        public void GetFormJsonTest()
        {
            //case 1
            //Error("获取失败")
            string keyValue = "";
            var retTarget = new AjaxResult
            {
                state = ResultType.error.ToString(),
                message = "获取失败"
            }.ToJson();
            var ret = (accountType.GetFormJson(keyValue) as ContentResult).Content;
            Assert.AreEqual(retTarget, ret);
        }
    }
}