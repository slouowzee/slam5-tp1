namespace SLAM5___TP1
{
    public partial class FormCommande : Form
    {
        private Form1 mainForm;
		private int _ajout;
        private int _idCommande;

        public FormCommande(Form1 form, int ajout, int idCommande)
        {
            InitializeComponent();
            mainForm = form;
            _ajout = ajout;
            _idCommande = idCommande;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (_ajout == 1 && _idCommande == 0)
            {
                if (Model.Model.AjoutCommande(Convert.ToInt32(tbCommande.Text), dtpCommande.Value, Convert.ToInt32(cbCommandeForm.SelectedValue), Convert.ToInt32(cbLivraison.SelectedValue)))
                    MessageBox.Show("Commande ajoutée");
                else
                    MessageBox.Show("Erreur lors de l'ajout de la commande");
				this.Close();
                mainForm.ChargerCommandes();
			}
            else if (_ajout == 0 && _idCommande != 0)
            {
                if (Model.Model.ModifierCommande(_idCommande, Convert.ToInt32(tbCommande.Text), dtpCommande.Value, Convert.ToInt32(cbCommandeForm.SelectedValue), Convert.ToInt32(cbLivraison.SelectedValue)))
                    MessageBox.Show("Commande modifiée");
                else
                    MessageBox.Show("Erreur lors de la modification de la commande");
				this.Close();
				mainForm.ChargerCommandes();
			}
			else
            {
                MessageBox.Show("Erreur dans les paramètres du formulaire");
            }
        }

        private void FormCommande_Load(object sender, EventArgs e)
        {
            var clients = Model.Model.listeClients()
                .Select(x => new
                {
                    x.Numcli,
                    nomComplet = x.Nomcli + " " + x.Prenomcli
                })
            .ToList();
            var livraisons = Model.Model.listeLivraison()
                .Select(x => new
                {
                    x.Id,
                    x.Lbl
                });

			if (_ajout == 0 && _idCommande != 0)
            {
                btnOK.Text = "Modifier";
                var commande = Model.Model.listeCommandes().FirstOrDefault(c => c.Numcde == _idCommande);
                if (commande != null)
                {
                    tbCommande.Text = commande.Montantcde.ToString();
                    dtpCommande.Value = ((DateOnly)commande.Datecde).ToDateTime(TimeOnly.Parse("00:00"));
                    cbCommandeForm.SelectedValue = commande.Numcli;
                }
                cbCommandeForm.ValueMember = "Numcli";
                cbCommandeForm.DisplayMember = "nomComplet";
                cbCommandeForm.DataSource = clients;
                cbCommandeForm.SelectedValue = commande.Numcli;
                cbLivraison.ValueMember = "Id";
                cbLivraison.DisplayMember = "Lbl";
                cbLivraison.DataSource = livraisons.ToList();
                cbLivraison.SelectedValue = commande.Idlivraison;
			}
            else
            {
                clients.Insert(0, new { Numcli = 0, nomComplet = "" });
                cbCommandeForm.ValueMember = "Numcli";
                cbCommandeForm.DisplayMember = "nomComplet";
                cbCommandeForm.DataSource = clients;
                cbCommandeForm.SelectedIndex = 0;
                cbLivraison.ValueMember = "Id";
                cbLivraison.DisplayMember = "Lbl";
                cbLivraison.DataSource = livraisons.ToList();
                cbLivraison.SelectedIndex = -1;
			}
		}
    }
}
