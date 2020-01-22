using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblioteka
{
    [Serializable]
    public class Pracownik
    {
        public string Imie;
        public string Nazwisko;
        public long PESEL;
        public string Login;
        public string Haslo;

        public Pracownik()
        {

        }
        public Pracownik(string imie, string nazwisko, long pesel, string login, string haslo)
        {
            this.Imie = imie;
            this.Nazwisko = nazwisko;
            this.PESEL = pesel;
            this.Login = login;
            this.Haslo = haslo;
        }

        public virtual void Dane()
        {
            Console.WriteLine("       Imię: " + this.Imie);
            Console.WriteLine("       Nazwisko: " + this.Nazwisko);
        }
    }
}
