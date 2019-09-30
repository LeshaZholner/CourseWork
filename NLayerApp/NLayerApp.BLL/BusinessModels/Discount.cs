using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NLayerApp.BLL.BusinessModels
{
    public class Discount
    {
        private decimal _value = 0;
        public decimal Value { get { return _value; } }

        public decimal getDiscountPrice(decimal sum)
        {
            return sum - sum * _value;
        }

        public Discount(decimal val)
        {
            _value = val;
        }
    }
}
