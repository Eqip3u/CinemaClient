using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Windows;
using System.Windows.Threading;
using CinemaClient.Commands;
using CinemaClient.Extensions;
using CinemaClient.Helpers.Comparers;
using CinemaClient.Helpers.InternetAvailability;
using CinemaClient.Models;
using CinemaClient.Services;

namespace CinemaClient.ViewModels
{
    public class CinemaViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<FilmShow> FilmShows { get; } = new ObservableCollection<FilmShow>();

        public ILoadFilmShowsService _loadService = new LoadFilmShowsService();
        public IOrderTicketFilmService _orderTicketService = new OrderTicketFilmService();

        public CinemaViewModel()
        {
            DispatcherInit();
        }

        private FilmShow selectedFilmShow;
        public FilmShow SelectedFilmShow
        {
            get { return selectedFilmShow; }
            set
            {
                selectedFilmShow = value;
                OnPropertyChanged("SelectedFilmShow");
            }
        }

        private RelayCommand _orderTicketCommand;
        public RelayCommand OrderTicketCommand
        {
            get
            {
                return _orderTicketCommand ??
                            (_orderTicketCommand = new RelayCommand(async (obj) =>
                            {
                                if (obj is FilmShow filmShow)
                                {
                                    await _orderTicketService.PostOrderTicket(
                                        new OrderTicket
                                        {
                                            Name = filmShow.Name,
                                            CountTicket = filmShow.CountTicket,
                                            OrderTime = DateTime.Now
                                        });
                                }
                            },
                            (obj) => SelectedFilmShow != null));
            }
        }

        private void DispatcherInit()
        {
            DispatcherTimer dispatcherTimer = new DispatcherTimer
            {
                Interval = TimeSpan.FromSeconds(App.BackgroundUpdateFilmShows)
            };
            dispatcherTimer.Tick += LoadFilmShows;
            dispatcherTimer.Start();
        }

        private async void LoadFilmShows(object sender, EventArgs e)
        {
            try
            {
                var newFilmShows = await _loadService.GetFilmShows();
                FilmShows.UpdateFilmShows(newFilmShows);
            }
            catch (Exception exception)
            {
                Debug.WriteLine($"Сервер не отвечает \n Ошибка: {exception}");
            }
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }

        #endregion
    }
}
