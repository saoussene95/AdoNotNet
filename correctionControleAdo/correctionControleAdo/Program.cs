﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;
using System.Data;

namespace correctionControleAdo
{
    class program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Connexion a la Base de Donnée");
            Console.WriteLine("Host:");
            string h = Convert.ToString(Console.ReadLine());
            Console.WriteLine("database:");
            string db = Convert.ToString(Console.ReadLine());
            Console.WriteLine("user:");
            string u = Convert.ToString(Console.ReadLine());
            Console.WriteLine("mot de passe:");
            string pswd = Convert.ToString(Console.ReadLine());
            Requetes rqt = new Requetes(h, u, db, pswd);
            Console.WriteLine("Afficher menu True/False");
            Boolean choix1 = Convert.ToBoolean(Console.ReadLine());
            while (choix1)
            {

                Console.WriteLine("Choix");
                Console.WriteLine("0. Liste des joueurs");
                Console.WriteLine("1. Liste des joueurs par sponsor");
                Console.WriteLine("2. Liste des joueurs ayant la meme nation que leur sponsor");
                Console.WriteLine("3. Chiffre d'affaires des sponsors");
                Console.WriteLine("4. Insertion de Nadal");
                Console.WriteLine("5. Update de Nadal");
                Console.WriteLine("6. Delete de Nadal");
                int choix = Convert.ToInt32(Console.ReadLine());
                switch (choix)
                {
                    case 0:
                        Console.WriteLine("REQUETE 1");
                        Console.WriteLine(rqt.Listejoueurs());
                        break;
                    case 1:
                        Console.WriteLine("REQUETE 2");
                        Console.WriteLine(rqt.ListeJoueursSponsor());
                        break;
                    case 2:
                        Console.WriteLine("REQUETE 3");
                        Console.WriteLine(rqt.ListeJoueursSponsorNation());
                        break;
                    case 3:
                        Console.WriteLine("REQUETE 4");
                        Console.WriteLine("Chiffre d'affaires: {0}", rqt.MontantSponsor());
                        break;
                    case 4:
                        Console.WriteLine("Insertion de Nadal:");
                        rqt.InsertJoueurs();
                        Console.WriteLine(rqt.Listejoueurs());
                        break;
                    case 5:
                        Console.WriteLine("Update de Nadal:");
                        rqt.UpdateJoueurs();
                        Console.WriteLine(rqt.Listejoueurs());
                        break;
                    case 6:
                        Console.WriteLine("Delete de Nadal:");
                        rqt.DeleteJoueurs();
                        Console.WriteLine(rqt.Listejoueurs());
                        break;
                    default:
                        Console.WriteLine("Index hors limite !");
                        break;
                }
                Console.WriteLine("Afficher menu True/False");
                choix1 = Convert.ToBoolean(Console.ReadLine());
            }




            Console.WriteLine("Afficher le menu Call? True/False");
            Boolean choix2 = Convert.ToBoolean(Console.ReadLine());
            while (choix2)
            {

                Console.WriteLine("Choix");
                Console.WriteLine("0. nvlEmploye");
                Console.WriteLine("1. selectDiplome");
                Console.WriteLine("2. borneSalaire");
                Console.WriteLine("3. budget");
                Console.WriteLine("4. Moyenne");
                Console.WriteLine("5.MSalariale");
                int choixCall = Convert.ToInt32(Console.ReadLine());
                switch (choixCall)
                {
                    case 0:
                        Console.WriteLine("nvlEmploye");
                        rqt.CallCreationEmployer();
                        break;
                    case 1:
                        Console.WriteLine("selectDiplome");
                        Console.WriteLine(rqt.CallListeEmploye());
                        break;
                    case 2:
                        Console.WriteLine("borneSalaire");
                        Console.WriteLine(rqt.CallSalaireEmployer());
                        break;
                    case 3:
                        Console.WriteLine("budget");
                        rqt.CallMajBudget();
                        break;
                    case 4:
                        Console.WriteLine("Moyenne");
                        Console.WriteLine(rqt.CallAvgDiplomeSup());
                        break;
                   
                    default:
                        Console.WriteLine("Index hors limite !");
                        break;
                }
                Console.WriteLine("Afficher le menu Call? True/False");
                choix2 = Convert.ToBoolean(Console.ReadLine());
            }

            Console.ReadLine();

        }

    }
}
