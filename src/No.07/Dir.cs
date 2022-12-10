// (c) 2022 QSOFT Development

using System.Collections.Generic;
using System.Linq;

namespace No._07
{
    public class Dir
    {
        private readonly string path;
        public readonly Dir? parent;
        private long fileSize;
        private readonly List<Dir> children = new();

        public Dir(string path, Dir? parent = null)
        {
            this.path = path;
            this.parent = parent;
        }

        public void addFileSize(long fSize)
            => this.fileSize += fSize;

        public long subTreeFileSize()
            => this.fileSize + this.children.ConvertAll(child => child.subTreeFileSize()).Sum();

        public Dir getChild(string childPath)
        {
            Dir? dir = this.children.FirstOrDefault(child => child.path == childPath);
            if (dir is not null)
                return dir;

            dir = new Dir(childPath, this);
            this.children.Add(dir);

            return dir;
        }

        public long sumSubtreeSizesbelow(int maxSizeOfDirContents)
            => this.children.ConvertAll(child => child.sumSubtreeSizesbelow(maxSizeOfDirContents)).Sum();
    }
}