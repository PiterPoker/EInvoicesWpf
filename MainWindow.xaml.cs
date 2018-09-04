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
        }

        private void MenuItem_Click(object sender, RoutedEventArgs e)
        {

        }      
        
        private void SelectBtn(int index)
        {
            List<Button> brushList = new List<Button>() { step1Btn,
                step2Btn,
                step3Btn,
                step4Btn,
                step5Btn };
            for (int i = 0; i < brushList.Count; i++)
                if (i != index) { brushList[i].Foreground = Brushes.White; } else { brushList[i].Foreground = Brushes.Red; }
        }

        private void step1Btn_Click(object sender, RoutedEventArgs e)
        {
            SelectBtn(0);
        }

        private void step2Btn_Click(object sender, RoutedEventArgs e)
        {
            SelectBtn(1);
        }

        private void step3Btn_Click(object sender, RoutedEventArgs e)
        {
            SelectBtn(2);
        }

        private void step4Btn_Click(object sender, RoutedEventArgs e)
        {
            SelectBtn(3);
        }

        private void step5Btn_Click(object sender, RoutedEventArgs e)
        {
            SelectBtn(4);
        }
    }
}
