using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MMTShop.Server.Base
{
    public class ResponseBase
    {
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}
