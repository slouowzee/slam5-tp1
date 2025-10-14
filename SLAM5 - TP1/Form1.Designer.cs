namespace SLAM5___TP1
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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

		/// <summary>
		///  Required method for Designer support - do not modify
		///  the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();
			bsClients = new BindingSource(components);
			bsCommandes = new BindingSource(components);
			cbClients = new ComboBox();
			dgvCommandes = new DataGridView();
			bsClients2 = new BindingSource(components);
			tbFiltre = new TextBox();
			cbTables = new ComboBox();
			lblClients = new Label();
			bsPartitions = new BindingSource(components);
			btnAdd = new Button();
			btnMod = new Button();
			btnSup = new Button();
			bsLivraison = new BindingSource(components);
			cbLivraisonForm = new ComboBox();
			((System.ComponentModel.ISupportInitialize)bsClients).BeginInit();
			((System.ComponentModel.ISupportInitialize)bsCommandes).BeginInit();
			((System.ComponentModel.ISupportInitialize)dgvCommandes).BeginInit();
			((System.ComponentModel.ISupportInitialize)bsClients2).BeginInit();
			((System.ComponentModel.ISupportInitialize)bsPartitions).BeginInit();
			((System.ComponentModel.ISupportInitialize)bsLivraison).BeginInit();
			SuspendLayout();
			// 
			// cbClients
			// 
			cbClients.DropDownStyle = ComboBoxStyle.DropDownList;
			cbClients.FormattingEnabled = true;
			cbClients.Location = new Point(1023, 814);
			cbClients.Name = "cbClients";
			cbClients.Size = new Size(242, 40);
			cbClients.TabIndex = 1;
			// 
			// dgvCommandes
			// 
			dgvCommandes.AllowUserToAddRows = false;
			dgvCommandes.AllowUserToDeleteRows = false;
			dgvCommandes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			dgvCommandes.Location = new Point(31, 40);
			dgvCommandes.Name = "dgvCommandes";
			dgvCommandes.ReadOnly = true;
			dgvCommandes.RowHeadersWidth = 82;
			dgvCommandes.Size = new Size(952, 814);
			dgvCommandes.TabIndex = 2;
			// 
			// bsClients2
			// 
			bsClients2.CurrentChanged += bsClients2_CurrentChanged;
			// 
			// tbFiltre
			// 
			tbFiltre.Location = new Point(1023, 755);
			tbFiltre.Name = "tbFiltre";
			tbFiltre.Size = new Size(242, 39);
			tbFiltre.TabIndex = 3;
			tbFiltre.TextChanged += tbFiltre_TextChanged;
			// 
			// cbTables
			// 
			cbTables.DropDownStyle = ComboBoxStyle.DropDownList;
			cbTables.FormattingEnabled = true;
			cbTables.Location = new Point(1023, 40);
			cbTables.Name = "cbTables";
			cbTables.Size = new Size(242, 40);
			cbTables.TabIndex = 4;
			// 
			// lblClients
			// 
			lblClients.AutoSize = true;
			lblClients.Location = new Point(1114, 702);
			lblClients.Name = "lblClients";
			lblClients.Size = new Size(77, 32);
			lblClients.TabIndex = 5;
			lblClients.Text = "Filtres";
			// 
			// btnAdd
			// 
			btnAdd.Location = new Point(1075, 112);
			btnAdd.Name = "btnAdd";
			btnAdd.Size = new Size(150, 46);
			btnAdd.TabIndex = 6;
			btnAdd.Text = "Ajouter";
			btnAdd.UseVisualStyleBackColor = true;
			btnAdd.Click += btnAdd_Click;
			// 
			// btnMod
			// 
			btnMod.Location = new Point(1075, 192);
			btnMod.Name = "btnMod";
			btnMod.Size = new Size(150, 46);
			btnMod.TabIndex = 7;
			btnMod.Text = "Modifier";
			btnMod.UseVisualStyleBackColor = true;
			btnMod.Click += btnMod_Click;
			// 
			// btnSup
			// 
			btnSup.Location = new Point(1075, 316);
			btnSup.Name = "btnSup";
			btnSup.Size = new Size(150, 46);
			btnSup.TabIndex = 8;
			btnSup.Text = "Supprimer";
			btnSup.UseVisualStyleBackColor = true;
			btnSup.Click += btnSup_Click;
			// 
			// cbLivraisonForm
			// 
			cbLivraisonForm.FormattingEnabled = true;
			cbLivraisonForm.Location = new Point(1023, 646);
			cbLivraisonForm.Name = "cbLivraisonForm";
			cbLivraisonForm.Size = new Size(242, 40);
			cbLivraisonForm.TabIndex = 9;
			// 
			// Form1
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(1294, 888);
			Controls.Add(cbLivraisonForm);
			Controls.Add(btnSup);
			Controls.Add(btnMod);
			Controls.Add(btnAdd);
			Controls.Add(lblClients);
			Controls.Add(cbTables);
			Controls.Add(tbFiltre);
			Controls.Add(dgvCommandes);
			Controls.Add(cbClients);
			Name = "Form1";
			Text = "Form1";
			Load += Form1_Load;
			((System.ComponentModel.ISupportInitialize)bsClients).EndInit();
			((System.ComponentModel.ISupportInitialize)bsCommandes).EndInit();
			((System.ComponentModel.ISupportInitialize)dgvCommandes).EndInit();
			((System.ComponentModel.ISupportInitialize)bsClients2).EndInit();
			((System.ComponentModel.ISupportInitialize)bsPartitions).EndInit();
			((System.ComponentModel.ISupportInitialize)bsLivraison).EndInit();
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion
		private BindingSource bsClients;
        private BindingSource bsCommandes;
        private ComboBox cbClients;
        private DataGridView dgvCommandes;
        private BindingSource bsClients2;
        private TextBox tbFiltre;
        private ComboBox cbTables;
        private Label lblClients;
        private BindingSource bsPartitions;
        private Button btnAdd;
        private Button btnMod;
		private Button btnSup;
		private BindingSource bsLivraison;
		private ComboBox cbLivraisonForm;
	}
}
