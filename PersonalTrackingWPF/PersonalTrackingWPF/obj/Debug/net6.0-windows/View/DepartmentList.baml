   M S B A M L   `   `   `  ����N  JPersonalTrackingWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:PersonalTrackingWPF.ViewPersonalTrackingWPF.View  5      -    'PersonalTrackingWPF.View.DepartmentList   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:PersonalTrackingWPF.View     5      .��5	      �   � RowDefinitions  5
   
   �� 5      $��6* �6   6*   �� 5      $��* �6   6)   .+�5   
   � $��1��6    � ColumnDefinitions 5      �� 5      $��* �6#   6/   �� 5      $��* �6#   6/   �� 5      $��* �6#   6/   .+�5      �� -   5        $��btnAdd��5   (   $��	40,5,40,5q�6   $	��Add��66   $��18(�6D   $
��bold"�6R   6{   �� 5      -   5        $��	btnUpdate��5   (   $��	40,5,40,5q�6   $��Update��69   $��1��6J   $��18(�6Z   $
��bold"�6h   6�   �� 5      -   5        $��	btnDelete��5   (   $��	40,5,40,5q�6   $��Delete��69   $��2��6J   $��18(�6Z   $
��bold"�6h   6�   5      &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ gridDepartment��5         
IsReadOnly$
 True��6+      AutoGenerateColumns$ False��6=      SelectionUnit$ FullRow=�6Y      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 61   	   
Visibility$	 Hidden=�6R   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6;   �� *Id+6h     5      $ Department Name��6%   $
 auto 6>   
 6K   �� *DepartmentName+6p   5      5      5      