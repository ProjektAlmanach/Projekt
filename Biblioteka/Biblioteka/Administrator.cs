using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    [Serializable]
    public class Administrator : Pracownik
    {
        public string typ = "admin";

        public Administrator()
        {

        }
        public Administrator(string imie, string nazwisko, long pesel, string login, string haslo)
           : base(imie, nazwisko, pesel, login, haslo)
        {

        }

        public override void Dane()
        {
            base.Dane();
            Console.WriteLine("       Stanowisko: Administrator");
        }
    }
}
