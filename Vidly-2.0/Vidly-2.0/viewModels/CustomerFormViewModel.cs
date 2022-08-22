using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly_2._0.Models;

namespace Vidly_2._0.viewModels
{
    public class CustomerFormViewModel
    {
        public IEnumerable<MembershipType> MembershipTypes { get; set; }
        public Customer Customer { get; set; }
    }
}