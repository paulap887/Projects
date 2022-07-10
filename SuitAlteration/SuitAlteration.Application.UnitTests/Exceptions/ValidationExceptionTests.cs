using FluentAssertions;
using FluentValidation.Results;
using NUnit.Framework;
using SuitAlteration.Application.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Application.UnitTests.Exceptions
{
    public class ValidationExceptionTests
    {
        [Test]
        public void DefaultConstructorCreatesAnEmptyErrorDictionary()
        {
            var actual = new ValidationException().Errors;

            actual.Keys.Should().BeEquivalentTo(Array.Empty<string>());
        }

        [Test]
        public void SingleValidationFailureCreatesASingleElementErrorDictionary()
        {
            var failures = new List<ValidationFailure>
            {
                new ValidationFailure("Entity", "should not be null"),
            };

            var actual = new ValidationException(failures).Errors;

            actual.Keys.Should().BeEquivalentTo(new string[] { "Entity" });
            actual["Entity"].Should().BeEquivalentTo(new string[] { "should not be null" });
        }

        [Test]
        public void MulitpleValidationFailureForMultiplePropertiesCreatesAMultipleElementErrorDictionaryEachWithMultipleValues()
        {
            var failures = new List<ValidationFailure>
            {
                new ValidationFailure("Entity", "should not be null"),
                new ValidationFailure("Entity", "should be valid"),
                new ValidationFailure("Remarks", "must be 300 characters in length"), 
                new ValidationFailure("Remarks", "must be minimum 10 characters in length"), 
            };

            var actual = new ValidationException(failures).Errors;

            actual.Keys.Should().BeEquivalentTo(new string[] { "Entity", "Remarks" });

            actual["Entity"].Should().BeEquivalentTo(new string[]
            {
                "should not be null",
                "should be valid",
            });

            actual["Remarks"].Should().BeEquivalentTo(new string[]
            {
                "must be 300 characters in length",
                "must be minimum 10 characters in length" 
            });
        }
    }

}
