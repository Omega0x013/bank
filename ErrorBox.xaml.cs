using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace bank
{
    public class ErrorBox : Window
    {
		public ErrorBox()
		{
			this.DataContext = this;
			InitializeComponent();
		}

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }
    }
}