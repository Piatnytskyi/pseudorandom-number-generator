using LinearCongruentialGeneratorTest.ViewModel;
using System.Windows;

namespace LinearCongruentialGeneratorTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new LinearCongruentialGeneratorViewModel();
        }
    }
}
