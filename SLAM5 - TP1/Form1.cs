namespace SLAM5___TP1
{
	public partial class Form1 : Form
	{
		public DataGridView DgvCommandes => dgvCommandes;

		public Form1()
		{
			InitializeComponent();
			cbTables.SelectedIndexChanged += cbTables_SelectedIndexChanged;

			lblClients.Visible = false;
			cbClients.Visible = false;
			tbFiltre.Visible = false;
			btnAdd.Visible = false;
			btnMod.Visible = false;
			btnSup.Visible = false;
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			ChargerTables();
		}

		public void ChargerTables()
		{
			cbTables.Items.Clear();
			cbTables.Items.Add("Séléctionnez");
			cbTables.Items.Add("Commandes");
			cbTables.Items.Add("Partition");
			cbTables.Items.Add("Livraison");
			cbTables.SelectedIndex = 0;
		}

		public void ChargerCommandes()
		{
			bsClients.DataSource = Model.Model.listeClients();
			bsLivraison.DataSource = Model.Model.listeLivraison();
			bsCommandes.DataSource = Model.Model.listeCommandes().Select(x => new
			{
				x.Numcde,
				x.Montantcde,
				x.Datecde,
				x.IdlivraisonNavigation.Lbl,
				x.NumcliNavigation.Nomcli,
				x.NumcliNavigation.Prenomcli,
			}).ToList();

			var clients = Model.Model.listeClients()
				.Select(x => new
				{
					x.Numcli,
					nomComplet = x.Nomcli + " " + x.Prenomcli
				})
				.ToList();

			clients.Insert(0, new { Numcli = 0, nomComplet = "" });

			var livraisons = Model.Model.listeLivraison()
				.Select(x => new
				{
					x.Id,
					x.Lbl
				})
				.ToList();

			bsClients2.DataSource = clients;
			bsLivraison.DataSource = livraisons;
			cbClients.ValueMember = "Numcli";
			cbClients.DisplayMember = "nomComplet";
			cbClients.DataSource = bsClients2;
			cbClients.SelectedIndex = 0;
			cbLivraisonForm.ValueMember = "Id";
			cbLivraisonForm.DisplayMember = "Lbl";
			cbLivraisonForm.DataSource = bsLivraison;
			dgvCommandes.DataSource = bsCommandes;

			lblClients.Visible = true;
			cbClients.Visible = true;
			tbFiltre.Visible = true;
			btnAdd.Visible = true;
			btnMod.Visible = true;
			btnSup.Visible = true;
		}

		public void ChargerPartitions()
		{
			lblClients.Visible = false;
			cbClients.Visible = false;
			tbFiltre.Visible = false;
			btnAdd.Visible = false;
			btnMod.Visible = false;
			btnSup.Visible = false;

			bsPartitions.DataSource = Model.Model.listePartitions().Select(x => new
			{
				x.Numpart,
				x.Libpart,
			}).ToList();
			dgvCommandes.DataSource = bsPartitions;
		}

		public void ChargerLivraison()
		{
			lblClients.Visible = false;
			cbClients.Visible = false;
			tbFiltre.Visible = false;
			btnAdd.Visible = false;
			btnMod.Visible = false;
			btnSup.Visible = true;

			bsLivraison.DataSource = Model.Model.listeLivraison().Select(x => new
			{
				x.Id,
				x.Lbl,
			}).ToList();
			dgvCommandes.DataSource = bsLivraison;
		}

		private void cbTables_SelectedIndexChanged(object sender, EventArgs e)
		{
			if (cbTables.SelectedItem == null || string.IsNullOrWhiteSpace(cbTables.SelectedItem.ToString()))
			{
				lblClients.Visible = false;
				cbClients.Visible = false;
				tbFiltre.Visible = false;
				btnAdd.Visible = false;
				btnMod.Visible = false;
				btnSup.Visible = false;
				dgvCommandes.DataSource = null;
				return;
			}

			string table = cbTables.SelectedItem.ToString();
			if (table == "Partition")
			{
				ChargerPartitions();
			}
			else if (table == "Commandes")
			{
				ChargerCommandes();
			}
			else if (table == "Livraison")
			{
				ChargerLivraison();
			}
			else
			{
				lblClients.Visible = false;
				cbClients.Visible = false;
				tbFiltre.Visible = false;
				btnAdd.Visible = false;
				btnMod.Visible = false;
				btnSup.Visible = false;
				dgvCommandes.DataSource = null;
			}
		}

		private void bsClients2_CurrentChanged(object sender, EventArgs e)
		{
			if (cbTables.SelectedItem == null || cbTables.SelectedItem.ToString() != "Commandes")
				return;

			if (cbClients.SelectedIndex == 0 || cbClients.SelectedValue == null || Convert.ToInt32(cbClients.SelectedValue) == 0)
			{
				bsCommandes.DataSource = Model.Model.listeCommandes().Select(x => new
				{
					x.Numcde,
					x.Montantcde,
					x.Datecde,
					x.NumcliNavigation.Nomcli,
					x.NumcliNavigation.Prenomcli,
					x.IdlivraisonNavigation.Lbl
				}).ToList();
			}
			else
			{
				int IdClient = Convert.ToInt32(cbClients.SelectedValue);
				bsCommandes.DataSource = Model.Model.listeCommandesParClient(IdClient).Select(x => new
				{
					x.Numcde,
					x.Datecde,
					x.Montantcde,
					x.NumcliNavigation.Nomcli,
					x.NumcliNavigation.Prenomcli
				}).OrderBy(x => x.Datecde).ToList();
			}
			dgvCommandes.DataSource = bsCommandes;
		}

		private void tbFiltre_TextChanged(object sender, EventArgs e)
		{
			if (cbTables.SelectedItem == null || cbTables.SelectedItem.ToString() != "Commandes")
				return;

			if (!string.IsNullOrWhiteSpace(tbFiltre.Text))
			{
				if (int.TryParse(tbFiltre.Text, out int montantMin))
				{
					if (cbClients.SelectedIndex == 0 || cbClients.SelectedValue == null || Convert.ToInt32(cbClients.SelectedValue) == 0)
					{
						bsCommandes.DataSource = Model.Model.listeCommandesParMontant(montantMin).Select(x => new
						{
							x.Numcde,
							x.Datecde,
							x.Montantcde,
							x.NumcliNavigation.Nomcli,
							x.NumcliNavigation.Prenomcli
						}).OrderBy(x => x.Datecde).ToList();
					}
					else
					{
						int IdClient = Convert.ToInt32(cbClients.SelectedValue);
						bsCommandes.DataSource = Model.Model.listeCommandesParClientEtParMontant(IdClient, montantMin).Select(x => new
						{
							x.Numcde,
							x.Datecde,
							x.Montantcde,
							x.NumcliNavigation.Nomcli,
							x.NumcliNavigation.Prenomcli
						}).OrderBy(x => x.Datecde).ToList();
					}
					dgvCommandes.DataSource = bsCommandes;
				}
				else
				{
					bsCommandes.DataSource = null;
					dgvCommandes.DataSource = bsCommandes;
				}
			}
			else
			{
				if (cbClients.SelectedIndex == 0 || cbClients.SelectedValue == null || Convert.ToInt32(cbClients.SelectedValue) == 0)
				{
					bsCommandes.DataSource = Model.Model.listeCommandes().Select(x => new
					{
						x.Numcde,
						x.Montantcde,
						x.Datecde,
						x.NumcliNavigation.Nomcli,
						x.NumcliNavigation.Prenomcli,
						x.IdlivraisonNavigation.Lbl
					}).ToList();
				}
				else
				{
					int IdClient = Convert.ToInt32(cbClients.SelectedValue);
					bsCommandes.DataSource = Model.Model.listeCommandesParClient(IdClient).Select(x => new
					{
						x.Numcde,
						x.Montantcde,
						x.Datecde,
						x.NumcliNavigation.Nomcli,
						x.NumcliNavigation.Prenomcli
					}).OrderBy(x => x.Datecde).ToList();
				}
				dgvCommandes.DataSource = bsCommandes;
			}
		}

		private void btnAdd_Click(object sender, EventArgs e)
		{
			FormCommande formCommande = new FormCommande(this, 1, 0);
			formCommande.Show();
		}

		private void btnMod_Click(object sender, EventArgs e)
		{
			System.Type type = bsCommandes.Current.GetType();
			int idCommande = (int)type.GetProperty("Numcde").GetValue(bsCommandes.Current, null);

			FormCommande formCommande = new FormCommande(this, 0, idCommande);
			formCommande.Show();
		}

		private void btnSup_Click(object sender, EventArgs e)
		{
			System.Type type = bsCommandes.Current.GetType();
			int idCommande = (int)type.GetProperty("Numcde").GetValue(bsCommandes.Current, null);
			
			if (MessageBox.Show("Voulez-vous vraiment supprimer la commande " + idCommande + " ?", "Suppression", MessageBoxButtons.OKCancel) == DialogResult.OK)
			{
				if (Model.Model.SupprimerCommande(idCommande))
					MessageBox.Show("Commande supprimée");
				else
					MessageBox.Show("Erreur lors de la suppression de la commande");
			}
			ChargerCommandes();
		}
	}
}
