services.AddAuthorization(opt =>
{
    opt.AddPolicy("CanPostStickies", policy => policy
        .AddRequirements(new StormpathCustomDataRequirement("canPost", true))
        .AddRequirements(new StormpathCustomDataRequirement("userType", "admin")));
});
