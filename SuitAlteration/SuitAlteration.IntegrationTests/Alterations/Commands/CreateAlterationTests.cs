using SuitAlteration.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;
using SuitAlteration.Application.Alterations.Commands;
using System.Collections.Generic;
using System;
using SuitAlteration.Application.Common.Exceptions;

namespace Testings.Application.IntegrationTests.Test.Commands;  

using static Testing;

public class CreateAlterationTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new CreateNewAlterationCommand();

        var result = await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test] 
    public async Task ShouldCreateAlteration()
    {
        var command = new CreateNewAlterationCommand
        {
            CustomerId = 123,
            SalesAssociateId = 75,
            AlterationDetails = new List<AlterationDetails>()
            {
                new AlterationDetails()
                {
                    SuitPieceType = SuitAlteration.Domain.Enums.SuitPieceType.Jacket,
                    AdjustmentInCms = -4,
                    SuitPieceTypeSide = SuitAlteration.Domain.Enums.SuitPieceTypeSide.Left
                }
            },
            Remarks = "Test Remark"
        };

        var itemId = await SendAsync(command);

        var item = await FindAsync<Alteration>(itemId);

        item.Should().NotBeNull();

        item.CustomerId.Should().Be(command.CustomerId);
        item.SalesAssociateId.Should().Be(command.SalesAssociateId);
        item.Remarks.Should().Be(command.Remarks);
        item.Created.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromMilliseconds(10000));
        item.LastModified.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromMilliseconds(10000));
    }
}
