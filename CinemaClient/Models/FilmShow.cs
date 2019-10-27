using System;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

namespace CinemaClient.Models
{
    public class FilmShow
    {
        private string _name;
        private DateTime _filmStartTime;
        private int _countTicket;

        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                OnPropertyChanged("Name");
            }
        }

        public DateTime FilmStartTime
        {
            get { return _filmStartTime; }
            set
            {
                _filmStartTime = value;
                OnPropertyChanged("FilmStartTime");
            }
        }
        public int CountTicket
        {
            get { return _countTicket; }
            set
            {
                _countTicket = value;
                OnPropertyChanged("CountTicket");
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
