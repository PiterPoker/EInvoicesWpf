   M S B A M L   `   `   `  ����G  CEInvoicesWpf, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null+clr-namespace:EInvoicesWpfEInvoicesWpf  5   	       EInvoicesWpf.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   ,localclr-namespace:EInvoicesWpf     5   	     � Title$  EInvoice��5   	   $	��500��6   $	��750��6'   $	��750��63   $	��500��6B    � 	Resources 5	      ��%    5      .��5      �  � ShowGridLines . 
������� � RowDefinitions 5   
   �� 5      $	��50* �6   6+   �� 5      $
��430* �6   6,   �� 5      $	��20* �6   6+    � ColumnDefinitions 5   
   �� 5      $	��75* �6   6-   �� 5      $
��225* �6   6.   .+�5   
   �� -   5         ��Name$ LabelStatus��5   �   $��0��6   $��0��6    ���	#FF3470D8
�������$��24(�6W   $
��Bold"�6e   $��Segoe Script)�6w   $��Stretch=�6�   $��2��6�   $��Center=�6�   .��6  
EInvoice6  ]� 5   
   ���	#FF3470D8��.  $��1��6A   .+�5      �� -   5         ��Name$ step1Btn��5      $	��Top=�6>      BlackAndWhite#��[  6S   .��6z   
Шаг 16�   �� 5      -   5        $ step2Btn��5      $	��Top=�6>   #��[  6S   .��6z   
Шаг 26�   �� 5      -   5        $ step3Btn��5      $	��Top=�6>   #��[  6S   .��6z   
Шаг 36�   �� 5      -   5        $ step4Btn��5      $	��Top=�6>   #��[  6S   .��6z   
Шаг 46�   �� 5      -   5        $ step5Btn��5      $	��Top=�6>   #��[  6S   .��6z   
Шаг 56�   5       � 5   
   -   5          �Name$ 	frameMain��5      $��1��6%   $��1��62     � NavigationUIVisibility$ Hidden=�6B   ]� 5    
   $��0��6   $��2��6$   $��2��61   .+�5!      �� $��Bottom=�6   ���	#FF3470D8.@�5"      �� .��5#      �� -   5        	 ��Name$	 	statusTxt��5#       
�������63   5$      5%      5&      �� 5'   
     SettingButton#��[ 6   $��0,5,10,5q�68   $��1��6J   $��Right=�6Z   $��40��6v   5(      5)      