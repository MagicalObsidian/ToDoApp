   M S B A M L   `   `   `  ????B  >ToDoApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullE'clr-namespace:ToDoApp.Common.ConvertersToDoApp.Common.Converters  5      -clr-namespace:ToDoApp.ViewsToDoApp.Views  5      7 clr-namespace:ToDoApp.ViewModelsToDoApp.ViewModels  5          ToDoApp.Views.IndexView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      6cv'clr-namespace:ToDoApp.Common.Converters     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      'localclr-namespace:ToDoApp.Views  5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
      1
viewmodels clr-namespace:ToDoApp.ViewModels  5        ? 	Resources  5      1   +ToDoApp.Common.Converters.IntToBoolConveter   	intToBool??%   &	          5   
   6   5      .??5      ?  ? RowDefinitions 5   
   ?? 5      $
??auto ?6   ?? 5      $
??auto ?6   ?? 5      .+?5   
   ?? $
??15,5q?5      $??30(?5       ??5!      ?? *Title+?? 5$   
   $??1??6   ??6$   ?? *
TaskBars+??5%      ?? 5&      .R?5(      A?  A? Columns$ 4??6"   5)      ??5-      ?? 5.      .R?5/      ?? $??15q?50       ?? CornerRadius$ 10??52      ??51      ?? *Color+ J? InputBindings 54      d? 55       d? MouseAction$ 	LeftClicke?58   !    ?? Command 56   !   ?? *DataContext.NavigateCommand+ ?? RelativeSource ??  ?? Mode$ FindAncestor=?	 ?? AncestorType	 ItemsControl
 ?? CommandParameter
 57   !   ?? 58   !   ??5<      ?? 5=       ?? 
TargetType" ??6$    ?? Triggers 5>   "   P? 5?   &    P? Property ?@J?IsMouseOver P? Value$
 True??6E   . ?5@   *   ??  ?? Property ?@J?Effect ?? Value 5A   .   3  -System.Windows.Media.Effects.DropShadowEffect  5B   2      
BlurRadius$ 10Q?5C   5      ShadowDepth$ 1Q?5D   5      Color$ #DDDDDD??5E   5   5G   +   5H   '   5J      ._?5M      ? .+?5N      ?? $??20,10q?6)   .+?5P   "   '  !MaterialDesignThemes.Wpf.PackIcon  $??30??5Q   %   $??30??5R   %      Kind 5S   %   ?? *Icon+?? 5U   "   $	??0,5q?5V   %   $??30(?5W   %   ??5X   %   ?? *Title+?? 5[   "   $??30(?5\   %   $
??Bold"?5]   %   ??5^   %   ?? *	Content+5_      ?? 5b      $
}?True??6%   .+?5c   "   ?? 
 ?? Top$ 30??5d   %    ?? Right$	 -60??5e   %   $	??120??5f   %   $	??120??5g   %   
????? ?$	 100??5i   %    J? Opacity$	 0.1Q?5j   %   ?? 5k   "   $ 80??5l   %   $	 -30??5m   %   $	??120??5n   %   $	??120??5o   %   ???#FFFFFF$	 100??5q   %   $	 0.1Q?5r   %   5s      5t      5u      5v      5x      ? 5{   
   $??2??6   $
??0,10q?6    ? ColumnDefinitions 5|      ?? 5}      ?? 5~      .+?5?      ?? $
??15,0q?5?      ???#bebebe$ 10??5?      $	 0.1Q?5?      ]? 5?      $
??15,0q?6   .+?5?      ]? $
??15,5q?5?      $	??Top=?5?      $??False??5?      .+?5?      ?? $??30(?5?      $
??Bold"?5?      $??待办事项??5?      ?? 5?      $??30??5?      $??30??5?      $
??0,10q?5?      $	??Top=?5?      $??新增待办??5?      $??Right=?5?       , (MaterialDesignFloatingActionAccentButton#??[ 5?      ??5?      ?? *ExecuteCommand+.??5?        $	 Add=?62   5?      5?      ?? 5?      -   5         ??Name$ todoList??5?      $??Stretch=?5?      $??Hidden=?5?      ??5?      ?? *Summary.ToDoList+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5?      +  %Microsoft.Xaml.Behaviors.EventTrigger  5?         	EventName$ MouseDoubleClick??6)   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5?      2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 64   ?? *EditToDoCommand+   CommandParameter 6X   ??  ?? ElementName$ todoList??  ?? Path$  SelectedItem?5?      ??5?      ?? 5?      .R?5?      ]? $??80??6(   $??False??67   .+?5?   "   d? $??Right=?5?   %   ??5?   %   ?? *!DataContext.ToDoCompltedCommand+ ?? $ FindAncestor=?	 ItemsControl??5?   %   ?? ! d? 	IsChecked! 5?   %   ?? *Status+" ?? 	Converter#" [  ?? 5?   "   .+?5?   &   ?? $??20(?5?   )   $
??Bold"?5?   )   ??5?   )   ?? *Title+?? 5?   &   $	??0,5q?5?   )   $	 0.5Q?5?   )   ??5?   )   ?? *	Content+5?   #   5?      5?      5?      5?      ?? 5?      $??1??5?      $
??15,0q?5?      ???#bebebe$ 10??5?      $	 0.1Q?5?      ]? 5?      $??1??6   $
??15,0q?6(   .+?5?      ]? $
??15,5q?5?      $	??Top=?5?      $??False??5?      .+?5?      ?? $??30(?5?      $
??Bold"?5?      $??	备忘录??5?      ?? 5?      $??30??5?      $??30??5?      $
??0,10q?5?      $	??Top=?5?      $??新增备忘录??5?      # ? Cursor$
# Hand??5?      $??Right=?5?      #??[ 5?      ??5?      ?? *ExecuteCommand+.??5?        $	 Add=?62   5?      5?      ?? 5?      -   5        $ memoList??5?      $??Hidden=?5?      ??5?      ?? *Summary.MemoList+ 5?        5?      $ MouseDoubleClick??6)   . 5?         64   ?? *EditMemoCommand+ 6X   ?? $ memoList??$  SelectedItem?5?      ??5?      ?? 5?      .R?5?      ?? .+?5?   "   ?? $??20(?5?   %   $
??Bold"?5?   %   ??5?   %   ?? *Title+?? 5?   "   $	??0,5q?5?   %   $	 0.5Q?5?   %   ??5?   %   ?? *	Content+5?      5?      5?      5?      5      5     5     