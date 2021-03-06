﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ErpMaterial.Models;
using ErpMaterial.Repository;
using ErpMaterial.Service.ViewModel;

namespace ErpMaterial.Service
{
    public class SysAuthorityService : Interface.ISysAuthorityService
    {
        private IGenericRepository<SysAuthorityInfo> _repo;
        public SysAuthorityService(IGenericRepository<SysAuthorityInfo> repo)
        {
            this._repo = repo;
        }

        public bool Del(int id)
        {
            var info = _repo.GetEntity(w => w.AuthorityId == id);
            return _repo.Delete(info).Result;
        }

        public PageLayUI<SysAuthorityInfo> listPage(int page, int limit, Dictionary<string, object> whereList)
        {
            var skip = page == 1 ? 0 : (page - 1) * limit;

            var info = _repo.GetEntities(w=>w.AuthorityId>0);
            if (!string.IsNullOrEmpty(whereList["searchAuthorityName"].ToString()))
            {
                info = info.Where(w => w.AuthorityName.Contains(whereList["searchAuthorityName"].ToString()));
            }
            if (!string.IsNullOrEmpty(whereList["searchAuthorityType"].ToString()))
            {
                info = info.Where(w => w.AuthorityType==whereList["searchAuthorityType"].ToString());
            }

            PageLayUI<SysAuthorityInfo> pageLayUI = new PageLayUI<SysAuthorityInfo>();
            pageLayUI.count = info.Count();
            pageLayUI.data = info.OrderBy(o => o.AuthorityId).Skip(skip).Take(limit).ToList();
            return pageLayUI;
        }

        public MenuLayUI memuList()
        {
            var menuDataList = new List<MenuDataLayUI>();
            var rootMenu = _repo.GetEntities(w => w.AuthorityType == "菜单"&&w.MenuFatherId==0).ToList();
            foreach (var item in rootMenu)
            {
                var menuData = new MenuDataLayUI();
                menuData.icon = item.MenuIcon;
                menuData.jump = item.MenuUrl;
                menuData.title = item.MenuName;
                menuData.list = GetChildMenu(item);
                menuDataList.Add(menuData);
            }

            var menu = new MenuLayUI()
            {
               code="",
               msg="",
               data=menuDataList
            };
            return menu;
        }

        public List<MenuDataLayUI> GetChildMenu(SysAuthorityInfo menu)
        {
            var menuDataList = new List<MenuDataLayUI>();
            var menuList = _repo.GetEntities(w => w.AuthorityType == "菜单" && w.MenuFatherId == menu.AuthorityId).ToList();
            foreach (var item in menuList)
            {
                var menuData = new MenuDataLayUI();
                menuData.icon = item.MenuIcon;
                menuData.jump = item.MenuUrl;
                menuData.title = item.MenuName;
                menuData.list = GetChildMenu(item);
                menuDataList.Add(menuData);
            }
            return menuDataList;
        }

        public bool Update(SysAuthorityInfo sysAuthorityInfo)
        {
            if (sysAuthorityInfo.AuthorityId != 0)
            {
                return _repo.Update(sysAuthorityInfo).Result;
            }
            else
            {
                return _repo.Add(sysAuthorityInfo).Result;
            }
        }

        public MenuLayUI memuList(List<int> userMenuID)
        {
            throw new NotImplementedException();
        }
    }
}
