   M S B A M L   `   `   `  ����N  JPersonalTrackingWPF, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:PersonalTrackingWPFPersonalTrackingWPF  5   	   C&clr-namespace:PersonalTrackingWPF.ViewPersonalTrackingWPF.View  5   	   G(clr-namespace:PersonalTrackingWPF.ModelsPersonalTrackingWPF.Models  5   	   O,clr-namespace:PersonalTrackingWPF.ViewModelsPersonalTrackingWPF.ViewModels  5	   	   $    PersonalTrackingWPF.MainWindow   5   	   W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:PersonalTrackingWPF     5   	   8views&clr-namespace:PersonalTrackingWPF.View     5   	   ;models(clr-namespace:PersonalTrackingWPF.Models     5   	   C
viewmodels,clr-namespace:PersonalTrackingWPF.ViewModels     5	   	   -   5        $��PersonalMainWindow��5   :     � Title$  Personal Tracking��6	    � Icon$ /dragonmain.png��6#   $	��540��6T   $
��1200��6a    � WindowStartupLocation$ CenterScreen=�6n   $��24(�6�   $
��bold"�6�   ���	#FFAAA5AF � 
ResizeMode$ NoResize=�6�   .��5      �  � ColumnDefinitions 5   
   �� 5      $��* �6   6+   �� 5      $��4* �6   6,    � RowDefinitions 5   
   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   �� 5      6   .+�5   
   �� $��/dragonmain.png��6   $��0,0,8,0q�6)   �� 5   
   $��1��6   $��0,0,0,0q�6=   $��1��6N   $��8��6[   $
��Auto��6l   $
��Auto��6z   ��6)   �� 6z   �� 5   
   -   5         ��Name$ lblWindowName��5      $��1��6'   $��Main Window��67   $��Center=�6M   $��
124,10,0,0q�6j   $	��Top=�6~   $��24(�6�   �� 5   
   $��1��6   $��0,2,0,0q�6"   .+�5       �� -   5        $��btnEmployee��5    "   $��1��6   $��60��65   $	��250��6A   $
��Left=�6M   .��5!      � $	��230��6    5"      �� 5#      $
��auto �6+   6:   �� 5$      $
��auto �6+   6:   .+�5&      �� -   5         ��Name$ ImageEmployee��5&      $
��Left=�63   $
��auto��6N   $��73��6\   $��0,0,0,4q�6g   $��/employee.png��6x   6�   �� 5'      $��Employee��6    $��1��60   $
��Left=�6@   $��Center=�6[   6x   5(      5)      5*      �� 5+   
   $��2��6   $��0,2,0,0q�6"   .+�5,      �� -   5        $��btnTask��5,   "   $��2��6   $��60��61   $	��250��6=   $
��Left=�6I   .��5-      � $	��230��6    5.      �� 5/      $
��auto �6+   6:   �� 50      $
��auto �6+   6:   .+�52      �� -   5        $ 	ImageTask��52      $
��Left=�6/   $
��auto��6J   $��73��6X   $��0,0,0,4q�6c   $��	/task.png��6t   6�   �� 53      $
��Task��6    $��1��6,   $
��Left=�6<   $��Center=�6W   6t   54      55      56      �� 57   
   $��3��6   $��0,2,0,0q�6"   .+�58      �� -   5        $��	btnSalary��58   "   $��3��6   $��60��63   $	��250��6?   $
��Left=�6K   .��59      � $	��230��6    5:      �� 5;      $
��auto �6+   6:   �� 5<      $
��auto �6+   6:   .+�5>      �� -   5        $ ImageSalary��5>      $
��Left=�61   $
��auto��6L   $��73��6Z   $��0,0,0,4q�6e   $��/salary.png��6v   6�   �� 5?      $��Salary��6    $��1��6.   $
��Left=�6>   $��Center=�6Y   6v   5@      5A      5B      �� 5C   
   $��4��6   $��0,2,0,0q�6"   .+�5D      �� -	   5        $��btnPermission��5D   "   $��4��6   $��60��67   $	��250��6C   $
��Left=�6O   .��5E      � $	��230��6    5F      �� 5G      $
��auto �6+   6:   �� 5H      $
��auto �6+   6:   .+�5J      �� -
   5        $ ImagePermission��5J      $
��Left=�65   $
��auto��6P   $��73��6^   $��0,0,0,4q�6i   $��/permission.png��6z   6�   �� 5K      $��
Permission��6    $��1��62   $
��Left=�6B   $��Center=�6]   6z   5L      5M      5N      �� 5O   
   -   5         ��Name$ stackDepartment��5O      $��5��6.   $��0,2,0,0q�6;   .+�5P      �� -   5        $��btnDepartment��5P   "   $��5��6   $��60��67   $	��250��6C   $
��Left=�6O   .��5Q      � $	��230��6    5R      �� 5S      $
��auto �6+   6:   �� 5T      $
��auto �6+   6:   .+�5V      �� -   5        $ ImageDepartment��5V      $
��Left=�65   $
��auto��6P   $��73��6^   $��0,0,0,4q�6i   $��/department.png��6z   6�   �� 5W      $��
Department��6    $��1��62   $
��Left=�6B   $��Center=�6]   6z   5X      5Y      5Z      �� 5[   
   -   5        $ stackPosition��5[      $��6��6,   $��0,2,0,0q�69   .+�5\      �� -   5        $��btnPosition��5\   "   $��6��6   $��60��65   $	��250��6A   $
��Left=�6M   .��5]      � $	��230��6    5^      �� 5_      $
��auto �6+   6:   �� 5`      $
��auto �6+   6:   .+�5b      �� -   5        $ ImagePosition��5b      $
��Left=�63   $
��auto��6N   $��73��6\   $��0,0,0,4q�6g   $��/position.png��6x   6�   �� 5c      $��Position��6    $��1��60   $
��Left=�6@   $��Center=�6[   6x   5d      5e      5f      �� 5g   
   -   5        $ stackLogout��5g      $��7��6*   $��0,2,0,0q�67   .+�5h      �� -   5        $��	btnLogout��5h   "   $��7��6   $��60��63   $	��250��6?   $
��Left=�6K   .��5i      � $	��230��6    5j      �� 5k      $
��auto �6+   6:   �� 5l      $
��auto �6+   6:   .+�5n      �� -   5        $ ImageLogout��5n      $
��Left=�61   $
��auto��6L   $��73��6Z   $��0,0,0,4q�6e   $��/logout.png��6v   6�   �� 5o      $��Logout��6    $��1��6.   $
��Left=�6>   $��Center=�6Y   6v   5p      5q      5r      �� 5s   
   -   5        $ 	stackExit��5s      $��8��6(   $��0,2,0,0q�65   .+�5t      �� -   5        $��btnExit��5t   "   $��8��6   $��60��61   $	��250��6=   $
��Left=�6I   .��5u      � $	��230��6    5v      �� 5w      $
��auto �6+   6:   �� 5x      $
��auto �6+   6:   .+�5z      �� -   5        $ 	ImageExit��5z      $
��Left=�6/   $
��auto��6J   $��73��6X   $��0,0,0,4q�6c   $��	/exit.png��6t   6�   �� 5{      $
��Exit��6    $��1��6,   $
��Left=�6<   $��Center=�6W   6t   5|      5}      5~      5      	 � 	Resources	 5�      
 �� DataType8   2PersonalTrackingWPF.ViewModels.DepartmentViewModel-   'PersonalTrackingWPF.View.DepartmentList6   0PersonalTrackingWPF.ViewModels.PositionViewModel+   %PersonalTrackingWPF.View.PositionList6   0PersonalTrackingWPF.ViewModels.EmployeeViewModel+   %PersonalTrackingWPF.View.EmployeeList2   ,PersonalTrackingWPF.ViewModels.TaskViewModel'   !PersonalTrackingWPF.View.TaskList4	   .PersonalTrackingWPF.ViewModels.SalaryViewModel)
   #PersonalTrackingWPF.View.SalaryList8   2PersonalTrackingWPF.ViewModels.PermissionViewModel-   'PersonalTrackingWPF.View.PermissionList��%t  (��       5�   3   *, +)(�� R     5�   1   *, +)(�� �     5�   1   *, +)(�� �     5�   -   *, +)(�� >    5�   /   *,	 +)(�� �    5�   3   *, +)�� 5�   
   DepartmentTemplate��"
  63   .R�5�        5�      5�      �� 5�   
   PositionTemplate��"
  61   .R�5�        5�      5�      �� 5�   
   EmployeeTemplate��"
  61   .R�5�        5�      5�      �� 5�   
   TaskTemplate��"
  6-   .R�5�        5�      5�      �� 5�   
   SalaryTemplate��"
 	 6/   .R�5�      
  5�      5�      �� 5�   
   PermissionTemplate��"
  63   .R�5�        5�      5�      5�      5�      