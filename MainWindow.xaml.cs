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
using TestTask.ViewModels;

using BruTile.Predefined;
// using BruTile.
using Mapsui.Layers;
namespace TestTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MainWindowViewModel mainVM;
        public MainWindow()
        {
            InitializeComponent();
            mainVM = new MainWindowViewModel();
            this.DataContext = mainVM;

            MyMapControl.Map.Layers.Add(new TileLayer(KnownTileSources.Create(source:KnownTileSource.OpenStreetMap)));
            
            // MyMapControl.Map.Se
        }

        private void button_Click(object sender, RoutedEventArgs e)
        {
            mainVM.Search();
        }

        private void button1_Click(object sender, RoutedEventArgs e)
        {
            mainVM.LoadLibrary();
        }
    }
}
