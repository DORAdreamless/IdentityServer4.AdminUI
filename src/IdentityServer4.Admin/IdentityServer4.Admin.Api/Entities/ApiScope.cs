﻿// Copyright (c) Brock Allen & Dominick Baier. All rights reserved.
// Licensed under the Apache License, Version 2.0. See LICENSE in the project root for license information.

#pragma warning disable 1591

using System.Collections.Generic;

namespace IdentityServer4.Admin.Api.Entities
{
    public  class ApiScope
    {
        public virtual  int Id { get; set; }
        public virtual  string Name { get; set; }
        public virtual  string DisplayName { get; set; }
        public virtual  string Description { get; set; }
        public virtual  bool Required { get; set; }
        public virtual  bool Emphasize { get; set; }
        public virtual  bool ShowInDiscoveryDocument { get; set; } = true;
        public virtual  List<ApiScopeClaim> UserClaims { get; set; }

        public virtual  int ApiResourceId { get; set; }
        public virtual  ApiResource ApiResource { get; set; }
    }
}