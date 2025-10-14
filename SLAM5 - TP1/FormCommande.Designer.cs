namespace SLAM5___TP1
{
    partial class FormCommande
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

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			tbCommande = new TextBox();
			lblMontant = new Label();
			dtpCommande = new DateTimePicker();
			cbCommandeForm = new ComboBox();
			btnOK = new Button();
			cbLivraison = new ComboBox();
			SuspendLayout();
			// 
			// tbCommande
			// 
			tbCommande.Location = new Point(193, 38);
			tbCommande.Name = "tbCommande";
			tbCommande.Size = new Size(200, 39);
			tbCommande.TabIndex = 0;
			// 
			// lblMontant
			// 
			lblMontant.AutoSize = true;
			lblMontant.Location = new Point(67, 41);
			lblMontant.Name = "lblMontant";
			lblMontant.Size = new Size(106, 32);
			lblMontant.TabIndex = 1;
			lblMontant.Text = "Montant";
			// 
			// dtpCommande
			// 
			dtpCommande.Location = new Point(67, 104);
			dtpCommande.Name = "dtpCommande";
			dtpCommande.Size = new Size(326, 39);
			dtpCommande.TabIndex = 2;
			// 
			// cbCommandeForm
			// 
			cbCommandeForm.DropDownStyle = ComboBoxStyle.DropDownList;
			cbCommandeForm.FormattingEnabled = true;
			cbCommandeForm.Location = new Point(67, 172);
			cbCommandeForm.Name = "cbCommandeForm";
			cbCommandeForm.Size = new Size(330, 40);
			cbCommandeForm.TabIndex = 3;
			// 
			// btnOK
			// 
			btnOK.Location = new Point(145, 304);
			btnOK.Name = "btnOK";
			btnOK.Size = new Size(150, 46);
			btnOK.TabIndex = 4;
			btnOK.Text = "Ajouter";
			btnOK.UseVisualStyleBackColor = true;
			btnOK.Click += btnOK_Click;
			// 
			// cbLivraison
			// 
			cbLivraison.FormattingEnabled = true;
			cbLivraison.Location = new Point(67, 238);
			cbLivraison.Name = "cbLivraison";
			cbLivraison.Size = new Size(330, 40);
			cbLivraison.TabIndex = 5;
			// 
			// FormCommande
			// 
			AutoScaleDimensions = new SizeF(13F, 32F);
			AutoScaleMode = AutoScaleMode.Font;
			ClientSize = new Size(456, 376);
			Controls.Add(cbLivraison);
			Controls.Add(btnOK);
			Controls.Add(cbCommandeForm);
			Controls.Add(dtpCommande);
			Controls.Add(lblMontant);
			Controls.Add(tbCommande);
			Name = "FormCommande";
			Text = "FormCommande";
			Load += FormCommande_Load;
			ResumeLayout(false);
			PerformLayout();
		}

		#endregion

		private TextBox tbCommande;
        private Label lblMontant;
        private DateTimePicker dtpCommande;
        private ComboBox cbCommandeForm;
        private Button btnOK;
		private ComboBox cbLivraison;
	}
}