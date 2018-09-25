using EInvoicesWpf.PagesStep;
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

namespace EInvoicesWpf
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            frameMain.Content = new Step1();
            Properties.Settings.Default.run_app++; //Добавляем +1 к кол-ву запусков программы.
            statusTxt.Text = "Всего запусков программы: " + Properties.Settings.Default.run_app.ToString();
        }
        
        private void step1Btn_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Content = new Step1();
        }

        private void step2Btn_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Content = new Step2();
        }

        private void step3Btn_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Content = new Step3();
        }

        private void step4Btn_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Content = new Step4();
        }

        private void step5Btn_Click(object sender, RoutedEventArgs e)
        {
            frameMain.Content = new Step5();
        }

        private void txtEditor_SelectionChanged(object sender, RoutedEventArgs e)
        {
            statusTxt.Text = Properties.Settings.Default.run_app.ToString();
        }
    }
}
