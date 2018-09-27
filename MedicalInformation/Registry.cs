using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Registry
    {
        private readonly string _keyName;
        public Registry(string pathRoot)
        {
            _keyName = pathRoot;
        }

        public string[] GetRegistry(string valueName)
        {
            try
            {
                return Microsoft.Win32.Registry.GetValue(_keyName, valueName, null) as string[];
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool SetRegistry(string valueName, object value)
        {
            try
            {
                Microsoft.Win32.Registry.SetValue(_keyName, valueName, value);
                return true;
            }
            catch (Exception)
            {
                return false;
            }

        }
    }
}
