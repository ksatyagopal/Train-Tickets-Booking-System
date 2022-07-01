using AdminAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AdminAPI.Repositories;

namespace AdminAPI.Services
{
    public class ContributionService : IContributionService<Contribution>
    {
        private readonly IContributionRepo<Contribution> repo;
        public ContributionService(IContributionRepo<Contribution> crepo)
        {
            repo = crepo;
        }
        public bool AddContribution(Contribution contribution)
        {
            return repo.AddContribution(contribution);
        }

        public bool ContributionExists(int id)
        {
            return repo.ContributionExists(id);
        }

        public bool DeleteContribution(int id)
        {
            return repo.DeleteContribution(id);
        }

        public bool EditContribution(Contribution contribution)
        {
            return repo.EditContribution(contribution);
        }

        public Contribution? GetContribution(int id)
        {
            return repo.GetContribution(id);
        }

        public List<Contribution> GetContributions()
        {
            return repo.GetContributions();
        }
    }
}
