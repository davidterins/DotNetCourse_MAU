   M S B A M L   `   `   `  ����H  DAssignment_2b, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Assignment_2b.ViewsAssignment_2b.Views  5      $    Assignment_2b.Views.PlayerView   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Assignment_2b.Views     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      ��5	   7   Z� .��5
      � .+�5      �� $	��430��6   .+�5      "   Assignment_2b.Views.HandView    � DataContext  6   �� *Hand+�� 5       �� Orientation$ 
Horizontal=�6   .+�5      �� $��Heavy"�6   
���������66   �� *
PlayerID+�� 5      $��Heavy"�6   
�������$��10,0,0,0q�66   ��6H   �� *Score+ �� StringFormat$ 
Score: {0}�� �� UpdateSourceTrigger$ PropertyChanged=�5      �� 5      $��10q�6   $ 
Horizontal=�6n   $��Center=�6�   {�6   �� *
IsInGame+ �� Mode$ TwoWay=�$ PropertyChanged=�.+�5      ��  � ToolTip$	 Hit��6   
�������$��0q�6.   $��5,0,5,0q�6;   $��40��6L   $��40��6X   ��6c   �� *
HitCommand+$ PropertyChanged=�.��5      '  !MaterialDesignThemes.Wpf.PackIcon  
�������$��38��62   $��38��6=   �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$
 Plus=�6I    � Cursor$
 Hand��6U   5      �� 5      $ Stand��6   $��5,0,5,0q�6   $��0q�6.   $��40��6;   $��40��6G   ��6R   �� *StandCommand+$ PropertyChanged=�.��5        
�������$��38��62   $��38��6=   $
 Hand=�6I   $
 Hand��6V   5      �� 5      $ Shuffle��6   $��5,0,5,0q�6   $��0q�60   $��40��6<   $��40��6H   ��6S   �� *ShuffleCommand+$ PropertyChanged=�.��5        
�������$��38��62   $��38��6=   $ Shuffle=�6I   $
 Hand��6Y   5      �� 5      $ Split��6   $��5,0,5,0q�6   $��0q�6.   $��40��6<   $��40��6H   ��6S   �� *SplitCommand+$ PropertyChanged=�.��5        
�������$��38��62   $��38��6=   $ 	CallSplit=�6I   $
 Hand��6[   5      �� 5       $ Double��6   $��5,0,5,0q�6   $��0q�6/   $��40��6;   $��40��6G   ��6R   �� *DoubleCommand+$ PropertyChanged=�.��5!        
�������$��38��62   $��38��6=   $ ChevronDoubleUp=�6I   $
 Hand��6a   5"      5#      5%      5&      5'      