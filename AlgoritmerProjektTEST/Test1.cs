using AlgoritmerProjektAfl;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace AlgoritmerProjektTEST;

// Jeg har indført IEnumerable da testen fejlede uden
public class MyList<T> : IEnumerable<T>
{
    private List<T> items = new List<T>();

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
}

{
    [TestClass]
    public sealed class Test1
    {
        // MyList indeholder allerede sorteret tal, og bør efter sortering stadig være sorteret.
        [TestMethod]
        public void InsertionSortAlreadySorted()
        {
            // Opretter en MyList med heltal der allerede er sorteret i stigende rækkefølge
            MyList<int> alreadySorted = new MyList<int>() { 2, 4, 5, 18, 38, 57, 69 };
            // Opretter den liste jeg forventer som resultat efter sorteringen
            MyList<int> expectedSorted = new MyList<int>() { 2, 4, 5, 18, 38, 57, 69 };
            // Kalder InsertionSort metoden på listen
            alreadySorted.InsertionSort();
            // Sammenligner de to lister ved at konvertere dem til arrays
            CollectionAssert.AreEqual(expectedSorted.ToArray(), alreadySorted.ToArray());
        }
    }
}
