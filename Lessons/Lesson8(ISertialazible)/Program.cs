using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.IO;
using System.Globalization;

namespace Xml_ISertialazible
{
   [Serializable]
    public class Client
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DataBorn { get; set; }
        public long NumberPhone { get; set; }
        public string EMail { get; set; }
        public string NumberPassport { get; set; }
        public DateTime DataCart { get; set; }
        public long NumberCart { get; set; }
    }
        class Program
        {
            static void Main(string[] args)
            {

            Console.WriteLine("The object have created");
             
            Client client1 = new Client{FirstName="Sergey",LastName="Pavlichenko",DataBorn = new DateTime(1991,02,24),NumberPhone=380505600789,EMail="Ivanov@gmail.com",NumberCart=1234356235626372,NumberPassport="AA362739",DataCart=new DateTime(2017,02,1)};
            Client client2 =    new Client{FirstName="Aleksander",LastName="Petrenko",DataBorn = new DateTime(1994,05,27),NumberPhone=380505667689,EMail="Petrov@gmail.com",NumberCart=7373927382038263,NumberPassport="BB479209",DataCart=new DateTime(2018,06,1)};
            Client client3  =     new Client{FirstName="Pavlo",LastName="Yarmolenko",DataBorn = new DateTime(1992,07,29),NumberPhone=380505167689,EMail="Petrov@gmail.com",NumberCart=7493027384937283,NumberPassport="CC783923",DataCart=new DateTime(2019,05,1)}                    ;             
            Client[] clients = new Client[] { client1, client2,client3 };

            XmlSerializer formatter = new XmlSerializer(typeof(Client[]));
                              
            using (FileStream fs = new FileStream("clients.xml", FileMode.OpenOrCreate))
                {
                    formatter.Serialize(fs, clients);

                    Console.WriteLine("The object have serialized");
                }

            using (FileStream fs = new FileStream("clients.xml", FileMode.OpenOrCreate))
                {
                    Client [] newClients = (Client[])formatter.Deserialize(fs);

                    Console.WindowWidth = 115;
                    Console.WriteLine(new string('-',110));
                    foreach(var item in newClients)
                    {
                        string _databorn = String.Format("{0:D2}.{1:D2}.{2:D4}", item.DataBorn.Day, item.DataBorn.Month, item.DataBorn.Year);
                        string _datacart = String.Format("{0:D2}/{1:D4}", item.DataCart.Month, item.DataCart.Year);
                        string _numbercart = String.Format("{0:####-####-####-####}", item.NumberCart);

                        object[] arg = { item.FirstName, item.LastName, _databorn, item.NumberPhone, _numbercart, _datacart, item.NumberPassport, item.EMail };
                        string str = String.Format(CultureInfo.CurrentCulture, "|{0,12:G}|{1,12:G}|{2,10:F0}|{3,12:F0}|{4,18:F0}|{5,10:G}|{6,8:G}|{7,10:G}", arg);
                        Console.WriteLine(str);
                    }
                }

                      Console.WriteLine(new string('-', 110));                 
                      Console.WriteLine("The object have deserialized");              
                      Console.ReadLine();
            }
        }
}
