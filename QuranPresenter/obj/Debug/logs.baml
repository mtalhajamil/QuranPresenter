   M S B A M L   `   `   `  ����  QuranPresenter    QuranPresenter.logs   5   	   R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   -   5          � Title$
  logs��5   	   $	��350��6   $	��525��6#    � WindowStyle$
 None=�6/    � WindowState$ 	Maximized=�6B    � 
ResizeMode$ NoResize=�6Z   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $��30 �6   6*   .+�5   
   &   System.Windows.Controls.DataGrid  -   5        $��logView��5      $��Adobe Garamond Pro)�6"   $��24(�6B      
IsReadOnly .    AutoGenerateColumns .  $��0��6~      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Serial Number��6=   1  +System.Windows.Controls.DataGridBoundColumn	   Binding	 6%   �� *sNo+6=     5      $ Surah Number��6A   	 6%   �� *	surahNo+6A     5      $ Ayat Number��6@   	 6%   �� *ayatNo+6@     5      $
 Time��6C   
   Width5  /System.Windows.Controls.DataGridLengthConverter$
 * 6Q   	 6%   �� *	stateTime+6Q     5      $
 Date��6C   $
 * 6Q   	 6%   �� *	stateDate+6Q   5      �� 5   
   -   5        $��
Clear Logs��5      $��1��6&   $��0,5,0,0q�63   $��5q�6D   $��18(�6g   $��Nyala)�6w   $��0q�6�   ���	#FF4E6B76���	#7F13D4A05      5      5      