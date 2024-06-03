using GameManager.Model;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameManager.ViewModel
{
    class GameViewModel : INotifyPropertyChanged
    {
        private ObservableCollection<DataClient> _games;

        public ObservableCollection<DataClient> Games
        {

            get => _games;
            set
            {
                _games = value;
                OnPropertyChanged(nameof(Games));
            }
        }


        public GameViewModel()
        {
            Games = new ObservableCollection<DataClient>();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
