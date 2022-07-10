using NUnit.Framework;
using System.Threading.Tasks;

namespace Testings.Application.IntegrationTests; 

using static Testing;

[TestFixture]
public abstract class BaseTestFixture
{
    [SetUp]
    public async Task TestSetUp()
    {
        await ResetState();
    }
}
