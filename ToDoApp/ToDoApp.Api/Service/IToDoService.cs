using ToDoApp.Api.Context;
using ToDoApp.Shared.Dtos;
using ToDoApp.Shared.Parameters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDoApp.Api.Service
{
    public interface IToDoService : IBaseService<ToDoDto>
    {
        Task<ApiResponse> GetAllAsync(ToDoParameter query);

        Task<ApiResponse> Summary();
    }
}
