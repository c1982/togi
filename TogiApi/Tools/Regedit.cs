using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Win32;

namespace TogiApi
{
    public class Regedit
    {
        public const string ProgramKey = "Software\\Togi";
        public const string RunKey = @"SOFTWARE\Microsoft\Windows\CurrentVersion\Run";

        public static void SetKey_(string key_, string value_)
        {
            RegistryKey masterKey = Registry.CurrentUser.OpenSubKey(ProgramKey, true);

            if (masterKey == null)
            {
                masterKey = Registry.CurrentUser.CreateSubKey(ProgramKey);
            }

            masterKey.SetValue(key_, value_);
            Registry.LocalMachine.Flush();
            masterKey.Close();
        }

        public static string GetKey_(string key_)
        {
            string Deger = String.Empty;

            RegistryKey masterKey = Registry.CurrentUser.OpenSubKey(ProgramKey, false);

            if (masterKey == null)
            {
                masterKey = Registry.CurrentUser.CreateSubKey(ProgramKey);
            }

            if (masterKey.GetValue(key_) != null)
            {
                Deger = masterKey.GetValue(key_).ToString();
            }

            masterKey.Close();

            return Deger;
        }

        public static void SetRun()
        {
            RegistryKey masterKey = Registry.LocalMachine.OpenSubKey(RunKey, true);

            if (masterKey == null)
            {
                masterKey = Registry.CurrentUser.CreateSubKey(RunKey);
            }

            masterKey.SetValue("Togi Twitter Client", Environment.CommandLine.ToString());
            Registry.LocalMachine.Flush();
            masterKey.Close();            
        }

        public static void DeleteRun()
        {
            RegistryKey masterKey = Registry.LocalMachine.OpenSubKey(RunKey, true);

            if (masterKey != null)
            {
                    masterKey.DeleteValue("Togi Twitter Client",false);
            }
        }
    }
}
