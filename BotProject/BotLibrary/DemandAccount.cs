using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BotProject
{
    public class DemandAccount : Account
    {
        public DemandAccount(decimal sum, int percentage) : base(sum, percentage)
        {
        }
        protected internal override void Open()
        {
            base.OnOpened(new AccountEventArgs("Now you have new raxunok! Id raxunok: " + this._id, this._sum));
            //переопределяем данный метод
        }
    }
}
