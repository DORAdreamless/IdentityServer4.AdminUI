﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


#pragma warning disable 1591

namespace IdentityServer4.Admin.Api.Entities
{
    public abstract class UserClaim
    {
        public virtual int Id { get; set; }
        public virtual string Type { get; set; }
    }
}