using System.Windows;
using System.Windows.Input;

namespace TabGrabber {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {

        public MainWindow() {
            InitializeComponent();
            LoadSavedLibrary();
        }

        private void LoadLibrary_Clicked(object sender, RoutedEventArgs e) {
            LoadSavedLibrary();
        }

        private void LoadSavedLibrary() {
            foreach (var song in Library.LazyLoadAll(@"F:\iTunes\iTunes Media\Music")) {
                listView.Items.Add(song);
            }
        }

        private void AddButton_Clicked(object sender, RoutedEventArgs e) {
            var newSongWindow = new AddSong();
            newSongWindow.Show();
        }

        private void SaveButton_Clicked(object sender, RoutedEventArgs e) {
            var conn = new DatabaseConnection();
        }

        private void Control_OnMouseDoubleClick(object sender, MouseButtonEventArgs e) {
            var s = (Song)listView.SelectedItem;
            if (s.Tab) MessageBox.Show("Bananas!");
        }
    }
}