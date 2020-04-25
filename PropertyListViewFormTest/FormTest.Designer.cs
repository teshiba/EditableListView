namespace PropertyListViewFormTest
{
    partial class FormTest
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.propertyGridListview = new System.Windows.Forms.PropertyGrid();
            this.propertyListView = new CustomListView.PropertyListView();
            this.radioButtonHeaderSize = new System.Windows.Forms.RadioButton();
            this.radioButtonColumnContent = new System.Windows.Forms.RadioButton();
            this.radioButtonHeaderOrContentsMax = new System.Windows.Forms.RadioButton();
            this.SuspendLayout();
            // 
            // propertyGridListview
            // 
            this.propertyGridListview.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyGridListview.Location = new System.Drawing.Point(536, 34);
            this.propertyGridListview.Name = "propertyGridListview";
            this.propertyGridListview.Size = new System.Drawing.Size(361, 543);
            this.propertyGridListview.TabIndex = 1;
            this.propertyGridListview.Click += new System.EventHandler(this.propertyGrid_Click);
            // 
            // propertyListView
            // 
            this.propertyListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            // 
            // 
            // 
            this.propertyListView.ListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.propertyListView.ListView.FullRowSelect = true;
            this.propertyListView.ListView.GridLines = true;
            this.propertyListView.ListView.HideSelection = false;
            this.propertyListView.ListView.Location = new System.Drawing.Point(82, 3);
            this.propertyListView.ListView.Name = "listView";
            this.propertyListView.ListView.Size = new System.Drawing.Size(11075, 15244);
            this.propertyListView.ListView.TabIndex = 92;
            this.propertyListView.ListView.UseCompatibleStateImageBehavior = false;
            this.propertyListView.ListView.View = System.Windows.Forms.View.Details;
            this.propertyListView.Location = new System.Drawing.Point(12, 30);
            this.propertyListView.Name = "propertyListView";
            this.propertyListView.PropertyGrid = this.propertyGridListview;
            this.propertyListView.Size = new System.Drawing.Size(518, 547);
            this.propertyListView.TabIndex = 0;
            this.propertyListView.Load += new System.EventHandler(this.propertyListView_Load);
            // 
            // radioButtonHeaderSize
            // 
            this.radioButtonHeaderSize.AutoSize = true;
            this.radioButtonHeaderSize.Location = new System.Drawing.Point(12, 8);
            this.radioButtonHeaderSize.Name = "radioButtonHeaderSize";
            this.radioButtonHeaderSize.Size = new System.Drawing.Size(80, 16);
            this.radioButtonHeaderSize.TabIndex = 2;
            this.radioButtonHeaderSize.TabStop = true;
            this.radioButtonHeaderSize.Text = "HeaderSize";
            this.radioButtonHeaderSize.UseVisualStyleBackColor = true;
            this.radioButtonHeaderSize.CheckedChanged += new System.EventHandler(this.radioButtonHeaderSize_CheckedChanged);
            // 
            // radioButtonColumnContent
            // 
            this.radioButtonColumnContent.AutoSize = true;
            this.radioButtonColumnContent.Location = new System.Drawing.Point(98, 8);
            this.radioButtonColumnContent.Name = "radioButtonColumnContent";
            this.radioButtonColumnContent.Size = new System.Drawing.Size(101, 16);
            this.radioButtonColumnContent.TabIndex = 3;
            this.radioButtonColumnContent.TabStop = true;
            this.radioButtonColumnContent.Text = "ColumnContent";
            this.radioButtonColumnContent.UseVisualStyleBackColor = true;
            this.radioButtonColumnContent.CheckedChanged += new System.EventHandler(this.radioButtonColumnContent_CheckedChanged);
            // 
            // radioButtonHeaderOrContentsMax
            // 
            this.radioButtonHeaderOrContentsMax.AutoSize = true;
            this.radioButtonHeaderOrContentsMax.Location = new System.Drawing.Point(205, 8);
            this.radioButtonHeaderOrContentsMax.Name = "radioButtonHeaderOrContentsMax";
            this.radioButtonHeaderOrContentsMax.Size = new System.Drawing.Size(138, 16);
            this.radioButtonHeaderOrContentsMax.TabIndex = 4;
            this.radioButtonHeaderOrContentsMax.TabStop = true;
            this.radioButtonHeaderOrContentsMax.Text = "HeaderOrContentsMax";
            this.radioButtonHeaderOrContentsMax.UseVisualStyleBackColor = true;
            this.radioButtonHeaderOrContentsMax.CheckedChanged += new System.EventHandler(this.radioButtonHeaderOrContentsMax_CheckedChanged);
            // 
            // FormTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(907, 589);
            this.Controls.Add(this.radioButtonHeaderOrContentsMax);
            this.Controls.Add(this.radioButtonColumnContent);
            this.Controls.Add(this.radioButtonHeaderSize);
            this.Controls.Add(this.propertyGridListview);
            this.Controls.Add(this.propertyListView);
            this.Name = "FormTest";
            this.Text = "PropertyListView Test Form";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private CustomListView.PropertyListView propertyListView;
        private System.Windows.Forms.PropertyGrid propertyGridListview;
        private System.Windows.Forms.RadioButton radioButtonHeaderSize;
        private System.Windows.Forms.RadioButton radioButtonColumnContent;
        private System.Windows.Forms.RadioButton radioButtonHeaderOrContentsMax;
    }
}

