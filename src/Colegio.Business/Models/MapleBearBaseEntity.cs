﻿namespace Colegio.Business.Models
{
    public abstract class ColegioBaseEntity
    {
        public ColegioBaseEntity()
        {
            Id = Guid.NewGuid();
            Ativo = true;
        }

        public Guid Id { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime UpdatedDateTime { get; set; }
        public string? UpdatedBy { get; set; }
        public bool Ativo { get; set; }
    }
}
