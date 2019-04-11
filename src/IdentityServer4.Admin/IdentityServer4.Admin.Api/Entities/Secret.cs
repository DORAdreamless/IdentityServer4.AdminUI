// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


#pragma warning disable 1591

using System;

namespace IdentityServer4.Admin.Api.Entities
{
    public abstract class Secret
    {
        public virtual int Id { get; set; }
        public virtual string Description { get; set; }
        public virtual string Value { get; set; }
        public virtual DateTime? Expiration { get; set; }
        public virtual string Type { get; set; } = "SharedSecret";
        public virtual DateTime Created { get; set; } = DateTime.UtcNow;
    }
}