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
                                    CreateCustommer(line);
                                }
                                if (entityType.GetType() == typeof(Sale))
                                {
                                    CreateSale(line);
                                }
                                if (entityType.GetType() == typeof(SalesMan))
                                {
                                    CreateSalesMan(line);
                                }
                                else
                                {
                                    continue;
                                }

                            }

                            OutFile outFile = new OutFile();

                            WriteOutFile(OutFile)
                        }
                        
                    }
                }
            }

        }
        public static Custommer CreateCustommer(string data)
        {
            try
            {
                var props = data.Split('ç');
                return new Custommer(props[0], props[1], props[2], props[3], props[4]);
            }
            catch
            {
                return null;
            }

        }
        public static Sale CreateSale(string data)
        {
            try
            {
                var props = data.Split('ç');
                string item = props[2];
                string[] itemProps = item.Replace("[", "").Replace("]", "").Split('-');
                var saleItem = new SaleItem(long.Parse(itemProps[0]), int.Parse(itemProps[1]), decimal.Parse(itemProps[2]));
               
                return new Sale(props[0], props[1], saleItem, props[2]);
            }
            catch
            {
                return null;
            }
        }
        public static SalesMan CreateSalesMan(string data)
        {
            try
            {
                var props = data.Split('ç');
                return new SalesMan(props[0], props[1], props[2], decimal.Parse(props[3]));
            }
            catch
            {
                return null;
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
