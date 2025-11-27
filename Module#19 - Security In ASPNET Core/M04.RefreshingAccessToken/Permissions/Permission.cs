using Microsoft.AspNetCore.Authorization;

namespace M04.RefreshingAccessToken.Permissions;

public static class Permission
{
    public static class Project
    {
        public const string Create = "project:create";
        public const string Read = "project:read";
        public const string Update = "project:update";
        public const string Delete = "project:delete";
        public const string AssignMember = "project:assign_member";
        public const string ManageBudget = "project:manage_budget";
    }

    public static class Task
    {
        public const string Create = "task:create";
        public const string Read = "task:read";
        public const string Update = "task:update";
        public const string Delete = "task:delete";
        public const string AssignUser = "task:assign_user";
        public const string UpdateStatus = "task:update_status";
        public const string Comment = "task:comment";
    }

    public static IEnumerable<string> GetAllPermissions()
    {
        return typeof(Permission)
            .GetNestedTypes()
            .SelectMany(t => t.GetFields(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Static))
            .Select(f => f.GetValue(null)?.ToString()!)
            .Where(v => !string.IsNullOrEmpty(v));
    }
}

public static class AuthorizationPolicyExtensions
{
    public static void AddAllPermissions(this AuthorizationOptions options)
    {
        foreach (var permission in Permission.GetAllPermissions())
        {
            options.AddPolicy(permission, policy =>
                policy.RequireClaim("permission", permission));
        }
    }

      public static AuthorizationBuilder AddAllPermissions(this AuthorizationBuilder builder)
    {
        foreach (var permission in Permission.GetAllPermissions())
        {
            builder.AddPolicy(permission, policy =>
                policy.RequireClaim("permission", permission));
        }

        return builder; // 👈 عشان تقدر تكمل chain لو حبيت
    }
}