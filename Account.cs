namespace bank
{
	public sealed class User {
		public string name, address, phone, email;

		// public override string ToString()
		// {
		// 	return string.Format(">>>\n USER \n-====-\nNAME : {0}\nADDR : {1}\nPHONE: {2}\nEMAIL: {3}\n<<<", name, address, phone, email);
		// }

		// public override string ToString() => 
		// public static implicit operator string(User u) => string.Format("{0}, {1}. {2}, {3}:",u.name,u.address,u.phone,u.email);
		public static implicit operator string(User u) =>
			$"{u.name}, {u.address}. {u.phone}, {u.email}:";
		public override string ToString() => this;
	}

	class Account
	{
		public short id;
		public string typeString() => type ? "Savings" : "Current";
		// public static implicit operator string(Account a) => 
			// $"{a.owner.ToString()} {a.typeString()} ${a.balance} + {a.val_interest}% -- {a.count}/{a.limit}";
		public override string ToString() => this;
		public static implicit operator string(Account a) =>
			$"{a.id.ToString("X4")} :  £{a.balance} + {a.val_interest}% {a.typeString()} {a.count}/{a.limit} --- {a.owner.ToString()}";
		// public override string ToString() => this.typeString();
		public double balance;
		public double min;
		public int limit;
		public int count;
		
		public double check() {
			return this.balance;
		}

		public bool credit(double amount) {
			balance += amount;
			return balance > 0;
		}

		public bool debit(double amount) {
			balance -= amount;
			return balance > 0;
		}

		public bool type;
		public User owner;

		public double val_interest; // Interest in %

		public void interest() => balance += balance * (val_interest / 100);
	}
}