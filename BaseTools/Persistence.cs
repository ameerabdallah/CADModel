using System;

namespace BaseTools
{
    class Persistence
    {
        public abstract void Save(Writer writer);
        public abstract void Reader(Reader reader);
    }
}
