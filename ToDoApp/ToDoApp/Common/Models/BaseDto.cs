using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDoApp.Common.Models
{
    /// <summary>
    /// Dto:数据传输对象
    /// 这个类用于其他类继承，包含 id、date等信息
    /// </summary>
    public class BaseDto
    {
        private int id;

        public int Id
        {
            get { return id; }
            set { id = value; }
        }

        private DateTime createDate;

        public DateTime CrateDate
        {
            get { return createDate; }
            set { createDate = value; }
        }

        private DateTime updateDate;

        public DateTime UpdateDate
        {
            get { return updateDate; }
            set { updateDate = value; }
        }


    }
}
