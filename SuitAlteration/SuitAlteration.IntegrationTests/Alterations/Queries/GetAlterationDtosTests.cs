using NUnit.Framework;
using Testings.Application.IntegrationTests;
using System.Threading.Tasks;
using SuitAlteration.Application.Alterations.Queries;
using SuitAlteration.Domain.Entities;
using FluentAssertions;

namespace Testings.Application.IntegrationTests.Test.Queries;

using static Testing;

public class GetAlterationDtosTests : BaseTestFixture
{

    [Test]
    public async Task ShouldReturnAlterationsByStatus()
    {
        await AddAsync(new Alteration
        {
            CustomerId = 123,
            SalesAssociateId = 75,
            Remarks = "Test Remark",
            Status = SuitAlteration.Domain.Enums.AlterationStatus.Created
        });

        var query = new GetAlterationsQuery()
        {
            Status = SuitAlteration.Domain.Enums.AlterationStatus.Created
        };

        var result = await SendAsync(query);

        result.Items.Should().HaveCount(1);
    }
}
