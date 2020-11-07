using System;

namespace SupermarcheMetier
{
    public class Employe
    {
        public int NumE { get; set; }
        public string PrenomE { get; set; }

        public Employe(int unNum, string unPrenom)
        {
            NumE = unNum;
            PrenomE = unPrenom;
        }
    }
}
