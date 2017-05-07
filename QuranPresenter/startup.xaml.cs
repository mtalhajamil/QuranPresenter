using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.OleDb;
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
    /// Interaction logic for startup.xaml
    /// </summary>
    public partial class startup : Window
    {
        public startup()
        {
            InitializeComponent();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            index i = new index();
            try
            {
                i.Show();
            }
            catch (Exception exp) 
            {
                MessageBox.Show(exp.Message.ToString());
            }
                
            
        }

        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Close();
        }

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            string sTable = "lastState";
            string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            DataSet dataSetSurahNo;
            dataSetSurahNo = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter(@"SELECT TOP 1 surahNo,ayatNo FROM lastState ORDER BY sNo DESC", conn);
            da.Fill(dataSetSurahNo, sTable);
            DataTable dtable = dataSetSurahNo.Tables[sTable];
            DataRow drow;
            drow = dtable.Rows[0];

            ayatDisplay newWindow = new ayatDisplay();
            newWindow.Show();
            newWindow.surahCall(drow["surahNo"].ToString(), drow["ayatNo"].ToString());
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
