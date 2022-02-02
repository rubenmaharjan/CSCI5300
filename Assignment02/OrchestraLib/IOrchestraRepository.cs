using System;
using System.Collections.Generic;

namespace OrchestraLib
{
    public interface IOrchestraRepository
    {
        ICollection<Orchestra> ReadAll();
        Orchestra Read(int id);
        void Create(Orchestra orchestra);
    }
}
