   M S B A M L   `   `   `  ����N  JPersonalTrackingWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PersonalTrackingWPFPersonalTrackingWPF  5   	   #    PersonalTrackingWPF.LoginPage   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:PersonalTrackingWPF     5   	     � Title$  Personal Tracking Login��5   	    � WindowStartupLocation$ CenterScreen=�6)    � Icon$ \dragonmain.png��6N   $	��200��6e   $	��350��6r   ���	#FFAAA5AF � 
ResizeMode$ NoResize=�6�   $��18(�6�   $
��Bold"�6�   .��5	      �  � ColumnDefinitions 5
   
   �� 5      $��* �6   6+   �� 5      $��* �6   6+    � RowDefinitions 5   
   �� 5      $��* �6   6)   �� 5      $��* �6   6)   �� 5      $��* �6   6)   .+�5   
   �� $��User number��6   $��Center=�6&   $��Center=�6C   6`   �� 5   
   -   5         ��Name$ txtUserNumber��5      $��1��6)   $	��150��69   $
��Left=�6E   $��Center=�6`   6�   �� 5   
   $��Password��6   $��1��6#   $��Center=�60   $��Center=�6M   6j   �� 5   
   -   5        $ txtPassword��5      $��1��6'   $��1��64   $	��150��6D   $
��Left=�6P   $��Center=�6k   6�   �� 5   
   -   5         ��Name$ btnLogin��5      $��2��6#   $��Login��60   $��50,0,0,0q�6@   $	��100��6R   $��Center=�6^   $��Center=�6{   6�   �� 5   
   -   5        $ btnExit��5      $��2��6"   $��1��6/   $
��Exit��6?   $��50,0,0,0q�6N   $	��100��6`   $
��Left=�6l   $��Center=�6�   6�   5      5      