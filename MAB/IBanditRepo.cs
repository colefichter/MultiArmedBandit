using System;

namespace MAB
{
    public interface IBanditRepo<T1>
    {
        IAlternative[] Alternatives { get; }
    }
}
