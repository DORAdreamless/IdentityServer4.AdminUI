﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

#pragma warning disable 1591

namespace IdentityServer4.Admin.Api.Entities
{
    public class ApiClaim : UserClaim
    {
        public virtual int ApiResourceId { get; set; }
        public virtual ApiResource ApiResource { get; set; }
    }
}