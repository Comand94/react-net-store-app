using react_net_store_core.DTO;
using react_net_store_database.Classes;


namespace react_net_store_core.Services
{
    public interface IUsersServices
    {
        public bool HasAdminRights(User user);
        UserDTO GetUserById(long id);
        Task<UserDTO> SignUp(User user);
        Task<UserDTO> SignIn(User user);
        Task<UserDTO> ExternalSignIn(User user);
    }

}
