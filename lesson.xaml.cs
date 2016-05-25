
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkID=390556

namespace Guitar
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class lesson : Page
    {
        int lessonNumber= App.lessonNumber;
        singleLesson sl;
        int i = 0;
        int lessonSize;

        public lesson()
        {
            this.InitializeComponent();
            popUp(lessonNumber.ToString());
            sl = chooseLesson.DB.getLesson(lessonNumber);
            if (sl.getType() == "chords")
            {
                chordBlock.Text = sl.getchordsList()[0].ToString();
                lessonSize = sl.getchordsList().Count();
                nextButtun.Visibility = Visibility.Visible;
                prevButtun.Visibility = Visibility.Visible;
                //TODO
                //GuitarMethods.setMode(Mode.Chords);
                //GuitarMethods.playChord(sl.getchordsList()[0])){
            } else    //its a song
            {
                //TODO
                //GuitarMethods.setMode(Mode.Stream);
                //GuitarMethods.playChord(sl.getchordsList()[0]);

                //set stream to return bool
                //if (GuitarMethods.stream(sl.getchordsList().ToArray(), sl.getDelaysList().ToArray(), true)){
                //showMenu();
                //}


                showMenu();
                int n;

            }

        }


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
                Frame.Navigate(typeof(chooseLesson));
            }
        }

        private async void popUp(String str)
        { 
            MessageDialog msgbox = new MessageDialog(str);
            await msgbox.ShowAsync();
        } 

        private void nextButtun_Click(object sender, RoutedEventArgs e)
        {
            if (i < lessonSize-1)
            {
                ++i;
                chordBlock.Text = sl.getchordsList()[i].ToString();
              //  popUp(i.ToString());
                //GuitarMethods.playChord(sl.getchordsList()[i]))
            }
            else {     //finished lesson
                this.chordBlock.Text = "";
                this.nextButtun.Visibility = Visibility.Collapsed;
                this.prevButtun.Visibility = Visibility.Collapsed;
                this.Rack.Visibility = Visibility.Visible;
                this.finishedTextBox.Visibility = Visibility.Visible;
                this.finishedTextBox1.Visibility = Visibility.Visible;
                this.repeatButton.Visibility = Visibility.Visible;
                this.nextLesoonButton.Visibility = Visibility.Visible;
                this.lessonsButton.Visibility = Visibility.Visible;
            }
        }

        private void prevButtun_Click(object sender, RoutedEventArgs e)
        {
            if (i > 0)
            {
                i--;
                chordBlock.Text = sl.getchordsList()[i].ToString();
              //  popUp(i.ToString());
                
                //GuitarMethods.playChord(sl.getchordsList()[i]))
            }
        }

        private void repeatButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(lesson));
            i = 0;
        }

        private void nextLesoonButton_Click(object sender, RoutedEventArgs e)
        {
            if (App.lessonNumber < 6)
            {
                App.lessonNumber++;
                i = 0;
                Frame.Navigate(typeof(lesson));
            } else
            {

                showMenu(true);
            }
            
        }

        private void lessonsButton_Click(object sender, RoutedEventArgs e)
        {
            Frame.Navigate(typeof(chooseLesson));
            i = 0;
        }

        private void showMenu(bool lastOne= false)
        {
            this.chordBlock.Text = "";
            this.nextButtun.Visibility = Visibility.Collapsed;
            this.prevButtun.Visibility = Visibility.Collapsed;
            this.Rack.Visibility = Visibility.Visible;
            this.finishedTextBox.Visibility = Visibility.Visible;
            this.finishedTextBox1.Visibility = Visibility.Visible;
            this.lessonsButton.Visibility = Visibility.Visible;
            if (lastOne)
            {
                this.finishedTextBox.Text = "Congratulations!";
                this.finishedTextBox1.Text = "Now you are a\nSuper User!";
                this.repeatButton.Visibility = Visibility.Collapsed;
                this.nextLesoonButton.Visibility = Visibility.Collapsed;
            } else
            {
                this.repeatButton.Visibility = Visibility.Visible;
                this.nextLesoonButton.Visibility = Visibility.Visible;
            }
        }


    }
}
