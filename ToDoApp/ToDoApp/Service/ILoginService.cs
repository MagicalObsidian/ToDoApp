using ToDoApp.Shared.Contact;
using ToDoApp.Shared.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Service
{
    public interface ILoginService
    {
        Task<ApiResponse<UserDto>> LoginAsync(UserDto user);
        Task<ApiResponse> RegisterAsync(UserDto user);
    }
}
