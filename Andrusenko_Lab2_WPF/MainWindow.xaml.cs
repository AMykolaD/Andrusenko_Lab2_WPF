using Andrusenko_Lab2_WPF.ViewModels;
using System;
using System.Windows;

namespace Andrusenko_Lab2_WPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {

        private MainWindowViewModel mainWindowView;
        public MainWindow()
        {
            InitializeComponent();
            DataContext = mainWindowView = new MainWindowViewModel();
        }
    }
}
