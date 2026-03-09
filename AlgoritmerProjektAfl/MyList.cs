using System;
using System.Collections.Generic;
using System.Collections;
using System.Text;

namespace AlgoritmerProjektAfl
{
    // Den generiske listeklasse "MyList<T>, (jeg tilføjer IEnumerable for at få testen til at fungere)
    public class MyList<T> : IEnumerable<T>
    {
        // Array der gemmer elementerne i listen
        private List<T> items; new List<T>

          public void Add(T item)
        {
            items.Add(item);
        }

        public IEnumerator<T> GetEnumerator()
        {
            return items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }


        // Variabel der holder styr på antal elementer i listen
        private int count;

        //Property der giver adgang til Count
        public int Count { get { return count; } }

        // Tæller antal sammenligninger i sorteringsalgoritmer
        public int comparisonCount;

        // Konstruktor der opretter listen med en startkapacitet sat på 150, så jeg ikke løber tør for plads, når jeg tilføjer elementer
        public MyList(int capacity = 150)
        {
            // Indsætter elementet på næste ledige plads
            items = new T[capacity];
            // Øger antallet af elementer i listen
            count = 0;
        }
        // Metode til at tilføje et element til listen
        public void Add(T item)
        {
            // Indsætter elementet på næste ledige plads
            this.items[Count] = item;
            // Øger antallet af elementer i listen
            count++;

        }
        // Index der gør det muligt at tilgå elementer med indeks

        public T this[int index]
        {
            get
            {
                // Tjekker om indekset er gyldigt, og hvis ikke, kaster en undtagelse
                if (index < 0 || index >= count)
                {
                    // Fejl hvis indekset er ugyldigt
                    throw new IndexOutOfRangeException();
                }
                // Returnerer elementet på den ønskede position
                return items[index];
            }
            set
            {
                // Tjekker igen om indekset er gyldigt
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException();
                }
                // Opdaterer værdien på den valgte position
                items[index] = value;

            }

        }

        // Insertin Sort algoritme
        public void InsertionSort()
        {
            // Nulstiller tælleren for sammenligninger
            comparisonCount = 0;

            // Starter fra element nr. 1
            for (int i = 1; i < Count; i++)
            {
                // Gemmer det aktuelle element der skal indsættes
                T key = items[i];
                // Starter sammenligning med elementet før
                int j = i - 1;
                // Flytter elementer der er større end key, til en position en plads til højre
                while (j >= 0)
                {
                    // Tæller en sammenligning
                    comparisonCount++;
                    if (Comparer<T>.Default.Compare(items[j], key) > 0)
                    {
                        //Flytter elementet en plads til højre
                        items[j + 1] = items[j];

                        // Går et skridt tilbage for at sammenligne med det næste element
                        j--;
                    }
                    else
                    {
                        // Stopper hvis elementet står korrekt
                        break;

                    }
                }
                // Indsætter key på den korrekte position
                items[j + 1] = key;
            }
        }
        // Bubble Sort algoritme
        public void BubbleSort()
        {
            // Nulstiller tælleren for sammenligninger
            comparisonCount = 0;
            // Ydre løkke styrer hvor mange gennemløb der skal foretages, og stopper når alle elementer er sorteret
            for (int i = 0; i < Count - 1; i++)
            {
                // Indre løkke sammenligner naboelementer og bytter dem hvis de er i forkert rækkefølge
                for (int j = 0; j < Count - i - 1; j++)
                {
                    // Sammenligner to naboelementer
                    comparisonCount++;
                    if (Comparer<T>.Default.Compare(items[j], items[j + 1]) > 0)
                    {
                        // Bytter elementerne[j] og [j + 1] hvis de står i forkert rækkefølge
                        T temp = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = temp;
                    }
                }
            }
        }
    }
}
