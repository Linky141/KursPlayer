   M S B A M L   `   `   `  ����F  BKursyPlayer, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null)clr-namespace:KursyPlayerKursyPlayer  5   	       KursyPlayer.MainWindow   5   	   \ XPresentationFramework, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35^ ZWindowsFormsIntegration, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089W SPresentationCore, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35R NWindowsBase, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35H 9http://schemas.microsoft.com/winfx/2006/xaml/presentation      5   	   R NSystem.Xaml, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5   	   @d2http://schemas.microsoft.com/expression/blend/2008     5   	   Jmc;http://schemas.openxmlformats.org/markup-compatibility/2006     5   	   +localclr-namespace:KursyPlayer     5   	   -   5          � Title$  
MainWindow��5   	   $	��500��6   $
��1000��6)   
������  � WindowStyle$
 None=�6O   $	��500��5	   	   $
��1000��6   .��5
      �� 
�������._�5   
   �  � ColumnDefinitions 5      �� 5      $	��239 �6#   �� 5       � RowDefinitions 5      �� 5      $��211.02 �6    �� 5      �� 5      $��104.02 �6    .+�5      �� -   5         ��Name$ 
lbxCourses��5   �      ListBoxItemContainerStyle1#���   6     ListBoxStyle1#���  6X   $��
10,10,9,10q�6�   6�   �� 5      -   5        $ 
lbxLessons��5   �   #���   6   #���  6X   $��
10,10,9,45q�6�   $��1��6�   $��2��6�   6�   r� 5      -   5         r�Name$ mediaElement��5      $��1��61   $��
10,7,17,12q�6A   $��2��6U    r� LoadedBehavior$ Manual=�6f    r� UnloadedBehavior$ Manual=�6~   6�   �� 5      $��10,10,10,10q�6   $��1��6*   $��2��6:   $��1q�6G   ���#eeee �� CornerRadius$ 10��6o   ._�5      � .+�5      �� -   5        	 ��Name$	 btnLoadCourses��5      $��LoadCourses��65   $��	0,0,10,10q�6K   $��Bottom=�6^   $��Right=�6�   $	��111��6�   �� 5      -   5        
 ��Name$
 lblTime��5      $��-:-- / -:--��6-   $
��Left=�6C   $��
415,48,0,0q�6^   $	��Top=�6r   �� 5       -   5        $	 btnPlay��5    ,   $
��PLAY��6   $
��Left=�6=   $��	12,52,0,0q�6X   $	��Top=�6k   $��68��6�   $��20��6�   �� 5!      -   5        $	 
btnMinus10��5!   +   $	��-10��6   $��
231,52,0,0q�6?   $	��Top=�6S   $��20��6�   $
��Left=�6�   $��38��6�   �� 5"      -	   5        $	 	btnPlus10��5"   +   $	��+10��6   $
��Left=�6>   $��
274,52,0,0q�6Y   $	��Top=�6m   $��20��6�   $��38��6�   �� 5#      -
   5        $	 btnStop��5#   ,   $
��Stop��6   $
��Left=�6=   $��
158,52,0,0q�6X   $	��Top=�6l   $��20��6�   $��68��6�   �� 5$      -   5        $	 btnPasue��5$   -   $��PAUSE��6   $
��Left=�6?   $��	85,52,0,0q�6Z   $	��Top=�6m   $��20��6�   $��68��6�   �� 5%      -   5         ��Name$ sldProgress��5%   E     AppSliderStyle#��[ 6   $��1��6Z    � Minimum$ 0Q�6j    � Maximum$ 1Q�6v   $��
10,10,10,0q�6�   $��2��6�   $	��Top=�6�   $��18��6�    J� RenderTransformOrigin$ 0.427,0.071&�6�    �� IsSnapToTickEnabled$
 True��6   �� TickFrequency$ 0.001Q�68  �� 5&      -   5        $ 	sldVolume��5&   E   #��[ 6   $
��Left=�6X   $��
318,54,0,0q�6s   $	��Top=�6�   $��80��6�   $ 0Q�6�   $ 1Q�6�    � Value$	 0.8Q�6�   $
 True��6�   $ 0.001Q�6  �� 5'      $��Volume��6   $
��Left=�6-   $��
313,32,0,0q�6H   $	��Top=�6\   5(      5)      �� 5*      -   5        $	 btnMinimalizeWindow��5*      $��_��62   $
��Left=�6>   $��	10,74,0,0q�6Y   $��2��6l   $	��Top=�6y   $��44��6�   6�   �� 5+      -   5        $	 btnMaximalizeWindow��5+      $��[]��62   $��Center=�6?   $��0,74,0,0q�6\   $��2��6n   $	��Top=�6{   $	��121��6�   6�   �� 5,      -   5        $	 btnCloseWindow��5,      $��X��6-   $
��Left=�69   $��
185,74,0,0q�6T   $��2��6h   $	��Top=�6u   $��44��6�   6�   5-      5.      5/      