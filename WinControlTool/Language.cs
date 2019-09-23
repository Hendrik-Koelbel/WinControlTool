using Microsoft.Win32;
using System;
using System.ComponentModel;
using System.Globalization;
using System.Reflection;
using System.Threading;
using System.Windows.Forms;

namespace WinControlTool
{
    public static class Language
    {
        public static void ChangeLanguage(string lang)
        {
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(lang);
            Thread.CurrentThread.CurrentCulture = new CultureInfo(lang);
            foreach (Form frm in Application.OpenForms)
            {
                localizeForm(frm);
            }
        }

        public static void localizeForm(Form frm)
        {
            var manager = new ComponentResourceManager(frm.GetType());
            manager.ApplyResources(frm, "$this");
            applyResources(manager, frm.Controls);
        }

        private static void applyResources(ComponentResourceManager manager, Control.ControlCollection ctls)
        {
            foreach (Control ctl in ctls)
            {
                manager.ApplyResources(ctl, ctl.Name);
                applyResources(manager, ctl.Controls);
            }
        }

        /// <summary>
        /// Saves the program language data in the registry.
        /// </summary>
        /// <param name="selectedType">Languages Enum int's</param>
        public static void setCurrentLanguage2Registry(int selectedType = 1)
        {
            // Accessing the CurrentUser root element  
            // and adding "ApplicationName" subkey to the "SOFTWARE" subkey  
            RegistryKey key = Registry.CurrentUser.CreateSubKey(@"SOFTWARE\" + Application.ProductName + @"\LanguageSettings");
            //storing the values  
            key.SetValue("selectedType", selectedType); // set the selected Type for Combobox
            key.SetValue("currentCulture", Thread.CurrentThread.CurrentCulture); // default PC culture for example de-DE
            key.SetValue("currentCultureDisplayName", Thread.CurrentThread.CurrentCulture.DisplayName); // default PC culture name
            key.SetValue("currentCultureEnglishName", Thread.CurrentThread.CurrentCulture.EnglishName); // default PC culture name in english
            key.SetValue("currentCultureNativeName", Thread.CurrentThread.CurrentCulture.NativeName); // default PC culture name
            key.SetValue("currentUICulture", Thread.CurrentThread.CurrentUICulture); // default PC culture for example de-DE
            key.SetValue("twoLetterISOLanguageName", Thread.CurrentThread.CurrentCulture.TwoLetterISOLanguageName); // default PC culture for example "de"
            key.Close();
        }
        /// <summary>
        /// Defines the program language.
        /// </summary>
        public static void getLanguageFromRegistry()
        {
            // Accessing the CurrentUser root element  
            // and adding "ApplicationName" subkey to the "SOFTWARE" subkey  
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\" + Application.ProductName + @"\LanguageSettings");
            //storing the values  
            Thread.CurrentThread.CurrentCulture = new CultureInfo(key.GetValue("currentCulture").ToString()); // default PC culture for example de-DE
            Thread.CurrentThread.CurrentUICulture = new CultureInfo(key.GetValue("currentUICulture").ToString()); // default PC culture for example de-DE
            key.Close();
        }

        public enum Languages
        {
            [Description("Automatic")]
            auto = 1,
            [Description("English")]
            en = 2,
            [Description("German")]
            de = 3,
            [Description("Français")]
            fr = 4,
        }

        public static void checkLanguage(Form currentForm, ComboBox selectedComboboxItem)
        {
            //Language.setCurrentLanguage2Registry();
            // Accessing the CurrentUser root element  
            // and adding "ApplicationName" subkey to the "SOFTWARE" subkey  
            using (RegistryKey lokalKey = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\" + Application.ProductName + @"\LanguageSettings"))
            {
                if (lokalKey == null)
                {
                    setCurrentLanguage2Registry();
                }
            }
            RegistryKey key = Registry.CurrentUser.OpenSubKey(@"SOFTWARE\" + Application.ProductName + @"\LanguageSettings");
            //check the values  
            object keyValue = key.GetValue("selectedType");

            
            switch ((int)keyValue)
            {
                case (int)Languages.auto:
                    CultureInfo ci = CultureInfo.InstalledUICulture;
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(ci.Name);
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(ci.Name);
                    ChangeLanguage(Thread.CurrentThread.CurrentCulture.ToString());
                    localizeForm(currentForm);
                    selectedComboboxItem.SelectedIndex = selectedComboboxItem.FindString(GetDescription((Languages)(int)keyValue));
                    break;
                case (int)Languages.en:
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(key.GetValue("currentCulture").ToString()); // default PC culture for example de-DE
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(key.GetValue("currentUICulture").ToString()); // default PC culture for example de-DE
                    ChangeLanguage(Thread.CurrentThread.CurrentCulture.ToString()); // Sets the current language of the ComboBox
                    localizeForm(currentForm); // Updates the language of the current form
                    selectedComboboxItem.SelectedIndex = selectedComboboxItem.FindString(GetDescription((Languages)(int)keyValue));
                    break;
                case (int)Languages.de:
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(key.GetValue("currentCulture").ToString()); // default PC culture for example de-DE
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(key.GetValue("currentUICulture").ToString()); // default PC culture for example de-DE
                    ChangeLanguage(Thread.CurrentThread.CurrentCulture.ToString()); // Sets the current language of the ComboBox
                    localizeForm(currentForm); // Updates the language of the current form
                    selectedComboboxItem.SelectedIndex = selectedComboboxItem.FindString(GetDescription((Languages)(int)keyValue));
                    break;
                case (int)Languages.fr:
                    Thread.CurrentThread.CurrentCulture = new CultureInfo(key.GetValue("currentCulture").ToString()); // default PC culture for example de-DE
                    Thread.CurrentThread.CurrentUICulture = new CultureInfo(key.GetValue("currentUICulture").ToString()); // default PC culture for example de-DE
                    ChangeLanguage(Thread.CurrentThread.CurrentCulture.ToString()); // Sets the current language of the ComboBox
                    localizeForm(currentForm); // Updates the language of the current form
                    selectedComboboxItem.SelectedIndex = selectedComboboxItem.FindString(GetDescription((Languages)(int)keyValue));
                    break;
            }
            key.Close();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="currentType">The selected language must be passed here.</param>
        /// <param name="currentForm">The current form must be passed here. Best with the "this" command.</param>
        public static void switchCaseLanguage(Form currentForm, string currentType)
        {
            switch (currentType)
            {
                case nameof(Languages.auto):
                    CultureInfo ci = CultureInfo.InstalledUICulture;
                    ChangeLanguage(ci.Name); // Sets the current language of the ComboBox
                    localizeForm(currentForm); // Updates the language of the current form
                    setCurrentLanguage2Registry((int)Languages.auto);
                    break;
                case nameof(Languages.en):
                    ChangeLanguage(nameof(Languages.en)); // Sets the current language of the ComboBox
                    localizeForm(currentForm); // Updates the language of the current form
                    setCurrentLanguage2Registry((int)Languages.en);
                    break;
                case nameof(Languages.de):
                    ChangeLanguage(nameof(Languages.de)); // Sets the current language of the ComboBox
                    localizeForm(currentForm); // Updates the language of the current form
                    setCurrentLanguage2Registry((int)Languages.de);
                    break;
                case nameof(Languages.fr):
                    ChangeLanguage(nameof(Languages.fr)); // Sets the current language of the ComboBox
                    localizeForm(currentForm); // Updates the language of the current form
                    setCurrentLanguage2Registry((int)Languages.fr);
                    break;
            }
        }

        /// <summary>
        /// returns current Description
        /// </summary>
        /// <param name="value">currentEnum</param>
        /// <returns>returns Description or Null</returns>
        public static string GetDescription(this Enum value)
        {
            Type type = value.GetType();
            string name = Enum.GetName(type, value);
            if (name != null)
            {
                FieldInfo field = type.GetField(name);
                if (field != null)
                {
                    DescriptionAttribute attr =
                           Attribute.GetCustomAttribute(field,
                             typeof(DescriptionAttribute)) as DescriptionAttribute;
                    if (attr != null)
                    {
                        return attr.Description;
                    }
                }
            }
            return null;
        }
    }
}
