using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace CopyFile
{
    class Program
    {
        static void Main(string[] args)
        {
            string sourceDir = @"D:\Source_Code\CopyFile\CopyFile\bin\Debug\1";
            string targetDir = @"D:\Source_Code\CopyFile\CopyFile\bin\Debug\2";
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case "-s":
                        sourceDir = args[i + 1];
                        break;
                    case "-t":
                        targetDir = args[i + 1];
                        break;
                }
            }
            Console.WriteLine("source directory: " + sourceDir);
            Console.WriteLine("target directory: " + targetDir);
            Copy(sourceDir, targetDir);
            Console.WriteLine();
            Console.WriteLine("Done successfully!");
        }
        public static void Copy(string s,string t)
        {
            DirectoryInfo sourceDirInfo = new System.IO.DirectoryInfo(s);
            DirectoryInfo[] sourceNextFolders=sourceDirInfo.GetDirectories();
            DirectoryInfo targetDirInfo = new System.IO.DirectoryInfo(t);
            DirectoryInfo[] targetNextFolders=targetDirInfo.GetDirectories();
            foreach (DirectoryInfo nextsourceFolder in sourceNextFolders)
            {
                string targetFolder = "";
                foreach (DirectoryInfo nextTargetFolder in targetNextFolders)
                {
                    if (nextsourceFolder.Name == nextTargetFolder.Name)
                        targetFolder = nextTargetFolder.FullName;
                }

                FileInfo[] sourceFileInfo = nextsourceFolder.GetFiles();
                foreach (FileInfo nextFile in sourceFileInfo)
                {
                    if (targetFolder != "")
                        nextFile.CopyTo(targetFolder+"\\"+nextFile.Name,true);
                }
            }
        }
    }
}
