using System;

namespace ПочекунLibrary
{
    public sealed class ЄС
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
