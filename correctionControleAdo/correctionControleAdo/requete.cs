using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MySql.Data.MySqlClient;

namespace correctionControleAdo
{
    class Requetes
    {
        
        private MySqlConnection cnx;

        public Requetes(string h, string u, string db, string pswd)
        {
            connection2 cn = new connection2(h, u, db, pswd);
            this.cnx = cn.Cnx2;  
        }

        public string Listejoueurs()
        {
            string resultat = "";
            MySqlCommand cmdSql = new MySqlCommand();
            cmdSql.Connection = cnx;
            cmdSql.CommandText = "joueur";
            cmdSql.CommandType = System.Data.CommandType.TableDirect;

            cnx.Open();
            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                resultat+=String.Format("{0} : {1} : {2} : {3} : {4}\n", reader[0],reader[1], reader[2], reader[3], reader[4]);
            }
            cnx.Close();
            return resultat;
        }

        public string ListeJoueursSponsor()
        {
            string resultat = "";
            MySqlCommand cmdSql = new MySqlCommand();
            cmdSql.Connection = cnx;
            cmdSql.CommandText = "select nomJoueur,nomSponsor from joueur inner join sponsor on joueur.noSponsor = sponsor.noSponsor order by nomSponsor";
            cmdSql.CommandType = System.Data.CommandType.Text;
            cnx.Open();
            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                resultat += String.Format("{0} : {1}\n", reader[0], reader[1]);
            }
            cnx.Close();
            return resultat;
        }
        public string ListeJoueursSponsorNation()
        {
            string resultat = "";
            MySqlCommand cmdSql = new MySqlCommand();
            cmdSql.Connection = cnx;
            cmdSql.CommandText = "select nomJoueur,nomSponsor, nation from joueur inner join sponsor on joueur.noSponsor = sponsor.noSponsor where nation=nationalite ";
            cmdSql.CommandType = System.Data.CommandType.Text;
            cnx.Open();
            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                resultat += String.Format("{0} : {1} : {2}\n", reader[0], reader[1], reader[2]);
            }
            cnx.Close();
            return resultat;
        }
        public string MontantSponsor()
        {
            string resultat = "";
            MySqlCommand cmdSql = new MySqlCommand();
            cmdSql.Connection = cnx;
            cmdSql.CommandText = "select sum(chiffreaffaires) from sponsor ";
            cmdSql.CommandType = System.Data.CommandType.Text;
            cnx.Open();
            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                resultat += String.Format("{0}\n", reader[0]);
            }
            cnx.Close();
            return resultat;
        }
        public void InsertJoueurs()
        {
            MySqlCommand cmdSql = new MySqlCommand();
            cmdSql.Connection = cnx;
            cmdSql.CommandText = "Insert into joueur (numLicence,nomjoueur,prenom,agejoueur,nation,noSponsor) values (13,'Nadal','Rafael',30,'ESP',8)";
            cmdSql.CommandType = System.Data.CommandType.Text;
            cnx.Open();
            cmdSql.ExecuteNonQuery();
            cnx.Close();
        }
        public void UpdateJoueurs()
        {
            MySqlCommand cmdSql = new MySqlCommand();
            cmdSql.Connection = cnx;
            cmdSql.CommandText = "Update joueur set ageJoueur = 27 where nomJoueur='Nadal'";
            cmdSql.CommandType = System.Data.CommandType.Text;
            cnx.Open();
            cmdSql.ExecuteNonQuery();
            cnx.Close();
        }
        public void DeleteJoueurs()
        {
            MySqlCommand cmdSql = new MySqlCommand();
            cmdSql.Connection = cnx;
            cmdSql.CommandText = "Delete from joueur where nomJoueur = 'Nadal'";
            cmdSql.CommandType = System.Data.CommandType.Text;
            cnx.Open();
            cmdSql.ExecuteNonQuery();
            cnx.Close();
        }

        public void CallCreationEmployer()
        {
            string nom = "El youssefi";
            string prenom = "Saoussene";
            string sexe = "F";
            int cadre = 1;
            decimal salaire = 10000000;
            int service = 2;
            MySqlCommand cmdSql = new MySqlCommand();
            cmdSql.Connection = cnx;
            cmdSql.CommandText = "nvlEmploye";
            cmdSql.CommandType = System.Data.CommandType.StoredProcedure;
            cmdSql.Parameters.Add(new MySqlParameter("nom", MySqlDbType.String));
            cmdSql.Parameters["nom"].Value = nom;
            cmdSql.Parameters.Add(new MySqlParameter("prenom", MySqlDbType.String));
            cmdSql.Parameters["prenom"].Value = prenom;
            cmdSql.Parameters.Add(new MySqlParameter("sexe", MySqlDbType.String));
            cmdSql.Parameters["sexe"].Value = sexe;
            cmdSql.Parameters.Add(new MySqlParameter("cadre", MySqlDbType.Int32));
            cmdSql.Parameters["cadre"].Value = cadre;
            cmdSql.Parameters.Add(new MySqlParameter("salaire", MySqlDbType.Decimal));
            cmdSql.Parameters["salaire"].Value = salaire;
            cmdSql.Parameters.Add(new MySqlParameter("service", MySqlDbType.Int32));
            cmdSql.Parameters["service"].Value = service;
            this.cnx.Open();
            cmdSql.ExecuteNonQuery();
            this.cnx.Close();
        }

        public string CallListeEmploye()
        {
            string result = "";
            MySqlCommand cmdSql = new MySqlCommand();
            cmdSql.Connection = cnx;
            cmdSql.CommandText = "selectDiplome";
            cmdSql.CommandType = System.Data.CommandType.StoredProcedure;

            this.cnx.Open();
            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                result += String.Format("{0}, {1}\n", reader[0], reader[1]);
            }
            this.cnx.Close();
            return result;
        }

        public string CallSalaireEmployer()
        {
            decimal BorneInferieur = 5000;
            decimal BorneSuperieur = 6000;
            string result = "";
            MySqlCommand cmdSql = new MySqlCommand();
            cmdSql.Connection = cnx;
            cmdSql.CommandText = "borneSalaire";
            cmdSql.CommandType = System.Data.CommandType.StoredProcedure;
            cmdSql.Parameters.Add(new MySqlParameter("BorneInferieur", MySqlDbType.Decimal));
            cmdSql.Parameters["BorneInferieur"].Value = BorneInferieur;
            cmdSql.Parameters.Add(new MySqlParameter("BorneSuperieur", MySqlDbType.Decimal));
            cmdSql.Parameters["BorneSuperieur"].Value = BorneSuperieur;

            this.cnx.Open(); MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                result += String.Format("{0}, {1}\n",
                    reader[0], reader[1]);
            }
            this.cnx.Close();
            return result;
        }

        public void CallMajBudget()
        {
            int num = 1;
            decimal valeur = 10;
            MySqlCommand cmdSql = new MySqlCommand(); 
            cmdSql.Connection = cnx;
            cmdSql.CommandText = "budget";
            cmdSql.CommandType = System.Data.CommandType.StoredProcedure;
            cmdSql.Parameters.Add(new MySqlParameter("num", MySqlDbType.Int32));
            cmdSql.Parameters["num"].Value = num;
            cmdSql.Parameters.Add(new MySqlParameter("valeur", MySqlDbType.Decimal));
            cmdSql.Parameters["valeur"].Value = valeur;

            this.cnx.Open();
            cmdSql.ExecuteNonQuery();
            this.cnx.Close();
        }

        public string CallAvgDiplomeSup()
        {
            string result = "";
            MySqlCommand cmdSql = new MySqlCommand();
            cmdSql.Connection = cnx;
            cmdSql.CommandText = "Moyenne";
            cmdSql.CommandType = System.Data.CommandType.StoredProcedure;

            this.cnx.Open();
            MySqlDataReader reader = cmdSql.ExecuteReader();
            while (reader.Read())
            {
                result += String.Format("{0}, {1}, {2}\n",
                    reader[0], reader[1], reader[2]);
            }
            this.cnx.Close();
        return result;
    }
}
