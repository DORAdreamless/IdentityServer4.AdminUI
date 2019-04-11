// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.


#pragma warning disable 1591

using System;
using System.Collections.Generic;

namespace IdentityServer4.Admin.Api.Entities
{
    public  class IdentityResource
    {
        public virtual  int Id { get; set; }
        public virtual  bool Enabled { get; set; } = true;
        public virtual  string Name { get; set; }
        public virtual  string DisplayName { get; set; }
        public virtual  string Description { get; set; }
        public virtual  bool Required { get; set; }
        public virtual  bool Emphasize { get; set; }
        public virtual  bool ShowInDiscoveryDocument { get; set; } = true;
        public virtual  List<IdentityClaim> UserClaims { get; set; }
        public virtual  List<IdentityResourceProperty> Properties { get; set; }
        public virtual  DateTime Created { get; set; } = DateTime.UtcNow;
        public virtual  DateTime? Updated { get; set; }
        public virtual  bool NonEditable { get; set; }
    }
}
