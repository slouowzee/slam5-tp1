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
    }
}
