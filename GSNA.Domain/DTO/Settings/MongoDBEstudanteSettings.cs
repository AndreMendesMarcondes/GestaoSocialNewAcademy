﻿namespace GSNA.Domain.DTO.Settings
{
    public class MongoDBEstudanteSettings
    {
        public string ConnectionString { get; set; } = null!;
        public string DatabaseName { get; set; } = null!;
        public string CollectionName { get; set; } = null!;
    }
}