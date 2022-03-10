using System;
using System.Collections.Generic;

namespace OrchestraLib
{
    public interface IOrchestraRepository
    {
        ICollection<Orchestra> ReadAll();
        Orchestra Read(int id);
        void Create(Orchestra orchestra);
        void Update(Orchestra orchestra);
        void Delete(int id);
        int CreateAndGetId(Orchestra orchestra);
    }
}
