using System;
using System.Collections.Generic;
using System.Text;

namespace WzorceProjektowe
{
    // Nie zmieniaj poniższej klasy
    public class Klient
    {
        public string Imie;
        public string Nazwisko;
        public long PESEL;
        public bool SplacaTerminowo;
        public double MiesiecznyDochod;
        public double SrodkiNaKoncie;

        public Klient(string imie, string nazwisko, long pesel, bool splacaTerminowo, double miesiecznyDochod, double srodkiNaKoncie)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            PESEL = pesel;
            SplacaTerminowo = splacaTerminowo;
            MiesiecznyDochod = miesiecznyDochod;
            SrodkiNaKoncie = srodkiNaKoncie;
        }
    }
    // Nie zmieniaj poniższej klasy
    public class DataBase
    {
        private static DataBase DB = null;
        private Dictionary<long, Klient> klienci = new Dictionary<long, Klient>();
        DataBase()
        {
            klienci[8111038251] = new Klient("Harry", "Potter", 8111038251, true, 95421.2, 10025009.7);
            klienci[5012475774] = new Klient("Mieczysław", "Psikuta", 5012475774, false, 421.2, 39.3);
            klienci[4801356445] = new Klient("Zbigniew", "Kolegazwojska", 4801356445, true, 1521.2, 5071.4);
            klienci[5091425527] = new Klient("Robert", "Martin", 5091425527, true, 10421.2, 59009.01);
            klienci[7071519433] = new Klient("Genowefa", "Wiaderna", 7071519433, true, 8321.2, 5085.69);
        }
        public static DataBase GetDB()
        {
            if (DB == null)
                DB = new DataBase();
            return DB;
        }
        public Klient GetClientByPESEL(long pesel)
        {
            return klienci[pesel];
        }
    }
    public class Dochody
    {
        public bool DochodyWystarczajace(long PESEL, double miesiecznaRata)
        {
            // TODO
            Klient klient = DataBase.GetDB().GetClientByPESEL(PESEL);

            if (miesiecznaRata < klient.MiesiecznyDochod / 2)
                return true;

            return false;
        }
    }
    public class Kredyty
    {
        public bool SplacaTerminowo(long PESEL)
        {
            // TODO
            Klient klient = DataBase.GetDB().GetClientByPESEL(PESEL);

            if (klient.SplacaTerminowo)
                return true;

            return false;
        }
    }
    public class UdzielanieKredytu
    {
        public bool CzyWkladWlasnyTo10Procent(double wnioskowanaKwota, double wkladWlasny)
        {
            // TODO
            if(wkladWlasny >= wnioskowanaKwota*0.1)
                return true;

            return false;
        }

    }
    public class Fasada
    {
        Dochody dochody;
        Kredyty kredyty;
        UdzielanieKredytu udzielanieKredytu;
        public Fasada()
        {
            this.dochody = new Dochody();
            this.kredyty = new Kredyty();
            this.udzielanieKredytu = new UdzielanieKredytu();
        }
        public void WnioskowanieOKredyt(long PESEL, double wnioskowanaKwota, double wkladWlasny, int ileMiesiecy)
        {
            // TODO

            if (dochody.DochodyWystarczajace(PESEL, wnioskowanaKwota / ileMiesiecy) &&
                kredyty.SplacaTerminowo(PESEL) &&
                udzielanieKredytu.CzyWkladWlasnyTo10Procent(wnioskowanaKwota, wkladWlasny))
                Console.WriteLine($"Użykownik o numerze PESEL {PESEL} otrzyma kredyt");
            else
                Console.WriteLine($"Użykownik o numerze PESEL {PESEL} nie otrzyma kredytu");
        }
    }
    // Nie zmieniaj poniższej klasy
    public class Program
    {
        static void Main(string[] args)
        {
            Fasada fasada = new Fasada();
            fasada.WnioskowanieOKredyt(8111038251, 20000, 3000, 12);
            fasada.WnioskowanieOKredyt(5012475774, 20000, 1000, 12);
            fasada.WnioskowanieOKredyt(4801356445, 20000, 3000, 12);
            fasada.WnioskowanieOKredyt(5091425527, 20000, 1000, 12);
            fasada.WnioskowanieOKredyt(7071519433, 20000, 3000, 12);
        }
    }
}