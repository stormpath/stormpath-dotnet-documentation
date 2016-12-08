services.AddAuthorization(opt =>
{
    opt.AddPolicy("CanPost", policy => policy.AddRequirements(
        new StormpathCustomDataRequirement("canPost", true)));
});
