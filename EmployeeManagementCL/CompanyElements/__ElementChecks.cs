using System;

namespace EmployeeManagementCL
{
    public static class Checks
    {
        internal static void CheckLength(string toCheck, string name, int min, int max)
        {
            if (toCheck.Length <= min) throw new ArgumentException($"{name} length can't be lower or equal to {min}");
            if (toCheck.Length > max) throw new ArgumentException($"{name} length can't exceed {max}");
        }
    }
}
