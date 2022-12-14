using ToDoApp.Common;
using ToDoApp.Extensions;
using Prism.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace ToDoApp.Views
{
    /// <summary>
    /// MainView.xaml 的交互逻辑
    /// </summary>
    public partial class MainView : Window
    {
        private readonly IDialogHostService dialogHostService;


        public MainView(IEventAggregator aggregator, IDialogHostService dialogHostService)
        {
            InitializeComponent();

            //注册提示消息
            aggregator.ResgiterMessage(arg =>
            {
                Snackbar.MessageQueue.Enqueue(arg.Message);
            });

            //注册等待消息窗口
            aggregator.Resgiter(arg =>
            {
                DialogHost.IsOpen = arg.IsOpen;

                if(DialogHost.IsOpen)
                {
                    DialogHost.DialogContent = new ProgressView();
                }
            });

            //当选中左侧边导航栏的一项时，左侧导航栏收起
            menuBar.SelectionChanged += (s, e) => 
            {
                drawerHost.IsLeftDrawerOpen = false;
            };

            //导航栏点击拖拽移动
            ColorZone.MouseMove += (s, e) =>
            {
                if (e.LeftButton == MouseButtonState.Pressed)
                {
                    this.DragMove();
                }
            };

            //导航栏双击最大化或缩小
            ColorZone.MouseDoubleClick += (s, e) =>
            {
                if (this.WindowState == WindowState.Normal)
                {
                    this.WindowState = WindowState.Maximized;
                }
                else
                {
                    this.WindowState = WindowState.Normal;
                }
            };

            //最小化按钮
            btnMin.Click += (s, e) =>
            {
                this.WindowState = WindowState.Minimized;
            };

            //最大化按钮
            btnMax.Click += (s, e) =>
            {
                if (this.WindowState == WindowState.Normal)
                {
                    this.WindowState = WindowState.Maximized;
                }
                else
                {
                    this.WindowState = WindowState.Normal;
                }
            };

            //退出按钮
            btnClose.Click += async (s, e) =>
            {
                var dialogResult = await dialogHostService.Question("温馨提示", "确认退出系统?");
                if (dialogResult.Result != Prism.Services.Dialogs.ButtonResult.OK) return;
                this.Close();
            };

            menuBar.SelectionChanged += (s, e) =>
            {
                drawerHost.IsLeftDrawerOpen = false;
            };
            this.dialogHostService = dialogHostService;
        }
    }
}
