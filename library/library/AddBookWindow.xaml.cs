using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace library
{
	/// <summary>
	/// Interaction logic for AddBookWindow.xaml
	/// </summary>
	public partial class AddBookWindow : Window
	{
		public AddBookWindow()
		{
			InitializeComponent();
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

			private void AbwAddBT_Click(object sender, RoutedEventArgs e)
			{
				bookID = 
			}
		}
	}
}
