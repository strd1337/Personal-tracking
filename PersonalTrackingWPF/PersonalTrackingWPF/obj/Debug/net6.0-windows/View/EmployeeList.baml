   M S B A M L   `   `   `  ����N  JPersonalTrackingWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullC&clr-namespace:PersonalTrackingWPF.ViewPersonalTrackingWPF.View  5      +    %PersonalTrackingWPF.View.EmployeeList   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      8local&clr-namespace:PersonalTrackingWPF.View     5      -   5        $��18(�5   #   $
��Bold"�61   .��5	      �   � RowDefinitions  5
   
   �� 5      $��3* �6   6*   �� 5      $��6* �6   6*   �� 5      $��* �6   6)    � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+   �� 5      $��* �6   6+   .+�5   
   &   System.Windows.Controls.DataGrid  -   5          Name$ gridEmployee��5      $��1��6)   $��5��66      AutoGenerateColumns$ False��6J      
IsReadOnly$
 True��6f      SelectionMode$ Single=�6x      Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 61   	   
Visibility$	 Hidden=�6R   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6;   �� *Id+6h     5      $ 
UserNumber��6%   $ * 69   
 6C   �� *
UserNumber+6d     5      $
 Name��6%   $ * 63   
 6=   �� *Name+6X     5      $ Surname��6%   $ * 66   
 6@   �� *	Surname+6^     5      $ Position name��6%   $ * 6<   
 6F   �� *PositionName+6i     5      $ Department name��6%   $ * 6>   
 6H   �� *DepartmentName+6m     5      $ Salary��6%   $ * 65   
 6?   �� *Salary+6\     5      $ 
PositionId��6%   $ * 69   $	 Hidden=�6b   
 6C   �� *
PositionId+6x     5       $ DepartmentId��6%   $ * 6;   $	 Hidden=�6f   
 6E   �� *DepartmentId+6|     5!      $ isAdmin��6%   $ * 66   $	 Hidden=�6\   
 6@   �� *	isAdmin+6r     5"      $ Birthday��6%   $ * 67   $	 Hidden=�6^   
 6A   �� *
Birthday+6t     5#      $ Adress��6%   $ * 65   $	 Hidden=�6Z   
 6?   �� *Adress+6p     5$      $ Password��6%   $ * 67   $	 Hidden=�6^   
 6A   �� *
Password+6t     5%      $ 	ImagePath��6%   $ * 68   $	 Hidden=�6`   
 6B   �� *	ImagePath+6v   5'      � 5(   
   $��5��6     5)      �� 5*      6"   �� 5+      6"   �� 5,      6"    5.      �� 5/      $	��60* �6#   61   �� 50      $
��100* �6#   62   �� 51      $	��60* �6#   61   �� 52      $
��100* �6#   62   �� 53      $	��80* �6#   61   .+�55      �� $��
UserNumber��6   $
��auto��6)   $��50��66   $
��Left=�6B   $��Center=�6]   6z   �� 56      -   5         ��Name$ txtUserNumber��56      $��1��6-    �� TextWrapping$
 Wrap=�6=   $��0,0,0,0q�6Q   $��26��6b   6p   �� 57      $
��Name��6   $��1��6#   $
��auto��60   $��50��6=   $
��Left=�6I   $��Center=�6d   6�   �� 58      -   5        $ txtName��58      $��1��6'   $��1��64   $
 Wrap=�6D   $��0,0,0,0q�6X   $��26��6i   6w   �� 59      $��Surname��6   $��2��6&   $
��auto��63   $��50��6@   $
��Left=�6L   $��Center=�6g   6�   �� 5:      -   5        $ 
txtSurname��5:      $��2��6*   $��1��67   $
 Wrap=�6G   $��0,0,0,0q�6[   $��26��6l   6z   �� 5;      $��
Department��6   $��2��6)   $
��auto��69   $��34��6F   $
��Left=�6R   $��Center=�6m   6�   �� 5<      -   5         ��Name$ cmbDepartment��5<      $��3��6.   $��30��6>   $��0,0,0,0q�6J   6�   �� 5=      $��Position��6   $��1��6'   $��2��64   $
��auto��6D   $��34��6Q   $
��Left=�6]   $��Center=�6x   6�   �� 5>      -   5        $ cmbPosition��5>      $��1��6,   $��3��69   $��30��6I   $��0,0,0,0q�6U   6h   �� 5?      -   5        $��	btnSearch��5?   6   $��4��6   $��Search��6%   $��	20,5,10,5q�6G   6t   �� 5@      -	   5        $��btnClear��5@   B   $��1��6   $��4��6"   $��Clear��62   $��	20,5,10,5q�6R   6~   5A      �� 5B   
   -
   5         ��Name$ btnAdd��5B      $	��Add��6!   $��18(�6/   $
��Bold"�6=   $��1��6O   $��2��6_   $��	40,5,40,5q�6l   6�   �� 5C   
   -   5        $ 	btnDelete��5C      $��Delete��6$   $��18(�65   $
��Bold"�6C   $��3��6U   $��2��6e   $��	40,5,40,5q�6r   6�   5D      5E      