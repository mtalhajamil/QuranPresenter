using System;
using System.Collections.Generic;
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
using System.Windows.Shapes;

namespace QuranPresenter
{
    /// <summary>
    /// Interaction logic for imageList.xaml
    /// </summary>
    public partial class imageList : Window
    {
        private string surahNo = "1";
        private string ayatNo = "1";
        public imageList()
        {
            InitializeComponent();
            picList.Focus();
        }

        private void populateListBox()
        {
            picList.Items.Clear();
            string folderLocation = @"C:\QuranPresenter\";
            //string folderLocation = @"C:\QuranPresenter\" + surahNo + "\\" + ayatNo;
            //PopulateListBox(picList, folderLocation, "*.png");
            //PopulateListBox(picList, folderLocation, "*.jpg");
            string newSName = Convert.ToInt32(surahNo).ToString("000");
            string newAName = Convert.ToInt32(ayatNo).ToString("000");
            string fileName;
            var filetype = new string[] { "*.png", "*.jpg" };

            DirectoryInfo dinfo = new DirectoryInfo(folderLocation);
            foreach (String ftype in filetype)
            {
                FileInfo[] Files = dinfo.GetFiles(ftype);
                foreach (FileInfo file in Files)
                {
                    fileName = file.Name;
                    if (fileName.Length > 6)
                    if (fileName.Substring(0, 7) == String.Concat(newSName, "_", newAName))
                        picList.Items.Add(file.Name);
                }
            }

        }
        //private void PopulateListBox(ListBox lsb, string Folder, string FileType)
        //{
        //    DirectoryInfo dinfo = new DirectoryInfo(Folder);
        //    FileInfo[] Files = dinfo.GetFiles(FileType);
        //    foreach (FileInfo file in Files)
        //    {
        //        lsb.Items.Add(file.Name);
        //    }
        //}

        private void Window_KeyDown_1(object sender, KeyEventArgs e)
        {

            if (e.Key == Key.Escape)
                this.Close();
            //var focusedControl = FocusManager.GetFocusedElement(this);
        }

        internal void sendSurahAyatNo(string sNo, string aNo)
        {
            surahNo = sNo;
            ayatNo = aNo;
            populateListBox();

        }

        private void picList_PreviewKeyDown_1(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Enter)
            {
                displayImage window = new displayImage();
                try
                {

                    window.Show();
                    window.displayImageFrom(picList.SelectedItem.ToString(), surahNo, ayatNo);
                }
                catch
                {
                    window.Close();
                }
            }
            if (e.Key == (Key.D1) | e.Key == (Key.D2) | e.Key == (Key.D3) | e.Key == (Key.D4) | e.Key == (Key.D5) | e.Key == (Key.D6) | e.Key == (Key.D7) | e.Key == (Key.D8) | e.Key == (Key.D9))
            {
                int number = Convert.ToInt32((e.Key.ToString()).Substring(1));

                try
                {
                    displayImage imageForm = new displayImage();
                    imageForm.displayImageFrom(picList.Items[number - 1].ToString(), surahNo, ayatNo);
                    imageForm.Show();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }


            }
        }

        private void Window_Loaded_1(object sender, RoutedEventArgs e)
        {
            var desktopWorkingArea = System.Windows.SystemParameters.WorkArea;
            this.Left = desktopWorkingArea.Right - this.Width;
            this.Top = desktopWorkingArea.Bottom - this.Height;
        }

        internal void GeneralDisplayCall()
        {
            picList.Items.Clear();
            string folderLocation = @"C:\QuranPresenter\";
            //string folderLocation = @"C:\QuranPresenter\" + surahNo + "\\" + ayatNo;
            //PopulateListBox(picList, folderLocation, "*.png");
            //PopulateListBox(picList, folderLocation, "*.jpg");
            string fileName;
            var filetype = new string[] { "*.png", "*.jpg", "*.jpeg", "*.gif" };

            DirectoryInfo dinfo = new DirectoryInfo(folderLocation);
            foreach (String ftype in filetype)
            {
                FileInfo[] Files = dinfo.GetFiles(ftype);
                foreach (FileInfo file in Files)
                {
                    fileName = file.Name;
                    if (fileName.Substring(0, 1) == "G" || fileName.Substring(0, 1) == "g")
                        picList.Items.Add(file.Name);
                }
            }
        }
    }
}
