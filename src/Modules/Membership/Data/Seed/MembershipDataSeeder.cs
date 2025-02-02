using Shared.Data.Seed;

namespace Membership.Data.Seed;

public class MembershipDataSeeder(MembershipDbContext dbContext) : IDataSeeder
{
    public async Task SeedAllAsync() { }
}
