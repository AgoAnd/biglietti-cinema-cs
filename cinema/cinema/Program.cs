using System;
using System.Collections.Generic;

enum TipoBiglietto
{
    standard,
    ridotto,
    vip
}

enum StatoPrenotazione
{
    prenotato,
    pagato,
    annullato
}

struct Biglietto
{
    public int numeroDiPosto;
    public TipoBiglietto tipo;
    public StatoPrenotazione statoPrenotazione;
    public DateTime ddata;
}

class Program
{
    static List<Biglietto> biglietti = new List<Biglietto>();

    static void Main()
    {
        char r;
        int p = 2;
        do
        {
            int s;

            Console.WriteLine("Inserisci il numero dell'operazione:");
            Console.WriteLine("1) crea un biglietto");
            Console.WriteLine("2) pagare un biglietto");
            Console.WriteLine("3) annullare un biglietto");
            Console.WriteLine("4) visualizzare biglietti");

            bool v = int.TryParse(Console.ReadLine(), out s);
            while (!v || s < 1 || s > 4)
            {
                Console.WriteLine("errore");
                v = int.TryParse(Console.ReadLine(), out s);
            }

            // 1) crea biglietto
            if (s == 1)
            {
                Biglietto b = new Biglietto();

                Console.Write("Inserisci numero di posto: ");
                bool v1 = int.TryParse(Console.ReadLine(), out b.numeroDiPosto);
                while (!v1 || b.numeroDiPosto <= 0)
                {
                    Console.WriteLine("errore");
                    v1 = int.TryParse(Console.ReadLine(), out b.numeroDiPosto);
                }

                Console.WriteLine("Tipo biglietto:");
                Console.WriteLine("0) standard");
                Console.WriteLine("1) ridotto");
                Console.WriteLine("2) vip");

                int t;
                bool v2 = int.TryParse(Console.ReadLine(), out t);
                while (!v2 || t < 0 || t > 2)
                {
                    Console.WriteLine("errore");
                    v2 = int.TryParse(Console.ReadLine(), out t);
                }

                b.tipo = (TipoBiglietto)t;
                b.statoPrenotazione = StatoPrenotazione.prenotato;
                b.ddata = DateTime.Now;

                biglietti.Add(b);
                Console.WriteLine("Biglietto creato");
            }

            // 2) pagare biglietto
            if (s == 2)
            {
                if (biglietti.Count == 0)
                {
                    Console.WriteLine("Nessun biglietto disponibile");
                }
                else
                {
                    for (int i = 0; i < biglietti.Count; i++)
                    {
                        Biglietto temp = biglietti[i];
                        Console.WriteLine(i + ") Posto: " + temp.numeroDiPosto + " Stato: " + temp.statoPrenotazione);
                    }

                    Console.Write("Scegli indice biglietto: ");
                    int iScelta;
                    bool v3 = int.TryParse(Console.ReadLine(), out iScelta);
                    while (!v3 || iScelta < 0 || iScelta >= biglietti.Count)
                    {
                        Console.WriteLine("errore");
                        v3 = int.TryParse(Console.ReadLine(), out iScelta);
                    }

                    Biglietto b = biglietti[iScelta];
                    b.statoPrenotazione = StatoPrenotazione.pagato;
                    biglietti[iScelta] = b;

                    Console.WriteLine("Biglietto pagato");
                }
            }

            // 3) annullare biglietto
            if (s == 3)
            {
                if (biglietti.Count == 0)
                {
                    Console.WriteLine("Nessun biglietto disponibile");
                }
                else
                {
                    for (int i = 0; i < biglietti.Count; i++)
                    {
                        Biglietto temp = biglietti[i];
                        Console.WriteLine(i + ") Posto: " + temp.numeroDiPosto + " Stato: " + temp.statoPrenotazione);
                    }

                    Console.Write("Scegli indice biglietto: ");
                    int iScelta;
                    bool v4 = int.TryParse(Console.ReadLine(), out iScelta);
                    while (!v4 || iScelta < 0 || iScelta >= biglietti.Count)
                    {
                        Console.WriteLine("errore");
                        v4 = int.TryParse(Console.ReadLine(), out iScelta);
                    }

                    Biglietto b = biglietti[iScelta];
                    b.statoPrenotazione = StatoPrenotazione.annullato;
                    biglietti[iScelta] = b;

                    Console.WriteLine("Biglietto annullato");
                }
            }

            // 4) visualizzare biglietti
            if (s == 4)
            {
                if (biglietti.Count == 0)
                {
                    Console.WriteLine("Nessun biglietto creato");
                }
                else
                {
                    for (int i = 0; i < biglietti.Count; i++)
                    {
                        Biglietto temp = biglietti[i];
                        Console.WriteLine(i + ") Posto: " + temp.numeroDiPosto +
                                          " Tipo: " + temp.tipo +
                                          " Stato: " + temp.statoPrenotazione +
                                          " Data: " + temp.ddata.ToShortDateString());
                    }
                }
            }


         
        } while (p != 0);
    }
}
