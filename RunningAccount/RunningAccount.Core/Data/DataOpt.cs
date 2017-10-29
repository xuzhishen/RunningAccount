using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RunningAccount.Core.Data
{
    static class DataOpt
    {
        private const String filePath = "./RADB.json";

        private static DataMapping mapping;

        internal static void Load()
        {
            if (!File.Exists(filePath))
                File.Create(filePath).Dispose();

            String context = File.ReadAllText(filePath);

            mapping = JsonConvert.DeserializeObject<DataMapping>(context);
        }

        internal static void Save()
        {
            String context = JsonConvert.SerializeObject(mapping);
            File.WriteAllText(filePath, context);
        }

        internal static DataMapping Mapping
        {
            get { return mapping; }
        }

        static DataOpt()
        {
            Load();
        }
    }
}
