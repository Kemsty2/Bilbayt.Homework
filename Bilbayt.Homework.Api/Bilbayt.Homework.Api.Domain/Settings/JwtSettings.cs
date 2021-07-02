namespace Bilbayt.Homework.Api.Domain.Settings
{
    public class JwtSettings
    {
        /// <summary>
        /// Jwt Secret (Must be keep in secure place)
        /// </summary>
        public string Secret { get; set; }

        /// <summary>
        /// Jwt Issuer
        /// </summary>
        public string Issuer { get; set; }

        /// <summary>
        /// Jwt Audience
        /// </summary>
        public string Audience { get; set; }

        /// <summary>
        /// Access token expiration time in millisecond
        /// </summary>
        public int AccessTokenExpiration { get; set; }

        /// <summary>
        /// Refresh token expiration time in millisecond
        /// </summary>
        public int RefreshTokenExpiration { get; set; }
    }
}