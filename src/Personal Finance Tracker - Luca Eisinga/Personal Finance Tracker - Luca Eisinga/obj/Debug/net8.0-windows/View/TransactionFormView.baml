   M S B A M L   `   `   `  ����b  ^Personal Finance Tracker - Luca Eisinga, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:Personal_Finance_Tracker___Luca_Eisinga.View,Personal_Finance_Tracker___Luca_Eisinga.View  5   	   F    @Personal_Finance_Tracker___Luca_Eisinga.View.TransactionFormView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Llocal:clr-namespace:Personal_Finance_Tracker___Luca_Eisinga.View     5   	   $	��945��5   	   $
��1680��6   
�������  � 	Resources  5
      3  -System.Windows.Media.Effects.DropShadowEffect   
DropShadow   ShadowDepth   Color   Opacity   
BlurRadius  RoundedButton �� 
TargetType �� Property �� Value �� 
StartPoint	 �� EndPoint
 � Color � Offset �� 
TargetType �� CornerRadius��%�  &	        &	 Y       5   
   $ 3Q�5      $ Black��5      $	 0.2Q�5      $ 10Q�5      �� 5   
   " ��6&   .�5      ��  � ��
 �����6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$
 10,5q�6(   �� 5       � ��
 ���� 6,   �� 5       � �� 5      �� 5      $	 0,0&�6*   $		 0,1&�6;   .��5      � $
 	#FF6BD6FF��6'   $	 0.0Q�69   � 5      $
 	#FF1D92D1��6'   $	 1.0Q�69   5      5      �� 5       � �� 5      �� 5       " ��6&   .R�5!      �� #��z��6!   $ 10��5"      #��z��5#      $��1q�5$      ._�5%      �� $��Center=�6/   $��Center=�5&   #   5'      5(      5*      5+      5,      .��5.      � $��10q�6    � RowDefinitions 5/   
   �� 50      $
��0.2* �6   �� 52      $��* �6   .+�56   
   ]� $��0��6   
�������.+�58      �� -   5        $	��☰��58      $��40(�59      $��70��5:      $��70��5;      $��Center=�5<      $��0,0,40,0q�5>      #��[ 5?       � ContextMenu 5@      �� 5A      .@�5B      m� $��Overview��6    m� Command 61   �� *openOverviewCommand+m� 5C      $��Budgets��6    60   �� *openBudgetCommand+m� 5D      $��Settings��6    61   �� *openSettingsCommand+5E      5G      �� 5J      $��Transaction form��6   $��50(�5K      $
��Bold"�5L      $��Center=�5M      ���#3335N      5O      � 5Q   
   $��20q�6   $��1��6    5R      �� 5S      $
��Auto �6    �� 5U      $
��Auto �6    �� 5W      $
��Auto �6    �� 5Y      $
��Auto �6    �� 5[      $
��Auto �6    �� 5]      $��* �6    �� 5_      $
��Auto �6     � ColumnDefinitions 5b      �� 5c      $��* �6#   �� 5d      $��* �6#   �� 5e      $��* �6#   .+�5i      �� $��	Category:��6   $��0��6)   $��3��66   �� 5j      $��0��6   $��3��6$   $��	0,20,0,10q�68    �� DisplayMemberPath$
 name��5l      ��5k      �� *
categories+ �� SelectedItem 5m      �� *selectedCategory+�� 5p      $��Amount:��6   $��1��6'   $��3��64   �� 5q      $��1��6   $��3��6#   $��	0,20,0,10q�67   ��5r      �� *amount+�� 5u      $��Transaction Type:��6   $��2��61   $��2��6>   �� 5v      $��2��6   $��3��6$   $��	0,20,0,10q�68   ��5w      �� *transactionTypes+ 5x      �� *selectedTransactionType+�� 5{      $��Date:��6   $��3��6%   $��2��62   (  "System.Windows.Controls.DatePicker  5|      $��3��6   $��3��6&   $��	0,20,0,10q�6:      SelectedDate 5}      �� *date+�� 5�      $��Description:��6   $��4��6,   $��2��69   �� 5�      $��4��6   $��3��6#   $��	0,20,0,10q�67   ��5�      �� *description+�� 5�      $��Cancel��6   $��6��6&   $��0��63   $
��Left=�5�      $	��120��6,   $��	0,10,10,0q�68   ��5�      �� *cancelTransanctionFormCommand+�� 5�      $��Delete Transaction��6   $��6��62   $��1��6?   $��Center=�5�      $	��150��62   $��	0,10,10,0q�6>   ��5�      �� *deleteTransactionFormCommand+�� 5�      $��Save Transaction��6   $��6��60   $��2��6=   $��Right=�5�      $	��150��6-   $��	10,10,0,0q�69   ��5�      �� *saveTransactionFormCommand+5�      5�      5�      