using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ПочекунLibrary
{
    public class Україна
    {
        private static readonly Lazy<Україна> lazy =
            new Lazy<Україна>(() => new Україна());
        public static Україна Instance { get { return lazy.Value; } }

        private Україна()
        {
        }

        public БезвізовийРежим ОтриматиБезвізовийРежим()
        {
            return ЄС.Instance.БезвізовийРежимДляУкраїни;
        }

        public async Task<БезвізовийРежим> ПочекатиБезвізовийРежим()
        {
            return await new Func<БезвізовийРежим>(() => {
                //спробувати
                var безвізовийРежим = ОтриматиБезвізовийРежим();
                //якщо спіткала невдача
                while (безвізовийРежим == null)
                {
                    //#зрада
                    //почекати ще трошки
                    Thread.Sleep(1000);
                    //спробувати ще раз
                    безвізовийРежим = ОтриматиБезвізовийРежим();
                }
                //#перемога
                return безвізовийРежим;
            });
        }
    }
}
