using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarcheMetier
{
    public class GestionnaireBdd
    {
        public MySqlConnection cnx { get; set; }
        public MySqlCommand cmd { get; set; }
        public MySqlDataReader dr { get; set; }

        // Attention à enlever ou changer le Port !
        public GestionnaireBdd()
        {
            string chaine = "Server=localhost;Port=3308;Database=supermarche;Uid=root;Pwd=";
            cnx = new MySqlConnection(chaine);
            cnx.Open();
        }

        public List<Secteur> GetAllSecteurs()
        {
            List<Secteur> mesSecteurs = new List<Secteur>();
            cmd = new MySqlCommand("select nums, noms from secteur", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Secteur unSecteur = new Secteur(Convert.ToInt16(dr[0].ToString()), dr[1].ToString());
                mesSecteurs.Add(unSecteur);
            }
            dr.Close();
            return mesSecteurs;
        }
        public List<Employe> GetAllEmploye()
        {
            List<Employe> mesEmployes = new List<Employe>();
            cmd = new MySqlCommand("select nume, prenome from employe", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Employe unEmploye = new Employe(Convert.ToInt16(dr[0].ToString()), dr[1].ToString());
                mesEmployes.Add(unEmploye);
            }
            dr.Close();
            return mesEmployes;
        }
        public List<Rayon> GetAllRayons()
        {
            List<Rayon> mesRayons = new List<Rayon>();
            cmd = new MySqlCommand("select numr, nomr from rayon", cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Rayon unRayon = new Rayon(Convert.ToInt16(dr[0].ToString()), dr[1].ToString());
                mesRayons.Add(unRayon);
            }
            dr.Close();
            return mesRayons;
        }
        public List<Rayon> GetRayonParSecteur(int numS)
        {
            List<Rayon> mesRayons = new List<Rayon>();
            cmd = new MySqlCommand("select numr, nomr from rayon where numsecteur = " + numS, cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                Rayon uneCateg = new Rayon(Convert.ToInt16(dr[0].ToString()), dr[1].ToString());
                mesRayons.Add(uneCateg);
            }
            dr.Close();
            return mesRayons;
        }
        public List<Travailler> GetTravaillerParEmploye(int unNumE)
        {
            List<Travailler> mesTravaux = new List<Travailler>();
            cmd = new MySqlCommand("select codeE, codeR, nomR, date, temps from rayon join travailler on rayon.numR = travailler.codeR join employe on travailler.codeE = employe.numE where numE = " + unNumE, cnx);
            dr = cmd.ExecuteReader();
            while (dr.Read())
            { // Seulement la date est récupérée (Substring) car l'heure est toujours 00:00:00
                Travailler unTravail = new Travailler(Convert.ToInt16(dr[0].ToString()), Convert.ToInt16(dr[1].ToString()), dr[2].ToString(), dr[3].ToString().Substring(0, 10), Convert.ToInt16(dr[4].ToString()));
                mesTravaux.Add(unTravail);
            }
            dr.Close();
            return mesTravaux;
        }
        public int GetLastNumEmploye()
        {
            int max;
            cmd = new MySqlCommand("select max(nume) from employe", cnx);
            dr = cmd.ExecuteReader();
            dr.Read();
            max = Convert.ToInt16(dr[0].ToString()) + 1;
            dr.Close();
            return max;
        }
        public void InsererEmploye(int unNum, string unNom)
        {
            cmd = new MySqlCommand("insert into employe values (" + unNum + ",'" + unNom + "')", cnx);
            cmd.ExecuteNonQuery();
        }
        public void InsererTravaillerPourEmploye(int unCodeE, int unCodeR, string uneDate, int unTemps)
        {
            cmd = new MySqlCommand("insert into travailler values (" + unCodeE + "," + unCodeR + ",'" + uneDate + "'," + unTemps + ")", cnx);
            cmd.ExecuteNonQuery();
        }
    }
}
