   M S B A M L   `   `   `  ����P  LCargoManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:CargoManagementSystem.ViewCargoManagementSystem.View  5   	   -    'CargoManagementSystem.View.PromptWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   4local(clr-namespace:CargoManagementSystem.View  5   	   -   5          �Name$  Window��5
   	    � Title$ 提示��5	   	   $	��450��6   $	��800��6!    � WindowStartupLocation$ CenterScreen=�6-   .��5      �  � RowDefinitions 5   
   �� 5      $��* �6   �� 5      $��* �6   �� 5      $��90 �6   .+�5   
   �� $��0��6-   $��40(�6:   $��Center=�6H   $��Center=�5      
���  ����5      �� *	Message+5   /   � 5   
   $��1��6    � ColumnDefinitions 5      �� 5      $��1* �6#   �� 5      $��3* �6#   .+�5      �� $��0��6   $��详细信息:��6(   $��Microsoft YaHei)�65   $��20(�6R   $
��Bold"�6`   $	��Top=�6r   $��Center=�6�   �� 5       *  &MaterialDesignOutlinedTextFieldTextBox#���   6   $	��Top=�5       �� AcceptsReturn .  �� TextWrapping$
 Wrap=�6C   " �� VerticalScrollBarVisibility$
 Auto=�5      $��1��5       �� 
IsReadOnly . $��20(�68   $��0,0,40,0q�5      {�5   9   �� 	 �� Path$	 	IsChecked�
 �� ElementName$2
 ,MaterialDesignOutlinedTextBoxEnabledComboBox����5   F   �� *DetailMessage+5      5      � 5   
   $��2��6    5       �� 5!      �� 5"      .+�5$      �� $��0��6   $	��160��6%   $��40��61   $��Center=�6=   $
��Left=�6X   $��	120,0,0,0q�5%   !   +  %MaterialDesignThemes.Wpf.ButtonAssist   CornerRadius$ 8,8,8,8��64     MaterialDesignRaisedButton#���  5'      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�6N   
���������5&   !   �� *CancelCommand+��6C   �� $
 Window��.��5)      �� $��取  消��6   $��Microsoft YaHei)�6(   $��20(�6E   $
��Bold"�6S   5*      �� 5+      $��1��6   $	��160��6%   $��40��61   $��Center=�6=   $��Right=�6X   $��	0,0,120,0q�5,   !   $ 8,8,8,8��64   #���  5.      $ Depth3=�6N   
���������5-      �� *ConfirmCommand+��6<   �� $
 Window��.��50      �� $��确  认��6   $��Microsoft YaHei)�6(   $��20(�6E   $
��Bold"�6S   
���  ��6e   51      52      53      54      