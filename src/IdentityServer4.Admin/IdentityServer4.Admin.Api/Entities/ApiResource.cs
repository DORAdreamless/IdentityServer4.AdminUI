// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

#pragma warning disable 1591

using System;
using System.Collections.Generic;

namespace IdentityServer4.Admin.Api.Entities
{
    public  class ApiResource
    {
        public virtual  int Id { get; set; }
        public virtual  bool Enabled { get; set; } = true;
        public virtual  string Name { get; set; }
        public virtual  string DisplayName { get; set; }
        public virtual  string Description { get; set; }
        public virtual  List<ApiSecret> Secrets { get; set; }
        public virtual  List<ApiScope> Scopes { get; set; }
        public virtual  List<ApiClaim> UserClaims { get; set; }
        public virtual  List<ApiProperty> Properties { get; set; }
        public virtual  DateTime Created { get; set; } = DateTime.UtcNow;
        public virtual  DateTime? Updated { get; set; }
        public virtual  DateTime? LastAccessed { get; set; }
        public virtual  bool NonEditable { get; set; }
    }
}
