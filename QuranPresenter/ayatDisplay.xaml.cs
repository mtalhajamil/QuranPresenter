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
using System.ComponentModel;

namespace QuranPresenter
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class ayatDisplay : Window
    {
        public static RoutedCommand NextSurah = new RoutedCommand();
        public static RoutedCommand PreviousSurah = new RoutedCommand();
        public static RoutedCommand AnnounceFocus = new RoutedCommand();
        public static RoutedCommand SurahFocus = new RoutedCommand();
        public static RoutedCommand DisplayAnnounce = new RoutedCommand();
        private string surahNo;
        private string ayatNo;
        private string sTable = "Ayat";
        private string zoomIn = "1";



        public ayatDisplay()
        {
            InitializeComponent();
            InitializeComboBoxes();
            displaySettings();

            DataContext = ayatDisplay.BindingContainer;
            
            
            NextSurah.InputGestures.Add(new KeyGesture(Key.N, ModifierKeys.Alt));
            PreviousSurah.InputGestures.Add(new KeyGesture(Key.P, ModifierKeys.Alt));
            AnnounceFocus.InputGestures.Add(new KeyGesture(Key.A, ModifierKeys.Alt));
            SurahFocus.InputGestures.Add(new KeyGesture(Key.S, ModifierKeys.Alt));
            DisplayAnnounce.InputGestures.Add(new KeyGesture(Key.D, ModifierKeys.Alt));
        }

        private void displaySettings()
        {
            string sTable = "settings";
            string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            string CmdString = string.Empty;
            using (OleDbConnection con = new OleDbConnection(conn))
            {
                CmdString = @"select * from settings where ID = '1'";
                OleDbCommand cmd = new OleDbCommand(CmdString, con);
                OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                DataTable dt = new DataTable(sTable);
                sda.Fill(dt);
                DataRow drow = dt.Rows[0];

        //        var data = new string[] { drow["backgroundImageLink"].ToString(), drow["textColor"].ToString(), drow["opacity"].ToString() };

                BindingContainer.BackgroundColor = drow["backgroundColor"].ToString();
                BindingContainer.ForegroundColor = drow["textColor"].ToString();
                BindingContainer.Opacity = drow["opacity"].ToString();
                BindingContainer.Gridlines = drow["gridlines"].ToString();
                BindingContainer.Highlighter = drow["rowSelectionColor"].ToString();
                BindingContainer.HighlightText = drow["selectedTextColor"].ToString();
                BindingContainer.ImageLink = drow["backgroundImageLink"].ToString();
                ayatDisplayView.FontSize = Convert.ToInt32(drow["textSize"].ToString());
            }
        }

        private void InitializeComboBoxes()
        {
            for (int i = 10; i<=100 ; i+=10)
                textFontSize.Items.Add(i.ToString());

            //listSytemFonts.ItemsSource = Fonts.SystemFontFamilies;
            
        }

        private void Next(object sender, ExecutedRoutedEventArgs e)
        {
            if ((Convert.ToInt32(surahNo) + 1) > 114)
                MessageBox.Show("This is the last Surah");
            else
            {
                surahNo = (Convert.ToInt32(surahNo) + 1).ToString();
                FillDataGrid((Convert.ToInt32(surahNo)).ToString(), "1");
                selectCell();
            }
        }

        private void Previous(object sender, ExecutedRoutedEventArgs e)
        {
            if ((Convert.ToInt32(surahNo) - 1) < 1)
                    MessageBox.Show("This is the first Surah");
                else
                {
                    surahNo = (Convert.ToInt32(surahNo) - 1).ToString();
                    FillDataGrid((Convert.ToInt32(surahNo)).ToString(), "1");
                    selectCell();
                }
        }

        private void Announce(object sender, ExecutedRoutedEventArgs e)
        {
            textAnnounce.Focus();
            TopMenuArea.Opacity = 100;
        }

        private void Surah(object sender, ExecutedRoutedEventArgs e)
        {
            ayatDisplayView.Focus();
            ayatDisplayView.SelectedItem = ayatDisplayView.Items[Convert.ToInt32(textAyatNo.Text)];
            ayatDisplayView.ScrollIntoView(ayatDisplayView.Items[Convert.ToInt32(textAyatNo.Text)]);
            ayatDisplayView.CurrentCell = ayatDisplayView.SelectedCells[0];
            TopMenuArea.Opacity = 0;
        }


        private void Display(object sender, ExecutedRoutedEventArgs e)
        {
            
            announcement win = new announcement();
            win.Show();
            win.displayAnnouncement(textAnnounce.Text.ToString());
        }


        private void FillDataGrid(string surahNo, string focus)
        {
            try
            {

                zoomIn = focus;
                textFontSize.Text = ayatDisplayView.FontSize.ToString();
                string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                string CmdString = string.Empty;
                using (OleDbConnection con = new OleDbConnection(conn))
                {
                    CmdString = @"select IndoPakText from Ayat where SurahNo =" + surahNo + " ORDER BY RecordNo ASC";
                    OleDbCommand cmd = new OleDbCommand(CmdString, con);
                    OleDbDataAdapter sda = new OleDbDataAdapter(cmd);
                    DataTable dt = new DataTable(sTable);
                    sda.Fill(dt);

                    DataRow dr = dt.NewRow();
                    if (surahNo == "9")
                        dr["IndoPakText"] = " ";
                    else
                        dr["IndoPakText"] = " بِسْمِ اللّهِ الرَّحْمَنِ الرَّحِيمِ ";

                    dt.Rows.InsertAt(dr, 0);
                    ayatDisplayView.ItemsSource = dt.DefaultView;
                    setTextBoxes(surahNo, zoomIn, conn);
                }
            }
            catch (Exception) 
            {
                MessageBox.Show("Keep Values Nummeric & In Limits");
            }
            
        }

        private void setTextBoxes(string surahNo, string focus, string conn)
        {
            try
            {
                DataSet dataSet;
                dataSet = new DataSet();
                OleDbDataAdapter da = new OleDbDataAdapter("select distinct(SurahName) from ayat where SurahNo =" + surahNo + ";", conn);
                da.Fill(dataSet, sTable);
                DataTable dtable = dataSet.Tables[sTable];
                DataRow drow;
                drow = dtable.Rows[0];
                textSurahName.Content = drow["SurahName"].ToString();

                dataSet = new DataSet();
                da = new OleDbDataAdapter("select RukuSurah from ayat where SurahNo =" + surahNo + "AND AiyahNo =" + focus, conn);
                da.Fill(dataSet, sTable);
                dtable = dataSet.Tables[sTable];
                drow = dtable.Rows[0];
                textRukuNo.Text = drow["RukuSurah"].ToString();


                textSurahNo.Text = surahNo;
                textAyatNo.Text = focus;
                zoomIn = focus;
                
            }
            catch
            {
                textAyatNo.Text = "";
                textRukuNo.Text = "";
            }
        }

        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Escape)
            {
                string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

                try
                {
                    using (OleDbConnection con = new OleDbConnection(conn))
                    {
                        string query = "INSERT INTO lastState (surahNo, ayatNo)";
                        query += " VALUES (@surahNo, @ayahNo)";
                        OleDbCommand cmd = new OleDbCommand(query, con);

                        cmd.Parameters.AddWithValue("@surahNo", surahNo);
                        cmd.Parameters.AddWithValue("@ayahNo", (ayatDisplayView.SelectedIndex).ToString());
                        //cmd.Parameters.AddWithValue("@stateTime", DateTime.Now);
                        con.Open();
                        // ... other parameters
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch(Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
                this.Close();
            }
        }

        internal void surahCall(string sNo, string aNo)
        {
            surahNo = sNo;
            zoomIn = aNo;
            FillDataGrid(surahNo, aNo);

        }

        internal void parahCall(string pNo)
        {

            string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            DataSet dataSetSurahNo;
            dataSetSurahNo = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter("select SurahNo, AiyahNo from ayat where ParahNo =" + pNo + " order by RecordNo ASC;", conn);
            da.Fill(dataSetSurahNo, sTable);
            DataTable dtable = dataSetSurahNo.Tables[sTable];
            DataRow drow;
            drow = dtable.Rows[0];
            surahNo = drow["SurahNo"].ToString();
            ayatNo = drow["AiyahNo"].ToString();
            zoomIn = ayatNo;
            FillDataGrid(surahNo, ayatNo);
        }

        internal void manzilCall(string mNo)
        {

            string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            DataSet dataSetSurahNo;
            dataSetSurahNo = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter("select SurahNo, AiyahNo from ayat where Manzil =" + mNo + " order by RecordNo ASC;", conn);
            da.Fill(dataSetSurahNo, sTable);
            DataTable dtable = dataSetSurahNo.Tables[sTable];
            DataRow drow;
            drow = dtable.Rows[0];
            surahNo = drow["SurahNo"].ToString();
            ayatNo = drow["AiyahNo"].ToString();
            zoomIn = ayatNo;
            FillDataGrid(surahNo, ayatNo);
        }

        internal void hizbCall(string hNo)
        {

            string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            DataSet dataSetSurahNo;
            dataSetSurahNo = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter("select SurahNo, AiyahNo from ayat where Hizb =" + hNo + " order by RecordNo ASC;", conn);
            da.Fill(dataSetSurahNo, sTable);
            DataTable dtable = dataSetSurahNo.Tables[sTable];
            DataRow drow;
            drow = dtable.Rows[0];
            surahNo = drow["SurahNo"].ToString();
            ayatNo = drow["AiyahNo"].ToString();
            zoomIn = ayatNo;
            FillDataGrid(surahNo, ayatNo);
        }

        internal void totalAyatCall(string aNo)
        {

            string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            DataSet dataSetSurahNo;
            dataSetSurahNo = new DataSet();
            OleDbDataAdapter da = new OleDbDataAdapter("select SurahNo, AiyahNo from ayat where RecordNo =" + aNo + " order by RecordNo ASC;", conn);
            da.Fill(dataSetSurahNo, sTable);
            DataTable dtable = dataSetSurahNo.Tables[sTable];
            DataRow drow;
            drow = dtable.Rows[0];
            surahNo = drow["SurahNo"].ToString();
            ayatNo = drow["AiyahNo"].ToString();
            zoomIn = ayatNo;
            FillDataGrid(surahNo, ayatNo);
        }

        private void ayatDisplayView_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.F3)
            {
                try
                {
                    imageList displayImageList = new imageList();
                    displayImageList.sendSurahAyatNo(surahNo, (ayatDisplayView.SelectedIndex).ToString());
                    displayImageList.Show();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }

            }
            else if (e.Key == Key.F2)
            {
                try
                {
                    imageList displayImageList = new imageList();
                    displayImageList.GeneralDisplayCall();
                    displayImageList.Show();
                }
                catch (Exception er)
                {
                    MessageBox.Show(er.Message);
                }

            }

            else if (e.Key == Key.Enter )
            {
                try
                {
                    ayatDisplayView.SelectedIndex = ayatDisplayView.SelectedIndex + 1;
                }
                catch (Exception )
                {
                    MessageBox.Show("End Of The Surah");
                }

            }

            else if (e.Key == Key.Space || e.Key == Key.Right)
            {
                try
                {
                    ayatDisplayView.SelectedIndex = ayatDisplayView.SelectedIndex + 1;
                    ayatDisplayView.CurrentCell = ayatDisplayView.SelectedCells[0];
                }
                catch (Exception )
                {
                    MessageBox.Show("End Of The Surah");
                }

            }

            else if (e.Key == Key.Left)
            {
                try
                {
                    if (ayatDisplayView.SelectedIndex >= 1)
                    {
                    ayatDisplayView.SelectedIndex = ayatDisplayView.SelectedIndex - 1;
                    ayatDisplayView.CurrentCell = ayatDisplayView.SelectedCells[0];
                    }
                }
                catch (Exception)
                {
                    MessageBox.Show("End Of The Surah");
                }

            }
            
        }

        private void textSurahNo_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                    if (Convert.ToInt32(textSurahNo.Text) > 114 || Convert.ToInt32(textSurahNo.Text) < 1)
                        MessageBox.Show("Insert Value Between 1-114");
                    else
                    {
                        surahNo = textSurahNo.Text;
                        FillDataGrid(textSurahNo.Text, "0");
                        ayatDisplayView.Focus();
                        selectCell();
                    }
            }
            catch(Exception )
            {
                MessageBox.Show("Please Enter Numeric Values In Surah Limits");
            }
            
        }

        private void ayatDisplayView_KeyUp_1(object sender, KeyEventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            setTextBoxes(surahNo, (ayatDisplayView.SelectedIndex).ToString(), conn);
            

        }

        private void textFontSize_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    ayatDisplayView.FontSize = Convert.ToInt32(textFontSize.Text);

                    string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    try
                    {
                        using (OleDbConnection con = new OleDbConnection(conn))
                        {

                            string query = "UPDATE settings SET textSize = @color where ID = '1'";
                            OleDbCommand cmd = new OleDbCommand(query, con);

                            cmd.Parameters.AddWithValue("@color", textFontSize.SelectedValue.ToString());

                            con.Open();
                            // ... other parameters
                            cmd.ExecuteNonQuery();
                            con.Close();
                        }
                    }
                    catch (Exception )
                    {
                       // MessageBox.Show(exp.Message);
                    }
                }
            }
            catch (Exception )
            {
                MessageBox.Show("Please Enter Numeric Values In Limits");
            }
        }

        private void textAyatNo_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {

                    FillDataGrid(surahNo, (Convert.ToInt32(textAyatNo.Text) - 1).ToString());
                    zoomIn = textAyatNo.Text;
                    ayatDisplayView.Focus();
                    selectCell();

                }
            }
            catch (Exception )
            {
                MessageBox.Show("Please Enter Numeric Values In Limits");
            }
        }


        private void ayatDisplayView_PreviewMouseDown_1(object sender, MouseButtonEventArgs e)
        {
            string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
            setTextBoxes(surahNo, (ayatDisplayView.SelectedIndex).ToString(), conn);
        }

        private void textRukuNo_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            try
            {
                if (e.Key == Key.Enter)
                {
                    string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                    DataSet dataset;
                    dataset = new DataSet();
                    OleDbDataAdapter da = new OleDbDataAdapter("select AiyahNo from ayat where RukuSurah =" + textRukuNo.Text + "AND SurahNo =" + surahNo, conn);
                    da.Fill(dataset, sTable);
                    DataTable dtable = dataset.Tables[sTable];
                    DataRow drow;
                    drow = dtable.Rows[0];
                    ayatNo = drow["AiyahNo"].ToString();
                    FillDataGrid(surahNo, ayatNo);
                    zoomIn = (Convert.ToInt32(ayatNo) - 1).ToString();
                    ayatDisplayView.Focus();
                    selectCell();


                }
            }
            catch(Exception)
            {
                MessageBox.Show("Keep Numeric & In Surah Range");
            }
        }

       /* private void listSytemFonts_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            ayatDisplayView.FontFamily = (System.Windows.Media.FontFamily)listSytemFonts.SelectedValue;
            //MessageBox.Show(ayatDisplayView.FontFamily.ToString());
        }*/

        private void textAnnounce_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                ayatDisplayView.Focus();
                ayatDisplayView.SelectedItem = ayatDisplayView.Items[Convert.ToInt32(textAyatNo.Text)];
                ayatDisplayView.ScrollIntoView(ayatDisplayView.Items[Convert.ToInt32(textAyatNo.Text)]);
                ayatDisplayView.CurrentCell = ayatDisplayView.SelectedCells[0];
                
                announcement win = new announcement();
                win.Show();
                win.displayAnnouncement(textAnnounce.Text.ToString());
                
            }
        }

        private void ayatDisplayView_Loaded(object sender, RoutedEventArgs e)
        {
            try
            {
                ayatDisplayView.UpdateLayout();
                Dispatcher.BeginInvoke((Action)(() =>{
                    var firstCell = ayatDisplayView.Items[0];
                    if (firstCell != null)
                    {
                        selectCell();
                    }
                }));
            }
            catch (Exception exp) {
                Console.WriteLine(exp.Message);
            }
            
        }

        private void selectCell()
        {
            try
            {
                int numZoomIn = Convert.ToInt32(zoomIn);
                ayatDisplayView.Focus();
                ayatDisplayView.SelectedIndex = numZoomIn;
                
                //ayatDisplayView.SelectedItem = ayatDisplayView.Items[numZoomIn];
                ayatDisplayView.UpdateLayout();
                ayatDisplayView.ScrollIntoView(ayatDisplayView.Items[numZoomIn]);
                
                ayatDisplayView.CurrentCell = ayatDisplayView.SelectedCells[0];

            }
            catch (Exception)
            {
                MessageBox.Show("Keep The Values In Range Of Surah");
            }
        }

        private void ayatDisplayView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
        }

        private void textFontSize_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string size = textFontSize.SelectedValue.ToString();
                ayatDisplayView.FontSize = Convert.ToInt32(size);

                string conn = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
                try
                {
                    using (OleDbConnection con = new OleDbConnection(conn))
                    {

                        string query = "UPDATE settings SET textSize = @color where ID = '1'";
                        OleDbCommand cmd = new OleDbCommand(query, con);

                        cmd.Parameters.AddWithValue("@color", textFontSize.SelectedValue.ToString());

                        con.Open();
                        // ... other parameters
                        cmd.ExecuteNonQuery();
                        con.Close();
                    }
                }
                catch (Exception exp)
                {
                    MessageBox.Show(exp.Message);
                }
            }
            catch (Exception ) 
            {

            }
        }

        private void Settings_Click(object sender, RoutedEventArgs e)
        {
            options cw = new options(this);
            cw.Show();
            //options settings = new options();
            //settings.sendView(ayatDisplayView);
            //settings.Show();
        }

        

        private static MyBindableObject _bindingContainer = new MyBindableObject();
        public static MyBindableObject BindingContainer
        {
            get { return _bindingContainer; }
        }

        public static void setBackgroundColor(string backgroundColor)
        {
            // use this anywhere to update the value
            ayatDisplay.BindingContainer.BackgroundColor = backgroundColor;
        }

        public static void setForegroundColor(string foregroundColor)
        {
            // use this anywhere to update the value
            ayatDisplay.BindingContainer.ForegroundColor = foregroundColor;
        }

        public static void setOpacity(string opacity)
        {
            // use this anywhere to update the value
            ayatDisplay.BindingContainer.Opacity = opacity;
        }

        public static void setGridlines(string gridlines)
        {
            // use this anywhere to update the value
            ayatDisplay.BindingContainer.Gridlines = gridlines;
        }

        public static void setHighlighter(string highlighter)
        {
            // use this anywhere to update the value
            ayatDisplay.BindingContainer.Highlighter = highlighter;
        }

        public static void setHighlightText(string highlightText)
        {
            // use this anywhere to update the value
            ayatDisplay.BindingContainer.HighlightText = highlightText;
        }

        public static void setImageLink(string imageLink)
        {
            // use this anywhere to update the value
            ayatDisplay.BindingContainer.ImageLink = imageLink;
        }
    }

    public class MyBindableObject : INotifyPropertyChanged
    {

        private string _backgroundColor;
        public string BackgroundColor
        {
            get { return _backgroundColor; }
            set
            {
                if (_backgroundColor == value)
                    return;
                _backgroundColor = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("BackgroundColor"));
            }
        }

        private string _foregroundColor;
        public string ForegroundColor
        {
            get { return _foregroundColor; }
            set
            {
                if (_foregroundColor == value)
                    return;
                _foregroundColor = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ForegroundColor"));
            }
        }

        private string _opacity;
        public string Opacity
        {
            get { return _opacity; }
            set
            {
                if (_opacity == value)
                    return;
                _opacity = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Opacity"));
            }
        }

        private string _gridline;
        public string Gridlines
        {
            get { return _gridline; }
            set
            {
                if (_gridline == value)
                    return;
                _gridline = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Gridlines"));
            }
        }

        private string _highlighter;
        public string Highlighter
        {
            get { return _highlighter; }
            set
            {
                if (_highlighter == value)
                    return;
                _highlighter = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("Highlighter"));
            }
        }

        private string _highlightText;
        public string HighlightText
        {
            get { return _highlightText; }
            set
            {
                if (_highlightText == value)
                    return;
                _highlightText = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("HighlightText"));
            }
        }

        private string _imageLink;
        public string ImageLink
        {
            get { return _imageLink; }
            set
            {
                if (_imageLink == value)
                    return;
                _imageLink = value;

                if (PropertyChanged != null)
                    PropertyChanged(this, new PropertyChangedEventArgs("ImageLink"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }

    public static class SendKeys
    {
        /// <summary>
        ///   Sends the specified key.
        /// </summary>
        /// <param name="key">The key.</param>
        public static void Send(Key key)
        {
            if (Keyboard.PrimaryDevice != null)
            {
                if (Keyboard.PrimaryDevice.ActiveSource != null)
                {
                    var e1 = new KeyEventArgs(Keyboard.PrimaryDevice, Keyboard.PrimaryDevice.ActiveSource, 0, Key.Down) { RoutedEvent = Keyboard.KeyDownEvent };
                    InputManager.Current.ProcessInput(e1);
                }
            }
        }
    }
}
