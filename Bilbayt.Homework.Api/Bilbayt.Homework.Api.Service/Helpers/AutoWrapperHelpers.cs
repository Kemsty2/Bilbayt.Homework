using System.Collections.Generic;
using System.Linq;
using FluentValidation.Results;

namespace Bilbayt.Homework.Api.Service.Helpers
{
    public static class AutoWrapperHelpers
    {
        public static Dictionary<string, string[]> GetValidationsFailures(this IEnumerable<ValidationFailure> failures)
        {
            var result = new Dictionary<string, string[]>();
            var validationFailures = failures.ToList();
            var propertyNames = validationFailures
                .Select(e => e.PropertyName)
                .Distinct();

            foreach (var propertyName in propertyNames)
            {
                var propertyFailures = validationFailures
                    .Where(e => e.PropertyName == propertyName)
                    .Select(e => e.ErrorMessage)
                    .ToArray();

                result.Add(propertyName, propertyFailures);
            }

            return result;
        }
    }
}