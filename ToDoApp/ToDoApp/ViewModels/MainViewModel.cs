using Prism.Commands;
using Prism.Ioc;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Common;
using ToDoApp.Common.Models;
using ToDoApp.Extensions;

namespace ToDoApp.ViewModels
{
    public class MainViewModel : BindableBase, IConfigureService
    {
        private string userName;

        public string UserName
        {
            get { return userName; }
            set { userName = value; RaisePropertyChanged(); }
        }

        public DelegateCommand LoginOutCommand { get; private set; }

        /// <summary>
        /// 主视窗构造
        /// </summary>
        public MainViewModel(IContainerProvider containerProvider, IRegionManager regionManager)
        {
            //创建一个菜单栏
            MenuBars = new ObservableCollection<MenuBar>();

            //封装 Navigate 方法
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);

            //后退命令
            GoBackCommand = new DelegateCommand(() =>
            {
                if (journal != null && journal.CanGoBack)
                {
                    journal.GoBack();
                }
            });

            //前进命令
            GoForWardCommand = new DelegateCommand(() =>
            {
                if (journal !=null && journal.CanGoForward)
                {
                    journal.GoForward();
                }
            });

            LoginOutCommand = new DelegateCommand(() =>
            {
                //注销当前用户
                App.LoginOut(containerProvider);
            });

            this.containerProvider = containerProvider;

            //给区域管理器 赋参数值
            this.regionManager = regionManager;
        }

        //定义方法 导航
        private void Navigate(MenuBar obj)
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.NameSpace))
                return;

            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate(obj.NameSpace, back => 
            {
                journal = back.Context.NavigationService.Journal;
            });
        }

        //定义委托字段 驱动导航命令
        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }
        public DelegateCommand GoBackCommand { get; private set; }  
        public DelegateCommand GoForWardCommand { get; private set; }  

        private ObservableCollection<MenuBar> menuBars;
        private readonly IContainerProvider containerProvider;
        private readonly IRegionManager regionManager;//区域管理字段
        private IRegionNavigationJournal journal;

        //声明菜单栏字段
        public ObservableCollection<MenuBar> MenuBars 
        {
            get { return menuBars; }
            set { menuBars = value; RaisePropertyChanged(); }
        }


        //创建菜单栏                                                                                                                                                                                                                                                                                                                                                                              
        void CreateMenuBar()
        {
            MenuBars.Add(new MenuBar() { Icon = "Home", Title = "首页", NameSpace = "IndexView"});
            MenuBars.Add(new MenuBar() { Icon = "NoteBookOutline", Title = "待办事项", NameSpace = "ToDoView"});
            MenuBars.Add(new MenuBar() { Icon = "NoteBookPlus", Title = "备忘录", NameSpace = "MemoView"});
            MenuBars.Add(new MenuBar() { Icon = "Cog", Title = "设置", NameSpace = "SettingView"});
        }

        /// <summary>
        /// 配置首页初始化参数
        /// </summary>
        public void Configure()
        {
            //获取用户名
            UserName = AppSession.UserName;

            //给菜单栏添加菜单项
            CreateMenuBar();

            //初始配置显示主页
            regionManager.Regions[PrismManager.MainViewRegionName].RequestNavigate("IndexView");
        }
    }
}
