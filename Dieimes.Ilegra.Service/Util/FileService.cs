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
        public static Thread StartRead(string pathIn, string pathOut)
        {
            return new Thread(() =>
            {

                while (true)
                {
                    if (Directory.Exists(pathIn))
                    {
                        OutFile outFile = new OutFile();
                        foreach (FileInfo fileInfo in new DirectoryInfo(pathIn).GetFiles())
                        {
                            using (StreamReader streamReader = new StreamReader(fileInfo.FullName, encoding: Encoding.UTF8))
                            {
                                while (!streamReader.EndOfStream)
                                {
                                    var line = streamReader.ReadLine();
                                    var entityType = GetType(line);

                                    if (entityType == typeof(Custommer))
                                    {
                                        outFile.AddCustommer(CreateCustommer(line));
                                    }
                                    if (entityType == typeof(Sale))
                                    {
                                        outFile.AddSales(CreateSale(line));
                                    }
                                    if (entityType == typeof(SalesMan))
                                    {
                                        outFile.AddSalesMan(CreateSalesMan(line));
                                    }
                                    else
                                    {
                                        continue;
                                    }

                                }

                                streamReader.Close();
                            }

                        }
                        if (!Directory.Exists(pathOut))
                            Directory.CreateDirectory(pathOut);

                        WriteOutFile(outFile, pathOut + "//Arquivo de saida.tmp");
                        File.Copy(pathOut + "//Arquivo de saida.tmp", pathOut + "//Arquivo de saida.txt", true);

                    }
                    else
                    {
                        Directory.CreateDirectory(pathIn);
                    }
                }
            });


        }

        private static void WriteOutFile(OutFile outFile, string pathOut)
        {
            using(StreamWriter streamWriter = new StreamWriter(pathOut, false))
            {
                var custommersCount = outFile.CustommersCount();
                var salesManCount = outFile.SalesManCount();
                var salesExpansiveId = outFile.GetExpansiveSale()?.Id;
                var worstSalesMan = outFile.GetWorstSalesManName();

                streamWriter.WriteLine("Quantidade de clientes:" + custommersCount);
                streamWriter.WriteLine("Quantidade de Vendedores:" + salesManCount);
                streamWriter.WriteLine("Id da Venda mais cara:" + salesExpansiveId );
                streamWriter.WriteLine("Pior Vendedor: " + worstSalesMan);
                
                streamWriter.Flush();
                streamWriter.Close();
            }
        }

        public static Custommer CreateCustommer(string data)
        {
            try
            {
                var props = data.Split('ç');
                return new Custommer(props[0], props[1], props[2], props[3]);
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
                Sale sale = new Sale(props[0], props[1], props[3]);

                string[] items = item.Replace("[", "").Replace("]", "").Split(',');
                foreach(var strItem in items)
                {
                    var propItems = strItem.Split('-');
                    var saleItem = new SaleItem(long.Parse(propItems[0]), int.Parse(propItems[1]), decimal.Parse(propItems[2]));
                    sale.AddSaleItem(saleItem);

                }

                return sale;
            }
            catch(Exception e)
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
                    return new SalesMan().GetType();

                case "002":
                    return new Custommer().GetType();

                case "003":
                    return new Sale().GetType();

                default:
                    return null;
            }
            
        }
       

    }
}
