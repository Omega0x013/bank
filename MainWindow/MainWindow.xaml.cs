using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using System.Reactive;
using Avalonia.ReactiveUI;
using R = ReactiveUI;
using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace bank
{
    public class MainWindow : Window
    {
		ObservableCollection<Account> accounts {get; set;}

        public MainWindow()
        {
			// Accounts list
			accounts = new ObservableCollection<Account>();

			accounts.Add(
				new Account() {
				id=(short)0x69,
				owner=new User() {
					name = "Joe Mama",
					address = "69 Meme St",
					phone = "09015 22 52 04",
					email = "joe@ma.ma"
				},
				balance = 69420,
				min = 420,
				limit = 5,
				count = 0,
				type = true,
				val_interest = 69
			});

			// Make Commands available for binding
			this.DataContext = this;

			this.Closing += (s,e) => Console.WriteLine("Exit");

			// Load
            InitializeComponent();
        }

        private void InitializeComponent()
        {
            AvaloniaXamlLoader.Load(this);
        }

		async void AddData() {
			Console.WriteLine("Add + Open");
			// AddDialog dialog = new AddDialog();
			// Account r = await dialog.ShowDialog<Account>(this);
			Account r = await new AddDialog().ShowDialog<Account>(this);
			if (r != null) accounts.Add(r);
			else Console.WriteLine("Add + NULL");
		}
		async void RemoveData() {
			Console.WriteLine("Remove + Open");
			short r = await new SelectDialog().ShowDialog<short>(this);
			// Filter out matched using LINQ, reassemble into observablecollection using constructor
			// accounts = new ObservableCollection<Account>(from a in accounts where a.id != r select a);
			var query = (from a in accounts where a.id == r select a).ToArray();
			foreach(var i in query) accounts.Remove(i);

			// accounts.Remove(accounts.Where(i => i.id == r).Single());
		}
    }
}