using System;
using System.Collections.Generic;
using System.Text;

namespace SupermarcheMetier
{
    public class Rayon
    {
        public int NumR { get; set; }
        public string NomR { get; set; }

        public Rayon(int unNumR, string unNomR)
        {
            NumR = unNumR;
            NomR = unNomR;
        }
    }
}
