using DataAccess.Data.Entities;
using DataAccess;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlogFoodApi.Service;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using BlogFoodApi.ViewModel;

namespace BlogFoodApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
    
        private readonly ManageAppDbContext _manageAppDbContext;



        public CategoriesController( ManageAppDbContext manageAppDbContext)
        {
            _manageAppDbContext = manageAppDbContext;
   
        }






        [HttpGet]
        public async Task<ActionResult<List<CategoryViewModel>>> GetCategory()
        {
            var categories = await _manageAppDbContext.categories.ToListAsync();
            var list = new List<CategoryViewModel>();
            foreach (var item in categories)
            {
                var cate = new CategoryViewModel();
                cate.nameCategory = item.FoodType;
                list.Add(cate);
            }

            return Ok(list);
        }
    }
}
