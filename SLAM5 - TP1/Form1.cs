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
            dgvClients.DataSource = bsClients;
            dgvCommandes.DataSource = bsCommandes;
        }

        private void cbChoix_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
