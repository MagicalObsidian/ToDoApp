   M S B A M L   `   `   `  ????B  >ToDoApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=null7 clr-namespace:ToDoApp.ExtensionsToDoApp.Extensions  5      !clr-namespace:ToDoAppToDoApp  5      7 clr-namespace:ToDoApp.ViewModelsToDoApp.ViewModels  5          ToDoApp.Views.MainView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      0ext clr-namespace:ToDoApp.Extensions     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      !localclr-namespace:ToDoApp  5      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962aFmaterialDesign1http://materialdesigninxaml.net/winfx/xaml/themes  5	      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5
      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T	 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/  	 5      3
viewmodels clr-namespace:ToDoApp.ViewModels  	 5        ? Title$  
MainWindow??5      $
??1280??5      $	??768??5      ! 	 Prism.Mvvm.ViewModelLocator   AutoWireViewModel True5       ? AllowsTransparency$
 True??5         MaterialDesignPaper#???   5      $??微软雅黑)?5        MaterialDesignWindow#??[ 5      $??13(?5      $??Regular"?5        MaterialDesignBody#???  5      &   System.Windows.Media.TextOptions   TextFormattingMode$ Ideal=?5         TextRenderingMode$
 Auto=?5       ? WindowStartupLocation$ CenterScreen=?5       ? WindowStyle$
 None=?5      .??5      )  #MaterialDesignThemes.Wpf.DialogHost  -   5          Name$ 
DialogHost??5    	      DialogTheme$ Inherit=?5!   	   	   
Identifier$
	 Root??5"   	   .??5'   
   )  #MaterialDesignThemes.Wpf.DrawerHost  -   5        
  Name$
 
drawerHost??5'   $      IsLeftDrawerOpen 68   ??  ?? ElementName$ MenuToggleButton?? ?? Path$ 	IsChecked?   LeftDrawerContent 5)      ]? 5*      $	??220??6   .+?5+      ?? $
??0,20q?6!   $	??Top=?6/   .+?5,      ?? $	??100??5-      $	??100??5.      $??/Images/ali.jpg??5/      ?? 50      $
??0,10q?51      $??Center=?52      ??53      ?? *
UserName+54      ?? 57      -   5         ??Name$ menuBar??58        MyListBoxItemStyle#??[ 59      ??5:      ?? *
MenuBars+*  $Microsoft.Xaml.Behaviors.Interaction   Triggers 5;      +  %Microsoft.Xaml.Behaviors.EventTrigger  5<         	EventName$ SelectionChanged??6-   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5=   "   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     Command 68   ?? *NavigateCommand+   CommandParameter 6\   ?? *SelectedItem+ ?? RelativeSource ??  ?? Mode$ FindAncestor=? ?? AncestorType ListBox5>      ??5@      ?? 5A      .R?5B   "   ?? 
??????  ?? Orientation$ 
Horizontal=?6F   .+?5C   &   '	  !MaterialDesignThemes.Wpf.PackIcon	  $
??15,0q?6>    	  Kind 6L   ?? *Icon+?? 5D   &   $
??10,0q?5E   )   $??15(?5F   )   ??5G   )   ?? *Title+5H   #   5I      5K      5N      .??5Q      ?  ? RowDefinitions 5R      ?? 5S      $
??auto ?6$   ?? 5T      .+?5W      '
  !MaterialDesignThemes.Wpf.Snackbar
  -   5         
 Name$ Snackbar??5X       K? ZIndex$ 1??5Y       
  MessageQueue 5Z      4  .MaterialDesignThemes.Wpf.MessageQueueExtension  (  "MaterialDesignThemes.Wpf.ColorZone  5\      -   5          Name$ 	ColorZone??5]      $??16q?5^      +  %MaterialDesignThemes.Wpf.ShadowAssist   ShadowDepth$ Depth2=?5_      $	??Top=?5`          Mode$  
PrimaryMid=?5a      .??5b      ]? $??False??6    .+?5c      ?? $??Right=?6%   $ 
Horizontal=?6<   .+?5e      ?? -   5        ! ??Name$! btnMin??5f   !   $	??—??5g   !    ! MaterialDesignFlatMidBgButton#??[ 5h   !   ?? 5i      -   5        $! btnMax??5j   !   $	??⃞??5k   !   #??[ 5l   !   ?? 5m      -   5        $! btnClose??5n   !   $	??⛌??5o   !   " ? Cursor$
" Hand??5p   !   #??[ 5q   !   5s      '  !MaterialDesignThemes.Wpf.PopupBox  5v      $??Right=?62   #   ToggleContent# 5w      ?? 5x   "   $??30??5y   %   $??30??5z   %   $??/Images/ali.jpg??5{   %   $ J? Clip$ 5|   &   @? 5}   *   % @? Center$% 15,15&?5~   -   & @? RadiusX$& 15Q?5   -   ' @? RadiusY$' 15Q?5?   -   5?   #   (   PopupContent.( 5?      ?? .+?5?   "   ?? $??登出当前账户??6M   ??6)   ?? *LoginOutCommand+6M   5?      5?      ?? 5?      $ 
Horizontal=?6%   .+?5?      d? -	   5        ) d?Name$) MenuToggleButton??5?   !   4  .System.Windows.Automation.AutomationProperties*   Name$* HamburgerToggleButton??5?   !   + d? 	IsChecked$+ FalseY?5?   !    ' #MaterialDesignHamburgerToggleButton#??[ 5?   !   ?? 5?      $??24,0,0,0q?5?   !   $
" Hand??5?   !     MaterialDesignToolButton#??[ 5?   !   , ? ToolTip$, Previous Item??5?   !   +  %MaterialDesignThemes.Wpf.RippleAssist-   Feedback- 5?   !   ??  ?? *Self+$ 
Foreground?  BrushRoundConverter. ?? 	Converter#. [ ??5?   !   ?? *GoBackCommand+??5?   !   0  *MaterialDesignThemes.Wpf.PackIconExtension  /   Kind$/ 	ArrowLeft=?0   Size0 24??5?   !   ??  ?? " ?$ (TextElement.Foreground)?5?   !   ?? 5?      $??16,0,0,0q?5?   !   $
" Hand??5?   !   #??[ 5?   !   $, 	Next Item??5?   !   - 5?   !   ??  ?? *Self+$ 
Foreground?#. [ ??5?   !   ?? *GoForWardCommand+??5?   !     $/ 
ArrowRight=?0 24??5?   !   ??  ?? " ?$ (TextElement.Foreground)?5?   !   ?? 5?      $
??16,0q?5?   !   $??Center=?5?   !   $??Center=?5?   !   $%* Material Design In XAML Toolkit??5?   !   $??22(?5?   !   $??我的待办事项??5?   !   5?      5?      5?      ?? 5?      $??1??6!   %   ToDoApp.Extensions.PrismManager1   MainViewRegionName! 	 Prism.Regions.RegionManager2   
RegionName#2 Z1 6.   5?      5?      5?      5?      