using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System;

namespace bank
{
    public class SelectDialog : Window
    {
		string inID {get;set;}
		async void ShowError() => await new ErrorBox().ShowDialog(this);
        public SelectDialog()
        {
			this.DataContext = this;
			this.Closing += (s, e) => Console.WriteLine("Remove + Exit");
            AvaloniaXamlLoader.Load(this);
        }

		void ok() {
			Console.WriteLine("Remove + OK");
			if (inID == "") ShowError();
			else {
				try {
					Close(Convert.ToInt16(inID, 16));
					return;
				} catch {
					ShowError();
				}
			}
			Console.WriteLine("Remove + Error");
		}

		void cancel() {
			Console.WriteLine("Remove + Cancel");
			Close(null);
		}
    }
}