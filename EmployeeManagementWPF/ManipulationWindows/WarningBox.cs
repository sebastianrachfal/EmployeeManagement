using System.Windows;

namespace EmployeeManagementWPF
{
    /// <summary>
    /// Static class for showing Warning MessageBox
    /// </summary>
    public static class WarningBox
    {
        /// <summary>
        /// Method for showing WarningBox
        /// </summary>
        /// <param name="message">string containing the message</param>
        public static void Show(string message) => MessageBox.Show(message, "Warning", MessageBoxButton.OK, MessageBoxImage.Warning);
    }
}
