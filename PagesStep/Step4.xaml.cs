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

namespace EInvoicesWpf.PagesStep
{
    /// <summary>
    /// Логика взаимодействия для Step4.xaml
    /// </summary>
    public partial class Step4 : Page
    {
        public Step4()
        {
            InitializeComponent();
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PagesStep/Step5.xaml", UriKind.Relative));
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PagesStep/Step3.xaml", UriKind.Relative));
        }
    }
}
