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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace UserProfileWindow
{
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : Window
	{
        private const string ID = "49ae8f3e-09bb-4f70-baf8-b002e4eef8d3";
        private const string CONNECTION_STRING = "Server=A-104-10;Database=UserProfileData;Trusted_Connection=True;";

        public MainWindow()
        {
            InitializeComponent();

            Guid ProfileId = new Guid();
            Guid.TryParse(ID, out ProfileId);

            var profile = new UserProfile
            {
                Id = ProfileId
            };

            try
            {
                using (var context = new Context(CONNECTION_STRING))
                {
                    context.Profiles.Add(profile);
                    context.SaveChanges();
                }
            }
            catch
            {
                using (var context = new Context(CONNECTION_STRING))
                {
                    var thisProfile = context.Profiles.Where(p => String.Equals(p.Id.ToString(), ID)).FirstOrDefault<UserProfile>();

                    string userImageProfile = thisProfile.ImagePath;
                    if (userImageProfile == null)
                    {
                        userImageProfile = "https://icon-library.net/images/google-user-icon/google-user-icon-7.jpg";
                    }

                    userFirstName.Text = thisProfile.FirstName;
                    userLastName.Text = thisProfile.LastName;
                    userAddress.Text = thisProfile.Address;
                    userImage.Source = new BitmapImage(new Uri(userImageProfile, UriKind.Absolute));
                }
            }
        }

        private void SaveChangesClicked(object sender, RoutedEventArgs e)
        {
            if (String.IsNullOrWhiteSpace(userFirstName.Text) || String.IsNullOrWhiteSpace(userLastName.Text) || String.IsNullOrWhiteSpace(userAddress.Text))
            {
                MessageBox.Show("Необходимо заполнить все поля");
                return;
            }


            using (var context = new Context(CONNECTION_STRING))
            {
                var profile = context.Profiles.Where(p => string.Equals(p.Id.ToString(), ID)).FirstOrDefault<UserProfile>();

                profile.FirstName = userFirstName.Text;
                profile.LastName = userLastName.Text;
                profile.Address = userAddress.Text;

                context.SaveChanges();
            }
            MessageBox.Show("Успешно сохранено");
        }

        private void DownloadImageClicked(object sender, RoutedEventArgs e)
        {
            ImageUrlWindow imageUrlWindow = new ImageUrlWindow();
            imageUrlWindow.Show();
        }
    }
}
