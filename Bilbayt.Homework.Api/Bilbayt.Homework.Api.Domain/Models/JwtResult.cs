﻿namespace Bilbayt.Homework.Api.Domain.Models
{
    public class JwtResult
    {
        public string AccessToken { get; set; }
        public RefreshToken RefreshToken { get; set; }
    }
}