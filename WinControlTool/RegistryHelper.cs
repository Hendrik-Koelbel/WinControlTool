using Microsoft.Win32;
using System;
using System.Windows.Forms;

namespace WinControlTool
{
    public static class RegistryHelper
    {

        public static string RegPath = @"Software\" + Application.ProductName + @"\";

        #region ApplicationGenerics

        public static void SaveValue(string SubKeyName, string ValueName, object value)
        {
            var reg = RegPath;

            RegistryKey key = Registry.CurrentUser.CreateSubKey(reg + SubKeyName);
            key.SetValue(ValueName, value.ToString());
        }

        public static string GetString(string SubKeyName, string ValueName)
        {
            var reg = RegPath;

            var key = Registry.CurrentUser.OpenSubKey(reg + SubKeyName);
            if (key != null)
            {
                return key.GetValue(ValueName).ToString();
            }

            return null;
        }

        public static int GetInt(string SubKeyName, string ValueName)
        {
            var reg = RegPath;

            var key = Registry.CurrentUser.OpenSubKey(reg + SubKeyName);
            if (key != null)
            {
                var top = int.Parse(key.GetValue(ValueName).ToString());
                return top;
            }

            return 0;
        }

        public static double GetDouble(string SubKeyName, string ValueName)
        {
            var reg = RegPath;


            var key = Registry.CurrentUser.OpenSubKey(reg + SubKeyName);
            if (key != null)
            {
                Double top = Double.Parse(key.GetValue(ValueName).ToString());
                return top;
            }

            return 0.0;
        }

        public static bool GetBoolean(string SubKeyName, string ValueName)
        {
            var reg = RegPath;

            var key = Registry.CurrentUser.OpenSubKey(reg + SubKeyName);
            if (key != null)
            {
                bool top = bool.Parse(key.GetValue(ValueName).ToString());
                return top;
            }

            return false;
        }

        public static void CreateKeyIfNotExisting(string SubKeyName, string ValueName, object defaultValue)
        {
            var reg = RegPath;

            var key = Registry.CurrentUser.OpenSubKey(reg + SubKeyName);
            if (key == null)
            {
                Registry.CurrentUser.CreateSubKey(reg + SubKeyName);
                CheckIfValueExists(SubKeyName, ValueName, defaultValue);
            }
            else
            {
                CheckIfValueExists(SubKeyName, ValueName, defaultValue);
            }
        }

        public static void CheckIfValueExists(string SubKeyName, string ValueName, object defaultValue)
        {
            var reg = RegPath;

            var key = Registry.CurrentUser.OpenSubKey(reg + SubKeyName);
            Type type = defaultValue.GetType();

            if (key.GetValue(ValueName) == null)
            {
                if (type == typeof(string))
                {
                    SaveValue(SubKeyName, ValueName, defaultValue);
                }
                else if (type == typeof(int))
                {
                    SaveValue(SubKeyName, ValueName, defaultValue);
                }
                else if (type == typeof(double))
                {
                    SaveValue(SubKeyName, ValueName, defaultValue);
                }
                else if (type == typeof(bool))
                {
                    SaveValue(SubKeyName, ValueName, defaultValue);
                }
            }
        }

        #endregion ApplicationGenerics

        #region Preset Settings
        public static void ResetSettings()
        {
            var reg = RegPath;
            // Delete Keys to reset
        }
        #endregion
    }
}