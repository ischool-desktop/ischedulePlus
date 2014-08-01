using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ischedulePlus
{
    public static class ConfigDataExtension
    {
        public static void SaveAsync(this Campus.Configuration.ConfigData ConfigData)
        {
            Task vTask = Task.Factory.StartNew(()=> ConfigData.Save());
        }
    }
}