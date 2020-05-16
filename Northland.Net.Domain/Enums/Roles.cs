using System;
namespace Northland.Net.Domain
{
    [Flags]
    public enum Roles
    {
        None = 0,
        Admin = 1,
        User = 2
    }
}