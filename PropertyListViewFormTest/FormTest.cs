using CustomListView;
using CustomListViewFormTest;
using System;
using System.Windows.Forms;

namespace PropertyListViewFormTest
{
    public partial class FormTest : Form
    {
        public FormTest()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var list = new TestListViewClassCollection();
            propertyListView.InitListView(list);
        }

        private void propertyListView_Load(object sender, EventArgs e)
        {

        }

        private void propertyGrid_PropertyValueChanged(object s, PropertyValueChangedEventArgs e)
        {

        }

        private void propertyGrid_Click(object sender, EventArgs e)
        {

        }

        private void radioButtonHeaderSize_CheckedChanged(object sender, EventArgs e)
        {
            propertyListView.ResizeColumns(ResizeColumnOption.HeaderSize);
        }

        private void radioButtonColumnContent_CheckedChanged(object sender, EventArgs e)
        {
            propertyListView.ResizeColumns(ResizeColumnOption.ColumnContent);
        }

        private void radioButtonHeaderOrContentsMax_CheckedChanged(object sender, EventArgs e)
        {
            propertyListView.ResizeColumns(ResizeColumnOption.HeaderOrContentsMax);
        }
    }
}
