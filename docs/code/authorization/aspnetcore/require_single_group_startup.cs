services.AddAuthorization(opt =>
{
    opt.AddPolicy("AdminOnly", policy => policy.AddRequirements(
        new StormpathGroupsRequirement("admin")));
});
