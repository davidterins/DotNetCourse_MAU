   M S B A M L   `   `   `  ����H  DAssignment_1a, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Assignment_1a.ViewsAssignment_1a.Views  5      C&clr-namespace:Assignment_1a.ViewModelsAssignment_1a.ViewModels  5   	   $    Assignment_1a.Views.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3Views!clr-namespace:Assignment_1a.Views     5      =
ViewModels&clr-namespace:Assignment_1a.ViewModels     5   	      MainViewModel  � DataContext#  �   5	      $	��700��5   Q   $
��1000��6^   ���	#77474747 � Title 6	   �� *CurrentFileInUse+ �� UpdateSourceTrigger$ PropertyChanged=� � 	Resources 5      2   ,Assignment_1a.ViewModels.MainWindowViewModel �� 
TargetType �� Property �� Value  HeaderTextBlockStyle  AddButtonStyle��%t  &	        '��      &	 �     '�� �     '�� [    &	 �      5      6#   �� 5      " ��6
   .�5      ��  � ��
 �   �6"   �� 5       � ��$ 2q�6   5      �� 5      " ��6
   .�5      ��  � ��$ 15(�6    �� 5       � ��
 �   �6"   5      �� 5      " ��6
   .�5      ��  � ��
 �   �6"   �� 5       � ��$ 2q�6   5      �� 5       " ��6
   .�5!      ��  � ��
 �   �6"   �� 5"       � ��$ 2q�6   5#      �� 5%      " ��6
   .�5&      ��  � ��
 �����6"   �� 5'       � ��
 ��d�6"   5(      5*      .��5,      ]� #  [  6   .+�5-      o� $	��Top=�6	   ���	#77474747.@�5.      m� $��_File��6   
�������.@�5/      m� $
��_New��6   
���   �6   m� 50      $��_Open��6   
���   � m� Command 6=   �� *ImportSavedCommand+m� 51      $��_Save��6   
���   � 61   �� *SaveCommand+m� 52      $
��_XML��6   
���   �.@�53      m� $��Import from XML file��6    6.   �� *ImportFromXMLCommand+m� 54      $��Export to XML file��6    6,   �� *ExportToXMLCommand+55      �� 56      m� 57      $��_Exit��6   
���   �6   58      59      ]� 5:      $��0,40,0,0q�6   ���	#77474747.+�5;      �� $
��Auto��6   $	��500��6   $
��Left=�6+   
�������$��10q�6X   .+�5<      �� $��Search��6   
����������#474747$��24��6D   �� 5=      ��6   �� *SearchFilter+ �� Mode$ TwoWay=�$ PropertyChanged=��� 5>      ��6   �� *CollectionView+$ PropertyChanged=���5@      �� 5A      	 �� DataType1   +Assignment_1a.Views.HouseRepresentationView"	  6   .R�5B          6&   �� 5C      5E      5F      )   #Assignment_1a.Views.HouseEditorView  5G        6   �� *HouseEditViewModel+5H      5I      5J      