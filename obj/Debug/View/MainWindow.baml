   M S B A M L   `   `   `  ����P  LCargoManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:CargoManagementSystem.ViewCargoManagementSystem.View  5   	   +    %CargoManagementSystem.View.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   :d2http://schemas.microsoft.com/expression/blend/2008  5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   :local(clr-namespace:CargoManagementSystem.View     5   	     � Title$  仓库管理系统��5
   	   $	��520��6   $
��1000��6%    � WindowStartupLocation$ CenterScreen=�62    � 	Resources 5       �� MergedDictionaries �� Source�� 5   
    5      �� 5      $g apack://application:,,,/MaterialDesignThemes.Wpf;component/Themes/MaterialDesignTheme.TextBox.xaml?�6%   %    5      .��5      �  � ColumnDefinitions 5   
   �� 5      $	��160 �6   �� 5      $��* �6   .+�5   
   �� ���#FFFFFF$��0��6&    J� Effect 5      3  -System.Windows.Media.Effects.DropShadowEffect  5         Color$ #828282��6#      ShadowDepth$ 20Q�63   	   Opacity$		 0.1Q�6D   
   
BlurRadius$
 30Q�6R   5      � 5   
   $��0��6    � RowDefinitions 5      �� 5      $��80 �6    �� 5      $
��Auto �6    .+�5!      �� $��0��6   
�������$��0 0 0 1q�69   $��	25 0 25 0q�6S   ._�5"      �� $��功能列表��6    $   MaterialDesignHeadline6TextBlock#��[  6(   $��Center=�6b   $��Center=�6}   5#      �� 5$      $��1��6   .+�5%      �� -   5         ��Name$ SearchButton��5%        MaterialDesignRaisedButton#���  6/   +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth3=�6d   $��
15 30 15 0q�6�   .��5&      �� $��货物查询��6    $��Microsoft YaHei)�6,   $��15(�6I   $
��Bold"�6W   5'      �� 5(      -   5        $ WarehouseManagementButton��5(      #���  6<   $ Depth3=�6q   $��
15 30 15 0q�6�   .��5)      �� $��仓库管理��6    $��Microsoft YaHei)�6,   $��15(�6I   $
��Bold"�6W   5*      �� 5+      -   5        $ CatgoryManagementButton��5+      #���  6:   $ Depth3=�6o   $��
15 30 15 0q�6�   .��5,      �� $��货品管理��6    $��Microsoft YaHei)�6,   $��15(�6I   $
��Bold"�6W   5-      �� 5.      -   5        $ SellCargoButton��5.      #���  62   $ Depth3=�6g   $��
15 30 15 0q�6�   .��5/      �� $��卖  货��6    $��Microsoft YaHei)�6,   $��15(�6I   $
��Bold"�6W   50      �� 51      -   5        $ PurchaseCargoButton��51      #���  66   $ Depth3=�6k   $��
15 30 15 0q�6�   .��52      �� $��进  货��6    $��Microsoft YaHei)�6,   $��15(�6I   $
��Bold"�6W   53      �� 54      -   5        #���  54      $ Depth3=�6N   $��
15 30 15 0q�6   .��55      �� $��历史进货订单��6    $��Microsoft YaHei)�6.   $��15(�6K   $
��Bold"�6Y   56      �� 57      -   5        #���  57      $ Depth3=�6N   $��
15 30 15 0q�6   .��58      �� $��历史卖货订单��6    $��Microsoft YaHei)�6.   $��15(�6K   $
��Bold"�6Y   59      5;      5<      � 5=   
   -   5         �Name$ 	ShowPanel��5=      $��1��6"   $��
20,20,20,0q�62   5?      5B      5C      