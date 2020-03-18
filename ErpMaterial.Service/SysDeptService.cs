using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using ErpMaterial.Models;
using ErpMaterial.Repository;
using ErpMaterial.Service.ViewModel;
using LinqKit;

namespace ErpMaterial.Service
{
    public class SysDeptService : Interface.ISysDeptService
    {
        private IGenericRepository<SysDeptInfo> _repo;
        public SysDeptService(IGenericRepository<SysDeptInfo> repo)
        {
            this._repo = repo;
        }

        public bool Del(int id)
        {
            var info = _repo.GetEntity(w => w.DeptId == id);
            return _repo.Delete(info).Result;
        }

        public List<DeptLayUI> ListAll(string selectDeptList)
        {
            List<int> listInt = new List<int>();
            if (!string.IsNullOrEmpty(selectDeptList))
            {
                var listString = selectDeptList.Split(',');
                foreach (var item in listString)
                {
                    listInt.Add(Convert.ToInt32(item));
                }
            }

            Expression<Func<SysDeptInfo, bool>> exp = w => 1 == 1;
            var sysDeptInfoList = _repo.GetEntities(exp).OrderBy(o=>o.DeptOrder).ToList();
            List<DeptLayUI> deptList = new List<DeptLayUI>();
            foreach (var item in sysDeptInfoList.Where(w => w.DeptFatherId == -1).ToList())
            {
                var child = sysDeptInfoList.Where(w => w.DeptFatherId == item.DeptId).ToList();
                deptList.Add(new DeptLayUI
                {
                    id = item.DeptId,
                    spread = item.IsOpen == 0 ? false : true,
                    title = item.DeptName,
                    children = GetChild(child, listInt),
                    @checked=false
                });
            }

            return deptList;
        }

        public List<DeptLayUI> GetChild(List<SysDeptInfo> list,List<int> selectDeptIDList)
        {
            Expression<Func<SysDeptInfo, bool>> exp = w => 1 == 1;
            var sysDeptInfoList = _repo.GetEntities(exp).OrderBy(o => o.DeptOrder).ToList();

            List<DeptLayUI> deptList = new List<DeptLayUI>();
            foreach (var item in list)
            {
                var child = sysDeptInfoList.Where(w => w.DeptFatherId == item.DeptId).ToList();
                deptList.Add(new DeptLayUI
                {
                    id = item.DeptId,
                    spread = item.IsOpen == 0 ? false : true,
                    title = item.DeptName,
                    @checked=selectDeptIDList.Contains(item.DeptId)?true:false,
                    children = GetChild(child, selectDeptIDList)
                });
            }
            return deptList;
        }

        public bool Update(SysDeptInfo info)
        {
            if (info.DeptId != 0)
            {
                return _repo.Update(info).Result;
            }
            else
            {
                return _repo.Add(info).Result;
            }
        }

        public SysDeptInfo GetOne(int id)
        {
            Expression<Func<SysDeptInfo, bool>> exp = w =>w.DeptId==id;
            return _repo.GetEntity(exp);
        }
    }
}
