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
        }
        
        private void calendar1_MouseMove(object sender, MouseEventArgs e)
        {
            cheakDate();
        }

        void cheakDate()
        {
            if (calendar1.SelectedDates.Count > 0)
            {
                if (calendar1.SelectedDates[0].Date > calendar1.SelectedDates[calendar1.SelectedDates.Count - 1].Date)
                {
                    DateStart.Content = calendar1.SelectedDates[calendar1.SelectedDates.Count - 1].ToString("dd.MM.yyyy")+" г.";
                    DateEnd.Content = calendar1.SelectedDates[0].ToString("dd.MM.yyyy") + " г.";
                }
                else
                {
                    DateEnd.Content = calendar1.SelectedDates[calendar1.SelectedDates.Count - 1].ToString("dd.MM.yyyy") + " г.";
                    DateStart.Content = calendar1.SelectedDates[0].ToString("dd.MM.yyyy") + " г.";
                }
                dokPanelVis.Visibility = Visibility.Visible;
                Step3.selectedDates = calendar1;
                if (Mouse.Captured is CalendarItem)
                { Mouse.Capture(null); }
            }
        }

        private void calendar1_KeyUp(object sender, KeyEventArgs e)
        {
            cheakDate();
        }

        private void nextBtn_Click(object sender, RoutedEventArgs e)
        {
            cheakDate();
            NavigationService.Navigate(new Uri("/PagesStep/Step2.xaml", UriKind.Relative));
        }
    }
}
