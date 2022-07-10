using SuitAlteration.Domain.Entities;
using FluentAssertions;
using NUnit.Framework;
using System.Threading.Tasks;
using SuitAlteration.Application.Alterations.Commands;
using System.Collections.Generic;
using System;
using SuitAlteration.Application.Common.Exceptions;
using SuitAlteration.Domain.Exceptions;
using SuitAlteration.Application.Alterations_Payment;

namespace Testings.Application.IntegrationTests.Test.Commands;  

using static Testing;

public class StartPaidAlterationTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireMinimumFields()
    {
        var command = new StartPaidAlterationCommand();

        var result = await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<ValidationException>();
    }

    [Test]
    public async Task ShouldThrowNotFoundExceptionForInvalidAlterationId() 
    {
        var command = new StartPaidAlterationCommand()
        {
            AlterationId = Int32.MaxValue
        };

        var result = await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }


    [Test]
    public async Task ShouldThrowErrorFor_StartAlteration_ForUnPaid()
    {
        CreateNewAlterationCommand command = GenerateNewAlteration();

        var itemId = await SendAsync(command);

        // Start Alteration
        var startCommand = new StartPaidAlterationCommand
        {
            AlterationId = itemId
        };

        // Throw for Not Able to start it 
        var result = await FluentActions.Invoking(() =>
          SendAsync(startCommand)).Should().ThrowAsync<CantStartUnpaidAlterationException>();

    }
     
    [Test]
    public async Task ShouldStartAlteration()
    {
        CreateNewAlterationCommand command = GenerateNewAlteration();

        var itemId = await SendAsync(command);

        // Pay Alteration 
        var payCommand = new CollectPaymentCommand()
        {
            Amount = 50,
            EntityId = itemId,
            EntityType = SuitAlteration.Domain.Enums.PaymentCollectionEntityType.Alterations
        };

        itemId = await SendAsync(payCommand);

        // Start Alteration
        var startCommand = new StartPaidAlterationCommand
        {
            AlterationId = itemId
        };
        itemId = await SendAsync(startCommand); 

        var item = await FindAsync<Alteration>(itemId);

        item.Should().NotBeNull();

        item.Status.Should().Be(SuitAlteration.Domain.Enums.AlterationStatus.Started);
        item.Created.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromMilliseconds(10000));
        item.LastModified.Should().BeCloseTo(DateTime.UtcNow, TimeSpan.FromMilliseconds(10000));
    }

    #region Private Methods

    private static CreateNewAlterationCommand GenerateNewAlteration()
    {
        return new CreateNewAlterationCommand
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
    }

    #endregion
}
