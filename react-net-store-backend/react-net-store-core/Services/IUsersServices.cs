using react_net_store_core.DTO;
using react_net_store_database.Classes;


namespace react_net_store_core.Services
{
    public interface IUsersServices
    {
        public bool HasAdminRights(UserDTO user);
        Task<UserDTO> SignUp(User user);
        Task<UserDTO> SignIn(User user);
        Task<UserDTO> ExternalSignIn(User user);
    }

}
