   M S B A M L   `   `   `  ����O  Kmscorlib, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e0891&clr-namespace:System;assembly=mscorlibSystem  5   	   I EQuranPresenter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:QuranPresenterQuranPresenter 5   	       QuranPresenter.ayatDisplay   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   9System&clr-namespace:System;assembly=mscorlib     5   	   .localclr-namespace:QuranPresenter     5   	   -   5          � Title$  
MainWindow��5   	   $	��350��6   $	��525��6)    � WindowStyle$
 None=�65    � WindowState$ 	Maximized=�6H   ��5   	   �� *BackgroundColor+ +� FocusedElement 5   |   ��  �� ElementName$ ayatDisplayView�� � 	Resources 5         TextBoxBaseControlTemplate �� 
TargetType ��Name �� CornerRadius	 ��Name
 �� Triggers P� Property P� Value �� Value �� 
TargetName �� Property��%D  &	        �� 5	   
   " ��6=   .R�5
      �� $ Bd��5      #��z��5
      
���   �#��z��5      $ 3��6<   ._�5      �� $	 PART_ContentHost��6   5      
 5      P� 5       � {� .  . �5      �� # � ��63   $ Bd��6u    � ���� 5      # � ��63    � ��5      5      5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           QuranPresenter.ayatDisplay   	NextSurah   Command# Z 5      6J     5   
   -   5           PreviousSurah# Z 5      6N     5   
   -   5           AnnounceFocus# Z 5      6N     5   
   -   5           
SurahFocus# Z 5      6K     5   
   -   5           DisplayAnnounce# Z 5      6P   .��5       � ��5!   
   �� 5"       j� Stretch$
 None=�6@    �� Opacity$	 0.5Q�6O    �� ImageSource 6   ��  �� Path$ 	ImageLink�6O    � RowDefinitions 5$   
   �� 5%      $��* �6   �� 5&      $��45 �6    � ColumnDefinitions 5(   
   �� 5)      $��* �6   .+�5,   
   �� ��6   �� *dt+64   &   System.Windows.Controls.DataGrid  5.   
   -   5          Name$ ayatDisplayView��5.         AutoGenerateColumns .  $
��Left=�52      $��7q�53      $	��Top=�54      $��50(�55      $��0��58      $��0q�59         HeadersVisibility$
 None=�5:      $��0��5=      "    VerticalScrollBarVisibility$  Hidden=�5>      ��. ! %� 
ScrollUnit$! Pixel=�5@      $" �� IsSynchronizedWithCurrentItem$
" TrueY�5A      # �� SelectedIndex$# 1��5B      $   RowBackground
$ ���� $��Al Qalam Quran Publisher)�5F   G   ��5/      �� *dt+��50      �� $ ForegroundColor�%   GridLinesVisibility% 56      �� $ 	Gridlines���5C      �� $ BackgroundColor�& J� Opacity& 5G      �� $ Opacity�'   Columns' 5K      4  .System.Windows.Controls.DataGridTemplateColumn  5L      ,  &System.Windows.Controls.DataGridColumn(   Width5  /System.Windows.Controls.DataGridLengthConverter$( * 6)   )   CellTemplate) 5M      �� 5N      .R�5O      �� $	��Top=�6)   $
��Wrap=�5P   !   $��RightToLeft=�65   $	& 100Q�5Q   J   ��6-   �� *IndoPakText+��5T   "   �� 5V   &   * �� 
TargetType"* ��6,   + �� Triggers+ 5X   *   �� 5Y   .   , �� Binding, 6:   �� *IndoPakText+- �� ValueK- G بِسْمِ اللّهِ الرَّحْمَنِ الرَّحِيمِ 6Z   .a�5Z   2   ��  � �� �	#FF29E8166O   �� 5[   2    � ��$9 3/QuranPresenter;component/Resources/#Muhammadi Font)�6O   �� 5\   2    � ��$ Center=�6X   �� 5]   2    � ��$	 Top=�6V   5^   /   �� 5_   .   , 6:   �� *
IsSelected+. �� RelativeSource. �� / �� AncestorType)  #System.Windows.Controls.DataGridRow"/  - True6�   .a�5`   2   ��  � ��
 �����6O   5a   /   5e   '   5g      5i      5l       5p      0 �� Color��%�   (��       5q   "   * SystemColors.HighlightBrushKey+)(�� 2     5s   "   *1/SystemColors.InactiveSelectionHighlightBrushKey+)�� 5q      0 5r      �� $ Highlighter��� 5s      0 6e   �� $ Highlighter�5t      6  0System.Windows.Controls.Primitives.MultiSelector1   SelectedItems1 5v      V� 5w      5z      ]� 5{   
   -   5        $��TopMenuArea��5{   C   ���	#FF29E816$��5q�6+   $��1��66   $& 0Q�6V   2 � Triggers2 5|      :� 5}      3 :� RoutedEvent$3 DockPanel.MouseEnter��6   .[�5~      �� .��5      �� .��5�      W� 4 �� TargetProperty$4 Opacity�6.   5 �� 
TargetName$5 TopMenuArea��6R   6 W� From$	6 0.0X�5�      	7 W� To$	7 1.0X�6$   8 g� Duration$8 0:0:1D�6-   6@   5�      5�      5�      :� 5�      $3 DockPanel.MouseLeave��6   .[�5�      �� .��5�      �� .��5�      W� $4 Opacity�6.   $5 TopMenuArea��6R   $	6 1.0X�5�      $7 0X�6$   $8 0:0:1D�6+   6>   5�      5�      5�      9 J� Effect9 5�      3	  -System.Windows.Media.Effects.DropShadowEffect	  5�      : 	  Color$: 	#FF29E816��6#   .+�5�      �� 
�������$��Surah Name:��6.   $��Center=�6D   �� 5�      -	   5        ; ��Name$; textSurahName��5�   ;   
�������$
��auto��6.   $��Center=�6R   $��0q�6t   $��Center=�6�   $9��3/QuranPresenter;component/Resources/#Muhammadi Font)�6�   �� 5�      
�������$��No��6.   $��Center=�6;   �� 5�      -
   5        < ��Name$< textSurahNo��5�   �   #��[  6   $��Center=�6M   $��5q�6q   $��30��6|   $��Center=�6�   $��0q�6�   $��1��6�   = J� RenderTransformOrigin$= 0.5,0.5&�6  �� 5�      
�������$��Ayat No��6.   $��Center=�6@   �� 5�      -   5        $< 
textAyatNo��5�   �   #��[  6   $��Center=�6M   $��5q�6q   $��30��6|   $��Center=�6�   $��0q�6�   $��2��6�   �� 5�      
�������$��Ruku No��6.   $��Center=�6@   �� 5�      -   5        $< 
textRukuNo��5�   �   #��[  6   $��Center=�6M   $��5q�6q   $��30��6|   $��Center=�6�   $��0q�6�   $��3��6�   �� 5�      
�������$��FontSize��6.   $��Center=�6A   �� 5�      -   5        > ��Name$> textFontSize��5�   c   ? �� 
IsEditable? . $��Center=�6)   $��5q�6M   $��50��6X   $��Center=�6y   $��0q�6�   $��4��6�   6�   �� 5�      -   5        $��Settings��5�      $��Settings��6&   $��Center=�69   $��16(�6l   $��Nyala)�6|   $��0q�6�   
������ 
�������$
��Bold"�6�   �� 5�      
�������$��Announce��6.   $��Center=�6A   �� 5�      -   5        $< textAnnounce��5�   |   #��[  6   $��Center=�6M   $��5q�6q   $��Center=�6�   $��Urdu Typesetting)�6�   $��Stretch=�6�   $��0q�6�   $��6��63  5�      5�      5�      