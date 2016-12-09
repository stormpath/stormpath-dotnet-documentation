PostLoginHandler = async (ctx, ct) =>
{
    ctx.Account.CustomData["lastSeen"] = DateTimeOffset.UtcNow;
    await ctx.Account.SaveAsync(ct);
}
