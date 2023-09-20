using AutoMapper;
using IdentityProj.Infrastructure;
using IdentityProj.Infrastructure.Repositories;

namespace IdentityProj.Services;

public class BaseService
{
    private readonly IMapper _mapper;
    private readonly UserManagerRepository _userManagerRepo;
    
    protected BaseService(
        IMapper mapper,
        UserManagerRepository userManagerRepo)
    {
        _mapper = mapper;
        _userManagerRepo = userManagerRepo;
    }

    protected IMapper Mapper => _mapper;
    protected UserManagerRepository UserManagerRepository => _userManagerRepo;
}