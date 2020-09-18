using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StrawmanAtc.Models
{
    public struct Observation<TData>
    {
        public Observation(Spacetime spacetime, TData data)
        {
            Spacetime = spacetime;
            Data = data;
        }

        public Spacetime Spacetime { get; }
        public TData Data { get; }
    }
}
