   M S B A M L   `   `   `  ����>  :CRM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CRMCRM  5   	       CRM.MainWindow   5   	   a ]DevExpress.Xpf.Core.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:CRM     5   	   ;dx2http://schemas.devexpress.com/winfx/2008/xaml/core  5   	   -   5          � Title$  	Dashboard��5	   	   $��749.6��6   $
��1373��6*    � WindowState$ 	Maximized=�67    � 
ResizeMode$ CanResizeWithGrip=�6O    � Icon$ Content/images/logo.jpg��6�    � WindowStyle$
 None=�6�   .��5
      � $��0,0,2,0q�6   .+�5   
   � -   5         �Name$ gdUser��5   "   $��	0,0,0,659q�6   .+�5      ]� $
��Left=�6   $��60��63   ��.  $��0,0,-3,0q�6U   $	��Top=�6g   $
��1366��6   ���#1976D25      �� 5      -   5         ��Name$ lblCurventUser��5      $�� ��6,   $��27��67   $	��Top=�6C   $��1120,19,67,0q�6[   $��Verdana)�6q   $��16(�6�   
�������&   System.Windows.Media.TextOptions   TextHintingMode$ Animated=�6�   �� 5      -   5         ��Name$ image��5      $
��Left=�6#   $��37��6>   $��1301,12,0,0q�6J   $	��Top=�6_   $��58��6w   ��6�   *  $DevExpress.Xpf.Core.DXImageExtension  	   Image1  +DevExpress.Xpf.Core.Native.DXImageConverter$	 BOCustomer_32x32.png �� 5      $��Content/images/logo.jpg��6   $��6,-6,1319,31q�65   6M   �� 5      $!��Content/images/LogoText.png��6   $��36,10,1225,35q�69   6R   o� 5      -   5        
 o�Name$
 Mainmenu��5       o� 
IsMainMenu . $
��Left=�67   $��51��6S   $��	238,6,0,0q�6_   
������ 
�������$��24(�6�   $	��Top=�6�   $	��771��6�   .@�5      m� -   5         m�Name$ MenuDashboard��5   F   $��	Dashboard��6   $��50��6.   $	��150��6:    m� Icon 5      �� 5       �� Orientation$ 
Horizontal=�6%   
������ .+�5      �� $"��Content/images/Dashboard.png��6$   6L   5      .@�5      m� -   5        $ dashTask��5   0   $��Tasklar��6   ���#42A5F56r   m� 5      -   5        $ Report��5   1   $��Hesablar��6   ���#42A5F56o   5      m� 5       -	   5        $ MenuCustomer��5    G   $��Müştərilər��6   $��50��6/   $	��150��6;    5!      �� 5"      $ 
Horizontal=�6%   
������ .+�5#      �� $$��Content/images/businessman.png��6$   6N   5$      .@�5&      m� -
   5        $ 
AllCompany��5&   T   $��Bütün müstərilər��6   ���#42A5F56   m� 5'      -   5        $ 
CompanyAdd��5'   ]   $��Müstəri yarat��6   $��0,0,-1,0q�66   ���#42A5F56�   5)      m� 5*      -   5        $ MenuTasklar��5*   D   $��TaskLar��6   $��50��6,   $	��150��68    5+      �� 5,      $ 
Horizontal=�6%   
������ .+�5-      �� $��Content/images/list.png��6$   6G   5.      .@�50      m� -   5        $ AllTask��50   6   $��Bütün tasklar��6   ���#42A5F56v   m� 51      -   5        $ TaskAdd��51   3   $��
Task yarat��6   ���#42A5F56s   52      m� 53      -   5        $ 
MenuReyler��53   C   $��Rəylər��6   $��50��6+   $	��150��67    54      �� 55      $ 
Horizontal=�6%   
������ .+�56      �� $ ��Content/images/comment.png��6$   6J   57      .@�59      m� -   5        $ 
AllComment��59   5   $��Bütün rəylər��6   ���#42A5F56{   m� 5:      -   5        $ ReyAdd��5:   E   $��Rəy yaz��6   ���#42A5F56n   5;      m� 5=      -   5        $ 	MenuUsers��5=   J   $��Istifadəçilər��6   $��50��62   $	��158��6>    5>      �� 5?      $ 
Horizontal=�6%   .+�5@      �� $(��"Content/images/specialist-user.png��6$   6R   5A      .@�5C      m� -   5        $ AllUser��5C   i   $��Bütün istifadəçilər��6   ���#42A5F5$��	0,0,-27,0q�6z   6�   m� 5D      -   5        $ UserAdd��5D   O   $��Istifadəçi yarat��6   ���#42A5F56z   5E      5F      5H      � 5N   
   -   5        $ PnlDashboard��5N      $��0��6   $��
0,65,0,-65q�62   .+�5O      &   System.Windows.Controls.DataGrid  -   5          Name$ dgDashboard��5O      $��0,222,10,70q�6K      
IsReadOnly .    AutoGenerateColumns .  ��6,   �� *VwTask+   Columns 5P      0  *System.Windows.Controls.DataGridTextColumn  5Q      ,  &System.Windows.Controls.DataGridColumn   Header$ Id��6)      
Visibility$ Hidden=�65   1  +System.Windows.Controls.DataGridBoundColumn   Binding 6I   �� *Id+  5R      $ Şirkət��6)      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 69    6E   �� *	Company+  5S      $ 	Satıçı��6)   $	 120 69    6E   �� *
FullName+  5T      $ İzahat��6)   $ * 69    6C   �� *Description+  5U      $ Yarandığı Tarix��6)   $	 130 6B    6N   �� *
CreateAt+  5V      $ Bitiş tarixi��6)   $	 120 6?    6K   �� *
DeadLine+  5W      $ Bitibmi��6)   $ 80 6:    6E   �� *
Finished+5[      �� 5\      -   5         ��Name$ txtTaskAxtar��5\      $
��Left=�6,   $��30��6G   $��948,161,0,0q�6S    �� TextWrapping$
 Wrap=�6h   $	��Top=�6|   $	��180��6�   $��Verdana)�6�   �� 5_      -   5         ��Name$ 	btnLogout��5_      $��	Çıxış��6(   $
��Left=�68   $��
1288,6,0,0q�6S   $	��Top=�6g   $��49��6   $��41��6�   
�������6�   �� 5`      -   5        $ btnTaskAxtar��5`      $��Axtar��6+   $
��Left=�6;   $��1184,161,0,0q�6V   $	��Top=�6l   $	��100��6�   $��30��6�   $��Verdana)�6�   $��14(�6�   5b      �� 5c      -   5        $ label��5c      $��Xatırlatmalar:��6#   $
��Left=�6<   $��26,8,0,0q�6W   $	��Top=�6i   $��Verdana)�6�   $��14(�6�   $
��Bold"�6�   ���	#FFB01111��6�   Z� 6�   �� 5d      -   5        $ lblnotification��5d      $��***  ��6-   $
��Left=�6=   $��
151,10,0,0q�6X   $	��Top=�6l   $��Verdana)�6�   ���	#FFAC0C0C��6�   Z� 6�   �� 5e      -   5        $ label1��5e      $.��(Axtarış bütün tasklarda axtarılacaq��6$   $
��Left=�6R   $��948,131,0,0q�6m   $	��Top=�6�   $��Verdana)�6�   5l      5o      5q      