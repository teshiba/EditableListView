using System.Collections.ObjectModel;
using System.Drawing;

namespace CustomListViewFormTest
{
    internal enum TestEnum
    {
        Enum1,
        Enum2,
        Enum3,
    }

    internal class TestListViewClass
    {
        public int IntData { get; set; }
        public string StringData { get; set; }
        public Point PointData { get; set; }
        public TestEnum EnumData { get; set; }
    }

    internal class TestListViewClassCollection : Collection<TestListViewClass>
    {
        public TestListViewClassCollection()
        {
            var testlistview1 = new TestListViewClass(){
                IntData = 100,
                StringData = "testString100",
                PointData = new Point(1,1),
                EnumData = TestEnum.Enum1,
            };
            var testlistview2 = new TestListViewClass(){
                IntData = 200,
                StringData = "testString200",
                PointData = new Point(2,2),
                EnumData = TestEnum.Enum2,
            };
            var testlistview3 = new TestListViewClass(){
                IntData = 300,
                StringData = "testString300",
                PointData = new Point(3,3),
                EnumData = TestEnum.Enum3,
            };

            Add(testlistview1);
            Add(testlistview2);
            Add(testlistview3);
        }
    }
}
