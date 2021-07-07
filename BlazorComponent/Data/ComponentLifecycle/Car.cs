namespace BlazorComponent.Data.ComponentLifecycle
{
    public class Car
    {
        private string _color;

        public string Color
        {
            get => _color;
            set
            {
                _color = value;
                OnColorChanged?.Invoke(this, value);
            }
        }

        public event OnColorChangedHandler OnColorChanged;
        public delegate void OnColorChangedHandler(object sender, string color);
    }
}
