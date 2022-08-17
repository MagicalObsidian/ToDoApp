using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Common.Models;
using ToDoApp.Extensions;

namespace ToDoApp.ViewModels
{
    public class SettingViewModel : BindableBase
    {
        /// <summary>
        /// 构造
        /// </summary>
        public SettingViewModel(IRegionManager regionManager)
        {
            MenuBars = new ObservableCollection<MenuBar>();

            this.regionManager = regionManager;
            NavigateCommand = new DelegateCommand<MenuBar>(Navigate);
            CreateMenuBar();
        }

        //定义方法 导航
        private void Navigate(MenuBar obj)
        {
            if (obj == null || string.IsNullOrWhiteSpace(obj.NameSpace))
                return;

            regionManager.Regions[PrismManager.SettingViewRegionName].RequestNavigate(obj.NameSpace);
        }

        public DelegateCommand<MenuBar> NavigateCommand { get; private set; }
        private ObservableCollection<MenuBar> menuBars;
        private readonly IRegionManager regionManager;//区域管理字段


        //声明菜单栏字段
        public ObservableCollection<MenuBar> MenuBars
        {
            get { return menuBars; }
            set { menuBars = value; RaisePropertyChanged(); }
        }


        //创建菜单栏                                                                                                                                                                                                                                                                                                                                                                              
        void CreateMenuBar()
        {
            MenuBars.Add(new MenuBar() { Icon = "Palette", Title = "个性化", NameSpace = "SkinView" });
            MenuBars.Add(new MenuBar() { Icon = "CogOutline", Title = "系统设置", NameSpace = "" });
            MenuBars.Add(new MenuBar() { Icon = "Information", Title = "关于更多", NameSpace = "AboutView" }); 
        }
    }
}
