using Dieimes.Ilegra.Domain;
using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Dieimes.Ilegra.Service.Util
{
    public static class FileService
    {
        public static Thread StartRead(string pathIn)
        {
            while(true)
            {
                if(Directory.Exists(pathIn))
                {
                    foreach(FileInfo fileInfo in new DirectoryInfo(pathIn).GetFiles())
                    {
                        using (StreamReader streamReader = new StreamReader(fileInfo.FullName))
                        {
                            while(!streamReader.EndOfStream)
                            {
                                var line = streamReader.ReadLine();
                                var entityType = GetType(line);

                                if(entityType.GetType() == typeof(Custommer))
                                {

                                }
                                if (entityType.GetType() == typeof(Sale))
                                {

                                }
                                if (entityType.GetType() == typeof(SalesMan))
                                {

                                }
                                else
                                {

                                }

                            }
                        }
                        
                    }
                }
            }

        }
        public static Thread StartWrite(string pathOut)
        {
            while(true)
            {

            }
        }
        private static Type GetType(string line)
        {
            var strTipo = line.Substring(0, 3);
            switch(strTipo)
            {
                case "001":
                    return typeof(SalesMan);

                case "002":
                    return typeof(Custommer);

                case "003":
                    return typeof(Sale);

                default:
                    return null;
            }
            
        }
       

    }
}
