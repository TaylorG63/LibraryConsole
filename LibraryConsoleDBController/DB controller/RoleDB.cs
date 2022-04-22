using LibraryConsoleLib.DTO;

namespace LibraryConsoleDBController.DB_controller
{
    public class RoleDB : DBController<RoleDTO>
    {
        internal List<RoleDTO> Role;
        public RoleDB() { Role = new List<RoleDTO>(); }
        public RoleDB(List<RoleDTO> roles) { Role = roles; }
        public override void Add(RoleDTO add)
        {
            Role.Add(add);
        }

        public override void Delete(RoleDTO delete)
        {
            Role.Remove(delete);
        }

        public override List<RoleDTO> Get()
        {
            List<RoleDTO> roles = new List<RoleDTO>();
            foreach(var role in Enum.GetValues<Roles>())
            {
                roles.Add(new RoleDTO() {RoleName = role});
            }
            return roles;
        }

        public override void Update(RoleDTO update)
        {
            throw new NotImplementedException();
        }
    }
}
