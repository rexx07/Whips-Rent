﻿using Mb.Application.Common.Models;
using Microsoft.AspNetCore.Identity;

namespace Mb.Infrastructure.Identity;

public static class IdentityResultExtension
{
    public static Result ToApplicationResult(this IdentityResult result) =>
        result.Succeeded
            ? Result.Success()
            : Result.Failure(result.Errors.Select(e => e.Description));
}