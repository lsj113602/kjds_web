using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PLKJDS.Common;
using PLKJDS.Common.Enums;
namespace UnitTestProject
{
    [TestClass]
    public class EnumExtTest
    {
        [TestMethod]
        public void GetEnumCodeTest()
        {
            //case 1
            Assert.AreEqual(FileType.BMP.GetEnumCode(),"3");
        }
        [TestMethod]
        public void GetEnumNoteTest()
        {
            //case 1
            Assert.AreEqual(FileType.BMP.GetEnumNote(), "BMP");
            //case 2
            Assert.AreEqual(FileType.JPG.GetEnumNote(), "JPG");
            //case 3
            Assert.AreEqual(FileType.MP4.GetEnumNote(), "MP4");
        }
        [TestMethod]
        public void GetEnumDictTest()
        {
            //case 1
            var dict = EnumExt.GetEnumDict<FileType>();
            var length = Enum.GetNames(typeof(FileType)).Length;
            Assert.AreEqual(dict.Count, length);
            //case 2
            dict = EnumExt.GetEnumDict<ChapterContentType>();
            length = Enum.GetNames(typeof(ChapterContentType)).Length;
            Assert.AreEqual(dict.Count, length);
            //case 3
            dict = EnumExt.GetEnumDict<EmployTypes>();
            length = Enum.GetNames(typeof(EmployTypes)).Length;
            Assert.AreEqual(dict.Count, length);
            //case 4
            dict = EnumExt.GetEnumDict<Gender>();
            length = Enum.GetNames(typeof(Gender)).Length;
            Assert.AreEqual(dict.Count, length);
            //case 5
            dict = EnumExt.GetEnumDict<MessageType>();
            length = Enum.GetNames(typeof(MessageType)).Length;
            Assert.AreEqual(dict.Count, length);
            //case 6
            dict = EnumExt.GetEnumDict<ResumeConfigType>();
            length = Enum.GetNames(typeof(ResumeConfigType)).Length;
            Assert.AreEqual(dict.Count, length);


        }
        [TestMethod]
        public void GetEnumListTest()
        {
            //case 1
            var dict = EnumExt.GetEnumList<FileType>();
            var length = Enum.GetNames(typeof(FileType)).Length;
            Assert.AreEqual(dict.Count, length);
            //case 2
            dict = EnumExt.GetEnumList<ChapterContentType>();
            length = Enum.GetNames(typeof(ChapterContentType)).Length;
            Assert.AreEqual(dict.Count, length);

            //case 3
            dict = EnumExt.GetEnumList<EmployTypes>();
            length = Enum.GetNames(typeof(EmployTypes)).Length;
            Assert.AreEqual(dict.Count, length);
            //case 4
            dict = EnumExt.GetEnumList<Gender>();
            length = Enum.GetNames(typeof(Gender)).Length;
            Assert.AreEqual(dict.Count, length);
            //case 5
            dict = EnumExt.GetEnumList<MessageType>();
            length = Enum.GetNames(typeof(MessageType)).Length;
            Assert.AreEqual(dict.Count, length);
            //case 6
            dict = EnumExt.GetEnumList<ResumeConfigType>();
            length = Enum.GetNames(typeof(ResumeConfigType)).Length;
            Assert.AreEqual(dict.Count, length);


        }
    }
}
