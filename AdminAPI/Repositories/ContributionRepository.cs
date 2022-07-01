using AdminAPI.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminAPI.Repositories
{
    public class ContributionRepository : IContributionRepo<Contribution>
    {
        private readonly AdminsDBContext _context;
        public ContributionRepository(AdminsDBContext context)
        {
            _context = context;
        }
        public bool AddContribution(Contribution contribution)
        {
            try
            {
                _context.Contributions.Add(contribution);
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public bool ContributionExists(int id)
        {
            return _context.Contributions.Any(e => e.Cid == id);
        }

        public bool DeleteContribution(int id)
        {
            try
            {
                var contribution = GetContribution(id);
                _context.Contributions.Remove(contribution);
                _context.SaveChanges();
            }
            catch(Exception)
            {
                return false;
            }
            return true;
        }

        public bool EditContribution(Contribution contribution)
        {
            try
            {
                _context.Entry(contribution).State = EntityState.Modified;
                _context.SaveChanges();
            }
            catch (Exception)
            {
                return false;
            }
            return true;
        }

        public Contribution? GetContribution(int id)
        {
            return _context.Contributions.Find(id);
        }

        public List<Contribution> GetContributions()
        {
            return _context.Contributions.ToList();
        }
    }
}
