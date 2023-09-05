namespace Application.Contract.DTOs.Accesses
{
    public class UserRoleClaimActionSelectResponseDto
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int? ClaimID { get; set; }
        public string CalimName { get; set; }

        public int? RoleID { get; set; }
        public string RoleName { get; set; }
        public int? ParentRoleID { get; set; }
        public string ParentRoleName { get; set; }
        public int ActionID { get; set; }
        public string ActionName { get; set; }
        public int ControllerID { get; set; }
        public string ControllerName { get; set; }
        public int AreaID { get; set; }
        public string AreaName { get; set; }
        public int SiteID { get; set; }
        public string SiteName { get; set; }

    }

}
