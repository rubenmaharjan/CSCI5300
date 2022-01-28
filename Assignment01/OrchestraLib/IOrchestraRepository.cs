using System;
using System.Collections.Generic;

namespace OrchestraLib
{
    public interface IOrchestraRepository
    {
        ICollection<Orchestra> ReadAll();
    };
}
