using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLKJDS.Common;
using PLKJDS.Common.Enums;
namespace UnitTestProject
{
    [TestClass]
    public class FileHelperTest
    {
        [TestMethod]
        public void GetFileContentType()
        {
            string filename = "20170103172120635gallery-8.jpg";
            string path = Environment.CurrentDirectory + @"\" + filename;
            string contentType = FileHelper.GetFileContentType(filename);
            //Console.WriteLine(contentType);
            Assert.AreEqual(contentType, "image/jpeg");
        }
        
    }
}
