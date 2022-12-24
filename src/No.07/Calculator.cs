// (c) 2022 Ervin Peters (coder@ervnet.de)

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace No._07
{
    public class Calculator
    {
        private readonly Dir root = new(Path.DirectorySeparatorChar.ToString());

        public Calculator(List<string> data)
        {
            Dir cwd = this.root;
            foreach (string row in data)
            {
                if (row.StartsWith("$ "))
                {
                    List<string> cmdParts = row.Split(" ")
                        .Where(item => !string.IsNullOrWhiteSpace(item))
                        .ToList();

                    switch (cmdParts[1].Trim())
                    {
                        case "cd":
                            cwd = cmdParts[2].Trim() switch
                            {
                                "/" => this.root,
                                ".." => cwd.parent ?? throw new InvalidOperationException("cannot cd .. beyond /"),
                                _ => cwd.getChild(cmdParts[2].Trim())
                            };

                            break;

                        case "ls":
                            cwd.visits++;
                            break;

                        default:
                            throw new InvalidOperationException($"unknown cmd {cmdParts[1]}");
                    }
                }
                else
                {
                    string[] dirItemData = row.Split(" ");
                    if (dirItemData[0] == "dir") // subdir
                    {
                        _ = cwd.getChild(dirItemData[1].Trim());
                    }
                    else
                    {
                        long fileSize = Convert.ToInt64(dirItemData[0].Trim(), CultureInfo.InvariantCulture);
                        if (cwd is null)
                            throw new InvalidOperationException("no cwd to add filesize ??");
                        cwd.addFileSize(fileSize);
                    }
                }
            }
        }

        public long sizeOfDirsWithContentBelow(int maxSizeOfDirContents)
            => this.root.sumSubtreeSizesbelow(maxSizeOfDirContents);

        public long rootDirSize()
            => this.root.sumFileSize();

        public long findSmallestDirAboveSize(long needToFree)
            => this.root.findSmallestDirAboveSize(needToFree);
    }
}