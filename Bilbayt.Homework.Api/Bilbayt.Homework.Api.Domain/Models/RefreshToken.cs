using System;

namespace Bilbayt.Homework.Api.Domain.Models
{
    public class RefreshToken
    {
        /// <summary>
        /// Username of the autheticated user
        /// </summary>
        public string UserName { get; set; }

        /// <summary>
        /// Refresh token
        /// </summary>
        public string TokenString { get; set; }

        /// <summary>
        /// Expiration Datetime of the refresh token
        /// </summary>
        public DateTime ExpiredAt { get; set; }
    }
}