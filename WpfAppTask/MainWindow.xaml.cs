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
using System.Threading;
using System.Threading.Tasks;

namespace WpfAppTask
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }





        private CancellationTokenSource token = new CancellationTokenSource();


        private void btnStart1_Click(object sender, RoutedEventArgs e)
        {
            if (token == null)
                token = new CancellationTokenSource();
            Task.Factory.StartNew(() => Conteggio(token, 10000, lblRis));
        }

        private void Conteggio(CancellationTokenSource token, int max, Label lbl)
        {
            for (int i = 0; i < max; i++)
            {
                Dispatcher.Invoke(() => AggiornaUI(i, lbl));
                Thread.Sleep(500);
                Dispatcher.Invoke(() => AggiornaUI1(lbl));
                Thread.Sleep(500);
                if (token.Token.IsCancellationRequested)
                    break;
            }
            Dispatcher.Invoke(() => AggiornaUI2(lbl));
        }

        private void AggiornaUI2(Label lbl)
        {
            lbl.Content = "Ho finito!";
        }

        private void AggiornaUI(int i, Label lbl)
        {
            lbl.Content = $"Sto contando...{i.ToString()}";
        }

        private void AggiornaUI1(Label lbl)
        {
            lbl.Content = "Sto aspettando... !";
        }


    }
}
