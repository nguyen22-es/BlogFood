﻿using DataAccess.Data.Entities;
using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;

namespace DataAccess.Data.Entities;

public partial class LikePost
{
    public string? LikePostId { get; set; }

    public string? PostId { get; set; }

    public string? UserId { get; set; }

    public virtual Post? Post { get; set; }

    public virtual ManageUser? User { get; set; }
}
