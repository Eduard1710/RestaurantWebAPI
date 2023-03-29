﻿using AutoMapper;
using RestaurantWebAPI.Entities;
using RestaurantWebAPI.ExternalModels;
using RestaurantWebAPI.Services.UnitsOfWork;

namespace RestaurantWebAPI.Services.Managers
{
    public class MenuService
    {
        private readonly IMenuUnitOfWork _menuUnit;
        private readonly IMapper _mapper;
        public MenuService(IMenuUnitOfWork menuUnit, IMapper mapper)
        {
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
            _menuUnit = menuUnit ?? throw new ArgumentNullException(nameof(menuUnit));
        }

        public MenuDTO GetMenu(Guid id)
        {
            var menuEntity = _menuUnit.Menus.Get(id);
            return _mapper.Map<MenuDTO>(menuEntity);
        }

        public List<MenuDTO> GetAllMenus()
        {
            var menuEntities = _menuUnit.Menus.Find(o => o.Deleted == false || o.Deleted == null);
            return _mapper.Map<List<MenuDTO>>(menuEntities);
        }

        public MenuDTO GetMenuDetails(Guid id)
        {
            var menuEntity = _menuUnit.Menus.GetMenuDetails(id);
            return _mapper.Map<MenuDTO>(menuEntity);
        }

        public MenuDTO AddMenu(MenuDTO menu)
        {
            var menuEntity = _mapper.Map<Menu>(menu);
            _menuUnit.Menus.Add(menuEntity);
            _menuUnit.Complete();
            return _mapper.Map<MenuDTO>(menuEntity);
        }

        public CategoryDTO GetCategoryDetails(Guid id)
        {
            var categoryEntity = _menuUnit.Categories.GetCategoryDetails(id);
            return _mapper.Map<CategoryDTO>(categoryEntity);
        }

        public bool DeleteMenu(Guid id)
        {
            var menuEntity = _menuUnit.Menus.Get(id);
            if (menuEntity == null)
            {
                return false;
            }
            menuEntity.Deleted = true;
            _menuUnit.Menus.Remove(menuEntity);
            _menuUnit.Complete();
            return true;
        }
    }
}
