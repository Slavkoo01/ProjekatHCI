   M S B A M L   `   `   `  ����G  CProjekat_HCI, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null5clr-namespace:Projekat_HCI.ViewProjekat_HCI.View  5      ?$clr-namespace:Projekat_HCI.ViewModelProjekat_HCI.ViewModel  5      !    Projekat_HCI.View.AdminView   5      W SPresentationCore, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=7.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=7.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      1localclr-namespace:Projekat_HCI.View     5      GblenderManualViewModel$clr-namespace:Projekat_HCI.ViewModel     5      .��5
      ��   �� CornerRadius$  50��6   $��8q�6   
������ $
��1280��6M   $	��720��6Z   ._�5   
   �  � RowDefinitions 5      �� 5      $��80 �6    �� 5      .+�5      �  � ColumnDefinitions 5      �� 5      �� 5      $	��135 �6'   �� 5      $��35 �6'   �� 5      $��35 �6'   �� 5      $��25 �6'   .+�5      �� -   5         ��Name$ LogOutButton��5         LogOutButtonStyle#��[  6/   $��1��6Z   $��Log Out��6j   $��
10,0,10,30q�6|   ��6�   �� *LogOutCommand+�� 5       �� Orientation$ 
Horizontal=�6   $��	20 20 0 0q�66   .+�5      �� -   5        $ DeleteButton��5      $��Delete��63   $��
10,0,10,10q�6D     DeleteButtonStyle#��[ 6X   ��6�   �� *DeleteCommand+�� 5      -   5        $ 	AddButton��5      $	��Add��60   $��
10,0,10,10q�6>     AddButtonStyle#��[ 6R   ��6z   �� *
AddCommand+5      5      � 5      $��2��6   .+�5!      &   System.Windows.Controls.DataGrid  -   5          Name$ AdminDataGrid��5!      $��2��62      
IsReadOnly$
 True��5"      $��1��5#      $��3��5$         AutoGenerateColumns$ False��5%      $��25,10,25,25q�5&        DataGridStyle#��[ 5(      ��5'      �� *BMData+   Columns 5+      4  .System.Windows.Controls.DataGridTemplateColumn  5-      ,  &System.Windows.Controls.DataGridColumn	   Header$	 Image��62   
   Width5  /System.Windows.Controls.DataGridLengthConverter$	
 30* 6A      CellTemplate 5.      �� 5/   "   .R�50   &   �� $	��150��6I   $	��150��6U   $
��Fill=�6b   ��6,   �� *	ImagePath+6b   51   #   53      5  /System.Windows.Controls.DataGridHyperlinkColumn  55      $	 	HyperLink��57      $	
 25* 58      1  +System.Windows.Controls.DataGridBoundColumn   Binding 56      �� *	HyperLink+   ElementStyle 59      �� 5:   "    �� 
TargetType" ��6(     	HyperLink �� BasedOn# [ 6?   .�5;   &   -   5        5<   #   5>      0  *System.Windows.Controls.DataGridTextColumn  5A      $	 
Date Added��6-   $	
 25* 6_    6A   �� *	DateAdded+6_     5D      $	 Delete��61   $	
 15* 6A    5E      �� 5F   "   .R�5G   &   ��  ��Name$ DeleteCheckBox��6/     CheckBoxStyle#��[ 6G    d� 	IsChecked 6n   �� *	IsChecked+ �� Mode$ TwoWay=� �� UpdateSourceTrigger$ PropertyChanged=�5H   #   5J      5P      5R      5T      5V      5W      