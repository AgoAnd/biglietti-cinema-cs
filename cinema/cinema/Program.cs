using System;
using System.Collections.Generic;

namespace esBiglietto
{
    enum TipoBiglietto
    {
        Intero,
        Ridotto,
        VIP
    }

    enum StatoPrenotazione
    {
        Prenotato,
        Pagato,
        Annullato
    }

    struct Biglietto
    {
        public int id;
        public int numeroDiPosto;
        public TipoBiglietto tipo;
        public StatoPrenotazione stato;
        public DateTime data;

        public Biglietto(int id, int numeroDiPosto, TipoBiglietto tipo, DateTime data)
        {
            this.id = id;
            this.numeroDiPosto = numeroDiPosto;
            this.tipo = tipo;
            this.stato = StatoPrenotazione.Prenotato;
            this.data = data;
        }

        public string GetInfo()
        {
            return "Biglietto " + id +
                   ": Posto = " + numeroDiPosto +
                   ", Tipologia = " + tipo +
                   ", Stato = " + stato +
                   ", Data = " + data;
        }

        public void CambiaStato(StatoPrenotazione nuovoStato)
        {
            this.stato = nuovoStato;
        }
    }

    class Program
    {
        static List<Biglietto> memory = new List<Biglietto>();
        static int numberOfTickets = 1;

        static void Main(string[] args)
        {
            int action;
            bool loop = true;

            while (loop)
            {
                Console.WriteLine();
                Console.WriteLine("1. Crea un biglietto");
                Console.WriteLine("2. Elimina un biglietto");
                Console.WriteLine("3. Modifica un biglietto");
                Console.WriteLine("4. Visualizza i biglietti");
                Console.WriteLine("5. Esci");
                Console.WriteLine();
                Console.WriteLine("Inserisci azione:");

                bool control = int.TryParse(Console.ReadLine(), out action);

                while (!control || action < 1 || action > 5)
                {
                    Console.WriteLine("Numero non valido, reinserire (1-5):");
                    control = int.TryParse(Console.ReadLine(), out action);
                }

                switch (action)
                {
                    case 1:
                        Biglietto ticket = CreaBiglietto(numberOfTickets);
                        memory.Add(ticket);
                        numberOfTickets++;
                        break;

                    case 2:
                        EliminaBiglietto();
                        break;

                    case 3:
                        ModificaBiglietto();
                        break;

                    case 4:
                        VisualizzaBiglietti();
                        break;

                    case 5:
                        loop = false;
                        break;
                }
            }

            Console.WriteLine("Arrivederci!");
        }

        static Biglietto CreaBiglietto(int number)
        {
            int posto;
            int tipologia;
            bool control;

            Console.WriteLine("Inserire numero posto:");
            control = int.TryParse(Console.ReadLine(), out posto);

            while (!control || posto <= 0)
            {
                Console.WriteLine("Numero non valido, reinserire:");
                control = int.TryParse(Console.ReadLine(), out posto);
            }

            Console.WriteLine("Tipologia (0=Intero, 1=Ridotto, 2=VIP):");
            control = int.TryParse(Console.ReadLine(), out tipologia);

            while (!control || tipologia < 0 || tipologia > 2)
            {
                Console.WriteLine("Tipologia non valida, reinserire (0-2):");
                control = int.TryParse(Console.ReadLine(), out tipologia);
            }

            Console.WriteLine("Biglietto creato!");

            return new Biglietto(number, posto, (TipoBiglietto)tipologia, DateTime.Now);
        }

        static void EliminaBiglietto()
        {
            if (memory.Count == 0)
            {
                Console.WriteLine("Nessun biglietto da eliminare.");
                return;
            }

            int id;
            bool control;

            Console.WriteLine("Inserire ID del biglietto da eliminare:");
            control = int.TryParse(Console.ReadLine(), out id);

            while (!control)
            {
                Console.WriteLine("Numero non valido, reinserire:");
                control = int.TryParse(Console.ReadLine(), out id);
            }

            bool trovato = false;

            for (int i = 0; i < memory.Count; i++)
            {
                if (memory[i].id == id)
                {
                    memory.RemoveAt(i);
                    trovato = true;
                    Console.WriteLine("Biglietto eliminato.");
                    break;
                }
            }

            if (!trovato)
            {
                Console.WriteLine("Biglietto non trovato.");
            }
        }

        static void ModificaBiglietto()
        {
            if (memory.Count == 0)
            {
                Console.WriteLine("Nessun biglietto da modificare.");
                return;
            }

            int id;
            int stato;
            bool control;

            Console.WriteLine("Inserire ID del biglietto da modificare:");
            control = int.TryParse(Console.ReadLine(), out id);

            while (!control)
            {
                Console.WriteLine("Numero non valido, reinserire:");
                control = int.TryParse(Console.ReadLine(), out id);
            }

            bool trovato = false;

            for (int i = 0; i < memory.Count; i++)
            {
                if (memory[i].id == id)
                {
                    Console.WriteLine("Nuovo stato (0=Prenotato,1=Pagato,2=Annullato):");
                    control = int.TryParse(Console.ReadLine(), out stato);

                    while (!control || stato < 0 || stato > 2)
                    {
                        Console.WriteLine("Stato non valido, reinserire (0-2):");
                        control = int.TryParse(Console.ReadLine(), out stato);
                    }

                    Biglietto temp = memory[i];
                    temp.CambiaStato((StatoPrenotazione)stato);
                    memory[i] = temp;

                    Console.WriteLine("Stato modificato.");
                    trovato = true;
                    break;
                }
            }

            if (!trovato)
            {
                Console.WriteLine("Biglietto non trovato.");
            }
        }

        static void VisualizzaBiglietti()
        {
            if (memory.Count == 0)
            {
                Console.WriteLine("Nessun biglietto presente.");
            }
            else
            {
                for (int i = 0; i < memory.Count; i++)
                {
                    Console.WriteLine(memory[i].GetInfo());
                }
            }
        }
    }
}

