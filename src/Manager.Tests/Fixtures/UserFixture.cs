using Manager.Service.DTO;

namespace Manager.Tests.Fixtures
{
    public class UserFixture
    {

        public static UserDTO CreateInvalidUserDTO()
        {
            return new UserDTO
            {
                Id = 0,
                Name = "",
                Email = "",
                Password = ""
            };
        }

        public static UserDTO createValidUserDTO(string name, string email, string password)
        {
            return new UserDTO
            {
                Id = 0,
                Name = name,
                Email = email,
                Password = password
            };
        }
    }
}
