using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Common.Models;

namespace ToDoApp.ViewModels
{
    public class ToDoViewModel : BindableBase
    {
        /// <summary>
        /// 构造
        /// </summary>
        public ToDoViewModel()
        {
            ToDoDtos = new ObservableCollection<ToDoDto>();

            CreateToDoList();

            AddCommand = new DelegateCommand(Add);
        }



        //定义委托字段 添加待办事项 命令
        public DelegateCommand AddCommand { get; private set; }

        /// <summary>
        /// 待办数据传输 字段
        /// </summary>
        private ObservableCollection<ToDoDto> toDoDtos;

        public ObservableCollection<ToDoDto> ToDoDtos
        {
            get { return toDoDtos; }
            set { toDoDtos = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 右侧添加窗口是否展开 字段   
        /// </summary>
        private bool isRightDrawerOpen;

        public bool IsRightDrawerOpen
        {
            get { return isRightDrawerOpen; }
            set { isRightDrawerOpen = value; RaisePropertyChanged(); }
        }



        /// <summary>
        /// 创建 待办事项 数据列表
        /// </summary>
        private void CreateToDoList()
        {
            for (int i = 0; i < 20; i++)
            {
                ToDoDtos.Add(new ToDoDto()
                {
                    Title = "标题" + i,
                    Content = "测试数据..."
                });
            }
        }

        /// <summary>
        /// 添加 待办事项 方法
        /// </summary>
        private void Add()
        {
            IsRightDrawerOpen = true;   
        }
    }
}
