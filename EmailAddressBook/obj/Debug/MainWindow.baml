   M S B A M L   `   `   `  ����K  GEmailAddressBook, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null3clr-namespace:EmailAddressBookEmailAddressBook  5   	   !    EmailAddressBook.MainWindow   5   	   W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35U QWPFToolkit, Version=3.5.40128.1, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   0localclr-namespace:EmailAddressBook     5   	     � Title$  E-mail Address Book��5   	   $	��450��6%   $	��800��62   .��5	      �  � RowDefinitions 5
   
   �� 5      $��1* �6   6*   �� 5      $��5* �6   6*    � ColumnDefinitions 5   
   �� 5      $��1* �6   6,   �� 5      $��1* �6   6,   �� 5      $��1* �6   6,   .+�5   
   �� -   5        $��5q�5   >   $��1��6I   $��0��6V   $��5��6f   $��3��6w    �� SelectedItem 6�   �� *SelectedPerson+��6�   �� *
Contacts+��5      �� 5      .R�5      ]� .+�5      �� ���	#FF00AADE$��18(�67   
 � Tag 6E   �� *Id+��6X   �� *Name+6s   5      5      5      �� 5   
   -   5         ��Name$ 	txtSearch��5      $��0��6%   $��1��62   $��Center=�6B   $��23��6_    �� TextWrapping$
 Wrap=�6k   $��Center=�6   $	��220��6�   $��
Search....��6�    J� Opacity$
 0.50Q�6  5      5      