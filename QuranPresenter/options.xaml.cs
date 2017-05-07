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
    /// Interaction logic for options.xaml
    /// </summary>
    public partial class options : Window
    {

        private ayatDisplay ayatDisplay;
        public options()
        {
            InitializeComponent();
            
        }

        private void IntializeComboBox()
        {
            //foreach (System.Reflection.PropertyInfo prop in typeof(Color).GetProperties())
            //{
            //    if (prop.PropertyType.FullName == "System.Drawing.Color")
            //        backgroundColor.Items.Add(prop.Name);
            //}

            for (double i = 0.1; i <= 1; i += 0.1)
                opacityComboBox.Items.Add(i.ToString());

            gridlinesComboBox.Items.Add("None");
            gridlinesComboBox.Items.Add("Horizontal");


            DataContext = ayatDisplay.BindingContainer;
        }


        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            IntializeComboBox();
        }




        public options(ayatDisplay ayatDisplay)
        {
            InitializeComponent();
            this.ayatDisplay = ayatDisplay;
        }



        internal void sendView(DataGrid ayatDisplayView)
        {

        }

        private void backgroundColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {

                ayatDisplay.setBackgroundColor(backgroundColor.SelectedValue.ToString());
               
                string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                try
                {
                    using (OleDbConnection con = new OleDbConnection(conn))
                    {

                        string query = "UPDATE settings SET backgroundColor = @color where ID = '1'";
                        OleDbCommand cmd = new OleDbCommand(query, con);

                        cmd.Parameters.AddWithValue("@color", backgroundColor.SelectedValue.ToString());

                        con.Open();
                        // ... other parameters
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception )
                {
                    
                }
                
            }
            catch (Exception )
            {

            }


        }

        private void foregroundColor_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ayatDisplay.setForegroundColor(foregroundColor.SelectedValue.ToString());

                string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                try
                {
                    using (OleDbConnection con = new OleDbConnection(conn))
                    {

                        string query = "UPDATE settings SET textColor = @color where ID = '1'";
                        OleDbCommand cmd = new OleDbCommand(query, con);

                        cmd.Parameters.AddWithValue("@color", foregroundColor.SelectedValue.ToString());

                        con.Open();
                        // ... other parameters
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception )
                {
                    
                }
            }
            catch (Exception )
            {

            }

        }

        private void opacity_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ayatDisplay.setOpacity(opacityComboBox.SelectedValue.ToString());

                string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                using (OleDbConnection con = new OleDbConnection(conn))
                {
                    con.Open();
                    using (OleDbCommand cmd =
                        new OleDbCommand("UPDATE settings SET opacity=@color" +
                            " WHERE Id=@Id", con))
                    {
                        
                        cmd.Parameters.AddWithValue("@color", opacityComboBox.SelectedValue.ToString());
                        cmd.Parameters.AddWithValue("@Id", "1");
                        int rows = cmd.ExecuteNonQuery();
                        con.Close();
                        
                    }
                }
            }
            catch (Exception )
            {

            }
        }

        private void gridlinesComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ayatDisplay.setGridlines(gridlinesComboBox.SelectedValue.ToString());

                string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                try
                {
                    using (OleDbConnection con = new OleDbConnection(conn))
                    {

                        string query = "UPDATE settings SET gridlines = @color where ID ='1'";
                        OleDbCommand cmd = new OleDbCommand(query, con);

                        cmd.Parameters.AddWithValue("@color", gridlinesComboBox.SelectedValue.ToString());

                        con.Open();
                        // ... other parameters
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception )
                {
                  
                }


            }
            catch (Exception)
            {

            }
        }

        private void highlighterComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                ayatDisplay.setHighlighter(highlighterComboBox.SelectedValue.ToString());

                string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                try
                {
                    using (OleDbConnection con = new OleDbConnection(conn))
                    {

                        string query = "UPDATE settings SET rowSelectionColor = @color where ID = '1'";
                        OleDbCommand cmd = new OleDbCommand(query, con);

                        cmd.Parameters.AddWithValue("@color", highlighterComboBox.SelectedValue.ToString());

                        con.Open();
                        // ... other parameters
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception )
                {

                }
            }
            catch (Exception )
            {

            }
        }

        private void selectImageLink_Click(object sender, RoutedEventArgs e)
        {
            // Create OpenFileDialog 
            Microsoft.Win32.OpenFileDialog dlg = new Microsoft.Win32.OpenFileDialog();



            // Set filter for file extension and default file extension 
            dlg.DefaultExt = ".png";
            dlg.Filter = "PNG Files (*.png)|*.png|JPEG Files (*.jpeg)|*.jpeg|JPG Files (*.jpg)|*.jpg|GIF Files (*.gif)|*.gif";


            // Display OpenFileDialog by calling ShowDialog method 
            Nullable<bool> result = dlg.ShowDialog();


            // Get the selected file name and display in a TextBox 
            if (result == true)
            {
                // Open document 
                string filename = dlg.FileName;

                try
                {
                    ayatDisplay.setImageLink(filename);

                    string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(conn))
                        {

                            string query = "UPDATE settings SET backgroundImageLink = @color where ID = '1'";
                            OleDbCommand cmd = new OleDbCommand(query, con);

                            cmd.Parameters.AddWithValue("@color", filename);

                            con.Open();
                            // ... other parameters
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    catch (Exception)
                    {

                    }
                }
                catch (Exception)
                {

                }
            }
        }

       

    }
}
