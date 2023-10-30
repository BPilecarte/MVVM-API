using MVVM_API_SampleProject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM_API_SampleProject.ViewModels
{
    public class PostViewModel
    {
        public Post Post {  get; set; }

        public PostViewModel()
        {
            Post = new Post()
            {
                UserId = 1,
                Id = 1,
                Title = "Titulo",
                Body = "Texto"
            };
        }
    }
}
