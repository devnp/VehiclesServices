   M S B A M L   `   `   `  ����J  FVehiclesService, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null9!clr-namespace:VehiclesServiceViewVehiclesServiceView  5   	   '    !VehiclesServiceView.HistoryWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35D 9http://schemas.microsoft.com/winfx/2006/xaml/presentation    5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   3local!clr-namespace:VehiclesServiceView     5   	     � Title$  History��5   	   $	��380��6   $	��525��6&   $	��380��62   $	��525��6B   
���z���.��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   �� 5      $��9* �6    � ColumnDefinitions 5   
   �� 5      $	��150 �6   �� 5      .+�5   
   �� -   5         ��Name$ HistorSelectionLabel��5      $'��!Select scope of the history logs:��6.   $��20(�6Z   $
��Left=�6r   $��Center=�6�   $��0��6�   $��2��6�   �� 5   
   -   5         ��Name$ HistoryTypePanel��5      $
��Left=�6/   $��0��6J   $��1��6Z   .+�5      	� -   5         	�Name$ AllRadioButton��5       	� 	GroupName$ HistoryLogs��62    d� 	IsChecked$
 TrueY�6J   $��15(�6[   .��6s   All history6�   	� 5      -   5        $ RegNoRadioButton��5      $ HistoryLogs��64   $��15(�6L   .��6�   Select by reg no.6�   �� 5      -   5         ��Name$ RegNoHistoryTextBox��5      $y�	Collapsed=�63   �� 5      -   5        	 ��Name$	 ViewHistory��5      $��View history��6*   6A   5      �� 5   
   -   5        
 ��Name$
 LogsScrollViewer��5      $��Visible=�61   $��Visible=�6Y   $��1��6   $��1��6�   �� 5   
   -   5        $	 BackFromRegistration��5      $
��Back��6/   $��17(�6?   $��0��6W   $��2��6g   $
��Left=�6t   $��Bottom=�6�   6�   5      5      