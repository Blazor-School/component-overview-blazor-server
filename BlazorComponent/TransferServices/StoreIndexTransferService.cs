using BlazorComponent.Data.ComponentInteraction;
using System;
using System.Collections.Generic;
using System.ComponentModel;

namespace BlazorComponent.TransferServices
{
    public class StoreIndexTransferService : IDisposable
    {
        private List<Game> _games = new();
        private Game _selectedGame = new();
        public List<Game> Games
        {
            get => _games;
            set
            {
                _games = value;
                OnGamesChanged?.Invoke(this, value);
            }
        }
        public delegate void OnGamesChangedEventHandler(object sender, List<Game> games);
        public event OnGamesChangedEventHandler OnGamesChanged;
        public Game SelectedGame
        {
            get => _selectedGame;
            set
            {
                _selectedGame.PropertyChanged -= PropertySelectedGameChangedEventHandler;
                _selectedGame = value;
                _selectedGame.PropertyChanged += PropertySelectedGameChangedEventHandler;
                OnSelectedGameChanged?.Invoke(this, value);
            }
        }
        public delegate void OnSelectedGameChangedEventHandler(object sender, Game game);
        public event OnSelectedGameChangedEventHandler OnSelectedGameChanged;

        private void PropertySelectedGameChangedEventHandler(object sender, PropertyChangedEventArgs propertyName)
        {
            OnSelectedGameChanged?.Invoke(this, _selectedGame);
            OnGamesChanged?.Invoke(this, _games);
        }

        public void Dispose()
        {
            SelectedGame.PropertyChanged -= PropertySelectedGameChangedEventHandler;
        }
    }
}
