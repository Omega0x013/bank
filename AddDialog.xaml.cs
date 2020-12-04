using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using R = ReactiveUI;
using System.Reactive;
using System;

namespace bank
{
    public class AddDialog : Window
    {
		private Random rnd = new Random();
        public AddDialog()
        {
			Console.WriteLine($"Add + Rnd {((short)rnd.Next()).ToString("X4")}");
			this.DataContext = this;
			/* This causes a recursive close loop, don't make this mistake again */
			// this.Closing += (s, e) => cancel(); // override normal X button

			// Using this instead: prints "Add + Exit" when the window closes.
			this.Closing += (s, e) => Console.WriteLine("Add + Exit");
			InitializeComponent();
        }

		async void ShowError() => await new ErrorBox().ShowDialog(this);

		void ok() {
			Console.WriteLine("Add + OK");
			double oMin, oInterest;
			int olimit;
			if (!double.TryParse(inMinBal, out oMin)) {
				Console.WriteLine("Add + Error : Min");
				// await ShowDialog(new ErrorBox("Min Value Invalid"));
				ShowError();
				return;
			}
			if (!double.TryParse(inInterest, out oInterest)) {
				Console.WriteLine("Add + Error : Interest");
				ShowError();
				return;
			}
			if (!int.TryParse(inLimit, out olimit)) {
				Console.WriteLine("Add + Error : Limit");
				ShowError();
				return;
			}

			Account result = new Account() {
				id = (short)rnd.Next(),
				type = inType,

				owner = new User() {
					name = inName,
					address = inAddress,
					phone = inPhone,
					email = inEmail,
				},

				balance = 0,
				min = oMin,
				val_interest = oInterest,

				limit = olimit,
				count = 0,
			};

			Close(result);
		}
		void cancel() {
			Console.WriteLine("Add + Cancel");
			Close(null);
		}

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

		// Radio Buttons call this with a command parameter to set inType.
		void typeSel(string param) => inType = param=="S";

		// bool inType {set; get;} // use !inType for the table
		bool inType {set; get;}
		string inName {set; get;}
		string inAddress {set; get;}
		string inPhone {set; get;}
		string inMinBal {set; get;} // cast to double or float
		string inLimit {set; get;} // cast to int
		string inInterest {get; set;} // double
		string inEmail {get; set;}
    }
}