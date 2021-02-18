using Bookstore.Application.Configuration.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bookstore.Application.Orders.ChangeOrderStatus
{
    public class ChangeOrderStatusCommand : ICommand
    {
        public int Id { get; set; }
        public int Status { get; set; }
    }
}
