using FluentAssertions;
using NUnit.Framework;
using SuitAlteration.Domain.Common;
using SuitAlteration.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SuitAlteration.Domain.UnitTests
{
    public class AlterationTests 
    {
        [Test]
        public void DefaultConstructorCreatesAnEmptyErrorDictionary()
        {
            var entity = new Alteration();

            entity.Currency.Should().BeEquivalentTo(EntityRules.DefaultCurrency);

            var type = entity.Status.GetType(); 
            type.Should().Be(typeof(Enums.AlterationStatus)); 
        }


    }
}
