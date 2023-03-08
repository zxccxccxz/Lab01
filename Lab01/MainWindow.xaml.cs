using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace Lab01
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly ViewModel _vm;
        public MainWindow()
        {
            InitializeComponent();
            _vm = new ViewModel(OnMsgBoxCreator);
            this.DataContext = _vm;
        }
        private void OnMsgBoxCreator(object? sender, MsgBoxCreatorEventArgs e)
        {
            MessageBox.Show(e.Msg);
        }
    }
}
