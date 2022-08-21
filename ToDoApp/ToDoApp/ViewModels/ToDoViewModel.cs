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
    public class ToDoViewModel : NavigationViewModel
    {
        private readonly IDialogHostService dialogHost;

        /// <summary>
        /// 构造
        /// </summary>
        public ToDoViewModel(IToDoService service, IContainerProvider provider) : base(provider)
        {
            ToDoDtos = new ObservableCollection<ToDoDto>();

            ExecuteCommand = new DelegateCommand<string>(Execute);
            DeleteCommand = new DelegateCommand<ToDoDto>(Delete);
            SelectedCommand = new DelegateCommand<ToDoDto>(Selected);

            dialogHost = provider.Resolve<IDialogHostService>();
            this.service = service;
            //CreateToDoList();
        }

        //声明委托字段
        //public DelegateCommand AddCommand { get; private set; }
        public DelegateCommand<ToDoDto> SelectedCommand { get; private set; }
        public DelegateCommand<string> ExecuteCommand { get; private set; }
        public DelegateCommand<ToDoDto> DeleteCommand { get; private set; }

        //字段名
        private ObservableCollection<ToDoDto> toDoDtos;
        private bool isRightDrawerOpen;
        private readonly IToDoService service;
        private ToDoDto currentDto;
        private int selectedIndex;
        private string search;

        /// <summary>
        /// 搜索条件 字段
        /// </summary>
        public string Search
        {
            get { return search; }
            set { search = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 下拉列表选中状态值 字段
        /// </summary> 
        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 待办数据传输 字段
        /// </summary>
        public ObservableCollection<ToDoDto> ToDoDtos
        {
            get { return toDoDtos; }
            set { toDoDtos = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 编辑选中/新增时对象
        /// </summary>
        public ToDoDto CurrentDto
        {
            get { return currentDto; }
            set { currentDto = value; RaisePropertyChanged(); }
        } 

        /// <summary>
        /// 右侧边栏是否打开 字段
        /// </summary>
        public bool IsRightDrawerOpen
        {
            get { return isRightDrawerOpen; }
            set { isRightDrawerOpen = value; RaisePropertyChanged(); }
        }

        /// <summary>
        /// 获取 待办事项 数据
        /// </summary>
        async void GetDataAsync()
        {
            //加载完成前等待
            UpdateLoading(true);

            //下拉框第一(0)行是全部 下拉框第三(2)行是已完成，则状态为1，否则为0
            int? Status = SelectedIndex == 0 ? null : SelectedIndex == 2 ? 1 : 0;

            var todoResult = await service.GetAllFilterAsync(new Shared.Parameters.ToDoParameter()
            {
                PageIndex = 0,  
                PageSize = 100,
                Search = Search,
                Status = Status
            });

            if(todoResult.Status)
            {
                ToDoDtos.Clear();
                foreach (var item in todoResult.Result.Items)
                {
                    ToDoDtos.Add(item);
                }
            }

            //加载完后关闭 等待窗口
            UpdateLoading(false);
        }

        /// <summary>
        /// 重写导航方法，添加获取待办事项数据方法
        /// </summary>
        /// <param name="navigationContext"></param>
        public override void OnNavigatedTo(NavigationContext navigationContext)
        {
            base.OnNavigatedTo(navigationContext);

            if (navigationContext.Parameters.ContainsKey("Value"))
                SelectedIndex = navigationContext.Parameters.GetValue<int>("Value");
            else
                SelectedIndex = 0;

            GetDataAsync();
        }

        /// <summary>
        /// 点击添加待办事项按钮后 方法
        /// </summary>
        private void Add()
        {
            CurrentDto = new ToDoDto();
            IsRightDrawerOpen = true;   
        }
      
        /// <summary>
        /// 点击选中待办事件时的方法
        /// </summary>
        /// <param name="obj"></param>
        private async void Selected(ToDoDto obj)
        {
            try
            {
                UpdateLoading(true);
                var todoResult = await service.GetFirstOfDefaultAsync(obj.Id);
                if (todoResult.Status)
                {
                    CurrentDto = todoResult.Result;
                    IsRightDrawerOpen = true;
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                UpdateLoading(false);
            }
        }

        /// <summary>
        /// 执行多个命令 方法
        /// </summary>
        /// <param name="obj"></param>
        private void Execute(string obj)
        {
            switch (obj)
            {
                case "新增": Add(); break;
                case "查询": GetDataAsync(); break;
                case "保存": Save(); break;
            }
        }

        /// <summary>
        /// 保存输入信息 方法
        /// </summary>
        private async void Save()
        {
            if (string.IsNullOrWhiteSpace(CurrentDto.Title) ||
                string.IsNullOrWhiteSpace(CurrentDto.Content))
                return;

            UpdateLoading(true);

            try
            {
                if (CurrentDto.Id > 0)//表示已存在，进行编辑
                {
                    var updateResult = await service.UpdateAsync(CurrentDto);
                    if (updateResult.Status)
                    {
                        var todo = ToDoDtos.FirstOrDefault(t => t.Id == CurrentDto.Id);
                        if (todo != null)
                        {
                            todo.Title = CurrentDto.Title;
                            todo.Content = CurrentDto.Content;
                            todo.Status = CurrentDto.Status;
                        }
                    }
                    IsRightDrawerOpen = false;
                }
                else
                {
                    var addResult = await service.AddAsync(CurrentDto);
                    if (addResult.Status)
                    {
                        ToDoDtos.Add(addResult.Result);
                        IsRightDrawerOpen = false;
                    }
                }
            }
            catch (Exception ex)
            {

            }
            finally
            {
                UpdateLoading(false);
            }
        }

        /// <summary>
        /// 删除当前待办事项 方法
        /// </summary>
        /// <param name="obj"></param>
        private async void Delete(ToDoDto obj)
        {
            try
            {
                //var dialogResult = await dialogHost.Question("温馨提示", $"确认删除待办事项:{obj.Title} ?");
                //if (dialogResult.Result != Prism.Services.Dialogs.ButtonResult.OK) return;

                UpdateLoading(true);
                var deleteResult = await service.DeleteAsync(obj.Id);
                if (deleteResult.Status)
                {
                    var model = ToDoDtos.FirstOrDefault(t => t.Id.Equals(obj.Id));
                    if (model != null)
                        ToDoDtos.Remove(model);
                }
            }
            finally
            {
                UpdateLoading(false);
            }
        }

    }
}
