using System;
using System.Collections.Generic;
using System.Text;

namespace UserCrud.Infrastructure.Options
{
    public sealed class DatabaseOptions
    {
        public const string SectionName = "Database";

        public string ConnectionString { get; set; } = string.Empty;
    }
}
