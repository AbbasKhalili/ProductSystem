namespace Shared.Core
{
    [AttributeUsage(AttributeTargets.Method)]
    public class HasPermissionAttribute : Attribute
    {
        public long PermissionCode { get; private set; }
        public int[] Roles { get; private set; }

        public HasPermissionAttribute(object enumValue, params int[] roles)
        {
            PermissionCode = (long)enumValue;
            Roles = roles;
        }
    }
}
