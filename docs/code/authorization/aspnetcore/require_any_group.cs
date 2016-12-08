services.AddAuthorization(opt =>
{
    opt.AddPolicy("PayingMembersOnly", policy => policy.AddRequirements(
        new StormpathGroupsRequirement("subscriber", "partner")));
});
