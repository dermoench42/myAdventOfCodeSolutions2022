// (c) 2022 Ervin Peters (coder@ervnet.de)

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
        public int visits;

        public Dir(string path, Dir? parent = null)
        {
            this.path = path;
            this.parent = parent;
        }

        public void addFileSize(long fSize)
        {
            if (this.visits < 2)
                this.fileSize += fSize;
        }

        public long sumFileSize()
        {
            long size = this.fileSize + this.children.ConvertAll(child => child.sumFileSize()).Sum();
            return size;
        }

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
        {
            long mySize = this.sumFileSize();
            long sumChildFileSizes = this.children.ConvertAll(child => child.sumSubtreeSizesbelow(maxSizeOfDirContents))
                .Sum();

            return mySize <= maxSizeOfDirContents ? sumChildFileSizes + mySize : sumChildFileSizes;
        }

        public long findSmallestDirAboveSize(long needToFree)
        {
            long result = this.sumFileSize();
            return result < needToFree
                ? -1
                : this.children.Select(child => child.findSmallestDirAboveSize(needToFree))
                    .Where(size => size > 0)
                    .Prepend(result).Min();
        }
    }
}