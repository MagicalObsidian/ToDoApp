   M S B A M L   `   `   `  ????B  >ToDoApp, Version=1.0.0.0, Culture=neutral, PublicKeyToken=nullG(clr-namespace:ToDoApp.ViewModels.DialogsToDoApp.ViewModels.Dialogs  5      -clr-namespace:ToDoApp.ViewsToDoApp.Views  5      7 clr-namespace:ToDoApp.ExtensionsToDoApp.Extensions  5      7 clr-namespace:ToDoApp.ViewModelsToDoApp.ViewModels  5          ToDoApp.Views.LoginView   5      W SPresentationCore, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35\ XPresentationFramework, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35e aSystem.Windows.Controls.Ribbon, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089R NWindowsBase, Version=6.0.2.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35F 9http://schemas.microsoft.com/winfx/2006/xaml/presentation     5      R NSystem.Xaml, Version=6.0.2.0, Culture=neutral, PublicKeyToken=b77a5c561934e089:x,http://schemas.microsoft.com/winfx/2006/xaml     5      @d2http://schemas.microsoft.com/expression/blend/2008     5      <dialogs(clr-namespace:ToDoApp.ViewModels.Dialogs     5      _ [Microsoft.Xaml.Behaviors, Version=1.1.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a3i+http://schemas.microsoft.com/xaml/behaviors  5      'localclr-namespace:ToDoApp.Views  5      Dmc;http://schemas.openxmlformats.org/markup-compatibility/2006  5	      b ^MaterialDesignThemes.Wpf, Version=4.1.0.2556, Culture=neutral, PublicKeyToken=df2a72020bd7962a:md1http://materialdesigninxaml.net/winfx/xaml/themes  5
      +pass clr-namespace:ToDoApp.Extensions  5      [ WPrism.DryIoc.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59T	 PPrism.Wpf, Version=8.1.97.5141, Culture=neutral, PublicKeyToken=40ee6c3a2184dc59&prismhttp://prismlibrary.com/  	 5      3
viewmodels clr-namespace:ToDoApp.ViewModels  	 5      $	??600??5      $	??350??5      # 	 Prism.Services.Dialogs.Dialog    WindowStyle  5      ?? 5   
    ?? 
TargetType" ?6   .?5      ??  ?? Property ? ?? ?? Value$	 600??6&   ?? 5       ? ??$	 350??6'   ?? 5       ?@?SizeToContent$ WidthAndHeight=?6.   ?? 5       ?@?
ResizeMode$ NoResize=?6+   ?? 5       ?@ WindowStartupLocation$ CenterScreen=?6C   5      .??5      ? 
??????? ? ColumnDefinitions 5   
   ?? 5      $
??1.5* ?6   ?? 5      .+?5!   
   '  !MaterialDesignThemes.Wpf.Snackbar  -   5          Name$ LoginSnackBar??5"      $??2??5#       K? ZIndex$ 1??5$         MessageQueue 5%      4  .MaterialDesignThemes.Wpf.MessageQueueExtension  ?? 5(   
   $??60q?6   $??/Images/LoginToDo.jpg??6   7  1MaterialDesignThemes.Wpf.Transitions.Transitioner  5*   
   $??1??5+      $??10q?5,       ?? SelectedIndex 5-      ?? *SelectedIndex+	 ?? FallbackValue$	 0??.@?5.      <  6MaterialDesignThemes.Wpf.Transitions.TransitionerSlide  .??5/      ]? $??15q?6   $??Center=?6(   .+?50      ?? $
??0,10q?51      $	??Top=?52      $??22(?53      $
??Bold"?54      $??欢迎使用??55      ?? 57      $
??0,10q?58      )  #MaterialDesignThemes.Wpf.HintAssist
   Hint$
 请输入账号??59      $	??Top=?5:      ??5;      ?? *	Account+G? 5<      $
??0,10q?5=      $
 请输入密码??5>      $	??Top=?5@      +   %ToDoApp.Extensions.PassWordExtensions   PassWord 5?      ?? *
PassWord+ ?? Mode$ TwoWay=? ?? UpdateSourceTrigger$ PropertyChanged=?*  $Microsoft.Xaml.Behaviors.Interaction   	Behaviors 5A      )	   #ToDoApp.Extensions.PasswordBehavior	  5B      5D      ?? 5F      $??Login??5H      $??登录系统??5I      $	??Top=?5J      ??5G      ?? *ExecuteCommand+5J      ]? 5L      $	??0,5q?6    $??False??6-   .+?5M      ?? $??注册账号??6$      Triggers 5N      +
  %Microsoft.Xaml.Behaviors.EventTrigger
  5O   "    
  	EventName$ MouseLeftButtonDown??61   *  $Microsoft.Xaml.Behaviors.TriggerBase   Actions. 5P   &   2  ,Microsoft.Xaml.Behaviors.InvokeCommandAction     CommandParameter$ ResgiterPage??6_      Command 6<   ?? *ExecuteCommand+6_   5Q   #   5S      ?? 5T      $??Right=?6$   $??忘记密码???6;   5U      5V      5W        5Y      .??5Z      ]? $??15q?6   $??Center=?6(   .+?5[      ?? $
??0,10q?5\      $	??Top=?5]      $??22(?5^      $
??Bold"?5_      $??注册账号??5`      ?? 5b      $	??0,5q?5c      $
 请输入用户名??5d      $	??Top=?5e      ??5f      ?? *UserDto.Account+?? 5g      $	??0,5q?5h      $
 请输入账号??5i      $	??Top=?5j      ??5k      ?? *UserDto.UserName+G? 5m      $	??0,5q?5n      $
 请输入密码??5o      $	??Top=?5q       5p      ?? *UserDto.PassWord+$ TwoWay=?$ PropertyChanged=? 5r      	  5s      5u      G? 5w      $	??0,5q?5x      $
 请再次输入密码??5y      $	??Top=?5{       5z      ?? *UserDto.NewPassWord+$ TwoWay=?$ PropertyChanged=? 5|      	  5}      5      ?? 5?      $??Resgiter??5?      $??注册账号??5?      $	??Top=?5?      ??5?      ?? *ExecuteCommand+5?      ?? 5?      $
??0,10q?5?      $??Return??5?      $??返回登录??5?      $	??Top=?5?          MaterialDesignOutlinedButton#??[  5?      ??5?      ?? *ExecuteCommand+5?      5?      5?      5?      5?      5?      