   M S B A M L   `   `   `  ����H  DAssignment_1a, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Assignment_1a.ViewsAssignment_1a.Views  5      Y1clr-namespace:Assignment_1a.ViewModels.Converters#Assignment_1a.ViewModels.Converters  5      1    +Assignment_1a.Views.HouseRepresentationView   5      \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3Views!clr-namespace:Assignment_1a.Views     5      H
Converters1clr-namespace:Assignment_1a.ViewModels.Converters     5        � 	Resources  5       �� 
TargetType �� Property �� Value   	EditStyle �� Triggers �� Binding �� Value<  6Assignment_1a.ViewModels.Converters.ImagePathConverter  ImagePathConverter��%9  '��       &	  H     &	     �� 5      " ��6
   .�5      ��  � ��$ 20��6   5      �� 5      " ��6
   .�5      ��  � ��
 ��d�6"    5      �� 5       6   �� *
EditMode+ true6/   .a�5      ��  � ��
 � � �6$   5      5        5      6"   5      .��5      � $	��500��6   $	��100��6   ���	#77474747 � ColumnDefinitions 5      �� 5      $	��100 �6   �� 5      $	��200 �6   �� 5       $	��200 �6    � ContextMenu 5"      �� 5#      .@�5$      m� $
��Edit��6   	 m� Command	 6   �� *EditCommand+
 �� Mode$
 TwoWay=�m� 5%      $��Delete��6   	 6   �� *DeleteCommand+$
 TwoWay=�5&      .+�5(      � 
����d�$��0��6*   .+�5)      �� ��6   �� *ImageFilePath+ �� 	Converter# [  �� UpdateSourceTrigger$ PropertyChanged=�5*      �� 5+      $��1��6   
�������.+�5,      �� $��18��6   $��2q�6   #��[  5-   H   
���������6   �� *ID+ �� StringFormat$ HouseInfo   ID:  {0}��6k   �� 5.      $��20��6   $��2,0,2,0q�6   
���������5/   
   �� *
Category+$ PropertyChanged=��� 50      $��20��6   $��2,0,2,0q�6   
���������51   
   �� *BuildingType+$ PropertyChanged=��� 52      $��20��6   $��2,0,2,0q�6   
���������53   
   �� *	LegalForm+$ PropertyChanged=��� 54      $��20��6   $��2,0,2,0q�6   
�������6,   55      �� 56      $��2��6   
�������.+�57      �� $��18��6   $��2q�6   $��Adress��6&   #��[  64   
�������6W   �� 58      $��20��6   $��2,0,2,0q�6   
���������59   
   �� *Street+$ PropertyChanged=��� 5:      $��20��6   $��2,0,2,0q�6   
���������5;   
   �� *Zip+$ PropertyChanged=��� 5<      $��20��6   $��2,0,2,0q�6   
���������5=   
   �� *City+$ PropertyChanged=��� 5>      $��20��6   $��2,0,2,0q�6   
���������5?   
   �� *
Country_+$ PropertyChanged=�5@      5A      5B      