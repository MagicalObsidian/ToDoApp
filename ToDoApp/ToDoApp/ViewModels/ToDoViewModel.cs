using ToDoApp.Common;
using ToDoApp.Common.Models;
using ToDoApp.Extensions;
using ToDoApp.Service;
using ToDoApp.Shared.Dtos;
using ToDoApp.Shared.Parameters;
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

namespace ToDoApp.ViewModels
{
    public class ToDoViewModel : BindableBase
    {
        /// <summary>
        /// 构造
        /// </summary>
        public ToDoViewModel(IToDoService service)
        {
            ToDoDtos = new ObservableCollection<ToDoDto>();

            AddCommand = new DelegateCommand(Add);
            this.service = service;
            CreateToDoList();
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
        private readonly IToDoService service;

        public bool IsRightDrawerOpen
        {
            get { return isRightDrawerOpen; }
            set { isRightDrawerOpen = value; RaisePropertyChanged(); }
        }



        /// <summary>
        /// 创建 待办事项 数据列表
        /// </summary>
        async void CreateToDoList()
        {
            var todoResult = await service.GetAllAsync(new Shared.Parameters.QueryParameter()
            {
                PageIndex = 0,  
                PageSize = 100,
                
            });

            if(todoResult.Status)
            {
                ToDoDtos.Clear();
                foreach (var item in todoResult.Result.Items)
                {
                    ToDoDtos.Add(item);
                }
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
