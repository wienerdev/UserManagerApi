using AutoMapper;
using Manager.Core.Exceptions;
using Manager.Domain.Entities;
using Manager.Infra.Interfaces;
using Manager.Service.DTO;
using Manager.Service.Interfaces;

namespace Manager.Service.Services
{
    public class UserService : IUserService
    {

        private readonly IMapper _mapper;
        private readonly IUserRepository _userRepository;

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _mapper = mapper;
            _userRepository = userRepository;
        }

        public async Task<UserDTO> Create(UserDTO userDTO)
        {
            var userExists = await _userRepository.GetByEmail(userDTO.Email);

            if (userExists != null) {
                throw new DomainException("Usuário já existente.");
            }

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userCreated = await _userRepository.Create(user);

            return _mapper.Map<UserDTO>(userCreated);
        }

        public async Task<UserDTO> Update(UserDTO userDTO)
        {
            var userExists = await _userRepository.GetById(userDTO.Id);
  
            if (userExists == null)
            {
                throw new DomainException("Usuário não existente.");
            }

            var user = _mapper.Map<User>(userDTO);
            user.Validate();

            var userCreated = await _userRepository.Update(user);

            return _mapper.Map<UserDTO>(userCreated);
        }

        public async Task Delete(long id)
        {
            await _userRepository.Delete(id);
        }

        public async Task<List<UserDTO>> GetAll()
        {
            return _mapper.Map<List<UserDTO>>(await _userRepository.GetAll());
        }

        public async Task<UserDTO> GetByEmail(string email)
        {
            return _mapper.Map<UserDTO>(await _userRepository.GetByEmail(email));
        }

        public async Task<UserDTO> GetById(long id)
        {
            return _mapper.Map<UserDTO>(await _userRepository.GetById(id));
        }

        public async Task<List<UserDTO>> SearchByEmail(string email)
        {
            return _mapper.Map<List<UserDTO>>(await _userRepository.SearchByEmail(email));

        }

        public async Task<List<UserDTO>> SearchByName(string name)
        {
            return _mapper.Map<List<UserDTO>>(await _userRepository.SearchByName(name));
        }
    }
}
