using AdminAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminAPI.Repositories
{
    public class AdminRepository : IAdminRepo<Admin>
    {
        private readonly AdminsDBContext _context;

        public AdminRepository(AdminsDBContext context)
        {
            _context = context;
        }
        public bool AddAdmin(Admin admin)
        {
            try
            {
                _context.Admins.Add(admin);
                _context.SaveChanges();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public bool AdminExists(int id)
        {
            return _context.Admins.Any(e => e.AdminId == id);
        }

        public bool DeleteAdmin(int id)
        {
            try
            {
                Admin admin = GetAdminById(id);
                admin.IsDeleted = true;
                admin.IsActive = false;
                admin.IsLocked = true;
                _context.SaveChanges();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public bool EditAdmin(Admin admin)
        {
            _context.Entry(admin).State = EntityState.Modified;
            try
            {
                _context.SaveChanges();
            }
            catch (Exception)
            {
                throw;
            }
            return true;
        }

        public Admin? GetAdminById(int id)
        {
            return _context.Admins.Find(id);
        }

        public List<Admin> GetAdmins()
        {
            return _context.Admins.ToList();
        }
    }
}
