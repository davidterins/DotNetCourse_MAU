   M S B A M L   `   `   `  ����H  DAssignment_2b, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:Assignment_2b.ViewsAssignment_2b.Views  5      %    Assignment_2b.Views.LogInScreen   5      R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5      R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      3local!clr-namespace:Assignment_2b.Views     5      V RMaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=nullFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5      .��5      #  MaterialDesignThemes.Wpf.Card  $	��300��6   $	��300��6#   .��5      �   � RowDefinitions  5      �� 5      $��30 �6   �� 5      $
��Auto �6   �� 5      �� 5      $��30 �6   .+�5      �� ���	#FF09090A.+�5      �� $��0��6   $��
Black jack��6   
�������$��Center=�6A   5      � 5      $��1��6
     5      �� 5      $
��Auto �6   �� 5      $
��Auto �6   �� 5      $
��Auto �6    � ColumnDefinitions 5      �� 5       $	��100 �6   �� 5!      $��* �6   .+�5$      �� $��0��6   
������� �� Padding$ 10q�65   $��Userame/Email:��6B   $	��100��6Y   �� 5%      $��	10,5,10,5q�6   $��1��6!   $	��200��62   
���   ���6>   �� *
UserName+ �� Mode$ TwoWay=�6e   �� 5(      $��1��6   
�������$ 10q�61   $��	Password:��6>   $	��100��6O   G� 5)      -   5         G�Name$ PasswordBox��5)   C   $��	10,5,10,5q�6   $��1��6%   $��1��65   $	��200��6Y   6e   �� 5+      $��2��6   $��2��6   $��	10,5,10,5q�6.   $��Sign in��6A   ��6S   �� *LoginCommand+5,      � 5.      $��2��6
     5/      �� 50      $
��Auto �6   �� 51      $
��Auto �6   �� 52      $
��Auto �6    54      �� 55      $	��100 �6   �� 56      $��* �6   .+�59      �� $��0��6   
�������$ 10q�65   $��Userame/Email:��6B   $	��100��6Y   �� 5:      $��	10,5,10,5q�6   $��1��6!   $	��200��62   
���   ���6>   �� *NewUserName+$ TwoWay=�6h   �� 5=      $��1��6   
�������$ 10q�61   $��	Password:��6>   $	��100��6O   G� 5>      -   5        $ NewPassword��5>   N   $��	10,5,10,5q�6   $��1��6%   $��1��65   $	��200��6B   6c   �� 5@      $��2��6   $��2��6   $��	10,5,10,5q�6.   $��Sign up��6A   ��6S   �� *SignUpCommand+5A      ]� 5C      $��3��6   ���	#FF09090A.+�5D      �� $��30��6:   $��30��6E   $��0q�6Q   ��6   Z� ��6#   Z� ��5E      �� *DeleteDBCommand+.��5F      '  !MaterialDesignThemes.Wpf.PackIcon  �  �ControlzEx.PackIconBase`1[[MaterialDesignThemes.Wpf.PackIconKind, MaterialDesignThemes.Wpf, Version=2.5.0.1205, Culture=neutral, PublicKeyToken=null]]   Kind$ Refresh=�6   5G      5H      5O      5P      5Q      