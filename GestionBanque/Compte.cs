using GestionBanqueDbContext.Data;
using GestionBanqueDbContext.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GestionBanqueDbContext
{
    public class Compte
    {
        public int ChoixMenu()
        {
            Console.WriteLine("MENU PRINCIPAL");
            Console.WriteLine("Qu'est-ce que tu aimerais faire?");
            Console.WriteLine("Tapez 1 pour ajouter des enregistrements.");
            Console.WriteLine("Tapez 2 pour afficher tous les enregistrements.");
            Console.WriteLine("Tapez 3 pour supprimer les enregistrements.");
            Console.WriteLine("Tapez 4 pour mettre à jour les enregistrements.");
            Console.WriteLine("Tapez 5 pour fermer l’application.");
            return Utils.ReadIntBetween("Votre choix : ", 1, 5);
        }
        public void UserCommand()
        {
            do
            {
                int choix = ChoixMenu();
                if (choix == 1)
                {
                    var informationBanque = new InformationsBanque
                    {
                        Date = DateTime.Now,
                        Libelle = Utils.ReadString("Donner une Libelle : "),
                        Montant = Utils.ReadInt("Entrer Un Montant : ")
                    };
                    using (var context = new AppDbContext())
                    {
                        context.Banques.Add(informationBanque);
                        context.SaveChanges();
                    };
                    Console.WriteLine();
                }
                else if (choix == 2)
                {
                    using (var context = new AppDbContext())
                    {
                        var informationBanque = context.Banques;
                        foreach(var result in informationBanque)
                            Console.WriteLine(result);
                        context.SaveChanges(); 
                    };
                }
                else if (choix == 3)
                {
                    using (var context = new AppDbContext())
                    {
                        var informationBanque = context.Banques.Single(
                            x => x.Id == Utils.ReadInt("Entre L'ID Pour Supprimer :"));
                        context.Banques.Remove(informationBanque);
                        context.SaveChanges();
                    };
                }
                else if (choix == 4)
                {
                    using (var context = new AppDbContext())
                    {
                        var informationBanque = context.Banques.Single(
                            x => x.Id == Utils.ReadInt("Donnez-moi l'ID dont vous modifiez les propriétés : "));
                        informationBanque.Date = DateTime.Now;
                        informationBanque.Libelle = Utils.ReadString("Entrer Nouveau Libelle : ");
                        informationBanque.Montant = Utils.ReadInt("Entrer Nouveau Montant");
                        context.SaveChanges();
                    };
                }
                else if (choix == 5)
                {
                    Console.WriteLine("Merci d'avoir utilisé notre application");
                    return;
                }
            } while (true);
        }
    }
}
