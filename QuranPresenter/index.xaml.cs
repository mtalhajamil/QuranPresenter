using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.IO;
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
using System.Data.OleDb;

namespace QuranPresenter
{
    /// <summary>
    /// Interaction logic for index.xaml
    /// </summary>
    public partial class index : Window
    {

        public static RoutedCommand Resize = new RoutedCommand();
        private DataTable dt;
        public index()
        {

            InitializeComponent();
            InitGridViews();
            FolderCreation();
            this.ShowInTaskbar = true;
            Resize.InputGestures.Add(new KeyGesture(Key.Enter, ModifierKeys.Alt));

        }

        private void ResizeCommand(object sender, ExecutedRoutedEventArgs e)
        {
            if (this.WindowStyle == WindowStyle.SingleBorderWindow)
            {
                this.WindowStyle = WindowStyle.None;
                this.WindowState = WindowState.Maximized;
                this.ResizeMode = ResizeMode.NoResize;
            }
            else
            {
                this.WindowStyle = WindowStyle.SingleBorderWindow;
            }
        }

        private void FolderCreation()
        {
            try
            {
                Directory.CreateDirectory("c:\\QuranPresenter\\");
                //string sTable = "Ayat";
                //string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                //DataSet dataSetAyatCount = new DataSet();
                //OleDbDataAdapter da = new OleDbDataAdapter("select Distinct(SurahNo),TotalAyah from ayat order by SurahNo asc;", conn);
                //da.Fill(dataSetAyatCount, sTable);
                //DataTable dtable = dataSetAyatCount.Tables[sTable];
                //DataRow drow;
                //string totalAyah;
                //int iTotalAyat;

                //string directoryPath;
                //string subDirectoryPath;
                //for (int i = 1; i <= 114; i++)
                //{
                //    directoryPath = "c:\\QuranPresenter\\" + i + "\\";
                //    Directory.CreateDirectory(directoryPath);

                //    drow = dtable.Rows[i - 1];
                //    totalAyah = drow["TotalAyah"].ToString();
                //    iTotalAyat = Convert.ToInt32(totalAyah);

                //    //MessageBox.Show(iTotalAyat.ToString());

                //    for (int innerLoop = 1; innerLoop <= iTotalAyat; innerLoop++)
                //    {
                //        subDirectoryPath = "c:\\QuranPresenter\\" + i + "\\" + innerLoop + "\\";
                //        Directory.CreateDirectory(subDirectoryPath);
                //    }
                //}

            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }

        private void InitGridViews()
        {
            try
            {
                string sTable = "Ayat";
                string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                string CmdString = string.Empty;
                using (OleDbConnection con = new OleDbConnection(conn))
                {
                    CmdString = @"select distinct(SurahNo),SurahName from ayat order by SurahNo asc";
                    OleDbCommand cmd = new OleDbCommand(CmdString, con);
                    OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                    dt = new DataTable(sTable);
                    sda.Fill(dt);
                    

                    surahNameView.ItemsSource = dt.DefaultView;

                    CmdString = @"select distinct(ParahNo) from ayat order by ParahNo asc";
                    cmd = new OleDbCommand(CmdString, con);
                    sda = new OleDbDataAdapter(cmd);
                    dt = new DataTable(sTable);
                    sda.Fill(dt);
                    

                    parahView.ItemsSource = dt.DefaultView;

                    CmdString = @"select distinct(Manzil) from ayat order by Manzil asc";
                    cmd = new OleDbCommand(CmdString, con);
                    sda = new OleDbDataAdapter(cmd);
                    dt = new DataTable(sTable);
                    sda.Fill(dt);
                    

                    manzilView.ItemsSource = dt.DefaultView;


                    CmdString = @"select distinct(Hizb) from ayat order by Hizb asc";
                    cmd = new OleDbCommand(CmdString, con);
                    sda = new OleDbDataAdapter(cmd);
                    dt = new DataTable(sTable);
                    sda.Fill(dt);
                    

                    hizbView.ItemsSource = dt.DefaultView;


                    CmdString = @"select distinct(RecordNo) from ayat order by RecordNo asc";
                    cmd = new OleDbCommand(CmdString, con);
                    sda = new OleDbDataAdapter(cmd);
                    dt = new DataTable(sTable);
                    sda.Fill(dt);
                    

                    totalAyatView.ItemsSource = dt.DefaultView;
                }
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message.ToString());
            }
        }

        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Escape)
                this.Close();
            //var focusedControl = FocusManager.GetFocusedElement(this);
        }

        private void surahNameView_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //  MessageBox.Show(FocusManager.GetFocusedElement(this).ToString());
                ayatDisplay window = new ayatDisplay();
                window.surahCall((surahNameView.SelectedIndex + 1).ToString(), "1");
                window.Show();
            }
        }

        private void parahView_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //MessageBox.Show((parahView.SelectedIndex + 1).ToString());
                ayatDisplay window = new ayatDisplay();
                window.Show();
                window.parahCall((parahView.SelectedIndex + 1).ToString());

            }
        }

        private void manzilView_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //  MessageBox.Show(FocusManager.GetFocusedElement(this).ToString());
                ayatDisplay window = new ayatDisplay();
                window.Show();
                window.manzilCall((manzilView.SelectedIndex + 1).ToString());

            }
        }

        private void hizbView_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //  MessageBox.Show(FocusManager.GetFocusedElement(this).ToString());
                ayatDisplay window = new ayatDisplay();
                window.Show();
                window.hizbCall((hizbView.SelectedIndex + 1).ToString());

            }
        }

        private void totalAyatView_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                //  MessageBox.Show(FocusManager.GetFocusedElement(this).ToString());
                ayatDisplay window = new ayatDisplay();
                window.Show();
                window.totalAyatCall((totalAyatView.SelectedIndex + 1).ToString());

            }
        }

        private void surahNameView_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            ayatDisplay window = new ayatDisplay();
            window.Show();
            window.surahCall((surahNameView.SelectedIndex + 1).ToString(), "1"); 
        }

        private void parahView_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            ayatDisplay window = new ayatDisplay();
            window.Show();
            window.parahCall((parahView.SelectedIndex + 1).ToString());
        }

        private void manzilView_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            ayatDisplay window = new ayatDisplay();
            window.Show();
            window.manzilCall((manzilView.SelectedIndex + 1).ToString());
        }

        private void hizbView_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            ayatDisplay window = new ayatDisplay();
            window.Show();
            window.hizbCall((hizbView.SelectedIndex + 1).ToString());
        }

        private void totalAyatView_MouseDown_1(object sender, MouseButtonEventArgs e)
        {
            ayatDisplay window = new ayatDisplay();
            window.Show();
            window.totalAyatCall((totalAyatView.SelectedIndex + 1).ToString());
        }

        private void surahNameView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string sTable = "Ayat";
            string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            DataSet dataSetSurahNo;
            dataSetSurahNo = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter("select SurahName, AiyahNo, RukuSurah, ParahNo, TotalAyah  from ayat where SurahNo =" + (surahNameView.SelectedIndex + 1) + ";", conn);
            da.Fill(dataSetSurahNo, sTable);
            DataTable dtable = dataSetSurahNo.Tables[sTable];
            DataRow drow;
            drow = dtable.Rows[0];
            DetailSurahName.Content = drow["SurahName"].ToString();
            DetailAyatNo.Content = drow["AiyahNo"].ToString();
            DetailRukuNo.Content = drow["RukuSurah"].ToString();
            DetailParahNo.Content = drow["ParahNo"].ToString();
            DetailTotalAyat.Content = drow["TotalAyah"].ToString();
        }

        private void parahView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string sTable = "Ayat";
            string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            DataSet dataSetSurahNo;
            dataSetSurahNo = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter("select SurahName, AiyahNo, RukuSurah, ParahNo, TotalAyah  from ayat where ParahNo =" + (parahView.SelectedIndex + 1) + " order by RecordNo ASC", conn);
            da.Fill(dataSetSurahNo, sTable);
            DataTable dtable = dataSetSurahNo.Tables[sTable];
            DataRow drow;
            drow = dtable.Rows[0];
            DetailSurahName.Content = drow["SurahName"].ToString();
            DetailAyatNo.Content = drow["AiyahNo"].ToString();
            DetailRukuNo.Content = drow["RukuSurah"].ToString();
            DetailParahNo.Content = drow["ParahNo"].ToString();
            DetailTotalAyat.Content = drow["TotalAyah"].ToString();
        }

        private void manzilView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string sTable = "Ayat";
            string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            DataSet dataSetSurahNo;
            dataSetSurahNo = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter("select SurahName, AiyahNo, RukuSurah, ParahNo, TotalAyah  from ayat where Manzil =" + (manzilView.SelectedIndex + 1) + " order by RecordNo ASC;", conn);
            da.Fill(dataSetSurahNo, sTable);
            DataTable dtable = dataSetSurahNo.Tables[sTable];
            DataRow drow;
            drow = dtable.Rows[0];
            DetailSurahName.Content = drow["SurahName"].ToString();
            DetailAyatNo.Content = drow["AiyahNo"].ToString();
            DetailRukuNo.Content = drow["RukuSurah"].ToString();
            DetailParahNo.Content = drow["ParahNo"].ToString();
            DetailTotalAyat.Content = drow["TotalAyah"].ToString();
        }

        private void hizbView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string sTable = "Ayat";
            string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            DataSet dataSetSurahNo;
            dataSetSurahNo = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter("select SurahName, AiyahNo, RukuSurah, ParahNo, TotalAyah  from ayat where Hizb =" + (hizbView.SelectedIndex + 1) + " order by RecordNo ASC;", conn);
            da.Fill(dataSetSurahNo, sTable);
            DataTable dtable = dataSetSurahNo.Tables[sTable];
            DataRow drow;
            drow = dtable.Rows[0];
            DetailSurahName.Content = drow["SurahName"].ToString();
            DetailAyatNo.Content = drow["AiyahNo"].ToString();
            DetailRukuNo.Content = drow["RukuSurah"].ToString();
            DetailParahNo.Content = drow["ParahNo"].ToString();
            DetailTotalAyat.Content = drow["TotalAyah"].ToString();
        }

        private void totalAyatView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            string sTable = "Ayat";
            string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            DataSet dataSetSurahNo;
            dataSetSurahNo = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter("select SurahName, AiyahNo, RukuSurah, ParahNo, TotalAyah  from ayat where RecordNo =" + (totalAyatView.SelectedIndex + 1) + ";", conn);
            da.Fill(dataSetSurahNo, sTable);
            DataTable dtable = dataSetSurahNo.Tables[sTable];
            DataRow drow;
            drow = dtable.Rows[0];
            DetailSurahName.Content = drow["SurahName"].ToString();
            DetailAyatNo.Content = drow["AiyahNo"].ToString();
            DetailRukuNo.Content = drow["RukuSurah"].ToString();
            DetailParahNo.Content = drow["ParahNo"].ToString();
            DetailTotalAyat.Content = drow["TotalAyah"].ToString();
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
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

        private void Button_Click_2(object sender, RoutedEventArgs e)
        {
            logs newWindow = new logs();
            newWindow.Show();
        }

        private void Button_Click_3(object sender, RoutedEventArgs e)
        {
            shortcuts newWindow = new shortcuts();
            newWindow.Show();
        }


        /*  protected override void OnKeyDown(KeyEventArgs args)
          {
              base.OnKeyDown(args);

              if (args.Key == Key.N)
                  MessageBox.Show(FocusManager.GetFocusedElement(Application.Current.Windows[0]).ToString());
          }*/



    }
}
