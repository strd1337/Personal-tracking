   M S B A M L   `   `   `  ����N  JPersonalTrackingWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PersonalTrackingWPFPersonalTrackingWPF  5   	   &     PersonalTrackingWPF.PositionPage   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:PersonalTrackingWPF     5   	   -   5          � Title$  Position Page��5   	   $
��Bold"�6   $��18(�61    � WindowStartupLocation$ CenterScreen=�6?    � 
ResizeMode$ NoResize=�6d   $	��200��6z   $	��350��6�   ���	#FFAAA5AF � Icon$ /dragonmain.png��6�   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   6+   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   .+�5   
   �� $��
Department��6   $��Center=�6%   $��Center=�6B   6_   �� 5   
   $��Position name��6   $��1��6(   $��Center=�65   $��Center=�6R   6o   �� 5   
   -   5        $��cmbDepartment��5      $��1��6(   $	��146��68   $
��Left=�6D   $��Center=�6_   6|   �� 5   
   -   5         ��Name$ txtPositionName��5      $��1��6+   $��1��68   $	��146��6H    �� TextWrapping$
 Wrap=�6T   $
��Left=�6h   $��Center=�6�   6�   �� 5   
   -   5         ��Name$ btnSave��5      $
��Save��6"   $��2��61   $��50,0,0,0q�6>   $	��100��6P   $��Center=�6\   $��Center=�6y   6�   �� 5   
   -   5        $ btnClose��5      $��Close��6#   $��2��63   $��1��6@   $��0,0,50,0q�6P   $	��100��6b   $��Center=�6n   $��Center=�6�   6�   5      5      