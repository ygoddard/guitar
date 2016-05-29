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
using Microsoft.WindowsAzure.MobileServices;
using System.Diagnostics;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=391641

namespace Guitar
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        private static MobileServiceCollection<Credential> items;

        public static async void generateCredential(String name, String password, String mail)
        {
            Credential item = new Credential
            {
                id = name,
                Password = password,
                Email = mail,
                pathToPic = "pathToPic"
            };
            try
            {
                await App.MobileService.GetTable<Credential>().InsertAsync(item);

            }
            catch (MobileServiceInvalidOperationException n)
            {
                Debug.WriteLine(n);
            }
            try
            {
                items.Add(item);
            }
            catch (Exception r)
            {
                Debug.WriteLine(r);
            }
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            // TODO: Prepare page for display here.

            // TODO: If your application contains multiple pages, ensure that you are
            // handling the hardware Back button by registering for the
            // Windows.Phone.UI.Input.HardwareButtons.BackPressed event.
            // If you are using the NavigationHelper provided by some templates,
            // this event is handled for you.
        }

        private void signInButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(signIn));
            // Frame.Navigate(typeof(signIn)); 
        }

        private void signUpButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(signUp));
        }


    }
}
