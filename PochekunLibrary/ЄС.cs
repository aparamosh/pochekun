using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ПочекунLibrary
{
    public class ЄС
    {
        private static readonly Lazy<ЄС> lazy =
             new Lazy<ЄС>(() => new ЄС());
        public static ЄС Instance { get { return lazy.Value; } }

        private ЄС()
        {
        }

        private БезвізовийРежим безвізовийРежим = null;
        public bool ЧиДатиБезвізовийРежимДляУкраїни()
        {
            return РакНаГорі.Instance.Свиснув;
        }

        public БезвізовийРежим БезвізовийРежимДляУкраїни
        {
            get
            {
                if ((безвізовийРежим == null) && ЧиДатиБезвізовийРежимДляУкраїни())
                {
                    безвізовийРежим = new БезвізовийРежим();
                }
                return безвізовийРежим;
            }
        }
    }
}
