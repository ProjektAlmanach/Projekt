using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using Biblioteka;
using System.Runtime.Serialization.Formatters.Binary;

namespace Szpital
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Pracownik> ListaPrac = new List<Pracownik>();
            Administrator Admin1 = new Administrator("Eryk", "Perliński", 95122500615, "admin", "admin");
            ListaPrac.Add(Admin1);
            BinaryFormatter binFormattter = new BinaryFormatter();
            try
            {
                using (Stream fStream =
            new FileStream("mojedane.dat", FileMode.Open, FileAccess.Read))
                {
                    ListaPrac = (List<Pracownik>)binFormattter.Deserialize(fStream);
                }
            }
            catch (System.IO.FileNotFoundException) { Console.WriteLine("Nie istnieje jeszcze żadna lista pracowników do odczytu."); }

            Console.WriteLine("                                            ");
            Console.WriteLine("                                            ");
            Console.WriteLine("       SYSTEM ADMINISTRCYJNY SZPITALA       ");
            Console.WriteLine("                                            ");
            Console.WriteLine("                LOGOWANE                    ");
            Console.WriteLine("                                            ");
            start: Console.Write("       LOGIN:  ");
            string login = Console.ReadLine();
            Pracownik Znaleziony = ListaPrac.Find(Element => Element.Login == login);
            try
            {
                if (login == Znaleziony.Login)
                {
                    Console.Write("       HASŁO:  ");
                    string haslo = Console.ReadLine();
                    if (Znaleziony.Haslo == haslo)
                    {
                        Console.WriteLine("       Zalogowano pomyślnie.");
                        Console.WriteLine("");
                        if (Znaleziony is Administrator)
                        {
                            start2:
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("--------------------------------------------");
                            Console.WriteLine("");
                            Console.WriteLine("       Zalogowano jako Administrator");
                            Console.WriteLine("");
                            Console.WriteLine("       Menu wyboru działania: ");
                            Console.WriteLine("       1. Wyświetl listę pracowników ");
                            Console.WriteLine("       2. Edytuj dane pracownika");
                            Console.WriteLine("       3. Dodaj nowego pracownika");
                            Console.WriteLine("       4. Wyloguj");
                            Console.WriteLine("       0. Zamknij program");
                            Console.WriteLine("");
                            Console.WriteLine("--------------------------------------------");
                            Console.Write("       Wybierz opcję: ");
                            int.TryParse(Console.ReadLine(), out int wybor);
                            switch (wybor)
                            {
                                case 0:
                                    {
                                        using (Stream fStream =
                                        new FileStream("mojedane.dat", FileMode.Create, FileAccess.Write))
                                        {
                                            binFormattter.Serialize(fStream, ListaPrac);
                                        }
                                        Environment.Exit(0);
                                    }
                                    break;
                                case 1:
                                    {
                                        Console.WriteLine("");
                                        Console.WriteLine("");
                                        Console.WriteLine("       Lista pracwników szpitala:");
                                        Console.WriteLine("       ");
                                        int i = 0;
                                        foreach (Pracownik p in ListaPrac)
                                        {
                                            i++;
                                            Console.WriteLine("");
                                            Console.WriteLine("       Pracownik " + i);
                                            Console.WriteLine("       ");
                                            p.Dane();
                                        }
                                    }
                                    goto start2;
                                    break;
                                case 2:
                                    {
                                        Console.Write("       Podaj numer pracownika z listy, którego dane chcesz edytować: ");
                                        int.TryParse(Console.ReadLine(), out int wybor2);
                                        Console.Write("       Edycja imienia: ");
                                        string zmiana = Console.ReadLine();
                                        ListaPrac[wybor2 - 1].Imie = zmiana;
                                        Console.Write("       Edycja nazwiska: ");
                                        zmiana = Console.ReadLine();
                                        ListaPrac[wybor2 - 1].Nazwisko = zmiana;
                                        Console.Write("       Edycja numeru PESEL: ");
                                        int.TryParse(Console.ReadLine(), out int zmiana2); ;
                                        ListaPrac[wybor2 - 1].PESEL = zmiana2;
                                    }
                                    goto start2;
                                    break;
                                case 3:
                                    {
                                        start3: Console.WriteLine("       Wybierz jaki typ użytkownika chcesz utworzyć: ");
                                        Console.WriteLine("       1. Pielęgniarka");
                                        Console.WriteLine("       2. Lekarz");
                                        Console.WriteLine("       3. Administrator");
                                        Console.WriteLine("       4. Cofnij");
                                        Console.WriteLine("       0. ZAmknij program");
                                        int.TryParse(Console.ReadLine(), out int wybor3);
                                        switch (wybor3)
                                        {
                                            case 0:
                                                {
                                                    using (Stream fStream =
                                                     new FileStream("mojedane.dat", FileMode.Create, FileAccess.Write))
                                                    {
                                                        binFormattter.Serialize(fStream, ListaPrac);
                                                    }
                                                    Environment.Exit(0);
                                                }
                                                break;
                                            case 1:
                                                {
                                                    Console.WriteLine("       Podaj imię nowego pracownika: ");
                                                    string imie2 = Console.ReadLine();
                                                    Console.WriteLine("       Podaj nazwisko nowego pracownika: ");
                                                    string nazwisko2 = Console.ReadLine();
                                                    Console.WriteLine("       Podaj nazwisko PESEL pracownika: ");
                                                    long.TryParse(Console.ReadLine(), out long pesel2);
                                                    Console.WriteLine("       Podaj login nowego pracownika: ");
                                                    string login2 = Console.ReadLine();
                                                    Console.WriteLine("       Podaj hasło nowego pracownika: ");
                                                    string haslo2 = Console.ReadLine();
                                                    ListaPrac.Add(new Pielegniarka(imie2, nazwisko2, pesel2, login2, haslo2));
                                                }
                                                goto start3;
                                                break;
                                            case 2:
                                                {
                                                    Console.WriteLine("       Podaj imię nowego pracownika: ");
                                                    string imie2 = Console.ReadLine();
                                                    Console.WriteLine("       Podaj nazwisko nowego pracownika: ");
                                                    string nazwisko2 = Console.ReadLine();
                                                    Console.WriteLine("       Podaj nazwisko PESEL pracownika: ");
                                                    long.TryParse(Console.ReadLine(), out long pesel2);
                                                    Console.WriteLine("       Podaj login nowego pracownika: ");
                                                    string login2 = Console.ReadLine();
                                                    Console.WriteLine("       Podaj hasło nowego pracownika: ");
                                                    string haslo2 = Console.ReadLine();
                                                    Console.WriteLine("       Podaj specjalizację nowego pracownika: ");
                                                    string specjalizacja2 = Console.ReadLine();
                                                    Console.WriteLine("       Podaj specjalizację numr PWZ pracownika: ");
                                                    int.TryParse(Console.ReadLine(), out int numerPWZ2);
                                                    ListaPrac.Add(new Lekarz(imie2, nazwisko2, pesel2, login2, haslo2, specjalizacja2, numerPWZ2));
                                                }
                                                goto start3;
                                                break;
                                            case 3:
                                                {
                                                    Console.WriteLine("       Podaj imię nowego pracownika: ");
                                                    string imie2 = Console.ReadLine();
                                                    Console.WriteLine("       Podaj nazwisko nowego pracownika: ");
                                                    string nazwisko2 = Console.ReadLine();
                                                    Console.WriteLine("       Podaj nazwisko PESEL pracownika: ");
                                                    long.TryParse(Console.ReadLine(), out long pesel2);
                                                    Console.WriteLine("       Podaj login nowego pracownika: ");
                                                    string login2 = Console.ReadLine();
                                                    Console.WriteLine("       Podaj hasło nowego pracownika: ");
                                                    string haslo2 = Console.ReadLine();
                                                    ListaPrac.Add(new Administrator(imie2, nazwisko2, pesel2, login2, haslo2));
                                                }
                                                goto start3;
                                                break;
                                            case 4:
                                                {
                                                    goto start2;
                                                }
                                                break;
                                            default:
                                                {
                                                    Console.WriteLine("       Wprowadzono błędną opcję.");
                                                    goto start3;
                                                }
                                                break;

                                        }
                                    }
                                    goto start2;
                                    break;
                                case 4:
                                    {

                                    }
                                    break;
                                default:
                                    Console.WriteLine("       Wprowadzono błędną opcję."); goto start2;
                                    break;
                            }
                        }
                        else
                        {
                            start4:
                            Console.WriteLine("");
                            Console.WriteLine("");
                            Console.WriteLine("--------------------------------------------");
                            Console.WriteLine("");
                            Console.WriteLine("       Zalogowano jak Użytkownik");
                            Console.WriteLine("");
                            Console.WriteLine("       Menu wyboru działania: ");
                            Console.WriteLine("       1. Wyświetl listę pracowników ");
                            Console.WriteLine("       2. Wyloguj");
                            Console.WriteLine("       0. Zamknij program");
                            Console.WriteLine("");
                            Console.WriteLine("--------------------------------------------");
                            Console.Write("       Wybierz opcję: ");
                            int.TryParse(Console.ReadLine(), out int wybor);
                            switch (wybor)
                            {
                                case 0:
                                    {
                                        using (Stream fStream =
                                        new FileStream("mojedane.dat", FileMode.Create, FileAccess.Write))
                                        {
                                            binFormattter.Serialize(fStream, ListaPrac);
                                        }
                                        Environment.Exit(0);
                                    }
                                    break;
                                case 1:
                                    {
                                        Console.WriteLine("       Lista pracwników szpitala:");
                                        Console.WriteLine("       ");
                                        int i = 0;
                                        foreach (Pracownik p in ListaPrac)
                                        {
                                            if (p is Administrator)
                                            {

                                            }
                                            else
                                            {
                                                i++;
                                                Console.WriteLine("");
                                                Console.WriteLine("       Pracownik " + i);
                                                Console.WriteLine("       ");
                                                p.Dane();
                                            }
                                        }
                                    }
                                    goto start4;
                                    break;
                                case 2:
                                    {
                                        goto start;
                                    }
                                    break;
                                default:
                                    Console.WriteLine("       Wprowadzono błędną opcję."); goto start4;
                                    break;
                            }
                        }
                    }
                    else Console.WriteLine("       Błąd logowania. Podane hasło nie pasuje do loginu."); goto start;
                }
            }
            catch (NullReferenceException) { Console.WriteLine("       Użytkownik o podanym loginie nie istnieje w systemie."); goto start; }

            Console.ReadKey();

        }
    }
}
