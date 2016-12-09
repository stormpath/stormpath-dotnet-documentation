private Task MyPreResetHandler(
    PreChangePasswordContext context,
    CancellationToken ct)
{
    return Task.FromResult(0);
}
