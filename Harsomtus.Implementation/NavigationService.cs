using Harsomtus.Models;
using Harsomtus.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace Harsomtus.Implementation
{
    // TODO: Here must be data service provider, it's just for testing
    public class NavigationService : INavigationService<Album>
    {
        #region Private

        private ObservableCollection<Album> albums;
        private int currentIndex;
        private int currentPage;
        private int totalItems;
        private int itemsOnPage;

        #endregion

        // TODO: Only for testing
        private void stubFill()
        {
            for (int i = 1; i <= 100; i++)
            {
                albums.Add(
                new Album
                {
                    Artist = new Artist { Name = "Artist" + i },
                    Title = "Album" + (i),
                    CoverImage = "D:/1.png"
                });
            }
        }

        public NavigationService()
        {
            albums = new ObservableCollection<Album>();
            stubFill();
            totalItems = albums.Count;
            currentPage = 1;
        } 

        public ObservableCollection<Album> Fetch(int itemsCount)
        {
            if (itemsOnPage > 0 && itemsCount != itemsOnPage && currentIndex > 0)
            {
                currentPage = (int)Math.Ceiling((double)currentIndex / itemsCount) + 1;
            }
            itemsOnPage = itemsCount;
            return new ObservableCollection<Album>(albums.Skip(currentIndex).Take(itemsCount));
        }

        public ObservableCollection<Album> First()
        {
            currentPage = 1;
            currentIndex = 0;
            return new ObservableCollection<Album>(albums.Take(itemsOnPage));
        }

        public ObservableCollection<Album> Last()
        {
            currentPage = (int)Math.Ceiling((double)totalItems / itemsOnPage); 
            currentIndex = albums.Count - itemsOnPage;
            return new ObservableCollection<Album>(albums.TakeLast(itemsOnPage));
        }

        public ObservableCollection<Album> Next()
        {
            if (currentIndex + itemsOnPage < albums.Count)
            {
                currentPage++;
                return new ObservableCollection<Album>(albums.Skip(currentIndex += itemsOnPage).Take(itemsOnPage));
            }
            return new ObservableCollection<Album>(albums.Skip(currentIndex).Take(itemsOnPage));
        }

        public ObservableCollection<Album> Prev()
        {
            if (currentPage > 1)
            {
                currentPage--;
            }
            return currentIndex - itemsOnPage >= 0
                ? new ObservableCollection<Album>(albums.Skip(currentIndex -= itemsOnPage).Take(itemsOnPage))
                : new ObservableCollection<Album>(albums.Take(itemsOnPage));         
        }

        public ObservableCollection<Album> Page(int page)
        {
            if (currentPage != page)
            {
                currentPage = page;
                currentIndex = (currentPage - 1) * itemsOnPage;
            }
            return new ObservableCollection<Album>(albums.Skip(currentIndex).Take(itemsOnPage));
        }

        public ObservableCollection<int> GetPageNumbers()
        {
            var collection = new ObservableCollection<int>();
            int pageNumber = (int)Math.Ceiling((double)totalItems / itemsOnPage);
            for (int i = 1; i <= pageNumber; i++)
            {
                collection.Add(i);
            }
            return collection;
        }

        public int GetCurrentPageNumber()
        {
            return currentPage;
        }
    }
}
