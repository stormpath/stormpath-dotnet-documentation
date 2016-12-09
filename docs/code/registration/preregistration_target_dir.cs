PreRegistrationHandler = async (ctx, ct) =>
{
    ctx.AccountStore = await ctx.Client.GetDirectoryAsync(
        "https://api.stormpath.com/v1/directories/xxx", ct);
}
