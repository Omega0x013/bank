using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace bank
{
    public class UpdateDialog : Window
    {
        public UpdateDialog()
        {
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}