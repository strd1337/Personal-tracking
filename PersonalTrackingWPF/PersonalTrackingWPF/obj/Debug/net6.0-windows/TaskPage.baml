   M S B A M L   `   `   `  ����N  JPersonalTrackingWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PersonalTrackingWPFPersonalTrackingWPF  5   	   "    PersonalTrackingWPF.TaskPage   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:PersonalTrackingWPF     5   	   -   5          � Title$  	Task Page��5   	   $	��540��6    � Icon$ \dragonmain.png��6(   ���	#FFAAA5AF � 
ResizeMode$ NoResize=�6V   $��18(�6l   $
��Bold"�6z    � WindowStartupLocation$ CenterScreen=�6�   $	��800��6�   .��5	      �  � ColumnDefinitions 5
   
   �� 5      6!   �� 5      6!   .+�5   
   �  5      �� 5      $��2* �6#   60   �� 5      $��3* �6#   60    � RowDefinitions 5      �� 5      6"   �� 5      6"   �� 5      6"   �� 5      6"   �� 5      6"   �� 5      6"   �� 5      6"   �� 5      6"   �� 5      6"   .+�5      �� $��User number��6   $��34��6*   $
��auto��66   $
��Left=�6C   $��Center=�6^   6{   �� 5      -   5         ��Name$ txtUserNumber��5      ${�False��6-   $��1��6?   $��26��6O   $��0,0,5,0q�6[   6n   �� 5       $
��Name��6   $��1��6#   $��34��60   $
��auto��6<   $
��Left=�6I   $��Center=�6d   6�   �� 5!      -   5        $ txtName��5!      $��1��6'   ${�False��64   $��1��6F   $��26��6V   $��0,0,5,0q�6b   6u   �� 5"      $��Surname��6   $��2��6&   $��34��63   $
��auto��6?   $
��Left=�6L   $��Center=�6g   6�   �� 5#      -   5        $ 
txtSurname��5#      $��2��6*   ${�False��67   $��1��6I   $��26��6Y   $��0,0,5,0q�6e   6x   �� 5$      $��Title��6   $��3��6$   $��34��61   $
��auto��6=   $
��Left=�6J   $��Center=�6e   6�   �� 5%      -   5        $ txtTitle��5%      $��3��6(   $��1��65    �� TextWrapping$
 Wrap=�6E   $��26��6Y   $��0,0,5,0q�6e   6x   �� 5&      $��Content��6   $��4��6&   $��34��63   $
��auto��6?   $
��Left=�6L   $��Center=�6g   6�   �� 5'      -   5        $ 
txtContent��5'      $��4��6*   $��1��67   $��3��6G   $
 Wrap=�6X   $��	0,10,5,10q�6l   6�   �� 5(      -   5         ��Name$ btnSave��5(      $
��Save��6&   $��8��65   $��Right=�6B   $��	0,10,0,15q�6^   $	��140��6q   6�   �� 5)      -   5        $ btnClose��5)      $��Close��6'   $��8��67   $��1��6D   $��Center=�6T   $��	0,10,0,15q�6q   $	��140��6�   6�   5*      � 5+   
   $��1��6    5,      �� 5-      $��2* �6#   60   �� 5.      $��3* �6#   60    50      �� 51      $��* �6    6-   �� 52      $��* �6    6-   �� 53      $��7* �6    6.   .+�55      �� $��
Department��6   $
��auto��6)   $
��Left=�66   $��Center=�6Q   $��34��6l   6z   �� 56      -	   5        $��cmbDepartment��56      $��1��6,   $��Center=�6<   $��30��6W   $��0,0,0,0q�6c   6�   �� 57      $��Position��6   $��1��6'   $
��auto��64   $
��Left=�6A   $��Center=�6\   $��34��6w   6�   �� 58      -
   5        $��cmbPosition��58      $��1��6*   $��1��67   $��Center=�6G   $��30��6b   $��0,0,0,0q�6n   6�   &   System.Windows.Controls.DataGrid  59      -   5        $��gridEmployee��59   e   $��2��6   	   AutoGenerateColumns$	 False��6$   $��2��6@   $��0,0,0,0q�6T   
   Columns
 5:      0  *System.Windows.Controls.DataGridTextColumn  5;      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$ * 65      
Visibility$ Hidden=�6V   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6?   �� *Id+6l     5<      $ 
UserNumber��6)   $ * 6=    6G   �� *
UserNumber+6h     5=      $
 Name��6)   $ * 67    6A   �� *Name+6\     5>      $ Surname��6)   $ * 6:    6D   �� *	Surname+6b   5@      5A      5B      5C      