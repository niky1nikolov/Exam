using System;
using System.Collections.Generic;
using System.Linq;

namespace FilesObject
{
    class Program
    {
        class File
        {
            public File(string root, string name, ulong size)
            {
                Root = root;
                Name = name;
                Size = size;
            }

            public string Root { get; set; }
            public string Name { get; set; }
            public ulong Size { get; set; }
        }


        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, List<File>> roodFile = new Dictionary<string, List<File>>();
           

            while (n != 0)
            {
                string[] input = Console.ReadLine().Split(new char[] { '\\', ';' }).ToArray();

                string root = input[0];
                string fileName = input[input.Length - 2];
                ulong fileSize = ulong.Parse(input[input.Length - 1]);

                File filePart = new File(root, fileName, fileSize);

                if (!roodFile.ContainsKey(root))
                {
                    List<File> curent = new List<File>() { filePart };
                    roodFile.Add(root, curent);
                }
                else
                {
                    roodFile[root].Add(filePart);
                }
                
                                
                n--;
            }

            if (roodFile.ContainsKey(roo))
            {

            }

            string[] queryFile = Console.ReadLine().Split().ToArray();
            string queryRoot = queryFile[2];
            string qeryExtension = queryFile[0];

            if (!roodFile.ContainsKey(queryRoot))
            {
                Console.WriteLine("No");
                return;
            }

            bool search = true;

            foreach (var kvp in roodFile)
            {
                if (kvp.Key == queryRoot)
                {
                    foreach (var file in kvp.Value.OrderByDescending(x => x.Size).ThenBy(y => y.Name).Where(r => r.Name.EndsWith(qeryExtension)))
                    {
                        Console.WriteLine($"{file.Name} - {file.Size} KB ");
                        search = false;
                    }
                }
            }
            if (search)
            {
                Console.WriteLine("No");
            }
            
        }
    }
}
