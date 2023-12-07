using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogFoodApi.ViewModel
{
    public class ApiResponse
    {
        public bool Success { get; set; }
        public string Message { get; set; }
        public RefreshModel Data { get; set; }
    }
}
