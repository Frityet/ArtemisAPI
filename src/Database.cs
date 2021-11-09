using System.Collections.Generic;
using System.IO;
using ArtemisAPI.Models;

namespace ArtemisAPI
{
    public class Database
    {
        public const string DIRECTORY_NAME = "database";
        public static Database Instance { get; }

        private DirectoryInfo _databaseDirectory;

        public IEnumerable<ProductionLine> Factories 
        {
            get
            {
                foreach (FileInfo item in collection)
                {
                    
                }
            }
        }

        static Database()
        {
            Instance = new Database(DIRECTORY_NAME);
        }

        public Database(string dirname)
        {
            if (!Directory.Exists(dirname))
            {
                _databaseDirectory = Directory.CreateDirectory(dirname);
            } else _databaseDirectory = new DirectoryInfo(dirname);
        }
    }
}