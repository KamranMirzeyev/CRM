   M S B A M L   `   `   `  ����>  :CRM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CRMCRM  5   	       CRM.AllComments   5   	   a ]DevExpress.Xpf.Core.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:CRM     5   	     � Title$  AllComments��5   	   $	��450��6   $��687.912��6*   $��Verdana)�6:   #��� ��6O    � WindowStartupLocation$ CenterScreen=�6�   .��5	      � .+�5
   
   �� -   5         ��Name$ btnReyAxtar��5
      $��Axtar��6&   $
��Left=�66   $��
524,37,0,0q�6Q   $	��Top=�6e   $��75��6}   6�   �� 5   
   -   5         ��Name$ txtReyAxtar��5      $
��Left=�6'   $��23��6B   $��
369,36,0,0q�6N    �� TextWrapping$
 Wrap=�6b   $	��Top=�6v   $	��120��6�   &   System.Windows.Controls.DataGrid  5   
   -   5          Name$ dgRey��5      $
��Left=�6"   $	��295��6_   $��	26,93,0,0q�6l   $	��Top=�6      AutoGenerateColumns .  $	��629��6�   ��6=   �� *	vwComment+   Columns 5      0  *System.Windows.Controls.DataGridTextColumn  5      ,  &System.Windows.Controls.DataGridColumn   Header$ id��6%   	   
Visibility$	 Hidden=�61   1  +System.Windows.Controls.DataGridBoundColumn
   Binding
 6E   �� *Id+  5      $ İstifadəçi��6%      Width5  /System.Windows.Controls.DataGridLengthConverter$	 120 69   
 6E   �� *
FullName+  5      $ Şirkət��6%   $	 120 65   
 6A   �� *	Company+  5      $ Comment��6%   $ * 66   
 6@   �� *	Comment+5      5      5      