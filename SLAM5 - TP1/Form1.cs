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
            cbClients.ValueMember = "NUMCLI";
            cbClients.DisplayMember = "nomComplet";
            bsClients2.DataSource = (Model.Model.listeClients()).Select(x => new
            {
                x.Numcli,
                nomComplet = x.Nomcli + " " + x.Prenomcli
            });
            cbClients.DataSource = bsClients2;
            dgvCommandes.DataSource = bsCommandes;
        }

        private void bsClients2_CurrentChanged(object sender, EventArgs e)
        {
            int IDC = Convert.ToInt32(cbClients.SelectedValue);
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
            dgvCommandes.DataSource = bsCommandes;
        }

        private void tbFiltre_TextChanged(object sender, EventArgs e)
        {
            if (tbFiltre.Text != "")
            {
                int IdClient = Convert.ToInt32(cbClients.SelectedValue);
                int montantMin = Convert.ToInt32(tbFiltre.Text);
                bsCommandes.DataSource = Model.Model.listeCommandesParClientEtParMontant(IdClient, montantMin).Select(x => new
                {
                    x.Numcde,
                    x.Datecde,
                    x.Montantcde,
                    x.NumcliNavigation.Nomcli,
                    x.NumcliNavigation.Prenomcli
                })
                .OrderBy(x => x.Datecde);
                dgvCommandes.DataSource = bsCommandes;
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
                });
                dgvCommandes.DataSource = bsCommandes;
            }
        }
    }
}
