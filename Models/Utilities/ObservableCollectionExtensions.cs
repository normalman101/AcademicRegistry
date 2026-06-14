using System.Collections;
using System.Collections.ObjectModel;

namespace AcademicRegistry.Models.Utilities;

public static class ObservableCollectionExtensions
{
    public static void UpdateWith<T>(this ObservableCollection<T> observableCollection, IEnumerable enumerable)
    {
        observableCollection.Clear();

        foreach (T element in enumerable) observableCollection.Add(element);
    }
}