   M S B A M L   `   `   `  ����N  JPersonalTrackingWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PersonalTrackingWPFPersonalTrackingWPF  5   	   (    "PersonalTrackingWPF.PermissionPage   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:PersonalTrackingWPF     5   	   -   5          � Title$  Permission Page��5   	   $	��450��6!    � Icon$ \dragonmain.png��6.   ���	#FFAAA5AF � 
ResizeMode$ NoResize=�6\   $��18(�6r   $
��Bold"�6�    � WindowStartupLocation$ CenterScreen=�6�   $	��800��6�   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   6+   �� 5      $��2* �6   6,    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� $��User number��6   $��34��6&   $
��auto��62   $
��Left=�6?   $��Center=�6Z   6w   �� 5   
   -   5         ��Name$ txtUserNumber��5      ${�False��6)   $��1��6;   $��26��6K   $��0,0,30,0q�6W   6k   �� 5   
   $��
Start date��6   $��34��6%   $��1��61   $
��Left=�6>   $��Center=�6Y   6v   (  "System.Windows.Controls.DatePicker  5   
   -   5        $��dpStart��5      $��1��6$   $��1��64   6u   �� 5   
   $��End date��6   $��34��6#   $��2��6/   $
��Left=�6<   $��Center=�6W   6t     5   
   -   5        $��dpEnd��5      $��1��6"   $��2��62   6q   �� 5   
   $��
Day amount��6   $��34��6%   $��3��61   $
��Left=�6>   $��Center=�6Y   6v   �� 5    
   -   5        $ txtDayAmount��5       ${�False��6(   $��3��6:   $��1��6G   $��26��6W   $��0,0,30,0q�6c   6w   �� 5!   
   $��Explanation��6   $��34��6&   $
��auto��62   $��4��6?   $
��Left=�6L   $��Center=�6g   6�   �� 5"   
   -   5        $ txtExplanation��5"      $��4��6*   $��2��67   $��1��6H   $��0,0,30,0q�6X   $��Stretch=�6j   $��Stretch=�6�   6�   � 5#   
   $��7��6   $��2��6    5$      �� 5%      6%   �� 5&      6%   .+�5(      �� -   5         ��Name$ btnSave��5(      $
��Save��6&   $��7��65   $��Center=�6B   $	��140��6_   $��0,0,0,0q�6k   6�   �� 5)      -   5        $ btnClose��5)      $��Close��6'   $��7��67   $��1��6D   $��Center=�6T   $	��140��6q   $��0,0,0,0q�6}   6�   5*      5+      5,      