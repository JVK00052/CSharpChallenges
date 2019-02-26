using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClaimChallenge
{
   public  class ClaimRepository
    {
        public ClaimRepository() { }

        private Queue<Claim> _claimsRepo = new Queue<Claim>();

        public void AddClaimToQueue(Claim claim)
        {
            _claimsRepo.Enqueue(claim); 
        }

        public void RemoveClaimFromQueue(Claim claim)
        {
            _claimsRepo.Dequeue();
        }

        public Queue<Claim> GetClaims()
        {
            return _claimsRepo;
        }
    }
}
