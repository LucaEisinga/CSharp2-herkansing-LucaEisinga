   M S B A M L   `   `   `  ����b  ^Personal Finance Tracker - Luca Eisinga, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullk:clr-namespace:Personal_Finance_Tracker___Luca_Eisinga.View,Personal_Finance_Tracker___Luca_Eisinga.View  5      F    @Personal_Finance_Tracker___Luca_Eisinga.View.TransactionlistView   5      W SPresentationCore, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=8.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=8.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      Llocal:clr-namespace:Personal_Finance_Tracker___Luca_Eisinga.View     5      
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
�������.+�58      �� -   5        $	��☰��58      $��40(�59      $��70��5:      $��70��5;      $��Center=�5<      $��0,0,40,0q�5>      #��[ 5?       � ContextMenu 5@   
   �� 5A      .@�5B      m� $��Overview��6    m� Command 6-   �� *openOverviewCommand+m� 5C      $��Budgets��6    6,   �� *openBudgetCommand+m� 5D      $��Settings��6    6-   �� *openSettingsCommand+5E      5G      �� 5J      $��Transaction list��6   $��50(�5K      $
��Bold"�5L      $��Center=�5M      ���#3335N      5O      � 5Q   
   $��20q�6   $��1��6    5R      �� 5S      $
��Auto �6    �� 5U      $��* �6    .+�5Z      �� $��0��6    �� Orientation$ 
Horizontal=�6&   $��0 0 0 20q�6?   $
��Left=�6Q   .+�5[      �� $	��150��6   ��6'   �� *sortByOptions+ �� SelectedItem 6M   �� *selectedSortOption+�� 5\      $	��150��6    �� DisplayMemberPath$
 name��6x   ��6'   �� *categoryFilter+ 6N   �� *selectedCategory+6x   �� 5]      $	��150��6   ��6'   �� *transactionTypes+ 6P   �� *selectedTransactionType+�� 5^      $��Apply Filter��6   $	��120��60   ��6<   �� *applyFilterCommand+5_      �� 5b      $��1��6   $
��Auto=�6(   .��5c      �� ��6   �� *filteredTransactions+��5d      �� 5e      .R�5f      �� $��5q�6%    �� Padding$ 10q�60   $ 8��6=   ���#F0F4F8���#DDD$��1q�5g   I   ._�5h   "   �  � ColumnDefinitions 5i   &   �� 5j   *   $
��1.5* �6;   �� 5l   *   $��1* �6;   �� 5n   *   $
��1.5* �6;   �� 5p   *   $
��1.5* �6;   �� 5r   *   $��1* �6;   �� 5t   *   $��1* �6;   .+�5x   &   �� $��0��6O   $
��Bold"�6_   ��60   �� *category.name+6_   �� 5y   &   $��1��6Q   ��60   �� *transactionType+6Q   �� 5z   &   $��2��6X   $��Right=�6h   ��60   �� *amount+ �� StringFormat$ C��6h   �� 5{   &   $��3��6h   $��Right=�6x   ��60   �� *date+$ {0:dd MMM yyyy}��6x   �� 5~   &   $��4��60   $��10,0,0,0q�6@   $��12(�6R   
�������$��CharacterEllipsis=�5   ,   $��🛈 Description��5�   L   $��Center=�5�   ,   $��Right=�6G    � ToolTip 5�   ,   �� *description+5�   G   �� 5�   &   $��5��6-   $
��Edit��6=   $��10 0 0 0q�5�   -   $��Right=�5�   -   $��60��5�   -   ��5�   -   �� *$"DataContext.editTransactionCommand+ �� RelativeSource ��  �� AncestorType UserControl��5�   -   �� 5�   -   5�   #   5�      5�      5�      5�      5�      5�      5�      