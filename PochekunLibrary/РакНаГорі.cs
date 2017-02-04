using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПочекунLibrary
{
    public sealed class РакНаГорі
    {
        private static readonly Lazy<РакНаГорі> lazy =
            new Lazy<РакНаГорі>(() => new РакНаГорі());
        public static РакНаГорі Instance { get { return lazy.Value; } }

        private РакНаГорі()
        {
        }

        public bool Свиснув { get { return false; } }
    }
}
