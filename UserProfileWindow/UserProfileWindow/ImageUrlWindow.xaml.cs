using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace UserProfileWindow
{
	/// <summary>
	/// Логика взаимодействия для ImageUrlWindow.xaml
	/// </summary>
	public partial class ImageUrlWindow : Window
	{
		public ImageUrlWindow()
		{
			InitializeComponent();
		}

		private void LoadClick(object sender, RoutedEventArgs e)
		{
			using (var context = new Context("Server=A-104-10;Database=UserProfile;Trusted_Connection=True;"))
			{
				var profile = context.Profiles.Where(p => p.Id.ToString() == "49ae8f3e-09bb-4f70-baf8-b002e4eef8d3").FirstOrDefault<ProfileClass>();
				profile.ImagePath = imageUrl.Text;
				context.SaveChanges();
			}
			MessageBox.Show("Фотография успешно загружена");
			this.Close();
		}
	}
}
