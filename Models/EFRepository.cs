using System.Collections.Generic;
using PartyInvites.Models;

namespace PartyInvites.Models
{
    public class EFRepository : IRepository
    {
        private ApplicationDbContext context = new ApplicationDbContext();
        public IEnumerable<GuestResponse> Responses => context.Invites;
        public void AddResponse(GuestResponse responce){
            context.Invites.Add(responce);
            context.SaveChanges();
        }
    }
}