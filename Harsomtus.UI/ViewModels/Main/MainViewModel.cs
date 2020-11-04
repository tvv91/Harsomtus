using Harsomtus.Models;
using Harsomtus.Services;
using Harsomtus.UI.Command;
using System.Collections.ObjectModel;
using System.Windows.Input;
using UIC = Harsomtus.Constants.UI;

namespace Harsomtus.UI.ViewModels
{
    public class MainViewModel : ViewModelBase
    {
        #region Private

        private readonly INavigationService<Album> _navService;

        #endregion        
        
        #region Constructor

        public MainViewModel(INavigationService<Album> navigationService)
        {
            _navService = navigationService;
            GridWidth = UIC.DEFAULT_AREA_WIDTH;
            GridHeight = UIC.DEFAULT_AREA_HEIGHT;
            WndSizeChanged.Execute(null);
        }

        #endregion

        #region Commands

        /// <summary>
        /// Next items
        /// </summary>
        public ICommand NextPage
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Albums = _navService.Next();
                    SelectedPageNumber = _navService.GetCurrentPageNumber();
                    OnPropertyChanged("Albums");
                    OnPropertyChanged("SelectedPageNumber");
                });
            }
        }

        /// <summary>
        /// Previous items
        /// </summary>
        public ICommand PrevPage
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Albums = _navService.Prev();
                    SelectedPageNumber = _navService.GetCurrentPageNumber();
                    OnPropertyChanged("Albums");
                    OnPropertyChanged("SelectedPageNumber");
                });
            }
        }

        /// <summary>
        /// Previous items
        /// </summary>
        public ICommand LastPage
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Albums = _navService.Last();
                    SelectedPageNumber = _navService.GetCurrentPageNumber();
                    OnPropertyChanged("Albums");
                    OnPropertyChanged("SelectedPageNumber");
                });
            }
        }

        /// <summary>
        /// Previous items
        /// </summary>
        public ICommand FirstPage
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Albums = _navService.First();
                    SelectedPageNumber = _navService.GetCurrentPageNumber();
                    OnPropertyChanged("Albums");
                    OnPropertyChanged("SelectedPageNumber");
                });
            }
        }

        public ICommand PageNumberSelected
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Albums = _navService.Page(SelectedPageNumber);
                    OnPropertyChanged("Albums");
                });
            }
        }

        /// <summary>
        /// Window size changed
        /// </summary>
        public ICommand WndSizeChanged
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    Albums = _navService.Fetch(ItemsCalc.Calc(GridWidth, GridHeight, UIC.COVER_WIDTH, UIC.COVER_HEIGHT));
                    PageNumbers = _navService.GetPageNumbers();
                    SelectedPageNumber = _navService.GetCurrentPageNumber();
                    OnPropertyChanged("Albums");
                    OnPropertyChanged("SelectedPageNumber");
                    OnPropertyChanged("PageNumbers");
                });
            }
        }

        /// <summary>
        /// Disable mouse wheel preview for page number selection
        /// </summary>
        public ICommand PreviewMouseWheel
        {
            get
            {
                return new RelayCommand(obj =>
                {
                    ((MouseWheelEventArgs)obj).Handled = true;
                });
            }
        }

        #endregion

        #region Properties

        /// <summary>
        /// List of page numbers
        /// </summary>
        public ObservableCollection<int> PageNumbers { get; set; }

        /// <summary>
        /// Selected page number
        /// </summary>
        public int SelectedPageNumber { get; set; }

        /// <summary>
        /// List of music albums
        /// </summary>
        public ObservableCollection<Album> Albums { get; set; }

        /// <summary>
        /// Selected album
        /// </summary>
        public Album SelectedAlbum { get; set; }

        /// <summary>
        /// Main grid width
        /// </summary>
        public double GridWidth { get; set; }

        /// <summary>
        /// Main grid height
        /// </summary>
        public double GridHeight { get; set; }

        #endregion
    }
}
