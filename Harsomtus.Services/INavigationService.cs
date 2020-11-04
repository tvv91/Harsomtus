using System.Collections.ObjectModel;

namespace Harsomtus.Services
{
    /// <summary>
    /// Navigation service
    /// </summary>
    public interface INavigationService<T>
    {        
        /// <summary>
        /// Load data
        /// </summary>
        /// <param name="itemsCount"></param>
        /// <returns></returns>
        ObservableCollection<T> Fetch(int itemsCount);

        /// <summary>
        /// Next items
        /// </summary>
        ObservableCollection<T> Next();

        /// <summary>
        /// Previous items
        /// </summary>
        ObservableCollection<T> Prev();

        /// <summary>
        /// First page
        /// </summary>
        /// <returns></returns>
        ObservableCollection<T> First();

        /// <summary>
        /// Last page
        /// </summary>
        /// <returns></returns>
        ObservableCollection<T> Last();

        /// <summary>
        /// Specific page
        /// </summary>
        /// <param name="page"></param>
        /// <returns></returns>
        ObservableCollection<T> Page(int page);

        /// <summary>
        /// Get collection of page numbers for navigation
        /// </summary>
        /// <returns></returns>
        ObservableCollection<int> GetPageNumbers();

        /// <summary>
        /// Returns current page number
        /// </summary>
        /// <returns></returns>
        int GetCurrentPageNumber();
    }
}
