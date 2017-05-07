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
using System.Windows.Shapes;

namespace QuranPresenter
{
    /// <summary>
    /// Interaction logic for announcement.xaml
    /// </summary>
    public partial class announcement : Window
    {
        public announcement()
        {
            InitializeComponent();
            DataContext = ayatDisplay.BindingContainer;
        }

        internal void displayAnnouncement(string announce)
        {
            displayAnnounce.Text = announce;
        }

        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
        }

    }
}
