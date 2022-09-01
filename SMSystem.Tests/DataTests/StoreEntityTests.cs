using Microsoft.VisualStudio.TestTools.UnitTesting;
using SMSystem.Core;
using SMSystem.Data;
using SMSystem.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace SMSystem.Tests.DataTests
{
    [TestClass]
    public class StoreEntityTests
    {
        // Fileds
        private IDataHelper<Stores> dataHelper;
        private DBContext db;
        private Stores stores;
        // Constructores
        public StoreEntityTests()
        {
            // dataHelper = (IDataHelper<Stores>)ContainerConfig.ObjectType("Store");
            dataHelper = new StoreEntity();
        }

        [TestMethod]
        [Description("This method return true if " +
            "can connect to databse")]
        [Owner("Safaa Jassim")]
        [Priority(1)]
        [TestCategory("DataBaseCon")]
        [TestInitialize]
        public void IsDbConnect_True()
        {
            // Arrange
            db = new DBContext();
            // Act
            bool act = dataHelper.IsDbConnect();
            bool expt = true;
            //Assert
            Assert.AreEqual(expt, act);
        }

        [TestMethod]
        [Description("This mehod return 1 if" +
            "proccess completed successfuly")]
        [Owner("Safaa Jassim")]
        [TestCategory("Add Data")]
        public void Add_TableData_1()
        {
            // Arrange
            db = new DBContext();
            stores = new Stores
            {
                Name = "مخزن1",
                Description = "هنا وصف معين للمخزن"
            };
            // Act
            int act = dataHelper.Add(stores);
            int expt = 1;
            // Assert
            Assert.AreEqual(expt, act);
        }

        [TestMethod]
        [Owner("Safaa Jassim")]
        [Description("This method retrun 1 if" +
            "proccess completed successfuly")]
        [TestCategory("Edit Data")]
        public void Edit_TableData_1()
        {
            // Arrange
            db = new DBContext();
            stores = new Stores
            {
                Id = 50,
                Name = "الاسم الجديد بعد التعديل",
                Description = "الوصف الجديد بعد التعديل"
            };
            // Act
            int act = dataHelper.Edit(stores);
            int expt = 1;
            // Assert
            Assert.AreEqual(expt, act);
        }

        [TestMethod]
        public void GetData_ListOfStores()
        {
            db = new DBContext();
            List<Stores> ListOFStores = new List<Stores>();
            ListOFStores = dataHelper.GetData();
            Assert.IsNotNull(ListOFStores);
        }

        [TestMethod]
        public void Find_Id50_StoreTable()
        {
            db = new DBContext();
            stores = dataHelper.Find(50);
            Assert.IsNotNull(stores);
        }
        [TestMethod]
        public void Delete_Id50_1()
        {
            db = new DBContext();
            int act = dataHelper.Delete(50);
            int expt = 1;
            Assert.AreEqual(expt, act);
        }

        [TestMethod]
        public void SearchItem_StoreList()
        {
            db = new DBContext();
            List<Stores> ListOFStores = new List<Stores>();
            ListOFStores = dataHelper.Search("مخزن");
            Assert.IsNotNull(ListOFStores);
        }

    }
}
