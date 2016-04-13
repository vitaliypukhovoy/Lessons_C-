using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Lesson3._2
{
    class Program
    {
        static void Main(string[] args)
        {
            CreateDirectories();
            MovetoDir2();
            MovetoDir2File();
        }


        public static void MovetoDir2File()
        {


            string fileName = "Text.txt";
            string targetPath = @"c:\temp\Dir2\Dir1";
            string sourcePath = Directory.GetParent(Directory.GetCurrentDirectory()).Parent.FullName;

            string sourceFile = Path.Combine(sourcePath, fileName);
            string destFile = Path.Combine(targetPath, fileName);


            if (Directory.Exists(targetPath))
            {
                File.Copy(sourceFile, destFile, true);
                File.SetAttributes(sourcePath, FileAttributes.Normal);

                string[] files = Directory.GetFiles(targetPath);
                foreach (var f in files)
                {
                    Console.WriteLine(f);
                
                }

                Console.WriteLine("File {0} have added", fileName);
            
            }
        
        }
        public static void MovetoDir2()
        {
            string path1 = @"c:\temp\Dir1";
            string path2 = @"c:\temp\Dir2\Dir1";
            try
            {

           if(Directory.Exists(path1)  && !Directory.Exists(path2))
            
            Directory.Move(path1,path2);
            Console.WriteLine("Directory Dir1 have moved to Dir2 ");
            }
            catch(Exception e)
            {
                Console.WriteLine("Sorry the  process failed ", e.ToString());
                Console.ReadKey();
            }
        }

        public static void CreateDirectories()
        {
            string path1 = @"c:\\temp\\Dir1";
            string path2 = @"c:\\temp\\Dir2";
            try
            {
                if (!Directory.Exists(path1) && !Directory.Exists(path2))
                {
                    DirectoryInfo dir1 = Directory.CreateDirectory(path1);
                    DirectoryInfo dir2 = Directory.CreateDirectory(path2);
                    dir1.Create();
                    dir2.Create();
                    Console.WriteLine("Directory Dir1 and Dir2 were added");
                }
                else
                {
                    Console.WriteLine("Directory Dir1 and Dir2 exists already");
                
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Sorry the  process failed ", e.ToString());
            }
    
    
       }
    }
}
