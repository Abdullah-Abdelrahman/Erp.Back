namespace Name.Data.Dto
{
    public class ManageUserRolesResult
    {
        public string UserId { get; set; }

        public List<Role> Roles { get; set; }

    }

    public class Role
    {
        public string RoleId { get; set; }
        public string RoleName { get; set; }

        public bool HasRole { get; set; }
    }
}
