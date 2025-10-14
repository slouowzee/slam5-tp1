using Microsoft.EntityFrameworkCore;
using SLAM5___TP1.Entities;
using System;
using System.Net;

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
        public static List<Livraison> listeLivraison()
        {
            return monModel.Livraisons.ToList();
		}
		public static List<Commande> listeCommandes()
        {
            return monModel.Commandes
                .Include(a => a.NumcliNavigation)
                .Include(a => a.IdlivraisonNavigation)
				.ToList();
		}
		public static List<Commande> listeCommandesParClient(int idClient)
        {
            return monModel.Commandes
                .Where(p => p.Numcli == idClient)
                .Include(p => p.NumcliNavigation)
                .Include(p => p.IdlivraisonNavigation)
				.ToList();
		}
        public static List<Commande> listeCommandesParMontant(int montantMin)
        {
            return monModel.Commandes
                .Where(p => p.Montantcde >= montantMin)
                .Include(p => p.NumcliNavigation)
                .Include(p => p.IdlivraisonNavigation)
				.ToList();
        }
        public static List<Commande> listeCommandesParClientEtParMontant(int idClient, int montantMin)
        {
            return monModel.Commandes
                .Where(p => p.Numcli == idClient && p.Montantcde >= montantMin)
                .Include(p => p.NumcliNavigation)
                .Include(p => p.IdlivraisonNavigation)
				.ToList();
        }

        public static List<Partition> listePartitions()
        {
            return monModel.Partitions.ToList();
        }

        public static bool AjoutCommande(int montant, DateTime dateC, int idClient, int idLivraison)
        {
            Commande maCommande;
            bool vretour = true;
            try
            {
                maCommande = new Commande();
                maCommande.Montantcde = montant;
                maCommande.Datecde = DateOnly.FromDateTime(dateC);

                maCommande.Numcli = idClient;
                monModel.Commandes.Add(maCommande);
                monModel.SaveChanges();
            }
            catch (Exception ex)
            {
                vretour = false;
            }
            return vretour;
        }

        public static Commande RecupererCommande(int idCommande)
        {
            Commande uneCommande = new Commande();
            try
            {
                uneCommande = monModel.Commandes.Include(c => c.Numparts).First(x => x.Numcde == idCommande);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
            return uneCommande;
        }

        public static bool ModifierCommande(int idCde, int montant, DateTime dateC, int idClient, int idLivraison)
        {
            try
            {
                monModel.Commandes.Where(c => c.Numcde == idCde).ToList().ForEach(c =>
                {
                    c.Montantcde = montant;
                    c.Datecde = DateOnly.FromDateTime(dateC);
                    c.Numcli = idClient;
                });
            }
            catch (Exception ex)
            {
                return false;
            }
            monModel.SaveChanges();
            return true;
        }

        public static bool SupprimerCommande(int idCde)
        {
            try
            {
                Commande c = monModel.Commandes.First(x => x.Numcde == idCde);
                monModel.Commandes.Remove(c);
                monModel.SaveChanges();
            }
            catch (Exception ex)
            {
				System.Windows.Forms.MessageBox.Show(ex.Message);
				return false;
            }
            return true;
		}
	}
}
