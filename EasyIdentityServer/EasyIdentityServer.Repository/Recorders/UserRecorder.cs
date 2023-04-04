using EasyIdentityServer.DAL.DatabaseContext;
using EasyIdentityServer.Domain.Model;
using EasyIdentityServer.DTO.Abstractions;

namespace EasyIdentityServer.Service.Services;

public class UserRecorder : IUserRecorder
{
    private EasyIdentityDbContext _db;
    public UserRecorder(EasyIdentityDbContext db)
    {
        _db = db;
    }


    public void Record(User user)
    {
        _db.Users.Add(user);
    }
}