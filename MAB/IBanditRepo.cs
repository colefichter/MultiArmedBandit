using System;

namespace MAB
{
    public interface IBanditRepo<T1> where T1 : IAlternative
    {
        IAlternative[] Alternatives { get; }
    }
}
