   M S B A M L   `   `   `  ����F  BWPF_Watcher, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:WPF_WatcherWPF_Watcher  5   	       WPF_Watcher.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:WPF_Watcher     5   	     � Title$  Watch your files��5   	   $	��500��6"   $	��800��6/    � 
ResizeMode$ CanMinimize=�5	   	   .��5
      �  � RowDefinitions 5   
   �� 5      $	��57* �6   �� 5      $	��70* �6   �� 5      $
��290* �6    � ColumnDefinitions 5   
   �� 5      �� 5      �� 5      .+�5   
   �� $��Путь к файлу:��6   $
��Left=�6(   $��Center=�6C   �� 5   
   -   5        $��FileWay��5      $
��Left=�6!   $��23��6<   $��
87,17,0,17q�6H    �� TextWrapping$
 Wrap=�6\   $��Center=�6p   $	��695��6�   $��3��6�   �� 5   
   -   5        $��Start��5      $��Start��6   $��1��6/   $��Center=�6<   $��Center=�6Y   ��6�   ��    Button_Template �� Source# [  �� 5   
   -   5        $��Display��5      $��3��6!   $��2��65   $��Center=�6B   $	��780��6_   $��5q�6k   �� 5   
   $
��Logs��6   $��1��6   $��1��6/   
���<��$��Center=�6Q   $	��Top=�6n   $��16(�6�   $
��Bold"�6�   �� 5   
   -   5        $
��Stop��5   �   $
��Stop��6   $��2��6    $��1��60   $��Center=�6=   $��Center=�6X   ��6u   �� # [  6�   �� 5   
   -   5        $��Clear��5      $��Clear��6   $��1��6.   $��1��6>   $��Bottom=�6K   $��Center=�6f   $��0 0 0 5q�6�   ��6�   �� # [  6�   5      5      