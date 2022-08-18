using System;


namespace ToDoApp.Api.Context.Repository
{
    public class UserRepository : Repository<User>, IRepository<User>
    {
        public UserRepository(ToDoAppContext dbContext) : base(dbContext)
        {
        }
    }
}
