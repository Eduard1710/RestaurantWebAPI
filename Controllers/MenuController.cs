using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using RestaurantWebAPI.Entities;
using RestaurantWebAPI.ExternalModels;
using RestaurantWebAPI.Services.Managers;
using RestaurantWebAPI.Services.UnitsOfWork;

namespace PraticaProiect.Controllers
{
    [Route("menu")]
    [ApiController]
    public class MenuController : ControllerBase
    {
        private readonly MenuService _menuService;
        public MenuController(MenuService menuService)
        {
            _menuService = menuService ?? throw new ArgumentNullException(nameof(menuService));
        }

        [HttpGet]
        [Route("{id}", Name = "GetMenu")]
        public IActionResult GetMenu(Guid id)
        {
            var menuEntity = _menuService.GetMenu(id);
            if (menuEntity == null)
            {
                return NotFound();
            }
            return Ok(menuEntity);
        }
        [HttpGet]
        [Route("", Name = "GetAllMenus")]
        public IActionResult GetAllMenus()
        {
            var menuEntities = _menuService.GetAllMenus();
            if (menuEntities == null)
            {
                return NotFound();
            }
            return Ok(menuEntities);
        }

        [HttpGet]
        [Route("details/{id}", Name = "GetMenuDetails")]
        public IActionResult GetMenuDetails(Guid id)
        {
            var menuEntity = _menuService.GetMenuDetails(id);
            if (menuEntity == null)
            {
                return NotFound();
            }
            return Ok(menuEntity);
        }

        [HttpPost]
        [Route("add", Name = "AddMenu")]
        public IActionResult AddMenu([FromBody] MenuDTO menu)
        {
            var mEntity = _menuService.AddMenu(menu);
            return CreatedAtRoute("GetMenu", new { id = mEntity.ID }, mEntity);
        }

        [HttpGet]
        [Route("category/{categoryId}", Name = "GetCategoryDetails")]
        public IActionResult GetCategoryDetails(Guid categoryId)
        {
            var categoryEntity = _menuService.GetCategoryDetails(categoryId);
            if (categoryEntity == null)
            {
                return NotFound();
            }
            return Ok(categoryEntity);
        }
        [HttpDelete]
        [Route("delete/{id}", Name = "DeleteMenu")]
        public IActionResult DeleteMenu(Guid id)
        {
            var deleteMenu = _menuService.DeleteMenu(id);
            if (deleteMenu == false)
            {
                return NotFound();
            }
            return NoContent();
        }
    }
}
