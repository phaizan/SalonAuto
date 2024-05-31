﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace SalonAuto.Features.DtoModels.Center
{
    public sealed record CenterDto
    {
        [Key]
        public Guid IsnNode { get; init; }

        [Required, MaxLength(20)]
        public string Code { get; init; }

        [Required, MaxLength(255)]
        public string Name { get; init; }
    }
}
