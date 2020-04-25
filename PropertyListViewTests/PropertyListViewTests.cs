using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Windows.Forms;

namespace CustomListView.Tests
{
    [TestClass]
    public class PropertyListViewTests
    {
        [TestMethod]
        public void PropertyListViewTest()
        {
            // Arrange

            // Act
            var testClass = new PropertyListView(){
                PropertyGrid = new PropertyGrid(),
            };

            // Assert
            Assert.IsNotNull(testClass.PropertyGrid);
        }

        [TestMethod]
        public void PropertyListViewTestNull()
        {
            // Arrange

            // Act
            var testClass = new PropertyListView(){
                PropertyGrid = null,
            };

            // Assert
            Assert.IsNull(testClass.PropertyGrid);
        }

        [TestMethod]
        public void PropertyListViewTestWithoutPropertyGrid()
        {
            // Arrange

            // Act
            var testClass = new PropertyListView();

            // Assert
            Assert.IsNull(testClass.PropertyGrid);
        }


        [TestMethod]
        public void InitListViewTest()
        {
            // Arrange
            Type expectedItemType = typeof(TestListViewClass);
            var propertyGrid = new PropertyGrid();

            // Act
            var testClass = new PropertyListView {
                PropertyGrid = propertyGrid
            };
            var listviewItems = new TestListViewClassCollection();
            testClass.InitListView(listviewItems);

            // Assert
            Assert.AreEqual(listviewItems, testClass.DataSource);
            Assert.AreEqual(expectedItemType, testClass.ItemType);
            Assert.IsNull(testClass.PropertyGrid.SelectedObject);
            // Columns
            Assert.AreEqual("IntData", testClass.ListView.Columns[0].Text);
            Assert.AreEqual("StringData", testClass.ListView.Columns[1].Text);
            Assert.AreEqual("PointData", testClass.ListView.Columns[2].Text);
            Assert.AreEqual("EnumData", testClass.ListView.Columns[3].Text);
            // testlistview1
            Assert.AreEqual("100", testClass.ListView.Items[0].Text);
            Assert.AreEqual("testString100", testClass.ListView.Items[0].SubItems[1].Text);
            Assert.AreEqual("{X=1,Y=1}", testClass.ListView.Items[0].SubItems[2].Text);
            Assert.AreEqual("Enum1", testClass.ListView.Items[0].SubItems[3].Text);
            // testlistview2
            Assert.AreEqual("200", testClass.ListView.Items[1].Text);
            Assert.AreEqual("testString200", testClass.ListView.Items[1].SubItems[1].Text);
            Assert.AreEqual("{X=2,Y=2}", testClass.ListView.Items[1].SubItems[2].Text);
            Assert.AreEqual("Enum2", testClass.ListView.Items[1].SubItems[3].Text);
            // testlistview3
            Assert.AreEqual("300", testClass.ListView.Items[2].Text);
            Assert.AreEqual("testString300", testClass.ListView.Items[2].SubItems[1].Text);
            Assert.AreEqual("{X=3,Y=3}", testClass.ListView.Items[2].SubItems[2].Text);
            Assert.AreEqual("Enum3", testClass.ListView.Items[2].SubItems[3].Text);
        }

        [TestMethod]
        public void InitListViewTestNull()
        {
            Assert.ThrowsException<ArgumentNullException>(() =>
            {
                var testClass = new PropertyListView();
                testClass.InitListView(null);
            });
        }

        [TestMethod]
        public void ReloadSelectedItemTest()
        {
            // Arrange
            var testClass = InitListView();
            var data = testClass.DataSource[1] as TestListViewClass;
            testClass.ListView.Items[1].Selected = true;

            // Act
            data.StringData = "StringUpdate";
            // Assert
            Assert.AreEqual("testString200", testClass.ListView.Items[1].SubItems[1].Text);

            // Act
            testClass.ReloadSelectedItem();
            // Assert
            Assert.AreEqual("StringUpdate", testClass.ListView.Items[1].SubItems[1].Text);
        }

        [TestMethod]
        public void RemoveSelectedItemsTest()
        {
            // Arrange
            var testClass = InitListView();
            testClass.ListView.Items[1].Selected = true;

            // Assert
            Assert.AreEqual("testString200", testClass.ListView.Items[1].SubItems[1].Text);
            Assert.AreEqual(3, testClass.ListView.Items.Count);

            // Act
            testClass.RemoveSelectedItems();
            // Assert
            Assert.AreEqual("testString300", testClass.ListView.Items[1].SubItems[1].Text);
            Assert.AreEqual(2, testClass.ListView.Items.Count);
            Assert.IsTrue(testClass.ListView.Items[1].Selected);
        }


        [TestMethod]
        public void RemoveSelectedItemsTestMultiAndEndSelected()
        {
            // Arrange
            var testClass = InitListView();
            testClass.ListView.Items[1].Selected = true;
            testClass.ListView.Items[2].Selected = true;

            // Assert
            Assert.AreEqual("testString300", testClass.ListView.Items[2].SubItems[1].Text);
            Assert.AreEqual(3, testClass.ListView.Items.Count);

            // Act
            testClass.RemoveSelectedItems();
            // Assert
            Assert.AreEqual("testString100", testClass.ListView.Items[0].SubItems[1].Text);
            Assert.AreEqual(1, testClass.ListView.Items.Count);
            Assert.AreEqual(0, testClass.ListView.SelectedItems.Count);
        }

        [TestMethod]
        public void RemoveSelectedItemsTestNoSelected()
        {
            // Arrange
            var testClass = InitListView();

            // Act
            testClass.RemoveSelectedItems();
            // Assert
            // testlistview1
            Assert.AreEqual("100", testClass.ListView.Items[0].Text);
            Assert.AreEqual("testString100", testClass.ListView.Items[0].SubItems[1].Text);
            Assert.AreEqual("{X=1,Y=1}", testClass.ListView.Items[0].SubItems[2].Text);
            Assert.AreEqual("Enum1", testClass.ListView.Items[0].SubItems[3].Text);
            // testlistview2
            Assert.AreEqual("200", testClass.ListView.Items[1].Text);
            Assert.AreEqual("testString200", testClass.ListView.Items[1].SubItems[1].Text);
            Assert.AreEqual("{X=2,Y=2}", testClass.ListView.Items[1].SubItems[2].Text);
            Assert.AreEqual("Enum2", testClass.ListView.Items[1].SubItems[3].Text);
            // testlistview3
            Assert.AreEqual("300", testClass.ListView.Items[2].Text);
            Assert.AreEqual("testString300", testClass.ListView.Items[2].SubItems[1].Text);
            Assert.AreEqual("{X=3,Y=3}", testClass.ListView.Items[2].SubItems[2].Text);
            Assert.AreEqual("Enum3", testClass.ListView.Items[2].SubItems[3].Text);
        }

        [TestMethod]
        public void AddItemTest()
        {
            // Arrange
            var testClass = InitListView();

            // Act
            testClass.AddItem();

            // Assert
            Assert.AreEqual("0", testClass.ListView.Items[3].Text);
            Assert.AreEqual("", testClass.ListView.Items[3].SubItems[1].Text);
            Assert.AreEqual("{X=0,Y=0}", testClass.ListView.Items[3].SubItems[2].Text);
            Assert.AreEqual("Enum1", testClass.ListView.Items[3].SubItems[3].Text);
        }

        [TestMethod]
        public void AddItemTestWithoutInit()
        {
            // Arrange
            var testClass = new PropertyListView();
            // Act
            testClass.AddItem();

            // Assert
            Assert.IsNull(testClass.DataSource);
        }

        [TestMethod]
        public void MoveSelectedItemTest()
        {
            // Arrange
            var testClass = InitListView();

            // Act
            testClass.ListView.Items[1].Selected = true;
            testClass.MoveSelectedItem(1);

            // Assert
            Assert.AreEqual("200", testClass.ListView.Items[2].Text);
            Assert.AreEqual("testString200", testClass.ListView.Items[2].SubItems[1].Text);
            Assert.AreEqual("{X=2,Y=2}", testClass.ListView.Items[2].SubItems[2].Text);
            Assert.AreEqual("Enum2", testClass.ListView.Items[2].SubItems[3].Text);

            // Act
            testClass.MoveSelectedItem(-1);

            // Assert
            Assert.AreEqual("200", testClass.ListView.Items[1].Text);
            Assert.AreEqual("testString200", testClass.ListView.Items[1].SubItems[1].Text);
            Assert.AreEqual("{X=2,Y=2}", testClass.ListView.Items[1].SubItems[2].Text);
            Assert.AreEqual("Enum2", testClass.ListView.Items[1].SubItems[3].Text);

            // Act
            testClass.ListView.Items[0].Selected = true;
            testClass.MoveSelectedItem(-1);

            // Assert nothing to move
            Assert.AreEqual("100", testClass.ListView.Items[0].Text);
            Assert.AreEqual("testString100", testClass.ListView.Items[0].SubItems[1].Text);
            Assert.AreEqual("{X=1,Y=1}", testClass.ListView.Items[0].SubItems[2].Text);
            Assert.AreEqual("Enum1", testClass.ListView.Items[0].SubItems[3].Text);

            // Act
            testClass.ListView.Items[2].Selected = true;
            testClass.MoveSelectedItem(1);

            // Assert nothing to move
            Assert.AreEqual("300", testClass.ListView.Items[2].Text);
            Assert.AreEqual("testString300", testClass.ListView.Items[2].SubItems[1].Text);
            Assert.AreEqual("{X=3,Y=3}", testClass.ListView.Items[2].SubItems[2].Text);
            Assert.AreEqual("Enum3", testClass.ListView.Items[2].SubItems[3].Text);
        }

        [TestMethod]
        public void MoveSelectedItemTestNoSelected()
        {
            // Arrange
            var testClass = InitListView();

            // Act
            testClass.MoveSelectedItem(1);

            // Assert nothing to move
            Assert.AreEqual("300", testClass.ListView.Items[2].Text);
            Assert.AreEqual("testString300", testClass.ListView.Items[2].SubItems[1].Text);
            Assert.AreEqual("{X=3,Y=3}", testClass.ListView.Items[2].SubItems[2].Text);
            Assert.AreEqual("Enum3", testClass.ListView.Items[2].SubItems[3].Text);
        }

        [TestMethod]
        public void ResizeColumnsTest()
        {
            // Arrange
            var testClass = InitListView();

            // Act
            testClass.ResizeColumns(ResizeColumnOption.HeaderSize);
            testClass.ResizeColumns(ResizeColumnOption.ColumnContent);
            testClass.ResizeColumns(ResizeColumnOption.HeaderOrContentsMax);
            testClass.ResizeColumns((ResizeColumnOption)3);
        }

        private static PropertyListView InitListView()
        {
            var testClass = new PropertyListView();
            var listviewItems = new TestListViewClassCollection();
            testClass.InitListView(listviewItems);
            return testClass;
        }

    }
}