using System.Security.AccessControl;

namespace Database_App
{
    partial class SearchForm
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
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            btnSearch = new Button();
            gridRoutes = new DataGridView();
            txtIata = new TextBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)gridRoutes).BeginInit();
            SuspendLayout();
            // 
            // btnSearch
            // 
            btnSearch.Location = new Point(365, 295);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(75, 23);
            btnSearch.TabIndex = 0;
            btnSearch.Text = "Find";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            // 
            // gridRoutes
            // 
            gridRoutes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            gridRoutes.Location = new Point(12, 12);
            gridRoutes.Name = "gridRoutes";
            gridRoutes.Size = new Size(451, 258);
            gridRoutes.TabIndex = 1;
            gridRoutes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            gridRoutes.BackgroundColor = SystemColors.ControlLightLight;
            gridRoutes.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            // 
            // txtIata
            // 
            txtIata.Location = new Point(101, 292);
            txtIata.Name = "txtIata";
            txtIata.PlaceholderText = "Enter IATA";
            txtIata.Size = new Size(109, 23);
            txtIata.TabIndex = 2;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(26, 295);
            label1.Name = "label1";
            label1.Size = new Size(69, 15);
            label1.TabIndex = 3;
            label1.Text = "Find Routes";
            // 
            // SearchForm
            // 
            ClientSize = new Size(746, 467);
            Controls.Add(label1);
            Controls.Add(txtIata);
            Controls.Add(gridRoutes);
            Controls.Add(btnSearch);
            Name = "SearchForm";
            ((System.ComponentModel.ISupportInitialize)gridRoutes).EndInit();
            ResumeLayout(false);
            PerformLayout();


        }
        #endregion


        private Button btnSearch;
        private DataGridView gridRoutes;
        private TextBox txtIata;
        private Label label1;
    }
}