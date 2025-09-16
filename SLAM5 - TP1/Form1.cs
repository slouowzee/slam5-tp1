namespace SLAM5___TP1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            bsClients.DataSource = Model.Model.listeClients();
            bsCommandes.DataSource = Model.Model.listeCommandes().Select(x => new
            {
                x.Numcde,
                x.Montantcde,
                x.Datecde,
                x.NumcliNavigation.Nomcli,
                x.NumcliNavigation.Prenomcli
            });

            var clients = Model.Model.listeClients()
                .Select(x => new
                {
                    x.Numcli,
                    nomComplet = x.Nomcli + " " + x.Prenomcli
                })
                .ToList();

            clients.Insert(0, new { Numcli = 0, nomComplet = "" });

            bsClients2.DataSource = clients;
            cbClients.ValueMember = "Numcli";
            cbClients.DisplayMember = "nomComplet";
            cbClients.DataSource = bsClients2;
            cbClients.SelectedIndex = 0;
            dgvCommandes.DataSource = bsCommandes;
        }

        private void bsClients2_CurrentChanged(object sender, EventArgs e)
        {
            if (cbClients.SelectedIndex == 0 || cbClients.SelectedValue == null || Convert.ToInt32(cbClients.SelectedValue) == 0)
            {
                bsCommandes.DataSource = Model.Model.listeCommandes().Select(x => new
                {
                    x.Numcde,
                    x.Montantcde,
                    x.Datecde,
                    x.NumcliNavigation.Nomcli,
                    x.NumcliNavigation.Prenomcli
                });
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
                })
                .OrderBy(x => x.Datecde);
            }
            dgvCommandes.DataSource = bsCommandes;
        }

        private void tbFiltre_TextChanged(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(tbFiltre.Text))
            {
                if (int.TryParse(tbFiltre.Text, out int montantMin))
                {
                    // Si aucun client sélectionné ou "tous", filtre sur tous les clients
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
                    // Si la saisie n'est pas un nombre, on ne filtre pas
                    bsCommandes.DataSource = null;
                    dgvCommandes.DataSource = bsCommandes;
                }
            }
            else
            {
                // Si le filtre est vide, on affiche selon le client sélectionné
                if (cbClients.SelectedIndex == 0 || cbClients.SelectedValue == null || Convert.ToInt32(cbClients.SelectedValue) == 0)
                {
                    bsCommandes.DataSource = Model.Model.listeCommandes().Select(x => new
                    {
                        x.Numcde,
                        x.Montantcde,
                        x.Datecde,
                        x.NumcliNavigation.Nomcli,
                        x.NumcliNavigation.Prenomcli
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
    }
}
