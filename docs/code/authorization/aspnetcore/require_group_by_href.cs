services.AddAuthorization(opt =>
{
    opt.AddPolicy("PayingMembersOnly", policy => policy.AddRequirements(
        new StormpathGroupsRequirement("https://api.stormpath.com/v1/groups/aRaNdOmGrOuPiDhEre")));
});
