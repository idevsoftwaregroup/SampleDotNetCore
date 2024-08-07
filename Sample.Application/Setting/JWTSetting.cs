﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Application.Setting
{
    public class JWTSettings
    {
        public const string SECTION_NAME = nameof(JWTSettings);

        public string Secret { get; init; } = null!;
        public string EncryptionKey { get; set; } = null!;
        public int ExpiryMinutes { get; init; }
        public string Issuer { get; init; } = null!;
        public string Audience { get; init; } = null!;
    }
}
