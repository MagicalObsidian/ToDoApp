using ToDoApp.Shared.Dtos;
using ToDoApp.Common;
using ToDoApp.Extensions;
using ToDoApp.Service;
using Prism.Commands;
using Prism.Events;
using Prism.Mvvm;
using Prism.Services.Dialogs;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ToDoApp.ViewModels
{
    public class LoginViewModel : BindableBase, IDialogAware
    {
        public LoginViewModel(ILoginService service, IEventAggregator aggregator)
        {
            userDto = new ResgiterUserDto();
            ExecuteCommand = new DelegateCommand<string>(Execute);
            this.service = service;
            this.aggregator = aggregator;
        }
        #region 属性
        private readonly IEventAggregator aggregator;
        public string Title { get; set; } = "ToDo";

        public event Action<IDialogResult> RequestClose;
        public DelegateCommand<string> ExecuteCommand { get; private set; }

        private string account;

        public string Account
        {
            get { return account; }
            set { account = value; }
        }
        
        private readonly ILoginService service;


        private string passWord;

        public string PassWord
        {
            get { return passWord; }
            set { passWord = value; }
        }


        private int selectedIndex;

        public int SelectedIndex
        {
            get { return selectedIndex; }
            set { selectedIndex = value; RaisePropertyChanged(); }
        }

        private ResgiterUserDto userDto;

        public ResgiterUserDto UserDto
        {
            get { return userDto; }
            set { userDto = value; RaisePropertyChanged(); }
        }


        #endregion

        public bool CanCloseDialog()
        {
            return true;
        }

        public void OnDialogClosed()
        {
            Logout();
        }

        public void OnDialogOpened(IDialogParameters parameters)
        {

        }
        void Execute(string arg)
        {
            switch (arg)
            {
                case "Login": Login(); break;
                case "Logout": Logout(); break;
                // 跳转注册页面
                case "Go": SelectedIndex = 1; break;
                // 跳转登陆页面
                case "Return": SelectedIndex = 0; break;
                case "Register": Register(); break;
            }
        }

        private async void Register()
        {
            if (string.IsNullOrWhiteSpace(UserDto.UserName) ||
                string.IsNullOrWhiteSpace(UserDto.Account) ||
                string.IsNullOrWhiteSpace(UserDto.PassWord))
            {
                aggregator.SendMessage("不能为空", "Login");
                return;
            }

            if (UserDto.PassWord != UserDto.NewPassWord)
            {
                aggregator.SendMessage("两次密码不一致", "Login");
                return;
            }

            var registerResult = await service.RegisterAsync(new UserDto()
            {
                Account = UserDto.Account,
                UserName = UserDto.UserName,
                PassWord = UserDto.PassWord
            });

            if (registerResult != null && registerResult.Status)
            {
                aggregator.SendMessage("注册成功", "Login");
                SelectedIndex = 0;
                //return;
            }
            else
            {   
              aggregator.SendMessage(registerResult.Message, "Login");
            }
        }

        private void Logout()
        {
            RequestClose?.Invoke(new DialogResult(ButtonResult.No));
        }

        private async void Login()
        {
            if (string.IsNullOrWhiteSpace(Account) ||
                string.IsNullOrWhiteSpace(PassWord))
                return;

            var loginResult = await service.LoginAsync(new UserDto()
            {
                Account = Account,
                PassWord = PassWord
            });

            if (loginResult != null && loginResult.Status)
            {
                //AppSession.UserName = loginResult.Result.UserName;
                RequestClose?.Invoke(new DialogResult(ButtonResult.OK));
            }
            else
            {
                //登录失败提示...
                aggregator.SendMessage(loginResult.Message, "Login");
            }
        }
    }
}
