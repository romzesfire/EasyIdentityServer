using System.Net;
using EasyIdentityServer.DAL.DatabaseContext;
using EasyIdentityServer.Domain.Model;
using EasyIdentityServer.DTO;
using EasyIdentityServer.DTO.Abstractions;
using EasyIdentityServer.DTO.Exception;
using EasyIdentityServer.DTO.Model;

namespace EasyIdentityServer.Service.Services;

public class UserRegister : IUserRegister
{
    private readonly ISecretKeyGenerator _keyGenerator;
    private readonly IUserRecorder _userRecorder;
    private readonly IRepository<Guid, User> _userRepository;
    private readonly EasyIdentityDbContext _db;
    private readonly IKeyHasher _hasher;
    public UserRegister(ISecretKeyGenerator keyGenerator, IUserRecorder userRecorder, 
        IRepository<Guid, User> userRepository, EasyIdentityDbContext db, IKeyHasher hasher)
    {
        _keyGenerator = keyGenerator;
        _userRepository = userRepository;
        _userRecorder = userRecorder;
        _db = db;
        _hasher = hasher;
    }

    public async Task<UserCredentials> Register(UserCreationModel userCreationModel, IPAddress ip)
    {
        var key = await _keyGenerator.GenerateAsync();
        var userExist = await _userRepository.TryGet(userCreationModel.UserId);
        if (userExist.Item1)
        {
            throw new RegisterExistUserException();
        }

        var user = new User(userCreationModel.UserId, _hasher.Hash(key), ip);
        _userRecorder.Record(user);

        await _db.SaveChangesAsync();
        return new UserCredentials(userCreationModel.UserId, key);
    }
}