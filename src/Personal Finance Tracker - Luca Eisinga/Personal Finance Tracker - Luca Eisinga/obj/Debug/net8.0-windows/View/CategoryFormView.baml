   M S B A M L   `   `   `  ����b  ^Personal Finance Tracker - Luca Eisinga, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:Personal_Finance_Tracker___Luca_Eisinga.View,Personal_Finance_Tracker___Luca_Eisinga.View  5      C    =Personal_Finance_Tracker___Luca_Eisinga.View.CategoryFormView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Llocal:clr-namespace:Personal_Finance_Tracker___Luca_Eisinga.View     5      $	��945��5      $
��1680��6   
�������  � 	Resources  5
      3  -System.Windows.Media.Effects.DropShadowEffect   
DropShadow   ShadowDepth   Color   Opacity   
BlurRadius  RoundedButton �� 
TargetType �� Property �� Value �� 
StartPoint	 �� EndPoint
 � Color � Offset �� 
TargetType �� CornerRadius��%�  &	        &	 Y       5   
   $ 3Q�5      $ Black��5      $	 0.2Q�5      $ 10Q�5      �� 5   
   " ��6&   .�5      ��  � ��
 �����6+   �� 5       � ��$
 Bold"�6+   �� 5       � ��$
 10,5q�6(   �� 5       � ��
 ���� 6,   �� 5       � �� 5      �� 5      $	 0,0&�6*   $		 0,1&�6;   .��5      � $
 	#FF6BD6FF��6'   $	 0.0Q�69   � 5      $
 	#FF1D92D1��6'   $	 1.0Q�69   5      5      �� 5       � �� 5      �� 5       " ��6&   .R�5!      �� #��z��6!   $ 10��5"      #��z��5#      $��1q�5$      ._�5%      �� $��Center=�6/   $��Center=�5&      5'      5(      5*      5+      5,      .��5-      � $��10q�6    � RowDefinitions 5.   
   �� 5/      $
��0.2* �6   �� 51      $��* �6   .+�55   
   ]� $��0��6   
�������.+�57      �� -   5        $	��☰��57      $��40(�58      $��70��59      $��70��5:      $��Center=�5;      $��0,0,40,0q�5=      #��[ 5>       � ContextMenu 5?      �� 5@      .@�5A      m� $��Overview��6    m� Command 61   �� *openOverviewCommand+m� 5B      $��Budgets��6    60   �� *openBudgetCommand+m� 5C      $��Settings��6    61   �� *openSettingsCommand+5D      5F      �� 5I      $��Category form��6   $��50(�5J      $
��Bold"�5K      $��Center=�5L      ���#3335M      5N      � 5P   
   $��1��6    5Q      �� 5R      $
��Auto �6    �� 5T      $
��Auto �6    �� 5V      $��* �6    �� 5X      $
��Auto �6    .+�5]      �� $��0��6   $��0 0 0 10q�6&   .+�5^      �� $��Category Name:��6   $��0 0 0 5q�62   �� 5_      ��6   �� *name+5`      �� 5c      $��1��6   $��0 0 0 10q�6&   .+�5d      �� $��Budget Limit:��6   $��0 0 0 5q�61   �� 5e      ��6   �� *budgetLimit+5f      �� 5i      $��Cancel��6   $��6��6&   $��0��63   $
��Left=�5j      $	��120��60   $��
0,10,10,10q�6<   ��5k      �� *cancelCategoryFormCommand+�� 5m      $��Delete Category��6   $��6��6/   $��1��6<   $��Center=�5n      $	��150��62   $��
0,10,10,10q�6>   ��5o      �� *deleteCategoryFormCommand+�� 5q      $��Save Transaction��6   $��6��60   $��1��6=   $��Right=�5r      $	��150��61   $��
10,10,0,10q�6=   ��5s      �� *saveCategoryFormCommand+5t      5u      5v      