using System;


namespace ToDoApp.Api.Context.Repository
{
    public class ToDoRepository : Repository<ToDo>, IRepository<ToDo>
    {
        public ToDoRepository(ToDoAppContext dbContext) : base(dbContext)
        {
        }
    }
}
