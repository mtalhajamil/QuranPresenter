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
    /// Interaction logic for displayImage.xaml
    /// </summary>
    public partial class displayImage : Window
    {
        public displayImage()
        {
            InitializeComponent();
        }

        internal void displayImageFrom(string imageLink, string surahNo, string ayatNo)
        {
            pictureBox1.Source = new BitmapImage(new Uri(@"C:\QuranPresenter\" + imageLink));
            //MessageBox.Show(imageLink);
        }

        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Escape)
                this.Close();
            //var focusedControl = FocusManager.GetFocusedElement(this);
        }
    }

    
}
