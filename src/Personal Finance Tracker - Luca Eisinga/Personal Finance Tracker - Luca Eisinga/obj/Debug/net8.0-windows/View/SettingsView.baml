   M S B A M L   `   `   `  ����b  ^Personal Finance Tracker - Luca Eisinga, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:Personal_Finance_Tracker___Luca_Eisinga.View,Personal_Finance_Tracker___Luca_Eisinga.View  5   	   ?    9Personal_Finance_Tracker___Luca_Eisinga.View.SettingsView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   Llocal:clr-namespace:Personal_Finance_Tracker___Luca_Eisinga.View     5   	   
�������$	��945��5	   	   $
��1680��6     � 	Resources  5
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
�������.+�58      �� -   5        $	��☰��58      $��40(�59   	   $��70��5:   	   $��70��5;   	   $��Center=�5<   	   $��0,0,40,0q�5>   	   #��[ 5?   	    � ContextMenu 5@      �� 5A      .@�5B      m� $��Overview��6#    m� Command 65   �� *openOverviewCommand+m� 5C      $��Budgets��6#    64   �� *openBudgetCommand+m� 5D      $��Settings��6#    65   �� *openSettingsCommand+5E      5G      �� 5J      $��Settings��6   $��50(�5K      $
��Bold"�5L      $��Center=�5M      ���#3335N      5O      �� 5Q   
    �� Orientation$ Vertical=�6   $��1��6,   .+�5T      �� $ 
Horizontal=�6   .+�5U      �� $��Export as JSON��6   $	��100��62   ��6>   �� *exportCommand+5V      �� 5Y      $
��Left=�6   $��Import��60   $	��100��6A   ��6M   �� *importCommand+�� 5\      $ 
Horizontal=�6   $��Center=�62   .+�5]      �� $��Dark Theme:��6   $��Center=�6/   �� 5^      $��Center=�6=    d� 	IsChecked 6   �� *isDarkTheme+6=   5_      �� 5b      $ 
Horizontal=�6   $��Center=�62   .+�5c      �� $��	Currency:��6   $��Center=�6-   �� 5d      $	��150��6   ��6'   �� *
currencies+ �� SelectedItem 6J   �� *selectedCurrency+5e      �� 5h      $ 
Horizontal=�6   $��Center=�62   .+�5i      �� $��Reset All Data��6   $	��150��62   ��6>   �� *resetCommand+�� 5j      $O��I⚠ This will delete all data. You'll need to re-add everything manually.��6   
���  ��$��Center=�5k   )   5l      5n      5o      5p      