   M S B A M L   `   `   `  ����b  ^Personal Finance Tracker - Luca Eisinga, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:Personal_Finance_Tracker___Luca_Eisinga.View,Personal_Finance_Tracker___Luca_Eisinga.View  5      w@clr-namespace:Personal_Finance_Tracker___Luca_Eisinga.Converters2Personal_Finance_Tracker___Luca_Eisinga.Converters  5      =    7Personal_Finance_Tracker___Luca_Eisinga.View.BudgetView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Llocal:clr-namespace:Personal_Finance_Tracker___Luca_Eisinga.View     5      Qconv@clr-namespace:Personal_Finance_Tracker___Luca_Eisinga.Converters     5      
�������  � 	Resources  5      R   LPersonal_Finance_Tracker___Luca_Eisinga.Converters.boolToVisibilityConverter   boolToVisibilityConverter3  -System.Windows.Media.Effects.DropShadowEffect  
DropShadow   ShadowDepth   Color   Opacity   
BlurRadius  RoundedButton �� 
TargetType �� Property �� Value �� 
StartPoint	 �� EndPoint
 � Color � Offset �� 
TargetType �� CornerRadius  RoundedTextBlock��%�  &	        &	      &	 l     &	 �      5   
   6)     5   
   $ 3Q�5      $ Black��5      $	 0.2Q�5      $ 10Q�5      �� 5   
   " ��6&   .�5      ��  � ��
 �����6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$
 10,5q�6(   �� 5       � ��
 ���� 6,   �� 5       � �� 5      �� 5      $	 0,0&�6*   $		 0,1&�6;   .��5      � $
 	#FF6BD6FF��6'   $	 0.0Q�69   � 5      $
 	#FF1D92D1��6'   $	 1.0Q�69   5      5!      �� 5"       � �� 5#      �� 5$      " ��6&   .R�5%      �� #��z��6!   $ 10��5&      #��z��5'      $��1q�5(      ._�5)      �� $��Center=�6/   $��Center=�5*   '   5+      5,      5.      5/      �� 51   
   " ��6)   .�52      ��  � �� 53      �� 54      $	 0,0&�6*   $		 0,1&�6;   .��55      � $
 	#FF6BD6FF��6'   $	 0.0Q�69   � 56      $
 	#FF1D92D1��6'   $	 1.0Q�69   57      59      �� 5:       �@��CornerRadius$ 10��6-   �� 5;       �@��Padding$ 10q�6(   �� 5<       �@J�Effect 5=        5>      $ 3Q�6'   $ Black��67   $	 0.2Q�6E   $ 10Q�6S   5@      5A      5B      .��5D      � $��10q�6    � RowDefinitions 5E   
   �� 5F      $
��0.2* �6   �� 5H      $��* �6   .+�5L   
   ]� $��0��6   
�������.+�5N      �� -   5        $	��☰��5N      $��40(�5O      $��70��5P      $��70��5Q      $��Center=�5R      $��0,0,40,0q�5T      #��[ 5U       � ContextMenu 5V      �� 5W      .@�5X      m� $��Overview��6#    m� Command 65   �� *openOverviewCommand+m� 5Y      $��Budgets��6#    64   �� *openBudgetCommand+m� 5Z      $��Settings��6#    65   �� *openSettingsCommand+5[      5]      �� 5`      #��[ 6   $��0,0,30,0q�6?   $��70��6Q   $��Center=�6]   ._�5a      �� $��Budget��6   $��40(�5b      $
��Bold"�5c      $��Center=�5d      
�������5e      5f      5g      �� 5i   
   ��6   �� *	budgets+��5j      �� 5k      .R�5l      �� $��10q�6    �� Padding$ 10q�6)   $ 10��66   
������� J� Effect# [ 6[   ._�5m      �  � ColumnDefinitions 5n      �� 5o   "   $��2* �63   �� 5p   "   $��1* �63   �� 5q   "   $��2* �63   �� 5r   "   $
��Auto �63   .+�5u      �� $��0��6M   $��16(�6]   $��Center=�6k   ��6(   �� *Budget.categoryName+6k   �� 5v      $��1��6O   $��16(�6_   $��Center=�6m   $��Right=�6�   ��6(   �� *spent+ �� StringFormat$ C��6�   � 5w       � Maximum$	 100Q�6G   $��20��6U   $��2��6a   $
��10,0q�6q    � Value 6*   �� *
percentage+6q   �� 5x      $	��⚠��6(   
���  ��$��16(�6B   $��3��6P   y�5y       �� *isOverLimit+ �� 	Converter# [  5z      5{      5|      5~      5�      5�      