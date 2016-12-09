private Task MyPostResetHandler(
    PostChangePasswordContext context,
    CancellationToken ct)
{
    return Task.FromResult(0);
}
