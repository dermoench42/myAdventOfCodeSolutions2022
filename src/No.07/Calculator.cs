// (c) 2022 QSOFT Development

using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

namespace No._07
{
    public class Calculator
    {
        private Dir root = new(Path.DirectorySeparatorChar.ToString());

        public Calculator(List<string> data)
        {
            Dir cwd = this.root;
            Dir? dirDir = null;
            foreach (string row in data)
            {
                if (row.StartsWith("$ "))
                {
                    List<string> cmdParts = row.Split(" ")
                        .Where(item => !string.IsNullOrWhiteSpace(item))
                        .ToList();

                    switch (cmdParts[1])
                    {
                        case "cd":
                            switch (cmdParts[2])
                            {
                                case "/":
                                    cwd = this.root;
                                    break;
                                case "..":
                                    cwd = cwd.parent ?? throw new InvalidOperationException("cannot cd .. beyond /");
                                    break;
                                case ".":
                                    break;
                                default:
                                    cwd = cwd.getChild(cmdParts[2].Trim());
                                    break;
                            }

                            break;

                        case "ls":
                            dirDir = cmdParts.Count > 2 ? cwd.getChild(cmdParts[3].Trim()) : null;
                            break;

                        default:
                            throw new InvalidOperationException($"unknown cmd {cmdParts[1]}");
                    }
                }
                else
                {
                    string[] dirItemData = row.Split(" ");
                    if (dirItemData[0] == "dir")
                    {
                        // ?
                    }
                    else
                    {
                        long fileSize = Convert.ToInt64(dirItemData[0].Trim(), CultureInfo.InvariantCulture);
                        if (cwd is null)
                            throw new InvalidOperationException("no cwd to add filesize ??");
                        (dirDir ?? cwd).addFileSize(fileSize);
                    }
                }
            }
        }

        public long sizeOfDirsWithContentBelow(int maxSizeOfDirContents)
            => this.root.sumSubtreeSizesbelow(maxSizeOfDirContents);
    }
}