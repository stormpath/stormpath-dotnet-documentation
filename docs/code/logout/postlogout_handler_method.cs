private Task MyPostLogoutHandler(
    PostLogoutContext context,
    CancellationToken ct)
{
    return Task.FromResult(0);
}
