   M S B A M L   `   `   `  ����I  EQuranPresenter, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null/clr-namespace:QuranPresenterQuranPresenter  5   	       QuranPresenter.index   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   .localclr-namespace:QuranPresenter     5   	   -   5        $��MainPage��5        � Title$  MainPage��6	   $	��350��6*   $	��525��67    � WindowStyle$
 None=�6C    � WindowState$ 	Maximized=�6V    � 
ResizeMode$ NoResize=�6n    � 	Resources 5         DetailStyle �� Property �� Value��%�   &	        �� 5   
   .�5      ��  � ��$ Adobe Caslon Pro)�67   6R   �� 5	       � ��$ 18(�65   6B   5
      5       J� CommandBindings 5      )  #System.Windows.Input.CommandBinding  5   
   -   5           QuranPresenter.index   Resize	   Command#	 Z 5      6A   .��5      � 
 � ColumnDefinitions
 5   
   �� 5      $��5 �6   6+   �� 5      $	��300 �6   6-   �� 5      $	��150 �6   6-   �� 5      $	��125 �6   6.   �� 5      $	��125 �6   6.   �� 5      $	��125 �6   6-   �� 5      $��* �6   6+   �� 5      $��5 �6   6+   ��5   
   �� 5       �� ImageSource$ Resources/index.jpg��6    j� Stretch$
 None=�6;    �� Opacity$	 0.5Q�6J   .+�5#   
   &   System.Windows.Controls.DataGrid  -   5          Name$ surahNameView��5#      $��1��6*   ���	#4CF0F0F0   RowBackground �	#4CF0F0F0   
IsReadOnly . $��0q�6}      GridLinesVisibility$
 None=�6�   $��24(�6�      AutoGenerateColumns .  $9��3/QuranPresenter;component/Resources/#Muhammadi Font)�6_     Columns 5$      0  *System.Windows.Controls.DataGridTextColumn  5%      ,  &System.Windows.Controls.DataGridColumn   Header$ Surah Number��6A   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6%   �� *	SurahNo+6A     5&      $ 
Surah Name��6C      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 6W    6%   �� *	SurahName+   ElementStyle 5'      �� 5(       �� 
TargetType" ��6    .�5)      ��  � ��$ Center=�6D   5*      5,      5.        5/   
   -   5        $ 	parahView��5/      $��2��6&   ���	#4CF0F0F0 �	#4CF0F0F0 . $��0q�6y   $
 None=�6�   $9��3/QuranPresenter;component/Resources/#Muhammadi Font)�6�   $��24(�6�    .   50        51      $ Parah Number��6A   $ * 6W    6%   �� *	ParahNo+6W   53        54   
   -   5        $ 
manzilView��54      $��3��6'   ���	#4CF0F0F0 �	#4CF0F0F0 . $��0q�6z   $
 None=�6�   $9��3/QuranPresenter;component/Resources/#Muhammadi Font)�6�   $��24(�6�    .   55        56      $ Manzil Number��6@   $ * 6W    6%   �� *Manzil+6W   58        59   
   -   5        $ hizbView��59      $��4��6%   ���	#4CF0F0F0 �	#4CF0F0F0 . $��0q�6x   $
 None=�6�   $9��3/QuranPresenter;component/Resources/#Muhammadi Font)�6�   $��24(�6�    .   5:        5;      $ Hizb Number��6>   $ * 6S    6%   �� *Hizb+6S   5=        5>   
   -   5        $ totalAyatView��5>      $��5��6*   ���	#4CF0F0F0 �	#4CF0F0F0 . $��0q�6}   $
 None=�6�   $9��3/QuranPresenter;component/Resources/#Muhammadi Font)�6�   $��24(�6�    .   5?        5@      $ Ayat Number��6B   $ * 6W    6%   �� *
RecordNo+6W   5B      �� 5E   
    �� Orientation$ Vertical=�6   $��6��6,   $��5q�6<   .+�5G      �� $��50��6   6"   �� 5H      
���   �$��.5q�6)   ._�5I      � 
 5J      �� 5K      $
��auto �6+   6:   �� 5L      $��* �6+   67    � RowDefinitions 5N      �� 5O      $
��auto �6(   68   �� 5P      $
��auto �6(   68   �� 5Q      $
��auto �6(   68   �� 5R      $
��auto �6(   68   �� 5S      $
��auto �6(   68   �� 5T      $
��auto �6(   68   .+�5V      �� $��0��6   $��0��6,   #���   69   .��6_   Surah Name:6l   �� 5W      -   5        $��DetailSurahName��5W   _   $��1��6   $��0��6,   #���   69   $9��3/QuranPresenter;component/Resources/#Muhammadi Font)�6v   6�   �� 5X      $��0��6   $��1��6,   #���   69   .��6_   Ayat Number:6m   �� 5Y      -	   5        $��DetailAyatNo��5Y   _   $��1��6   $��1��6,   #���   69   6u   �� 5Z      $��0��6   $��2��6,   #���   69   .��6_   Ruku Number:6m   �� 5[      -
   5        $��DetailRukuNo��5[   _   $��1��6   $��2��6,   #���   69   6u   �� 5\      $��0��6   $��3��6,   #���   69   .��6_   Parah Number:6n   �� 5]      -   5        $��DetailParahNo��5]   _   $��1��6   $��3��6,   #���   69   6v   �� 5^      $��0��6   $��4��6,   #���   69   .��6_   Total Ayats In This Surah:6{   �� 5_      -   5        $��DetailTotalAyat��5_   _   $��1��6   $��4��6,   #���   69   6x   5`      5a      �� 5b      -   5        $��Start From Last State��5b      $��0,5,0,0q�65   $��5q�6F   $��18(�6i   $��Nyala)�6y   $��0q�6�   ���	#4429E816
���   �$
��Bold"�6�   ��5c      �� 5d      " ��6    �� Triggers 5e      P� 5f       P� Property �@J�IsMouseOver P� Value .  . �5g   "   ��  � ��
 ���� 6?   �� 5h   "    � ��
 �   �6?   �� 5i   "    �@J�Opacity$	 1.0Q�6<   5j      :� 5k       :� RoutedEvent$ 
MouseLeave��6+   .[�5l   "   �� .��5m   &   �� .��5n   *   W�  �� TargetProperty$ Opacity�6:     W� From$	  0.2X�6^   	! W� To$! 1X�6i   6r   5o   '   5p   #   5q      :� 5r      $ 
MouseEnter��6+   .[�5s   "   �� .��5t   &   �� .��5u   *   W� $ Opacity�6:   $	  0.2X�6^   $	! 0.8X�6i   6t   5v   '   5w   #   5x      5z      5|      �� 5}      -   5        $��See Logs��5}      $��0,5,0,0q�6(   $��5q�69   $��18(�6\   $��Nyala)�6l   $��0q�6   ���	#4429E816
���   �$
��Bold"�6�   ��5~      �� 5      " ��6    5�      P� 5�       �@J�IsMouseOver .  . �5�   "   ��  � ��
 ���� 6?   �� 5�   "    � ��
 �   �6?   �� 5�   "    �@J�Opacity$	 1.0Q�6<   5�      :� 5�      $ 
MouseLeave��6+   .[�5�   "   �� .��5�   &   �� .��5�   *   W� $ Opacity�6:   $	  0.2X�6^   $! 1X�6i   6r   5�   '   5�   #   5�      :� 5�      $ 
MouseEnter��6+   .[�5�   "   �� .��5�   &   �� .��5�   *   W� $ Opacity�6:   $	  0.2X�6^   $	! 0.8X�6i   6t   5�   '   5�   #   5�      5�      5�      �� 5�      -   5        $��View HotKeys��5�      $��0,5,0,0q�6,   $��5q�6=   $��18(�6`   $��Nyala)�6p   $��0q�6�   ���	#4429E816
���   �$
��Bold"�6�   ��5�      �� 5�      " ��6    5�      P� 5�       �@J�IsMouseOver .  . �5�   "   ��  � ��
 ���� 6?   �� 5�   "    � ��
 �   �6?   �� 5�   "    �@J�Opacity$	 1.0Q�6<   5�      :� 5�      $ 
MouseLeave��6+   .[�5�   "   �� .��5�   &   �� .��5�   *   W� $ Opacity�6:   $	  0.2X�6^   $! 1X�6i   6r   5�   '   5�   #   5�      :� 5�      $ 
MouseEnter��6+   .[�5�   "   �� .��5�   &   �� .��5�   *   W� $ Opacity�6:   $	  0.2X�6^   $	! 0.8X�6i   6t   5�   '   5�   #   5�      5�      5�      5�      5�      5�      