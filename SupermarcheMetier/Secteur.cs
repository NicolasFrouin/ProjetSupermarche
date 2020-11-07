using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarcheMetier
{
    public class Secteur
    {
        public int NumS { get; set; }
        public string NomS { get; set; }

        public Secteur(int unNumS, string unNomS)
        {
            NumS = unNumS;
            NomS = unNomS;
        }
    }
}
