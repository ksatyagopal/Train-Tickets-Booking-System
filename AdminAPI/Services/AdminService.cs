using AdminAPI.Models;
using AdminAPI.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminAPI.Services
{
    public class AdminService : IAdminService<Admin>
    {
        private readonly IAdminRepo<Admin> adminrepo;

        public AdminService(IAdminRepo<Admin> _adminRepo)
        {
            adminrepo = _adminRepo;
        }

        public bool AddAdmin(Admin admin)
        {
            return adminrepo.AddAdmin(admin);
        }

        public bool AdminExists(int id)
        {
            return adminrepo.AdminExists(id);
        }

        public bool DeleteAdmin(int id)
        {
            return adminrepo.DeleteAdmin(id);
        }

        public bool EditAdmin(Admin admin)
        {
            return adminrepo.EditAdmin(admin);
        }

        public Admin? GetAdminById(int id)
        {
            return adminrepo.GetAdminById(id);
        }

        public List<Admin> GetAdmins()
        {
            return adminrepo.GetAdmins();
        }
    }
}
