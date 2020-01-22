using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    [Serializable]
    public class Pielegniarka : Pracownik
    {
        // List<int> listaDyzurowP = new List<int>();
        public string typ = "piel";

        public Pielegniarka()
        {

        }
        public Pielegniarka(string imie, string nazwisko, long pesel, string login, string haslo)
            :base(imie, nazwisko, pesel, login, haslo)
        {

        }

        public override void Dane()
        {
            base.Dane();
            Console.WriteLine("       Stanowisko: Pielęgniarka");
        }
    }
}
