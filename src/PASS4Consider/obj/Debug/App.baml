   M S B A M L   `   `   `  ����H  DPASS4Consider, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null-clr-namespace:PASS4ConsiderPASS4Consider  5      b ^PresentationFramework.Aero2, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35hKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2Microsoft.Windows.Themes 5      a ]PresentationFramework.Aero, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35gJclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.AeroMicrosoft.Windows.Themes 6i       PASS4Consider.App   5      W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      -localclr-namespace:PASS4Consider     5      ^ThemesKclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero2     5      ^Themes1Jclr-namespace:Microsoft.Windows.Themes;assembly=PresentationFramework.Aero     6i     �� 	Resources  5         FocusVisual �� Property �� Value J� SnapsToDevicePixels �� StrokeDashArray  ComboBox.Static.Background �� EndPoint �� 
StartPoint � Color � Offset  ComboBox.Static.Border	 �� Color ' #ComboBox.Static.Editable.Background # ComboBox.Static.Editable.Border . *ComboBox.Static.Editable.Button.Background * &ComboBox.Static.Editable.Button.Border  ComboBox.MouseOver.Glyph ! ComboBox.MouseOver.Background 	 ComboBox.MouseOver.Border *
 &ComboBox.MouseOver.Editable.Background & "ComboBox.MouseOver.Editable.Border 1 -ComboBox.MouseOver.Editable.Button.Background - )ComboBox.MouseOver.Editable.Button.Border  ComboBox.Pressed.Glyph  ComboBox.Pressed.Background  ComboBox.Pressed.Border ( $ComboBox.Pressed.Editable.Background $  ComboBox.Pressed.Editable.Border / +ComboBox.Pressed.Editable.Button.Background + 'ComboBox.Pressed.Editable.Button.Border  ComboBox.Disabled.Glyph   ComboBox.Disabled.Background  ComboBox.Disabled.Border ) %ComboBox.Disabled.Editable.Background % !ComboBox.Disabled.Editable.Border 0 ,ComboBox.Disabled.Editable.Button.Background , (ComboBox.Disabled.Editable.Button.Border  ComboBox.Static.Glyph  ComboBoxToggleButton
 �� 
TargetType �� 
TargetType+  %Microsoft.Windows.Themes.ButtonChrome  Name   BorderBrush   
Background J� IsMouseOver   RenderMouseOver   RenderPressed   RoundCorners F�Name  DownArrowGeometry �� Triggers P� Property P� Value �� 
TargetName  ComboBoxTemplate �Name � ColumnDefinitions �Name � AllowsTransparency �� Mode �� RelativeSource5  /Microsoft.Windows.Themes.SystemDropShadowChrome  Name   Color  �� MaxDropDownHeight! �� ElementName" d�Name# d� 	IsChecked$ ��Name% �� SelectionBoxItemTemplate& �� SelectionBoxItem#' �� SelectionBoxItemStringFormat( �� ContentStringFormat) J� IsHitTestVisible* P� 
SourceName+ ]� 
Conditions, �� Property- �� Value   TextBox.Static.Background ! ComboBoxEditableTextBox. ��Name " ComboBoxEditableTemplate5  /Microsoft.Windows.Themes.SystemDropShadowChrome/ ��Name0 �� ClearTypeHint1 ��Name2 ��Name-  'System.Windows.Input.KeyboardNavigation3   DirectionalNavigation,  &Microsoft.Windows.Themes.ListBoxChrome4  Name5   BorderBrush6   BorderThickness7   
Background8   RenderMouseOver9 J� IsKeyboardFocusWithin:   RenderFocused; ��Name< �� 
IsReadOnly # ComboBoxStyleSelf= �� Triggers��%?   &	        &	 �     &	 F    &	 i    &	 �    &	 �    &	 �    &	 �    &	     &		 �    &	
 �    &	 �    &	 !    &	 �    &	 �    &	     &	 �    &	 �    &	 �    &	     &	 �    &	 �    &	 �    &	     &	 0    &	 S    &	 v    &	 �    &	 �    &	 �    7  &	 �	    7  &	  +    &	! N    &	" n    7 ! 7  &	# "    7   7  7  7  7 " �� 5	   
   .�5
      ��  � �� 5      �� 5      .R�5      �� $��2q�6$    . #��� ��6J   $��1��6�   $	 1 2R�6�   5      5      5      �� 5   
   $	 0,1&�6A   $	 0,0&�6P   .��5      � $ 	#FFF0F0F0��6   $	 0.0Q�6-   � 5      $ 	#FFE5E5E5��6   $	 1.0Q�6-   5      �� 5   
   $	 	#FFACACAC��69   �� 5   
   $	 	#FFFFFFFF��6F   �� 5   
   $	 	#FFABADB3��6B   �� 5   
   $	 Transparent��6M   �� 5   
   $	 Transparent��6I   �� 5   
   $	 	#FF000000��6;   �� 5   
   $	 0,1&�6D   $	 0,0&�6S   .��5      � $ 	#FFECF4FC��6   $	 0.0Q�6-   � 5      $ 	#FFDCECFC��6   $	 1.0Q�6-   5      �� 5    
   $	 	#FF7EB4EA��6<   �� 5!   
   $	 	#FFFFFFFF��6I   �� 5"   
   $	 	#FF7EB4EA��6E   �� 5#   
   $	 0,1&�6T   $	 0,0&�6c   .��5$      � $ 	#FFEBF4FC��6   $	 0.0Q�6-   � 5%      $ 	#FFDCECFC��6   $	 1.0Q�6-   5&      �� 5'   
   $	 	#FF7EB4EA��6L   �� 5(   
   $	 	#FF000000��69   �� 5)   
   $	 0,1&�6B   $	 0,0&�6Q   .��5*      � $ 	#FFDAECFC��6   $	 0.0Q�6-   � 5+      $ 	#FFC4E0FC��6   $	 1.0Q�6-   5,      �� 5-   
   $	 	#FF569DE5��6:   �� 5.   
   $	 	#FFFFFFFF��6G   �� 5/   
   $	 	#FF569DE5��6C   �� 50   
   $	 0,1&�6R   $	 0,0&�6a   .��51      � $ 	#FFDAEBFC��6   $	 0.0Q�6-   � 52      $ 	#FFC4E0FC��6   $	 1.0Q�6-   53      �� 54   
   $	 	#FF569DE5��6J   �� 55   
   $	 	#FFBFBFBF��6:   �� 56   
   $	 	#FFF0F0F0��6?   �� 57   
   $	 	#FFD9D9D9��6;   �� 58   
   $	 	#FFFFFFFF��6H   �� 59   
   $	 	#FFBFBFBF��6D   �� 5:   
   $	 Transparent��6O   �� 5;   
   $	 Transparent��6K   �� 5<   
   $	 	#FF606060��68   �� 5=   
   "
 d�6-   .�5>      ��  �@�OverridesDefaultStyle . 66   �� 5?       � �� .  6*   �� 5@       � |� .  6*   �� 5A       �@��	ClickMode$ Press=�6*   �� 5B       � ��
 ���� 6+   �� 5C       � �� 5D      �� 5E      " d�6&   .R�5F        $ Chrome��6/   # z��6?   # z��6k   # z 6�   # z��6�    .   . #��� r�6!  ._�5G      F� $ Arrow��6#   8��  
���   �$��Center=�6i   $��0,1,0,0q�6�   $��Center=�6�   5H       5I      P� 5J       �@d�	IsChecked$
 trueY�6;   . �5K   "   �� $ Chrome��6B    �@ RenderPressed . 6V   5L      P� 5M       � {� .  . �5N   "   �� $ Arrow��69    � �� �#AFAFAF6L   5O      5Q      5S      5T      �� 5U   
   " ��63   .R�5V      � $ templateRoot��6    .  5W      �� 5X      $��* �6'   �� 5Y      #��� r�6'   $��0 �6z   .+�5[      � $ 
PART_Popup��6    . $��2��6F   $��1q�6�   #��� .�6�   $��Bottom=�6  ��6Z   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+.��5\        $ shadow��64   $ Transparent��6D   #��z  6X   ��6�   �� *ActualWidth+$! templateRoot��5]      d� 5^      $" toggleButton��6   #��z��65   #��z��6a   #��z��6�   $��2��6�   8��  # 6�   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+66  �� 5_      $$ contentPresenter��6#   #��z% 6=   #��z��6z   #��z& 6�   #( z' 6�   #��z��6-  ) .  #��z��6�  # z 6�  #��z��6�  5`       5a      P� 5b      $* 
PART_Popup��63    �@�HasDropShadow . . �5c      �� $ shadow��6/    � ��$ 0,0,5,5q�6C   �� 5d      $ shadow��6.    �@ Color$ 	#71000000��6B   5e      P� 5f       �@��HasItems .  . �5g      �� $ dropDownBorder��6@    � ��$ 95��6\   5h      ]� 5i      + 5j      �� 5k      , �@��
IsGrouping- . 6:   �� 5l      ", �@%�IsVirtualizingWhenGrouping- .  6\   ./�5n      ��  � �� .  6F   5o      P� 5p      $* DropDownScrollViewer��6C    � �� .  . �5q      �� $ 
opaqueRect��63    6K   �� *VerticalOffset+$! DropDownScrollViewer�� �@��Top�� 5r      $ 
opaqueRect��64    6L   �� *HorizontalOffset+$! DropDownScrollViewer�� �@��Left5s      5u      �� 5v   
   $	 	#FFFFFFFF��6<   �� 5w   
   "
 ��60   .�5x      ��  �@�OverridesDefaultStyle . 66   �� 5y       �@J�	AllowDrop . 6*   �� 5z       � ��$ 0��6)   �� 5{       � ��$ 0��6*   �� 5|       �@�FocusVisualStyle 61   Z� �� 5}       �@��PanningMode$ VerticalFirst=�69   �� 5~       �@��IsFlicksEnabled .  67   �� 5       � �� 5�      �� 5�      " ��6&   .R�5�      �� $. PART_ContentHost��6'   
������ |�.  $��Hidden=�6l   $��Hidden=�6�   5�      5�      5�      �� 5�   
   " ��6;   .R�5�      � $ 	Placement��6    .  5�      �� 5�      $��* �6'   �� 5�      $
��Auto �6'   .+�5�      � $ 
PART_Popup��6    . $��2��6F   #��� .�6�   $��Bottom=�6  ��6Z   �� *IsDropDownOpen+ �� *TemplatedParent+.��5�        $
 Shdw��65   $ Transparent��6C   #��z  6W   ��6�   �� *ActualWidth+$! 	Placement��._�5�      �� $/ DropDownBorder��6!   #��� ��69   $��1q�6�   #��� ��6�   ._�5�      �� $. DropDownScrollViewer��6+   .��5�   "   � $0 Enabled=�6'   .+�5�   &   �� $
��Left=�6-   $��0��6H   $	��Top=�6S   $��0��6k   .+�5�   *   �� $1 
OpaqueRect��64   ��6H   �� *
Background+$! DropDownBorder����6�   �� *ActualHeight+$! DropDownBorder����6�   �� *ActualWidth+$! DropDownBorder��5�   '   �� 5�   &   $2 ItemsPresenter��65   $3 	Contained=�6M   # z 6�   5�   #   5�      5�      5�      5�        5�      $4 Border��6(   #5 z��68   #6 z��6d   #7 z��6�   $��2��6�   #8 z 6�   #: z9 6  �� 5�      $; PART_EditableTextBox��6   #��z��68   #��z��6�   8��  #��z��6)  < 6�   �� *
IsReadOnly+ �� *TemplatedParent+6)  d� 5�      $��1��6   8�� # 6/   �� *IsDropDownOpen+$ TwoWay=� �� *TemplatedParent+6�   5�       5�      P� 5�       �@J�IsKeyboardFocusWithin . . �5�      ��  � ��
 �   �63   5�      P� 5�       �@��IsDropDownOpen . . �5�      �� $ Border��66    �@ RenderFocused . 6J   5�      P� 5�       �@��HasItems .  . �5�      �� $ DropDownBorder��6/    � ��$ 95��6K   5�      P� 5�       � {� .  . �5�      �� # � ��63    � ���� 5�       � �� �	#FFF4F4F463   5�      ]� 5�      + 5�      �� 5�      , �@��
IsGrouping- . 6:   �� 5�      ", �@%�IsVirtualizingWhenGrouping- .  6\   ./�5�      ��  � �� .  6F   5�      P� 5�      $* 
PART_Popup��63    �@�HasDropShadow . . �5�      �� $
 Shdw��6/    � ��$ 0,0,5,5q�6A   �� 5�      $
 Shdw��6.    �@ Color$ 	#71000000��6@   5�      P� 5�      $* DropDownScrollViewer��6C    � �� .  . �5�      �� $ 
OpaqueRect��63    6K   �� *VerticalOffset+$! DropDownScrollViewer�� �@��Top�� 5�      $ 
OpaqueRect��64    6L   �� *HorizontalOffset+$! DropDownScrollViewer�� �@��Left5�      5�      �� 5�   
   "
 ��6*   .�5�      ��  �@�FocusVisualStyle8   61   �� 5�       � ��8  6+   �� 5�       � ��8  6,   �� 5�       � ��# � ��6+   �� 5�       � ��$ 1q�60   �� 5�       � ��$
 Auto=�6K   �� 5�       � ��$
 Auto=�6I   �� 5�       � ��$ 6,3,5,3q�6(   �� 5�       � �� . 6>   �� 5�       �@��PanningMode$
 Both=�69   �� 5�       �@��IsFlicksEnabled .  67   �� 5�       � ��8  6)   = 5�      P� 5�       �@��
IsEditable . . �5�      ��  � �� .  62   �� 5�       � ��$ 2q�60   �� 5�       � ��8  61   5�      5�      5�      5�      