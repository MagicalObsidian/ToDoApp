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
    public class IndexViewModel : BindableBase
    {
        /// <summary>
        /// 构造
        /// </summary>
        public IndexViewModel()
        {
            TaskBars = new ObservableCollection<TaskBar>();

            CreateTaskBars();
            CreateTestData();
        }

        /// <summary>
        /// 任务栏 字段
        /// </summary>
        private ObservableCollection<TaskBar> taskBars;

        public ObservableCollection<TaskBar> TaskBars
        {
            get { return taskBars; }
            set { taskBars = value; RaisePropertyChanged(); }
        }

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
        /// 备忘录数据传输 字段
        /// </summary>
        private ObservableCollection<MemoDto> memoDtos;

        public ObservableCollection<MemoDto> MemoDtos
        {
            get { return memoDtos; }
            set { memoDtos = value; RaisePropertyChanged(); }
        }

        //给任务面板添加具体任务
        public void CreateTaskBars()
        {
            TaskBars.Add(new TaskBar()
            {
                Icon = "ClockFast",
                Title = "汇总",
                Content = "9",
                Color = "#0097ff",
                Target = ""
            });

            TaskBars.Add(new TaskBar()
            {
                Icon = "ClockCheckOutline",
                Title = "已完成",
                Content = "9",
                Color = "#1cba46",
                Target = ""
            });

            TaskBars.Add(new TaskBar()
            {
                Icon = "ChartLineVariant",
                Title = "完成率",
                Content = "100%",
                Color = "#00b3df",
                Target = ""
            });

            TaskBars.Add(new TaskBar()
            {
                Icon = "PlaylistStar",
                Title = "备忘录",
                Content = "19",
                Color = "#ffa000",
                Target = ""
            });
        }


        void CreateTestData()
        {
            ToDoDtos = new ObservableCollection<ToDoDto>();
            MemoDtos = new ObservableCollection<MemoDto>();

            for (int i = 0; i < 10; i++)
            {
                ToDoDtos.Add(new ToDoDto() { Title = "待办"+i, Content = "正在处理中..."});
                MemoDtos.Add(new MemoDto() { Title = "备忘"+i, Content = "我的密码" });
            }
        }
    }
}
