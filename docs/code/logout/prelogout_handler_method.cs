private Task MyPreLogoutHandler(
    PreLogoutContext context,
    CancellationToken ct)
{
    return Task.FromResult(0);
}
