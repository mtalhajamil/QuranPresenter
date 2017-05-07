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
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Threading;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.Windows.Controls.Primitives;
using System.Data.OleDb;

namespace QuranPresenter
{
    /// <summary>
    /// Interaction logic for logs.xaml
    /// </summary>
    public partial class logs : Window
    {
        public logs()
        {
            InitializeComponent();
            FillDataGrid();
        }

        private void FillDataGrid()
        {
            string sTable = "lastState";
            string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string CmdString = string.Empty;
            using (OleDbConnection con = new OleDbConnection(conn))
            {
                CmdString = @"select * from lastState ORDER BY sNo DESC";
                OleDbCommand cmd = new OleDbCommand(CmdString, con);
                OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable(sTable);
                sda.Fill(dt);
                logView.ItemsSource = dt.DefaultView;
            }
        }

        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Escape)
                this.Close();
            //var focusedControl = FocusManager.GetFocusedElement(this);
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            using (OleDbConnection con = new OleDbConnection(conn))
            {
                string query = "DELETE FROM lastState";

                OleDbCommand cmd = new OleDbCommand(query, con);

                con.Open();
                // ... other parameters
                cmd.ExecuteNonQuery();
                con.Close();
            }
            
        }
    }
}
