using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoApp.Common.Models;
using ToDoApp.Shared.Dtos;

namespace ToDoApp.ViewModels
{
    public class MemoViewModel : BindableBase
    {
        /// <summary>
        /// 构造
        /// </summary>
        public MemoViewModel()
        {
            MemoDtos = new ObservableCollection<MemoDto>();

            CreateMemoList();

            AddCommand = new DelegateCommand(Add);
        }



        //定义委托字段 添加备忘录 命令
        public DelegateCommand AddCommand { get; private set; }

        /// <summary>
        /// 备忘录数据传输 字段
        /// </summary>
        private ObservableCollection<MemoDto> memoDtos;

        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set { memoDtos = value; RaisePropertyChanged(); }
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
        /// 创建 备忘录 数据列表
        /// </summary>
        private void CreateMemoList()
        {
            for (int i = 0; i < 20; i++)
            {
                MemoDtos.Add(new MemoDto()
                {
                    Title = "标题" + i,
                    Content = "测试数据..."
                });
            }
        }

        /// <summary>
        /// 添加 备忘录 方法
        /// </summary>
        private void Add()
        {
            IsRightDrawerOpen = true;
        }
    }
}
