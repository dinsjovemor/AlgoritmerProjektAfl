using System;
using System.Collections.Generic;
using System.Text;

namespace AlgoritmerProjektAfl
{
    // Den generiske listeklasse "MyList<T>
    public class MyList<T>
    {
        // Array der gemmer elementerne i listen
        private T[] items;

        // Variabel der holder styr på antal elementer i listen
        private int count;

        //Property der giver adgang til Count
        public int Count { get { return count; } }

        // Tæller antal sammenligninger i sorteringsalgoritmer
        public int comparisonCount;

        // Konstruktor der opretter listen med en startkapacitet sat på 150, så jeg ikke løber tør for plads, når jeg tilføjer elementer
        public MyList(int capacity = 150)
        {
            items = new T[capacity];
            count = 0;
        }
        public void Add(T item)
        {
            this.items[Count] = item;
            count++;

        }

        public T this[int index]
        {
            get
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException();
                }
                return items[index];
            }
            set
            {
                if (index < 0 || index >= count)
                {
                    throw new IndexOutOfRangeException();
                }
                items[index] = value;

            }

        }


        public void InsertionSort()
        {

            comparisonCount = 0;

            for (int i = 1; i < Count; i++)
            {
                T key = items[i];
                int j = i - 1;
                while (j >= 0)
                {
                    comparisonCount++;
                    if (Comparer<T>.Default.Compare(items[j], key) > 0)
                    {
                        items[j + 1] = items[j];
                        j--;
                    }
                    else
                    {
                        break;

                    }
                }
                items[j + 1] = key;
            }
        }

        public void BubbleSort()
        {
            comparisonCount = 0;
            for (int i = 0; i < Count - 1; i++)
            {
                for (int j = 0; j < Count - i - 1; j++)
                {
                    comparisonCount++;
                    if (Comparer<T>.Default.Compare(items[j], items[j + 1]) > 0)
                    {
                        // Swap items[j] and items[j + 1]
                        T temp = items[j];
                        items[j] = items[j + 1];
                        items[j + 1] = temp;
                    }
                }
            }
        }
    }
}
