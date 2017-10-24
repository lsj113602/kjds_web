using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLKJDS.Common;
using PLKJDS.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PLKJDS.Common.Tests
{
    [TestClass()]
    public class EnityCopyHelperTests
    {
        [TestMethod()]
        public void CopyEnityTest()
        {
            //case 1
            AccountType account1 = new AccountType();
            AccountType account2 = new AccountType();
            account1.ID = "1";
            account1.TypeName = "公司";
            account2.ID = "2";
            account2.TypeName = "企业";
            account2.IsShow = null;
            EntityCopyHelper.CopyEnity(account1, account2);
            Assert.AreEqual(account1.ID, "2");
            Assert.AreEqual(account1.TypeName, "企业");
            Assert.AreEqual(account1.IsShow, null);
        }
    }
}