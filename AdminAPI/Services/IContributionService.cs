using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdminAPI.Services
{
    public interface IContributionService<Contribution>
    {
        public List<Contribution> GetContributions();
        public Contribution? GetContribution(int id);
        public bool EditContribution(Contribution contribution);
        public bool AddContribution(Contribution contribution);
        public bool DeleteContribution(int id);
        public bool ContributionExists(int id);
    }
}
