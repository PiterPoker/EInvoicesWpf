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
    /// Логика взаимодействия для Step3.xaml
    /// </summary>
    public partial class Step3 : Page
    {
        static public Calendar selectedDates { get; set; }

        public Step3()
        {
            InitializeComponent();
            ViewDate();
        }

        void ViewDate() {
            try
            {
                statusDate.Content = selectedDates.SelectedDates[0].ToString("dd.MM.yyyy") + " г.";
                statusDate.Content += selectedDates.SelectedDates[selectedDates.SelectedDates.Count - 1].ToString("dd.MM.yyyy") + " г.";
            }
            catch (Exception ex)
            {

                MessageBox.Show("Не выбрана дата! \n" + ex.Message);
            }
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PagesStep/Step4.xaml", UriKind.Relative));
        }

        private void backBtn_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("/PagesStep/Step2.xaml", UriKind.Relative));
        }
    }
}
