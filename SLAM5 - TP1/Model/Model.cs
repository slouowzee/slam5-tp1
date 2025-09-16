using Microsoft.EntityFrameworkCore;
using SLAM5___TP1.Entities;

namespace SLAM5___TP1.Model
{
    public static class Model
    {
        private static PiletGaelSlam5Tp1Context monModel;
        public static void init()
        {
            monModel = new PiletGaelSlam5Tp1Context();
        }
        public static List<Client> listeClients()
        {
            return monModel.Clients.ToList();
        }
        public static List<Commande> listeCommandes()
        {
            return monModel.Commandes.Include(a => a.NumcliNavigation).ToList();
        }
        public static List<Commande> listeCommandesParClient(int idClient)
        {
            List<Commande> lesCommandes = monModel.Commandes.Where(p => p.Numcli ==
            idClient).Include(p => p.NumcliNavigation).ToList();
            return lesCommandes;
        }
        public static List<Commande> listeCommandesParMontant(int montantMin)
        {
            List<Commande> lesCommandes = monModel.Commandes
                .Where(p => p.Montantcde >= montantMin)
                .Include(p => p.NumcliNavigation)
                .ToList();
            return lesCommandes;
        }
        public static List<Commande> listeCommandesParClientEtParMontant(int idClient, int montantMin)
        {
            List<Commande> lesCommandes = monModel.Commandes
                .Where(p => p.Numcli == idClient && p.Montantcde >= montantMin)
                .Include(p => p.NumcliNavigation)
                .ToList();
            return lesCommandes;
        }
    }
}
