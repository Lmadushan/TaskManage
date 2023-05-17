namespace TaskManage.Entities
{
    public static class AppConstants
    {
        public const string DateFormat = "dd-MM-yyyy";

        public static class Roles
        {
            public const string Admin = "Admin";
        }

        public static class SuperAdminFeature
        {
            public const string LeadView = "LeadView";
            public const string TenantView = "TenantView";
            public const string TenantAdd = "TenantAdd";
            public const string TenantEdit = "TenantEdit";
            public const string TenantDelete = "TenantDelete";
        }

        public static class AdminFeature
        {
            public const string UserAdd = "UserAdd";
            public const string UserDelete = "UserDelete";
            public const string UserEdit = "UserEdit";
            public const string UserView = "UserView";

            public const string RoleAdd = "RoleAdd";
            public const string RoleDelete = "RoleDelete";
            public const string RoleEdit = "RoleEdit";
            public const string RoleView = "RoleView";

            public const string CompanyProfileView = "CompanyProfileView";
            public const string CompanyProfileEdit = "CompanyProfileEdit";
        }

        public const string ApiRequestKeyName = "ApiRequestKey";
        public const string ApiRequestKeyValue = "1a53f438-093a-4ccc-87fb-198a0bfa04604d1e8e4c-83aa-4a4b-ab6a-cdf3f5da05c1";
    }
}
