using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    [Serializable]
    public class Lekarz : Pracownik
    {
        public string Specjalizacja;
        public int NumerPWZ;
        // List<string> listaDyzurowL = new List<string>();
        public string typ = "lek";

        public Lekarz()
        {

        }
        public Lekarz(string imie, string nazwisko, long pesel, string login, string haslo, string specjalizacja, int numerPWZ)
            : base(imie, nazwisko, pesel, login, haslo)
        {
            this.Specjalizacja = specjalizacja;
            this.NumerPWZ = numerPWZ;
        }

        public override void Dane()
        {
            base.Dane();
            Console.WriteLine("       Stanowisko: Lekarz");
            Console.WriteLine("       Specjalizacja: " + this.Specjalizacja);
        }
    }
}
