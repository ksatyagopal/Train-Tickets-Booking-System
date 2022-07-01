using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminAPI.Services
{
    public interface IAdminService<Admin>
    {
        public List<Admin> GetAdmins();

        public Admin? GetAdminById(int id);

        public bool EditAdmin(Admin admin);

        public bool AddAdmin(Admin admin);

        public bool DeleteAdmin(int id);

        public bool AdminExists(int id);
    }
}
