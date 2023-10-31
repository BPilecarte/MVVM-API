using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_API_SampleProject.Models
{
    public class ToDo
    {
        public int UserId { get; set; }
        public int Id { get; set; }
        public string Title { get; set; }
        public Boolean Completed { get; set; }

    }
}
