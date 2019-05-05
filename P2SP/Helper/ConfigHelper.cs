using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Helper
{
    public class ConfigHelper
    {
        private static Configuration appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);

        public static Configuration LoadConfig()
        {
            appConfig = ConfigurationManager.OpenExeConfiguration(ConfigurationUserLevel.None);
            return appConfig;
        }

        public static void SaveConfig()
        {
            appConfig.Save();
        }

        public static bool GetAttributeBool(string n)
        {
            try
            {
                string str = appConfig.AppSettings.Settings[n].Value;
                if (string.IsNullOrEmpty(str))
                {
                    return false;
                }
                return Convert.ToBoolean(str);
            }
            catch (Exception ex)
            {
                LogHelper.logerror.Error(ex);
                return false;
            }
        }

        public static int GetAttributeInt(string n, int i)
        {
            try
            {
                string str = appConfig.AppSettings.Settings[n].Value;
                if (string.IsNullOrEmpty(str))
                {
                    return i;
                }
                return Convert.ToInt32(str);
            }
            catch (Exception ex)
            {
                LogHelper.logerror.Error(ex);
                return i;
            }
        }

        public static double GetAttributeDouble(string n, double d)
        {
            try
            {
                string str = appConfig.AppSettings.Settings[n].Value;
                if (string.IsNullOrEmpty(str))
                {
                    return d;
                }
                return Convert.ToDouble(str);
            }
            catch (Exception ex)
            {
                LogHelper.logerror.Error(ex);
                return d;
            }
        }

        public static string GetAttribute(string n, string s)
        {
            try
            {
                string str = appConfig.AppSettings.Settings[n].Value;
                if (string.IsNullOrEmpty(str))
                {
                    return s;
                }
                return str;
            }
            catch (Exception ex)
            {
                LogHelper.logerror.Error(ex);
                return s;
            }
        }

        public static string GetAttribute(string n)
        {
            try
            {
                string str = appConfig.AppSettings.Settings[n].Value;
                if (string.IsNullOrEmpty(str))
                {
                    return "";
                }
                return str;
            }
            catch (Exception ex)
            {
                LogHelper.logerror.Error(ex);
                return "";
            }
        }

        public static void SetAttribute(string n, string v)
        {
            try
            {
                appConfig.AppSettings.Settings[n].Value = v;
            }
            catch (Exception ex)
            {
                LogHelper.logerror.Error(ex);
            }
            finally
            {
                SaveConfig();
            }
        }

        public static void SetAttribute(string n, bool v)
        {
            try
            {
                appConfig.AppSettings.Settings[n].Value = v.ToString().ToLower();
            }
            catch (Exception ex)
            {
                LogHelper.logerror.Error(ex);
            }
            finally
            {
                SaveConfig();
            }
        }

        public static void SetAttribute(string n, float v)
        {
            try
            {
                appConfig.AppSettings.Settings[n].Value = v.ToString();
            }
            catch (Exception ex)
            {
                System.Diagnostics.StackTrace st = new System.Diagnostics.StackTrace(new System.Diagnostics.StackFrame(true));
                System.Diagnostics.StackFrame sf = st.GetFrame(0);
                DebugHelper.Error(ex, sf);
            }
            finally
            {
                SaveConfig();
            }
        }
    }
}
