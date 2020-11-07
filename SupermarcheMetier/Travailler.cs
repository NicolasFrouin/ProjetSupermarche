using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarcheMetier
{
    public class Travailler
    {
        public int CodeE { get; set; }
        public int CodeR { get; set; }
        public string NomR { get; set; }
        public string date { get; set; }
        public int Temps { get; set; }

        public Travailler(int unCodeE, int unCodeR, string unNomR, string uneDate, int unTemps)
        {
            CodeE = unCodeE;
            CodeR = unCodeR;
            NomR = unNomR;
            date = uneDate;
            Temps = unTemps;
        }
    }
}
