   M S B A M L   `   `   `  ����b  ^Personal Finance Tracker - Luca Eisinga, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:Personal_Finance_Tracker___Luca_Eisinga.View,Personal_Finance_Tracker___Luca_Eisinga.View  5   	   [ WLiveChartsCore.SkiaSharpView.WPF, Version=2.0.0.0, Culture=neutral, PublicKeyToken=null}Xclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF LiveChartsCore.SkiaSharpView.WPF 5   	   ?    9Personal_Finance_Tracker___Luca_Eisinga.View.OverviewView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Llocal:clr-namespace:Personal_Finance_Tracker___Luca_Eisinga.View     5   	   hwpfXclr-namespace:LiveChartsCore.SkiaSharpView.WPF;assembly=LiveChartsCore.SkiaSharpView.WPF     5   	   
�������  � 	Resources  5      3  -System.Windows.Media.Effects.DropShadowEffect   
DropShadow   ShadowDepth   Color   Opacity   
BlurRadius  RoundedButton �� 
TargetType �� Property �� Value �� 
StartPoint	 �� EndPoint
 � Color � Offset �� 
TargetType �� CornerRadius��%�  &	        &	 Y       5   
   $ 3Q�5      $ Black��5      $	 0.2Q�5      $ 10Q�5      �� 5   
   " ��6&   .�5      ��  � ��
 �����6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$
 10,5q�6(   �� 5       � ��
 ���� 6,   �� 5       � �� 5      �� 5      $	 0,0&�6*   $		 0,1&�6;   .��5      � $
 	#FF6BD6FF��6'   $	 0.0Q�69   � 5      $
 	#FF1D92D1��6'   $	 1.0Q�69   5      5      �� 5        � �� 5!      �� 5"      " ��6&   .R�5#      �� #��z��6!   $ 10��5$      #��z��5%      $��1q�5&      ._�5'      �� $��Center=�6/   $��Center=�5(   +   5)      5*      5,      5-      5.      .��50      � $��10q�6    � ColumnDefinitions 51   
   �� 52      $
��0.7* �6   �� 54      $
��0.3* �6   .+�59   
   � $��0��6    � RowDefinitions 5:      �� 5<      $
��0.1* �6    �� 5>      $
��0.4* �6    �� 5@      $
��0.5* �6    .+�5D      ]� $��0��6   
�������.+�5F      �� -   5        $	��☰��5F      $��40(�5G      $��70��5H      $��70��5I      $��Center=�5J      $��0,0,40,0q�5L      #��[ 5M       � ContextMenu 5N      �� 5O      .@�5P      m� $��Overview��6'    m� Command 69   �� *openOverviewCommand+m� 5Q      $��Budgets��6'    68   �� *openBudgetCommand+m� 5R      $��Settings��6'    69   �� *openSettingsCommand+5S      5U      �� 5X      $��Overview��6   $��50(�5Y      $
��Bold"�5Z      $��Center=�5[      ���#3335\      5]      � 5`      $��1��6    5a      �� 5b      $��* �6'   �� 5c      $��* �6'   �� 5d      $��* �6'   .+�5h      �� $��0��6   $��70q�6)    �� Padding$ 10q�65   $ 8��6B    J� Effect# [  6S   ��5i      �� 5j      $	 0,0&�6.   $		 0,1&�6?   .��5k      � $
 	#FFB0FFB0��6+   $ 0Q�6=   � 5l      $
 	#FF70D070��6+   $ 1Q�6=   5m      ._�5o      �� $��Center=�6!   $��Center=�6<   .+�5p      �� $��Income��6$   $��20(�62   �� 5q      $
��Bold"�6A   $��20(�6S   ��6$   �� *totalIncome+6S   5r      5s      �� 5v      $��1��6   $��70q�6)   $ 10q�65   $ 8��6B   # [  6S   ��5w      �� 5x      $	 0,0&�6.   $		 0,1&�6?   .��5y      � $
 	#FFFFB0B0��6+   $ 0Q�6=   � 5z      $
 	#FFD07070��6+   $ 1Q�6=   5{      ._�5}      �� $��Center=�6!   $��Center=�6<   .+�5~      �� $��Spent��6$   $��20(�62   �� 5      $
��Bold"�6C   $��20(�6V   ��6$   �� *totalExpenses+6V   5�      5�      �� 5�      $��2��6   $��70q�6)   $ 10q�65   $ 8��6B   # [  6S   ��5�      �� 5�      $	 0,0&�6.   $		 0,1&�6?   .��5�      � $
 	#FF6BD6FF��6+   $	 0.0Q�6=   � 5�      $
 	#FF1D92D1��6+   $	 1.0Q�6=   5�      ._�5�      �� $��Center=�6!   $��Center=�6<   .+�5�      �� $��Balance��6$   $��20(�64   �� 5�      $
��Bold"�6=   $��20(�6P   ��6$   �� *	balance+6P   5�      5�      5�      �� 5�      $��2��6   ���#EEE$��0q�64   ._�5�      5  /LiveChartsCore.SkiaSharpView.WPF.CartesianChart  ,  &LiveChartsCore.SkiaSharpView.WPF.Chart   LegendPosition$ Right=�5�      $��10q�5�      $��2��5�         Series 5�   %   �� *series+   XAxes 5�      �� *xAxis+   YAxes 5�      �� *yAxis+5�      5�      5�      ]� 5�   
   $��1��6   $��10 0 0 0q�6$   .+�5�      �� $��Go to Transactions��6   $	��Top=�5�      $��40��5�      $��0 0 0 10q�6   #��[ 5�      # [  5�      ��5�      �� *openTransactionlistCommand+5�      �� 5�      $��Add Transaction��6   $��Bottom=�5�      $��40��5�      $��0 10 0 0q�6   #��[ 5�      # [  5�      ��5�      �� *openTransactionformCommand+5�      �� 5�      $��Add category��6   $��Bottom=�5�      $��40��5�      $��0 10 0 0q�6   #��[ 5�      # [  5�      ��5�      �� *openCategoryFormCommand+5�      �� 5�      ��6   �� *recentTransactions+��5�      �� 5�      .R�5�      ��  �� Orientation$ 
Horizontal=�6%   $��5q�6>   .+�5�      �� $��80��6[   ��6(   �� *date+ �� StringFormat$ 
{0:dd MMM}��6[   �� 5�      $	��100��6G   ��6(   �� *category.name+6G   �� 5�      $��80��6P    �� TextAlignment$ Right=�6[   ��6(   �� *amount+$ C��6[   5�      5�      5�      5�      5�      5�      