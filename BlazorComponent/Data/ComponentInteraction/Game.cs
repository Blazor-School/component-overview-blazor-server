using System.ComponentModel;

namespace BlazorComponent.Data.ComponentInteraction
{
    public class Game : INotifyPropertyChanged
    {
        private string _name;
        private double _price;

        public string Name
        {
            get => _name;
            set
            {
                _name = value;
                PropertyChanged?.Invoke(this, new(nameof(Name)));
            }
        }
        public double Price
        {
            get => _price;
            set
            {
                _price = value;
                PropertyChanged?.Invoke(this, new(nameof(Price)));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
