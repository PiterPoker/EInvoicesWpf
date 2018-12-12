using EInvoicesWpf.Models;
using EInvoicesWpf.Models.StepsViewModel;
using EInvoicesWpf.PagesStep;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace EInvoicesWpf
{
    /// <summary>
    /// Логика взаимодействия для Page1.xaml
    /// </summary>
    public partial class Step1 : Page
    {
        public Step1()
        {
            InitializeComponent();
            DataContext = new CalendarViewModel();
        }

        public void CombinedDialogClosingEventHandler()
        {
            var combined = calendar1.SelectedDates;
            ((CalendarViewModel)DataContext).DateTimeList = combined;
        }

        private void calendar1_MouseMove(object sender, MouseEventArgs e)
        {
        }

        private void calendar1_KeyUp(object sender, KeyEventArgs e)
        {
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            //запихнуть все это в команду
            var combined = from u in calendar1.SelectedDates
                           orderby u.Date
                           select u;
            ((CalendarViewModel)DataContext).DateTimeList = combined.ToList();
            NavigationService.Navigate(new Uri("/PagesStep/Step2.xaml", UriKind.Relative));
        }
    }
}
