using System.Net;
using EasyIdentityServer.DAL.DatabaseContext;
using EasyIdentityServer.Domain.Model;
using EasyIdentityServer.DTO.Abstractions;
using Microsoft.EntityFrameworkCore;

namespace EasyIdentityServer.Repository.Repositories;

public class UserRepository : IRepository<Guid, User?>
{
    private EasyIdentityDbContext _db; 
        
    public UserRepository(EasyIdentityDbContext db)
    {
        _db = db;
    }

    public async Task<(bool, User?)> TryGet(Guid id)
    {
        var user = await _db.Users.FirstOrDefaultAsync(u=>u.UserId == id);
        return (user != null, user);
    }
}