using System.Collections.Generic;
using System.Windows;

namespace TabGrabber {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void LoadLibrary_Clicked(object sender, RoutedEventArgs e) {
            List<Song> allSongs = Library.LoadAll(@"F:\iTunes\iTunes Media\Music");
            listView.ItemsSource = allSongs;
        }

        private void ButtonBase_OnClick(object sender, RoutedEventArgs e) {
            if (listView.Items.Count == 0) return;
            var song = listView.SelectedItem;
            WebQuery.CheckForTab(song as Song);

        }
    }
}