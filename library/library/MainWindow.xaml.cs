using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;

namespace library
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
		public MainWindow()
		{
			InitializeComponent();
			LoadBooksData("konyvek.txt");
			LoadMembersData("tagok.txt");
			LoadRentalsData("kolcsonzesek.txt");
		}

		public class Library
		{
			public int bookID { get; set; }
			public string author { get; set; }
			public string bookTitle { get; set; }
			public string yearOfPublishing { get; set; }
			public string publisher { get; set; }
			public bool rentalAvailability { get; set; }
			public Library(string row)
			{
				string[] part = row.Split(';');
				bookID = int.Parse(part[0]);
				author = part[1];
				bookTitle = part[2];
				yearOfPublishing = part[3];
				publisher = part[4];
				rentalAvailability = bool.Parse(part[5]);
			}
		}

		public class Library2
		{
			public int bookID { get; set; }
			public string author { get; set; }
			public string bookTitle { get; set; }
			public string yearOfPublishing { get; set; }
			public string publisher { get; set; }
			public bool rentalAvailability { get; set; }
		}

		//public List<Library> dataList = new List<Library>();

		public void LoadBooksData(string fileName)
		{
			//dataList.Clear();
			dataGrid.Items.Clear();
			int i = 0;
			foreach (var item in File.ReadAllLines(fileName))
			{
				//dataList.Add(new Library(item));
				dataGrid.Items.Add(new Library(item));
				i++;
			}
		}

		public class Members
		{
			public int memberID { get; set; }
			public string memberName { get; set; }
			public string memberDOB { get; set; }
			public string memberPC { get; set; }
			public string memberLoc { get; set; }
			public string memberAddr { get; set; }
			public Members(string row)
			{
				string[] part = row.Split(';');
				memberID = int.Parse(part[0]);
				memberName = part[1];
				memberDOB = part[2];
				memberPC = part[3];
				memberLoc = part[4];
				memberAddr = part[5];
			}
		}

		public class Members2
		{
			public int memberID { get; set; }
			public string memberName { get; set; }
			public string memberDOB { get; set; }
			public string memberPC { get; set; }
			public string memberLoc { get; set; }
			public string memberAddr { get; set; }
		}

		//public static List<Members> membersDataList = new List<Members>();

		public void LoadMembersData(string fileName)
		{
			//membersDataList.Clear();
			membersDataGrid.Items.Clear();
			int i = 0;
			foreach (var item in File.ReadAllLines(fileName))
			{
				//membersDataList.Add(new Members(item));
				membersDataGrid.Items.Add(new Members(item));
				i++;
			}
		}

		public class Rental
		{
			public int rID { get; set; }
			public int rMemberID { get; set; }
			public int rBookID { get; set; }
			public string rStart { get; set; }
			public string rEnd { get; set; }
			public Rental(string row)
			{
				string[] part = row.Split(';');
				rID = int.Parse(part[0]);
				rMemberID = int.Parse(part[1]);
				rBookID = int.Parse(part[2]);
				rStart = part[3];
				rEnd = part[4];
			}
		}

		public class Rental2
		{
			public int rID { get; set; }
			public int rMemberID { get; set; }
			public int rBookID { get; set; }
			public string rStart { get; set; }
			public string rEnd { get; set; }
		}

		public void LoadRentalsData(string fileName)
		{
			rentalsDataGrid.Items.Clear();
			int i = 0;
			foreach (var item in File.ReadAllLines(fileName))
			{
				rentalsDataGrid.Items.Add(new Rental(item));
				i++;
			}
		}

		private void AbAddBT_Click(object sender, RoutedEventArgs e)
		{
			Library2 addBook = new Library2();
			addBook.bookID = dataGrid.Items.Count + 1;
			addBook.author = abAuthor.Text;
			addBook.bookTitle = abTitle.Text;
			addBook.yearOfPublishing = abYear.Text;
			addBook.publisher = abPublisher.Text;
			addBook.rentalAvailability = (bool)abRental.IsChecked;
			StreamWriter sw = new StreamWriter("konyvek.txt", true);
			sw.WriteLine("{0};{1};{2};{3};{4};{5}", addBook.bookID, addBook.author, addBook.bookTitle, addBook.yearOfPublishing, addBook.publisher, addBook.rentalAvailability);
			sw.Close();
			LoadBooksData("konyvek.txt");
		}

		private void RemoveBT_Click(object sender, RoutedEventArgs e)
		{
			var myGrid = dataGrid;
			if (myGrid.SelectedIndex >= 0)
			{
				dataGrid.Items.RemoveAt(myGrid.SelectedIndex);
				myGrid.Items.Refresh();
			}
		}

		private void AddMemberBT_Click(object sender, RoutedEventArgs e)
		{
			Members2 addMember = new Members2();
			addMember.memberID = membersDataGrid.Items.Count + 1;
			addMember.memberName = amName.Text;
			addMember.memberDOB = amDOB.Text;
			addMember.memberPC = amPC.Text;
			addMember.memberLoc = amLoc.Text;
			addMember.memberAddr = amAddress.Text;
			StreamWriter sw = new StreamWriter("tagok.txt", true);
			sw.WriteLine("{0};{1};{2};{3};{4};{5}", addMember.memberID, addMember.memberName, addMember.memberDOB, addMember.memberPC, addMember.memberLoc, addMember.memberAddr);
			sw.Close();
			LoadMembersData("tagok.txt");
		}

		private void RemoveMemberBT_Click(object sender, RoutedEventArgs e)
		{
			var myGrid = membersDataGrid;
			if (myGrid.SelectedIndex >= 0)
			{
				membersDataGrid.Items.RemoveAt(myGrid.SelectedIndex);
				myGrid.Items.Refresh();
			}
		}

		bool addRentalEnabled;
		private void AddRentalBT_Click(object sender, RoutedEventArgs e)
		{
			addRentalEnabled = true;
			Rental2 addRental = new Rental2();
			try
			{
				addRental.rID = rentalsDataGrid.Items.Count + 1;
				addRental.rMemberID = int.Parse(rMemberIDTB.Text);
				addRental.rBookID = int.Parse(rBookIDTB.Text);
				addRental.rStart = rStartTB.Text;
				addRental.rEnd = rEndTB.Text;
			}
			catch (FormatException)
			{
				MessageBox.Show("Nem megfelelő bevitt adat!");
				addRentalEnabled = false;
			}
			finally
			{
				if (addRentalEnabled)
				{
					StreamWriter sw = new StreamWriter("kolcsonzesek.txt", true);
					sw.WriteLine("{0};{1};{2};{3};{4}", addRental.rID, addRental.rMemberID, addRental.rBookID, addRental.rStart, addRental.rEnd);
					sw.Close();
					LoadRentalsData("kolcsonzesek.txt");
				}
			}
		}

		private void RemoveRentalBT_Click(object sender, RoutedEventArgs e)
		{
			var myGrid = rentalsDataGrid;
			if (myGrid.SelectedIndex >= 0)
			{
				rentalsDataGrid.Items.RemoveAt(myGrid.SelectedIndex);
				myGrid.Items.Refresh();
			}
		}

		private void SearchTB_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{

		}

		private void MSearchTB_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{

		}

		private void RSearchTB_TextChanged(object sender, System.Windows.Controls.TextChangedEventArgs e)
		{

		}
	}
}