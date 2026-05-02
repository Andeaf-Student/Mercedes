using System;
using System.Collections.Generic;
using System.IO;
using LibrarieModele;

namespace NivelStocareDate
{
    public class AdministrareMasiniFisierText
    {
        private string numeFisier;

        public AdministrareMasiniFisierText(string numeFisier)
        {
            this.numeFisier = numeFisier;
            Stream stream = File.Open(numeFisier, FileMode.OpenOrCreate);
            stream.Close();
        }

        public void AddMasina(Masina masina)
        {
            using (StreamWriter sw = new StreamWriter(numeFisier, true))
            {
                sw.WriteLine(masina.ConversieLaSirPentruFisier());
            }
        }

        public List<Masina> GetMasini()
        {
            List<Masina> masini = new List<Masina>();
            using (StreamReader sr = new StreamReader(numeFisier))
            {
                string linie;
                while ((linie = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrWhiteSpace(linie)) continue;
                    masini.Add(new Masina(linie));
                }
            }
            return masini;
        }
    }
}