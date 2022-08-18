using System;

namespace ToDoApp.Api.Context.Repository
{
    public class MemoRepository : Repository<Memo>, IRepository<Memo>
    {
        public MemoRepository(ToDoAppContext dbContext) : base(dbContext)
        {

        }
    }
}
