﻿using FluentValidation.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ordering.Application.Exceptions
{
    internal class ValidationException
    : ApplicationException
    {
        public IDictionary<string, string[]> Errors { get; }
        public ValidationException() : base("one or more validation error have occurred.")
        {

        }
        public ValidationException(IEnumerable<ValidationFailure> failures) : this()
        {
            Errors = failures.GroupBy(e => e.PropertyName, e => e.ErrorMessage).ToDictionary(fg => fg.Key, fg => fg.ToArray());
        }
    }
}
