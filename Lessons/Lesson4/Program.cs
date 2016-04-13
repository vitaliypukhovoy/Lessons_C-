using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Text.RegularExpressions;
using System.Globalization;

namespace Lesson3
{
    interface IClient
        {
         string FirstName { get; set; }
         string LastName { get; set; }
         DateTime DataBorn { get; set; }
         long NumberPhone { get; set; }
         string EMail { get; set; }
         string NumberPassport { get; set; }
         DateTime DataCart { get; set; }
         long NumberCart { get; set; }       
    }

    interface ISort
    {
        void SortName(List<Client> client);
        void SortNumberPhone(List<Client> client);
        void SortDataBorn(List<Client> client);
    }

    interface IFinder
    {
        void FindBySubstringFirstName(List<Client> client, string substr, out string finderName);
        void FindBySubstringNumberPhone(List<Client> client, long substr, out string finderNumber);
        void FindBySubstringDataBorn(List<Client> client, string substr, out string finderData);    
    }

    public class Client : IClient, ISort,IFinder
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DataBorn { get; set; }
        public long NumberPhone { get; set; }
        public string EMail { get; set; }
        public string NumberPassport { get; set; }
        public DateTime DataCart { get; set; }
        public long NumberCart { get; set; }
                               
        public void  SortName(List<Client> client)
        {
            client.Sort(new CompareFirstName());
        }
         public void  SortNumberPhone(List<Client> client)
        {
             client.Sort(new CompareNumberPhone());
        }
         public void SortDataBorn(List<Client> client)
        {
            client.Sort(new CompareDataBorn());
        }
          void IFinder.FindBySubstringFirstName(List<Client> client, string substr, out string  finderName)
        {
          finderName =   client.Select(i => i.FirstName)
                .Where(i=>i.Contains(substr))                                
                .FirstOrDefault();                                              
        }
          void IFinder.FindBySubstringNumberPhone(List<Client> client, long substr, out string finderNumber)
         {
             
             var number = from s in client
                          select new
                          {
                              NumberPhone = s.NumberPhone.ToString()
                          };
             finderNumber = number.Where(i => i.NumberPhone.Contains(substr.ToString()))
                  .Select(i => i.NumberPhone)
                  .FirstOrDefault();                 
         }
          void IFinder.FindBySubstringDataBorn(List<Client> client, string substr, out string finderData)
         {

             var number = from s in client
                          select new
                          {
                              DataBorn = s.DataBorn.ToString()
                          };
             finderData = number.Where(i => i.DataBorn.Contains(substr.ToString()))
                   .Select(i => i.DataBorn)
                   .FirstOrDefault();
         }  
    }

    public class CompareFirstName : IComparer<Client> //,IComparer, //We can implement  IComparer too.    
    {
        public int Compare(Client a, Client b)
        {
            if (string.Compare(a.FirstName, b.FirstName) == 0)
                return 0;
            if (string.Compare(a.FirstName, b.FirstName) == -1)
                return -1;
            else
                return 1;  
        }
        //int IComparer.Compare(object a, object b)
        //{
        //    return Compare((Student)a, (Student)b);
        //}        
    }

    public class CompareNumberPhone : IComparer<Client>
    {
        public int Compare(Client a, Client b)
        {
            if (a.NumberPhone > b.NumberPhone)
                return 1;
            if (a.NumberPhone < b.NumberPhone)
                return -1;
            else
                return 0;
        }
    }

    public class CompareDataBorn : IComparer<Client>
    {
        public int Compare(Client a, Client b)
        {
            if (a.DataBorn > b.DataBorn)
                return 1;
            if (a.DataBorn < b.DataBorn)
                return -1;
            else
                return 0;
        }
    }

    public static class  FindFile
    {
       static string path = @"C:\Windows\System32";
       static string patern = "c*";  //key words       
       static public void GetFiles()                  
        { 
         try
           {
              string[] files = Directory.GetFiles(path, patern);
              foreach(var f in files)
              {
               Console.WriteLine("{0}",f);
               }
           }
         catch(Exception e)
           {
               Console.WriteLine(" The process filed {0}", e.ToString());
           
           }
        }                   
    }

    class Program
    {

        public static Regex reg1 = new Regex(@"^\+?380\s\d{2}\s\d{3}\s\d{2}\s\d{2}$");
        public static Regex reg2 = new Regex(@"^[A-Z,a-z]{2}\s\d{6}$");
        //string patern = @"^\+?[0-9]{3}-\d{2}-\d{3}-\d{2}-\d{2}"; 
        static public List<Client> ls = new List<Client>(){
            new Client{FirstName="Sergey",LastName="Pavlichenko",DataBorn = new DateTime(1991,02,24),NumberPhone=380505600789,EMail="Ivanov@gmail.com",NumberCart=1234356235626372,NumberPassport="AA362739",DataCart=new DateTime(2017,02,1)},
            new Client{FirstName="Aleksander",LastName="Petrenko",DataBorn = new DateTime(1994,05,27),NumberPhone=380505667689,EMail="Petrov@gmail.com",NumberCart=7373927382038263,NumberPassport="BB479209",DataCart=new DateTime(2018,06,1)},
            new Client{FirstName="Pavlo",LastName="Yarmolenko",DataBorn = new DateTime(1992,07,29),NumberPhone=380505167689,EMail="Petrov@gmail.com",NumberCart=7493027384937283,NumberPassport="CC783923",DataCart=new DateTime(2019,05,1)}                                 
           };

        static void Main(string[] args)
        {
            //FindFile.GetFiles();

            List<Client> ls = new  List<Client>(){
            new Client{FirstName="Sergey",LastName="Pavlichenko",DataBorn = new DateTime(1991,02,24),NumberPhone=380505600789,EMail="Ivanov@gmail.com",NumberCart=1234356235626372,NumberPassport="AA362739",DataCart=new DateTime(2017,02,1)},
            new Client{FirstName="Aleksander",LastName="Petrenko",DataBorn = new DateTime(1994,05,27),NumberPhone=380505667689,EMail="Petrov@gmail.com",NumberCart=7373927382038263,NumberPassport="BB479209",DataCart=new DateTime(2018,06,1)},
            new Client{FirstName="Pavlo",LastName="Yarmolenko",DataBorn = new DateTime(1992,07,29),NumberPhone=380505167689,EMail="Petrov@gmail.com",NumberCart=7493027384937283,NumberPassport="CC783923",DataCart=new DateTime(2019,05,1)}                                 
           };

            Client client = new Client();

            ISort clientSort = client;
            clientSort.SortName(ls);
           // clientSort.SortNumberPhone(ls);
           // clientSort.SortDataBorn(ls);

            
            IFinder clientFinder = client;
            string finderName = "", finderNumber = "", finderData = "";
            clientFinder.FindBySubstringFirstName(ls, "ek", out finderName);
            clientFinder.FindBySubstringNumberPhone(ls, 016, out finderNumber);
            clientFinder.FindBySubstringDataBorn(ls, "29",out finderData);


            //====Output===========================================================
            Console.WindowWidth = 115;
            string head = String.Format(CultureInfo.CurrentCulture,"|{0,12:G}|{1,12:G}|{2,10:F0}|{3,12:F0}|{4,18:F0}|{5,10:F0}|{6,8:G}|{7,10:G}", "Имя", "Фамилия", "Дата рожд.", "Телефон", "Ном.карты", "Дата карт.", "№пасп.", "e-mail");
            Console.WriteLine(head);

            Console.WriteLine(new string('-', 110));
            foreach (var s in ls)
            {
                string _databorn = String.Format("{0:D2}.{1:D2}.{2:D4}", s.DataBorn.Day, s.DataBorn.Month, s.DataBorn.Year);
                string _datacart = String.Format("{0:D2}/{1:D4}", s.DataCart.Month, s.DataCart.Year);  
                string _numbercart = String.Format("{0:####-####-####-####}",s.NumberCart);

                object[] arg = { s.FirstName, s.LastName, _databorn, s.NumberPhone, _numbercart, _datacart, s.NumberPassport, s.EMail };
                string str = String.Format(CultureInfo.CurrentCulture, "|{0,12:G}|{1,12:G}|{2,10:F0}|{3,12:F0}|{4,18:F0}|{5,10:G}|{6,8:G}|{7,10:G}",arg );
                Console.WriteLine(str);
            }
            
            Console.WriteLine(new string('-', 110));
            Console.WriteLine("  The FirstName found  - {0}", finderName);
            Console.WriteLine("  The NumberPhone found  - {0}", finderNumber);
            Console.WriteLine("  The DataBorn found  - {0}", finderData);
            Console.WriteLine(new string('-', 70));
            RegexMethod(reg1,reg2);
        }

 
        public static void RegexMethod(Regex reg1, Regex reg2)
        {
            Console.WriteLine("Please, Enter you phone in format +380 xx xxx xx xx!");
                               

            while (true)
            {
                string input1 = Console.ReadLine();
                if (reg1.IsMatch(input1))
                {

                    Console.WriteLine("Please, Enter you passport  ID!");
                    while (true)
                    {
                        string input2 = Console.ReadLine();

                        if (reg2.IsMatch(input2))
                        {
                            Console.WriteLine("Thank you");
                            break;
                        }
                        else
                            Console.WriteLine("Please, Enter correct you passport  ID in format AA XXXXXX!");
                    }
                    break;
                }
                else
                    Console.WriteLine("Please, Enter correct cell phone in format +380 XX XXX XX XX !");
            }

        }
    }
}


