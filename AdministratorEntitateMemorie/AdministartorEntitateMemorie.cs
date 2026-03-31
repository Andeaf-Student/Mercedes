using System;
using System.Collections.Generic;
using System.Linq;

namespace AdministratorEntitateMemorie
{
    public class AdministratorMasini
    {
        private List<Masina> masini = new List<Masina>();

        
        public void AdaugaMasina(Masina m)
        {
            masini.Add(m);
        }


        public List<Masina> MasiniMaiScumpeDe(double pretMinim)
        {
            return masini.Where(m => m.Pret > pretMinim).ToList();
        }
    }
}