   M S B A M L   `   `   `  ����P  LCargoManagementSystem, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:CargoManagementSystem.ViewCargoManagementSystem.View  5   	   @    :CargoManagementSystem.View.SellOrderCollectionDetailWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   b ^MaterialDesignThemes.Wpf, Version=3.2.0.1979, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5   	   4local(clr-namespace:CargoManagementSystem.View  5   	     � Title$  卖货订单详细信息��5	   	   $	��600��6   $
��1400��6'    � WindowStartupLocation$ CenterScreen=�64   .��5
      �  � RowDefinitions 5   
   �� 5      $��80 �6   �� 5      $��* �6   .+�5   
   � $��0��6   $��	20,0,20,0q�6    � ColumnDefinitions 5      �� 5      $��2* �6#   �� 5      $��2* �6#   �� 5      $��1* �6#   �� 5      $��1* �6#   �� 5      $��1* �6#   .+�5      ��  �� Orientation$ 
Horizontal=�6   $��0��62   $
��Left=�6B   $��10,0,0,0q�6]   .+�5      �� $��Microsoft YaHei)�6   $��20(�69   $
��Bold"�6G   $��顾客姓名 : ��6Y   $��0,0,0,0q�5   (   $
��Left=�69   $��Center=�6T   �� 5      $��Microsoft YaHei)�6   $��20(�69   $
��Bold"�6G   $��0,0,0,0q�5   (   $
��Left=�69   $��Center=�6T   ��5   Y   �� *?=SellOrderCollectionViewModel.SellOrderCollection.CustomerName+5   T   5      �� 5      $ 
Horizontal=�6   $��1��62   $
��Left=�6B   $��10,0,0,0q�6]   .+�5      �� $��Microsoft YaHei)�6   $��20(�69   $
��Bold"�6G   $��顾客电话 : ��6Y   $��0,0,0,0q�5   (   $
��Left=�69   $��Center=�6T   �� 5       $��Microsoft YaHei)�6   $��20(�69   $
��Bold"�6G   $��0,0,0,0q�5!   (   $
��Left=�69   $��Center=�6T   ��5    Y   �� *><SellOrderCollectionViewModel.SellOrderCollection.CustomerTel+5!   T   5"      �� 5#      $ 
Horizontal=�6   $��2��62   $
��Left=�6B   $��10,0,0,0q�6]   .+�5$      �� $��Microsoft YaHei)�6   $��20(�69   $
��Bold"�6G   $��总成本 : ��6Y   $��0,0,0,0q�5%   (   $
��Left=�69   $��Center=�6T   �� 5&      $��Microsoft YaHei)�6   $��20(�69   $
��Bold"�6G   $��0,0,0,0q�5'   (   $
��Left=�69   $��Center=�6T   ��5&   Y   �� *ECSellOrderCollectionViewModel.SellOrderCollection.TotalPurchasePrize+5'   T   5(      �� 5)      $ 
Horizontal=�6   $��3��62   $
��Left=�6B   $��10,0,0,0q�6]   .+�5*      �� $��Microsoft YaHei)�6   $��20(�69   $
��Bold"�6G   $��总售价 : ��6Y   $��0,0,0,0q�5+   (   $
��Left=�69   $��Center=�6T   �� 5,      $��Microsoft YaHei)�6   $��20(�69   $
��Bold"�6G   $��0,0,0,0q�5-   (   $
��Left=�69   $��Center=�6T   ��5,   Y   �� *A?SellOrderCollectionViewModel.SellOrderCollection.TotalSellPrize+5-   T   5.      �� 5/      $ 
Horizontal=�6   $��4��62   $
��Left=�6B   $��10,0,0,0q�6]   .+�50      �� $��Microsoft YaHei)�6   $��20(�69   $
��Bold"�6G   $��总利润 : ��6Y   $��0,0,0,0q�51   (   $
��Left=�69   $��Center=�6T   �� 52      $��Microsoft YaHei)�6   $��20(�69   $
��Bold"�6G   $��0,0,0,0q�53   (   $
��Left=�69   $��Center=�6T   ��52   Y   �� *><SellOrderCollectionViewModel.SellOrderCollection.TotalProfit+53   T   54      55      &   System.Windows.Controls.DataGrid  56   
   -   5          Name$ DataGrid��56      $��	20,0,20,0q�6%   "   VerticalScrollBarVisibility$ Visible=�68   $   HorizontalScrollBarVisibility$ Visible=�6^      CanUserAddRows .  	   GridLinesVisibility$		 All=�57   w   
   SelectionUnit$

 Cell=�6�      SelectionMode$ Extended=�58      $��1��60   $��Stretch=�6=      AutoGenerateColumns .  $��Center=�59      ��57      �� *20SellOrderCollectionViewModel.SellOrderViewModels+   Columns 5:      1  +MaterialDesignThemes.Wpf.DataGridTextColumn  5;      ,  &System.Windows.Controls.DataGridColumn   Header$ 	商品名��6\      Width5  /System.Windows.Controls.DataGridLengthConverter$
 Auto 6i      
IsReadOnly . 0  *System.Windows.Controls.DataGridTextColumn   FontSize$ 20Q�6�   1  +System.Windows.Controls.DataGridBoundColumn   Binding 64   �� *SellOrder.CargoName+   HeaderStyle 5<      �� 5=       �� 
TargetType=  7System.Windows.Controls.Primitives.DataGridColumnHeader"  6     &  "MaterialDesignDataGridColumnHeader �� BasedOn# [  6K   .�5>      ��  �� Property � �� �� Value$ Center=�6K   �� 5?       � ��$ 15(�69   �� 5@       � �� 5A   "   �� 5B   &   .R�5C   *   �� $
��Wrap=�64    �� TextAlignment$ Center=�6Y   ��6H   �� 6Y   5D   '   5F      5G         ElementStyle 5I      �� 5J      " ��6     ) %MaterialDesignDataGridTextColumnStyle# [ 6@   .�5K      ��  � ��$ Center=�6D   �� 5L       � ��$ Center=�6B   5M      5O        5P      $ 类别��6[   $
 Auto 6g    . $ 20Q�6�    64   �� *SellOrder.Category+ 5Q      �� 5R      "  6    # [  6K   .�5S      ��  � ��$ Center=�6K   �� 5T       � ��$ 15(�69   �� 5U       � �� 5V   "   �� 5W   &   .R�5X   *   �� $
��Wrap=�64   $ Center=�6Y   ��6H   �� 6Y   5Y   '   5[      5\       5^      �� 5_      " ��6    # [ 6@   .�5`      ��  � ��$ Center=�6D   �� 5a       � ��$ Center=�6B   5b      5d        5e      $ 材料��6[   $
 Auto 6g    . $ 20Q�6�    64   �� *SellOrder.Material+ 5f      �� 5g      "  6    # [  6K   .�5h      ��  � ��$ Center=�6K   �� 5i       � ��$ 15(�69   �� 5j       � �� 5k   "   �� 5l   &   .R�5m   *   �� $
��Wrap=�64   $ Center=�6Y   ��6H   �� 6Y   5n   '   5p      5q       5s      �� 5t      " ��6    # [ 6@   .�5u      ��  � ��$ Center=�6D   �� 5v       � ��$ Center=�6B   5w      5y        5z      $ 尺寸��6W   $
 Auto 6c    . $ 20Q�6�    64   �� *SellOrder.Size+ 5{      �� 5|      "  6    # [  6K   .�5}      ��  � ��$ Center=�6K   �� 5~       � ��$ 15(�69   �� 5       � �� 5�   "   �� 5�   &   .R�5�   *   �� $
��Wrap=�64   $ Center=�6Y   ��6H   �� 6Y   5�   '   5�      5�       5�      �� 5�      " ��6    # [ 6@   .�5�      ��  � ��$ Center=�6D   �� 5�       � ��$ Center=�6B   5�      5�        5�      $ 尺寸单位��6[   $
 Auto 6i    . $ 20Q�6�    64   �� *SellOrder.SizeUnit+ 5�      �� 5�      "  6    # [  6K   .�5�      ��  � ��$ Center=�6K   �� 5�       � ��$ 15(�69   �� 5�       � �� 5�   "   �� 5�   &   .R�5�   *   �� $
��Wrap=�64   $ Center=�6Y   ��6H   �� 6Y   5�   '   5�      5�       5�      �� 5�      " ��6    # [ 6@   .�5�      ��  � ��$ Center=�6D   �� 5�       � ��$ Center=�6B   5�      5�        5�      $ 标准品类��6^   $
 Auto 6l    . $ 20Q�6�    64   �� *SellOrder.StdCategory+ 5�      �� 5�      "  6    # [  6K   .�5�      ��  � ��$ Center=�6K   �� 5�       � ��$ 15(�69   �� 5�       � �� 5�   "   �� 5�   &   .R�5�   *   �� $
��Wrap=�64   $ Center=�6Y   ��6H   �� 6Y   5�   '   5�      5�       5�      �� 5�      " ��6    # [ 6@   .�5�      ��  � ��$ Center=�6D   �� 5�       � ��$ Center=�6B   5�      5�        5�      $ 标准名称��6Z   $
 Auto 6h    . $ 20Q�6�    64   �� *SellOrder.StdName+ 5�      �� 5�      "  6    # [  6K   .�5�      ��  � ��$ Center=�6K   �� 5�       � ��$ 15(�69   �� 5�       � �� 5�   "   �� 5�   &   .R�5�   *   �� $
��Wrap=�64   $ Center=�6Y   ��6H   �� 6Y   5�   '   5�      5�       5�      �� 5�      " ��6    # [ 6@   .�5�      ��  � ��$ Center=�6D   �� 5�       � ��$ Center=�6B   5�      5�        5�      $ 仓库��6`   $
 Auto 6l    . $ 20Q�6�    64   �� *SellOrder.WarehouseName+ 5�      �� 5�      "  6    # [  6K   .�5�      ��  � ��$ Center=�6K   �� 5�       � ��$ 15(�69   �� 5�       � �� 5�   "   �� 5�   &   .R�5�   *   �� $
��Wrap=�64   $ Center=�6Y   ��6H   �� 6Y   5�   '   5�      5�       5�      �� 5�      " ��6    # [ 6@   .�5�      ��  � ��$ Center=�6D   �� 5�       � ��$ Center=�6B   5�      5�        5�      $ 楼层��6\   $
 Auto 6h    . $ 20Q�6�    64   �� *SellOrder.PlaneName+ 5�      �� 5�      "  6    # [  6K   .�5�      ��  � ��$ Center=�6K   �� 5�       � ��$ 15(�69   �� 5�       � �� 5�   "   �� 5�   &   .R�5�   *   �� $
��Wrap=�64   $ Center=�6Y   ��6H   �� 6Y   5�   '   5�      5�       5�      �� 5�      " ��6    # [ 6@   .�5�      ��  � ��$ Center=�6D   �� 5�       � ��$ Center=�6B   5�      5�        5�      $ 区域��6\   $
 Auto 6h    . $ 20Q�6�    64   �� *SellOrder.BlockName+ 5�      �� 5�      "  6    # [  6K   .�5�      ��  � ��$ Center=�6K   �� 5�       � ��$ 15(�69   �� 5�       � �� 5�   "   �� 5�   &   .R�5   *   �� $
��Wrap=�64   $ Center=�6Y   ��6H   �� 6Y   5  '   5     5      5     �� 5     " ��6    # [ 6@   .�5     ��  � ��$ Center=�6D   �� 5	      � ��$ Center=�6B   5
     5       5     $ 平均进价��6g   $
 Auto 6u    . $ 20Q�6�    64   �� * SellOrder.AvgUnitPurchasePrize+ 5     �� 5     "  6    # [  6K   .�5     ��  � ��$ Center=�6K   �� 5      � ��$ 15(�69   �� 5      � �� 5  "   �� 5  &   .R�5  *   �� $
��Wrap=�64   $ Center=�6Y   ��6H   �� 6Y   5  '   5     5      5     �� 5     " ��6    # [ 6@   .�5     ��  � ��$ Center=�6D   �� 5      � ��$ Center=�6B   5     5!       5"     $ 单位售价��6`   $
 Auto 6n    . $ 20Q�6�    64   �� *SellOrder.UnitSellPrize+ 5#     �� 5$     "  6    # [  6K   .�5%     ��  � ��$ Center=�6K   �� 5&      � ��$ 15(�69   �� 5'      � �� 5(  "   �� 5)  &   .R�5*  *   �� $
��Wrap=�64   $ Center=�6Y   ��6H   �� 6Y   5+  '   5-     5.      50     �� 51     " ��6    # [ 6@   .�52     ��  � ��$ Center=�6D   �� 53      � ��$ Center=�6B   54     56       57     $ 数量��6Y   $
 Auto 6e    . $ 20Q�6�    64   �� *SellOrder.Amount+ 58     �� 59     "  6    # [  6K   .�5:     ��  � ��$ Center=�6K   �� 5;      � ��$ 15(�69   �� 5<      � �� 5=  "   �� 5>  &   .R�5?  *   �� $
��Wrap=�64   $ Center=�6Y   ��6H   �� 6Y   5@  '   5B     5C      5E     �� 5F     " ��6    # [ 6@   .�5G     ��  � ��$ Center=�6D   �� 5H      � ��$ Center=�6B   5I     5K     4  .System.Windows.Controls.DataGridTemplateColumn  5L     $ 操作��6)   $ * 65    5M     �� 5N     "  6    # [  6K   .�5O     ��  � ��$ Center=�6K   �� 5P      � ��$ 15(�69   �� 5Q      � �� 5R  "   �� 5S  &   .R�5T  *   �� $
��Wrap=�64   $ Center=�6Y   ��6H   �� 6Y   5U  '   5W     5X        CellTemplate 5Z     �� 5[     .R�5\     �� $ 
Horizontal=�6)   $��Stretch=�6B   $��Center=�6^   $��0,0,0,0q�6{   5]     5^     5`     5b     5d     5e     