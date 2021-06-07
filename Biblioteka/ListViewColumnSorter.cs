using System;
using System.Collections;
using System.Windows.Forms;

/// <summary>
/// Klasa sortująca kolumny ListView.
/// </summary>
public class ListViewColumnSorter : IComparer
{
    /// <summary>
    /// Kolejność kolum, według których następuje sortowanie.
    /// </summary>
    int[] ColumnsSortOrder;

    /// <summary>
    /// Porządek sortowania.
    /// </summary>
    SortOrder OrderOfSort;

    /// <summary>
    /// Obiekt porównujący ciągi.
    /// </summary>
    CaseInsensitiveComparer ObjectCompare;

    /// <summary>
    /// Konstruktor.
    /// </summary>
    /// <param name="columnCount">Liczba kolumn, branych pod uwagę podczas sortowania.</param>
    public ListViewColumnSorter(int columnCount)
    {
        if(columnCount <= 0)
        {
            throw new IndexOutOfRangeException("columnCount out of Range");
        }

        ColumnsSortOrder = new int[columnCount];
        ColumnsSortOrder[0] = 0;
        for(int i = 0; i < ColumnsSortOrder.Length; i++)
        {
            ColumnsSortOrder[i] = -1;
        }

        OrderOfSort = SortOrder.None;

        ObjectCompare = new CaseInsensitiveComparer();
    }

    /// <summary>
    /// Funkcja interfejsu IComparer. Porównuje wartości kolumn zgodnie z ustawieniami.
    /// </summary>
    /// <param name="x">Pierwszy obiekt do porównania.</param>
    /// <param name="y">Drugi obiekt do porównania.</param>
    /// <returns>Wynik porównania. "0", gdy są równe. Ujemne, gdy 'x' jest mniejsze od 'y'. Dodatnie w pozostałych przypadkach.</returns>
    public int Compare(object x, object y)
    {
        int compareResult;
        ListViewItem listviewX, listviewY;

        listviewX = (ListViewItem)x;
        listviewY = (ListViewItem)y;

        compareResult = 0;
        int orderIndex = 0;
        while (compareResult == 0 && orderIndex < ColumnsSortOrder.Length)
        {
            int columnIndex = ColumnsSortOrder[orderIndex];
            if (columnIndex >= 0)
            {
                string textX = listviewX.SubItems[columnIndex].Text;
                string textY = listviewY.SubItems[columnIndex].Text;
                if (!(TryCompareDate(textX, textY, out compareResult) || TryCompareLong(textX, textY, out compareResult)))
                {
                    compareResult = ObjectCompare.Compare(textX, textY);
                }
            }
            orderIndex++;
        }
        if (OrderOfSort == SortOrder.Ascending)
        {
            return compareResult;
        }
        else if (OrderOfSort == SortOrder.Descending)
        {
            return (-compareResult);
        }
        else
        {
            return 0;
        }
    }

    /// <summary>
    /// Ustawianie/Otrzymywanie priorytetowej kolumny w kolejności sortowania.
    /// </summary>
    public int SortColumn
    {
        get
        {
            return ColumnsSortOrder[0];
        }
        set
        {
            if (SortColumn != value)
            {
                for (int i = ColumnsSortOrder.Length - 2; i >= 0; i--)
                {

                    ColumnsSortOrder[i + 1] = ColumnsSortOrder[i];
                }

                ColumnsSortOrder[0] = value;
            }
        }
    }

    /// <summary>
    /// Ustawianie/Otrzymywanie kolejności kolumn w sortowaniu.
    /// </summary>
    public int[] ColumnsOrder
    {
        get
        {
            return ColumnsSortOrder;
        }
        set
        {
            ColumnsSortOrder = value;
        }
    }

    /// <summary>
    /// Próba porówanania wartości dat w tekstach komórek.
    /// </summary>
    /// <param name="textX">Pierwszy argument porównania</param>
    /// <param name="textY">Drugi argument porównania</param>
    /// <param name="result">Wynik porównania. Przy braku powodzenia odczytu ustawiany na 0.</param>
    /// <returns>True, gdy porównanie zostało wykonane dla dat.</returns>
    private bool TryCompareDate(string textX, string textY, out int result)
    {
        DateTime dateX;
        DateTime dateY;
        if(DateTime.TryParse(textX, out dateX) && DateTime.TryParse(textY, out dateY))
        {
            result = dateX.CompareTo(dateY);
            return true;
        }
        result = 0;
        return false;
    }

    /// <summary>
    /// Próba porówanania wartości całkowitych w tekstach komórek.
    /// </summary>
    /// <param name="textX">Pierwszy argument porównania</param>
    /// <param name="textY">Drugi argument porównania</param>
    /// <param name="result">Wynik porównania. Przy braku powodzenia odczytu ustawiany na 0.</param>
    /// <returns>True, gdy porównanie zostało wykonane dla liczb całkowitych.</returns>
    private bool TryCompareLong(string textX, string textY, out int result)
    {
        long longX;
        long longY;
        if (long.TryParse(textX, out longX) && long.TryParse(textY, out longY))
        {
            result = longX.CompareTo(longY);
            return true;
        }
        result = 0;
        return false;
    }

    /// <summary>
    /// Ustawianie/Otrzymywanie porządku sortowania.
    /// </summary>
    public SortOrder Order
    {
        set
        {
            OrderOfSort = value;
        }
        get
        {
            return OrderOfSort;
        }
    }

}