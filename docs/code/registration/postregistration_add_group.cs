PostRegistrationHandler = async (ctx, ct) =>
{
    await ctx.Account.AddGroupAsync("rebels", ct);
}
