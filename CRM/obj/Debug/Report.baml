   M S B A M L   `   `   `  ����>  :CRM, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullclr-namespace:CRMCRM  5   	       
CRM.Report   5   	   a ]DevExpress.Xpf.Core.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49aR NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   #localclr-namespace:CRM     5   	   c _DevExpress.Xpf.Charts.v17.2, Version=17.2.7.0, Culture=neutral, PublicKeyToken=b88d1754d700e49a>dxc4http://schemas.devexpress.com/winfx/2008/xaml/charts  5   	     � Title$  Report��5	   	   $��446.475��6   $��1047.5��6)   ���	#FFE0F2F1 � WindowStartupLocation$ CenterScreen=�6O    � 
ResizeMode$ NoResize=�6t   .��5
      � $��0,0,0,-4q�6   .+�5   
   � -   5         �Name$ Users��5   1   $
��Auto��6   $��	0,91,0,10q�6    � ColumnDefinitions 5      �� 5      $	��59* �6#   �� 5      $	��27* �6#   .+�5      � $
��Left=�6   $	��158��6.   $��	30,41,0,0q�6;   $	��Top=�6N   $	��296��6f   ���#006064.+�5      �� -   5         ��Name$ label1��5      $��Bitmiş tasklar:��6(   $
��Left=�6B   $��	40,31,0,0q�6]   $	��Top=�6p   
�������$��Verdana)�6�   $��14(�6�   �� 5      -   5        $ label1_Copy��5      $��Bitməmiş tasklar:��6-   $
��Left=�6I   $��	40,58,0,0q�6d   $	��Top=�6w   
�������$��Verdana)�6�   $��14(�6�   �� 5      -   5        $ label1_Copy1��5      $��Bütün tasklar:��6.   $
��Left=�6G   $��	40,85,0,0q�6b   $	��Top=�6u   
�������$��Verdana)�6�   $��14(�6�   (  "DevExpress.Xpf.Charts.ChartControl  5      $
��Left=�6#   $��317,-23,-684,-60q�6>   $	��Top=�6X   $	��663��6p   $	��275��6|      CrosshairOptions 5      ,  &DevExpress.Xpf.Charts.CrosshairOptions  5         ShowArgumentLabels .    ShowOutOfRangePoints . 	   ShowValueLabels	 . 0  *DevExpress.Xpf.Charts.CrosshairOptionsBase
   ShowValueLine
 . 6|   ,  &DevExpress.Xpf.Charts.ChartControlBase   Legends 5      "  DevExpress.Xpf.Charts.Legend  5      (  "DevExpress.Xpf.Charts.ChartElement   Width$	 190Q�6%      Diagram. 5      '  !DevExpress.Xpf.Charts.XYDiagram2D  $��Verdana)�6&   $��0,0,0,24q�6;   #  DevExpress.Xpf.Charts.Diagram   Series. 5      1	  +DevExpress.Xpf.Charts.BarSideBySideSeries2D	  "
  DevExpress.Xpf.Charts.Series 
  DisplayName$ Bütün tasklar��64   '  !DevExpress.Xpf.Charts.BarSeries2D   Model 5      -  'DevExpress.Xpf.Charts.Quasi3DBar2DModel  5   "    
  Points. 5!      '  !DevExpress.Xpf.Charts.SeriesPoint  -   5        curventAllTask��   Argument$ Tasklar��5!   F      Value$ 0Q�6Y   5"      	  5#      $ Bitməmiş tasklar��64    5$        5%   "   . 5'        -   5        curventCompleteTask��$ Tasklar��5'   K   $ 0Q�6^   5(      	  5)      $ Xatırlamalar��64    5*        5+   "   . 5-        -   5        notification��$ Hesabat��5-   E   $ 0Q�6X   5.      	  5/      $ Yeni istifadəçilər��64    50        51   "   . 53        -   5        NewUsers��$ Hesabat��53   @   $ 0Q�6S   54      	  55      $ Yeni şirkətlər��64    56        57   "   . 59        -	   5        
NewCompany��$ Hesabat��59   B   $ 0Q�6U   5:      	  5;      $# Vaxtında olunmamış tasklar��64    5<        5=   "   . 5?        -
   5        IncompleteTask��$ Hesabat��5?   F   $ 0Q�6Y   5@      	  5A      $ Commentlər��64    5B        5C   "   . 5E        -   5        
AllComment��$ Hesabat��5E   B   $ 0Q�6U   5F      5G      5H      �� 5I      -   5        $ 
lblAllTask��5I      $�� ��6,   $
��Left=�67   $��
153,87,0,0q�6R   $	��Top=�6f   
���������6~   Z� 6�   �� 5J      -   5        $ lblCurventCompleteTask��5J      $�� ��68   $
��Left=�6C   $��
171,60,0,0q�6^   $	��Top=�6r   
�������6�   �� 5K      -   5        $ lblCompetedTask��5K      $�� ��61   $
��Left=�6<   $��
152,32,0,0q�6W   $	��Top=�6k   
�������6�   5L      5N      (  "System.Windows.Controls.DatePicker  5V   
   -   5          Name$ dtpStart��5V      $
��Left=�6'   $��
676,65,0,0q�6B   $	��Top=�6V     5W   
   -   5        $ dtpEnd��5W      $
��Left=�6%   $��
802,65,0,0q�6@   $	��Top=�6T    J� RenderTransformOrigin$ 1.833,-0.292&�6l   �� 5X   
   -   5        $ label��5X      $��
Hesabatlar��6   $
��Left=�64   $��
489,10,0,0q�6O   $	��Top=�6c   $��Verdana)�6{   $��16(�6�   �� 5Y   
   -   5        $ label2��5Y      $��Başlama vaxtı��6    $
��Left=�68   $��
676,46,0,0q�6S   $	��Top=�6g   $��Verdana)�6   �� 5Z   
   -   5        $ label2_Copy��5Z      $��Bitmə vaxtı��6%   $
��Left=�6;   $��
803,46,0,0q�6V   $	��Top=�6j   $��Verdana)�6�   �� 5[   
   -   5         ��Name$ button��5[      $��Göstər��6!   $
��Left=�62   $��
932,65,0,0q�6M   $	��Top=�6a   $��75��6y   $��Verdana)�6�   ���	#FF14B20D6�   �� 5\   
   -   5        $ label3��5\      $$��Tarixlər arasındakı hesabat��6    $
��Left=�6F   $��
697,18,0,0q�6a   $	��Top=�6u   $��Verdana)�6�   $��14(�6�   5c      5d      