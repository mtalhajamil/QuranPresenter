﻿#pragma checksum "..\..\index.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "EA8214945A70E6DD4F465ADD9EA0927D"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using QuranPresenter;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Shell;


namespace QuranPresenter {
    
    
    /// <summary>
    /// index
    /// </summary>
    public partial class index : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\index.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal QuranPresenter.index MainPage;
        
        #line default
        #line hidden
        
        
        #line 35 "..\..\index.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid surahNameView;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\index.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid parahView;
        
        #line default
        #line hidden
        
        
        #line 52 "..\..\index.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid manzilView;
        
        #line default
        #line hidden
        
        
        #line 57 "..\..\index.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid hizbView;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\index.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid totalAyatView;
        
        #line default
        #line hidden
        
        
        #line 87 "..\..\index.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label DetailSurahName;
        
        #line default
        #line hidden
        
        
        #line 89 "..\..\index.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label DetailAyatNo;
        
        #line default
        #line hidden
        
        
        #line 91 "..\..\index.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label DetailRukuNo;
        
        #line default
        #line hidden
        
        
        #line 93 "..\..\index.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label DetailParahNo;
        
        #line default
        #line hidden
        
        
        #line 95 "..\..\index.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label DetailTotalAyat;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/QuranPresenter;component/index.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\index.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.MainPage = ((QuranPresenter.index)(target));
            
            #line 5 "..\..\index.xaml"
            this.MainPage.KeyDown += new System.Windows.Input.KeyEventHandler(this.Window_KeyDown_1);
            
            #line default
            #line hidden
            return;
            case 2:
            
            #line 14 "..\..\index.xaml"
            ((System.Windows.Input.CommandBinding)(target)).Executed += new System.Windows.Input.ExecutedRoutedEventHandler(this.ResizeCommand);
            
            #line default
            #line hidden
            return;
            case 3:
            this.surahNameView = ((System.Windows.Controls.DataGrid)(target));
            
            #line 35 "..\..\index.xaml"
            this.surahNameView.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.surahNameView_PreviewKeyDown_1);
            
            #line default
            #line hidden
            
            #line 35 "..\..\index.xaml"
            this.surahNameView.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.surahNameView_MouseDown_1);
            
            #line default
            #line hidden
            
            #line 35 "..\..\index.xaml"
            this.surahNameView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.surahNameView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 4:
            this.parahView = ((System.Windows.Controls.DataGrid)(target));
            
            #line 47 "..\..\index.xaml"
            this.parahView.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.parahView_PreviewKeyDown_1);
            
            #line default
            #line hidden
            
            #line 47 "..\..\index.xaml"
            this.parahView.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.parahView_MouseDown_1);
            
            #line default
            #line hidden
            
            #line 47 "..\..\index.xaml"
            this.parahView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.parahView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 5:
            this.manzilView = ((System.Windows.Controls.DataGrid)(target));
            
            #line 52 "..\..\index.xaml"
            this.manzilView.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.manzilView_PreviewKeyDown_1);
            
            #line default
            #line hidden
            
            #line 52 "..\..\index.xaml"
            this.manzilView.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.manzilView_MouseDown_1);
            
            #line default
            #line hidden
            
            #line 52 "..\..\index.xaml"
            this.manzilView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.manzilView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 6:
            this.hizbView = ((System.Windows.Controls.DataGrid)(target));
            
            #line 57 "..\..\index.xaml"
            this.hizbView.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.hizbView_PreviewKeyDown_1);
            
            #line default
            #line hidden
            
            #line 57 "..\..\index.xaml"
            this.hizbView.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.hizbView_MouseDown_1);
            
            #line default
            #line hidden
            
            #line 57 "..\..\index.xaml"
            this.hizbView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.hizbView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 7:
            this.totalAyatView = ((System.Windows.Controls.DataGrid)(target));
            
            #line 62 "..\..\index.xaml"
            this.totalAyatView.PreviewKeyDown += new System.Windows.Input.KeyEventHandler(this.totalAyatView_PreviewKeyDown_1);
            
            #line default
            #line hidden
            
            #line 62 "..\..\index.xaml"
            this.totalAyatView.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.totalAyatView_MouseDown_1);
            
            #line default
            #line hidden
            
            #line 62 "..\..\index.xaml"
            this.totalAyatView.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.totalAyatView_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 8:
            this.DetailSurahName = ((System.Windows.Controls.Label)(target));
            return;
            case 9:
            this.DetailAyatNo = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.DetailRukuNo = ((System.Windows.Controls.Label)(target));
            return;
            case 11:
            this.DetailParahNo = ((System.Windows.Controls.Label)(target));
            return;
            case 12:
            this.DetailTotalAyat = ((System.Windows.Controls.Label)(target));
            return;
            case 13:
            
            #line 98 "..\..\index.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_1);
            
            #line default
            #line hidden
            return;
            case 14:
            
            #line 125 "..\..\index.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_2);
            
            #line default
            #line hidden
            return;
            case 15:
            
            #line 152 "..\..\index.xaml"
            ((System.Windows.Controls.Button)(target)).Click += new System.Windows.RoutedEventHandler(this.Button_Click_3);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

