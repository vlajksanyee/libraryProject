using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

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
			LoadData("konyvek.txt");
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

		List<Library> dataList = new List<Library>();

		public void LoadData(string fileName)
		{
			int i = 0;
			foreach (var item in File.ReadAllLines(fileName))
			{
				dataList.Add(new Library(item));
				dataGrid.Items.Add(dataList[i]);
				i++;
			}
		}

		private void AddBookBT_Click(object sender, RoutedEventArgs e)
		{
			abAuthor.Visibility = Visibility.Visible;
			abTitle.Visibility = Visibility.Visible;
			abYear.Visibility = Visibility.Visible;
			abPublisher.Visibility = Visibility.Visible;
			abRental.Visibility = Visibility.Visible;
			abAddBT.Visibility = Visibility.Visible;
		}
	}
}
