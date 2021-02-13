using FluentValidation.Results;
using System.Collections.Generic;

namespace MMTShop.Shared.Base
{
    public class ResponseBase
    {
        public IEnumerable<ValidationFailure> Errors { get; set; }
    }
}
