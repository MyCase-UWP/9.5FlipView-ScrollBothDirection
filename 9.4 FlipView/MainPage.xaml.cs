using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace _9._4_FlipView
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        public ObservableCollection<ChapterData> MyChapterDataCollection = new ObservableCollection<ChapterData>();
        public MainPage()
        {
            this.InitializeComponent();

            MyChapterDataCollection.Add(new ChapterData());
            MyChapterDataCollection.Add(new ChapterData());
            ChapterFileView.ItemsSource = MyChapterDataCollection;

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //var item = MyDataCollection[0];
            //if (string.Equals(item.IsShowImage, "Visible"))
            //{
            //    item.IsShowImage = "Collapsed";
            //}
            //else {
            //    item.IsShowImage = "Visible";
            //}     
        }

        private void SlidesFlip_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

    

        private void SlidesFileView_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == VirtualKey.Left) {
                ChapterFileView.SelectedIndex--;
            }
            if (e.Key == VirtualKey.Right) {
                ChapterFileView.SelectedIndex++;
            }
        }

    }


    public class ChapterData : INotifyPropertyChanged
    {
        //propertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }


        private ObservableCollection<SlideData> slidedatas;
        public ObservableCollection<SlideData> Slidedatas
        {
            get { return slidedatas; }
        }


        public ChapterData() {
            this.slidedatas = new ObservableCollection<SlideData>();
            this.slidedatas.Add(new SlideData { Image = "/Assets/1.PNG", Name = "photo1", IsShowImage = "Visible" });
            this.slidedatas.Add(new SlideData { Image = "/Assets/2.PNG", Name = "photo2", IsShowImage = "Visible" });
        }
    }




    public class SlideData : INotifyPropertyChanged
    {
        //propertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyPropertyChanged(String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        //image
        private String image;
        public String Image {
            get { return image; }
            set {
                image = value;
                if (PropertyChanged != null) {
                    NotifyPropertyChanged();
                }
            }
        }

        //name
        private String name;
        public String Name {
            get { return name; }
            set {
                name = value;
                if (PropertyChanged != null) {
                    NotifyPropertyChanged();
                }
            }
        }

        //ishowImage
        private String ishowImage;
        public String IsShowImage {
            get { return ishowImage; }
            set {
                ishowImage = value;
                if (PropertyChanged != null) {
                    NotifyPropertyChanged();
                }
            }
        }
    }
}
