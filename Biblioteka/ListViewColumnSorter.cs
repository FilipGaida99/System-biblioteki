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
            var columnIndex = ColumnsSortOrder[orderIndex];
            if(columnIndex >= 0)
            {
                compareResult = ObjectCompare.Compare(listviewX.SubItems[columnIndex].Text, listviewY.SubItems[columnIndex].Text);
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
            for (int i = ColumnsSortOrder.Length - 2; i >= 0; i--)
            {

                ColumnsSortOrder[i + 1] = ColumnsSortOrder[i];
            }

            ColumnsSortOrder[0] = value;
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