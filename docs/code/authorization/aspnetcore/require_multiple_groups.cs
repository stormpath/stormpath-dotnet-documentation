services.AddAuthorization(opt =>
{
    opt.AddPolicy("AdminManagers", policy => policy
        .AddRequirements(new StormpathGroupsRequirement("admin"))
        .AddRequirements(new StormpathGroupsRequirement("manager")));
});
