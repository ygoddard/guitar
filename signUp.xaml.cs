using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.Phone.UI.Input;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Guitar
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class signUp : Page
    {
        public signUp()
        {
            this.InitializeComponent();
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Windows.Phone.UI.Input.HardwareButtons.BackPressed += HardwareButtons_BackPressed;
        }

        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            Windows.Phone.UI.Input.HardwareButtons.BackPressed -= HardwareButtons_BackPressed;
        }

        void HardwareButtons_BackPressed(object sender, Windows.Phone.UI.Input.BackPressedEventArgs e)
        {
            if (Frame.CanGoBack)
            {
                e.Handled = true;
                Frame.GoBack();
            }
        }

        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            if (NameTextBox.Text != "" && passwordBox.Password !="" && MailTextBox.Text != "")
            {
                Credential item = new Credential
                {
                    id = NameTextBox.Text,
                    Password = passwordBox.Password,
                    Email = MailTextBox.Text,
                    pathToPic = "pathToPic"
                };
                MainPage.userDetails = item;
                MainPage.generateCredential(item);
                Frame.Navigate(typeof(welcomeMenu));
            } else
            {
                //picTextBox.Text="fill all fields!";
               // picTextBox.Foreground= Bru.gr;
                PicText.Text = "fill all fields!";
                PicText.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                // PicText.Text.Replace(PicText.Text,"please fill all requierd fields!");
            }
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void cameraButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(camera));
        }

        private void galleryButton_Click(object sender, RoutedEventArgs e)
        {
            //App.MobileService.GetTable<Credential>()
            
        }
    }
}
