using System;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace CustomListView
{
    /// <summary>
    /// PropertyListView.
    /// </summary>
    public partial class PropertyListView : UserControl
    {
        private readonly int widthMargin = 10;
        private PropertyGrid propertyGrid;

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyListView"/> class.
        /// </summary>
        public PropertyListView()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Occurs when the System.Windows.Forms.ListView.SelectedIndices collection changes.
        /// </summary>
        [Browsable(true)]
        [Description("Occurs whenever the 'selectedIndex' property for this ListView changes")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public event EventHandler SelectedIndexChanged;

        /// <summary>
        /// Gets ListView control.
        /// </summary>
        [Browsable(true)]
        [Category("Control")]
        [Description("Display the ListView control of PropertyListView control")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        public ListView ListView => listView;

        /// <summary>
        /// Gets or sets PropertyGrid.
        /// </summary>
        [Browsable(true)]
        [Category("Control")]
        [Description("Display the PropertyGrid control of PropertyListView control")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public PropertyGrid PropertyGrid
        {
            get => propertyGrid;

            set {
                propertyGrid = value;
                if (propertyGrid != null) {
                    propertyGrid.PropertyValueChanged += PropertyGrid_PropertyValueChanged;
                }
            }
        }

        /// <summary>
        /// Gets type of litemlist items.
        /// </summary>
        public Type ItemType { get; private set; }

        /// <summary>
        /// Gets data of listview.
        /// </summary>
        public IList DataSource { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="PropertyListView"/> class.
        /// Initialize ListView items.
        /// </summary>
        /// <param name="items">items to register.</param>
        public void InitListView(IList items)
        {
            DataSource = items ?? throw new ArgumentNullException(nameof(items));

            ItemType = DataSource[0].GetType();

            var properties = ItemType.GetProperties();

            listView.BeginUpdate();

            // clear items.
            listView.Clear();
            if (propertyGrid != null) {
                PropertyGrid.SelectedObject = null;
            }

            // Set property name of data source class to column.
            foreach (var prop in properties) {
                listView.Columns.Add(prop.Name);
            }

            // Set ListView items.
            foreach (var item in DataSource) {
                listView.Items.Add(CreateListViewItem(item));
            }

            ResizeColumns(ResizeColumnOption.HeaderOrContentsMax);

            listView.EndUpdate();
        }

        /// <summary>
        /// Reload selected item.
        /// </summary>
        public void ReloadSelectedItem()
        {
            listView.BeginUpdate();

            // Reload the selected item from the DataSource.
            // don't replace listview, but copy selected DataSource so that the selected item is not unselected.
            var newItem = CreateListViewItem(GetSelectedDataSource());
            for (int i = 0; i < GetSelectedFirstItem().SubItems.Count; i++) {
                GetSelectedFirstItem().SubItems[i].Text = newItem.SubItems[i].Text;
            }

            ResizeColumns(ResizeColumnOption.HeaderOrContentsMax);

            listView.EndUpdate();
        }

        /// <summary>
        /// Remove selected items.
        /// </summary>
        public void RemoveSelectedItems()
        {
            if (listView.SelectedItems.Count != 0) {
                var selectedIndex = listView.SelectedItems[0].Index;

                foreach (ListViewItem item in listView.SelectedItems) {
                    DataSource.RemoveAt(item.Index);
                    listView.Items.Remove(item);
                }

                if (selectedIndex < listView.Items.Count) {
                    listView.Items[selectedIndex].Selected = true;
                }

            }
        }

        /// <summary>
        /// Add items.
        /// </summary>
        public void AddItem()
        {
            if (ItemType != null) {
                var item = Activator.CreateInstance(ItemType);
                DataSource.Add(item);
                listView.Items.Add(CreateListViewItem(item));
            }
        }

        /// <summary>
        /// Move selected item to offset.
        /// </summary>
        /// <param name="offset">offset from selected index.</param>
        public void MoveSelectedItem(int offset)
        {
            var selectedItem = GetSelectedFirstItem();

            // Nothing to do, if noone is selected.
            var insertPosition = selectedItem?.Index + offset ?? -1;

            // Nothing todo, if out of range.
            if (insertPosition < 0 || insertPosition > listView.Items.Count - 1) {
                return;
            }

            // Update Data
            var selectedData = DataSource[selectedItem.Index];
            DataSource.RemoveAt(selectedItem.Index);
            DataSource.Insert(insertPosition, selectedData);

            // Update View.
            listView.BeginUpdate();
            listView.Items.Remove(selectedItem);
            listView.Items.Insert(insertPosition, selectedItem);
            listView.EndUpdate();
        }

        /// <summary>
        /// Resize listview columns by given option.
        /// </summary>
        /// <param name="option">resize option.</param>
        public void ResizeColumns(ResizeColumnOption option)
        {
            ListView.BeginUpdate();

            switch (option) {
            case ResizeColumnOption.HeaderSize:
                ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.HeaderSize);
                break;
            case ResizeColumnOption.ColumnContent:
                ListView.AutoResizeColumns(ColumnHeaderAutoResizeStyle.ColumnContent);
                break;
            case ResizeColumnOption.HeaderOrContentsMax:
                foreach (ColumnHeader item in ListView.Columns) {
                    item.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                    var widthBeforeResize = item.Width;
                    item.AutoResize(ColumnHeaderAutoResizeStyle.ColumnContent);
                    if (item.Width < widthBeforeResize) {
                        item.AutoResize(ColumnHeaderAutoResizeStyle.HeaderSize);
                    }

                    item.Width += widthMargin;
                }

                break;
            default:
                break;
            }

            ListView.EndUpdate();
        }

        /// <summary>
        /// Create ListView item.
        /// </summary>
        /// <param name="item">object instance.</param>
        /// <returns>ListViewItem instance.</returns>
        private ListViewItem CreateListViewItem(object item)
        {
            if (item.GetType() != ItemType) {
                throw new ArgumentOutOfRangeException(nameof(item));
            }

            var listViewItem = new ListViewItem(GetPropertyValue(item, 0));
            listViewItem.Name = listViewItem.Text;

            // Set property to Subitems of ListView.
            for (var i = 1; i < listView.Columns.Count; i++) {
                listViewItem.SubItems.Add(GetPropertyValue(item, i));
            }

            return listViewItem;

            string GetPropertyValue(object listItem, int i)
            {
                return listItem.GetType()
                               .GetProperty(listView.Columns[i].Text)
                               .GetValue(listItem)?
                               .ToString() ?? string.Empty;
            }
        }

        private void ListView_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (propertyGrid != null) {
                PropertyGrid.SelectedObject = GetSelectedDataSource();
            }

            SelectedIndexChanged?.Invoke(GetSelectedDataSource(), e);
        }

        private object GetSelectedDataSource()
        {
            object ret = null;

            var index = GetSelectedFirstItem()?.Index ?? 0;
            if (index < DataSource.Count) {
                ret = DataSource[index];
            }

            return ret;
        }

        private ListViewItem GetSelectedFirstItem()
        {
            ListViewItem ret = null;

            if (listView.SelectedItems.Count != 0) {
                ret = listView.SelectedItems[0];
            }

            return ret;
        }

        // Event Handler //////////////////////////////////////////////////////
        private void PropertyGrid_PropertyValueChanged(object sender, PropertyValueChangedEventArgs e) => ReloadSelectedItem();

        private void ButtonAdd_Click(object sender, EventArgs e) => AddItem();

        private void ButtonRemove_Click(object sender, EventArgs e) => RemoveSelectedItems();

        private void ButtonUp_Click(object sender, EventArgs e) => MoveSelectedItem(-1);

        private void ButtonDown_Click(object sender, EventArgs e) => MoveSelectedItem(1);
    }
}
