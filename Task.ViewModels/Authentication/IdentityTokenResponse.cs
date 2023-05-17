namespace TaskManage.ViewModels
{
    public class IdentityTokenResponse
    {
        /// <summary>
        ///  Gets the access token.
        /// </summary>
        public string AccessToken { get; set; }

        /// <summary>
        /// Gets the identity token.
        /// </summary>
        public string IdentityToken { get; set; }

        /// <summary>
        ///  Gets the scope.
        /// </summary>
        public string Scope { get; set; }

        /// <summary>
        /// The issued token type
        /// </summary>
        public string IssuedTokenType { get; set; }

        /// <summary>
        /// The type of the token.
        /// </summary>
        public string TokenType { get; set; }

        /// <summary>
        /// The refresh token.
        /// </summary>
        public string RefreshToken { get; set; }

        /// <summary>
        /// The error description.
        /// </summary>
        public string ErrorDescription { get; set; }

        /// <summary>
        /// The expires in.
        /// </summary>
        public int ExpiresIn { get; set; }

        /// <summary>
        /// error status
        /// </summary>
        public bool IsError { get; set; }

        /// <summary>
        /// Error
        /// </summary>
        public string Error { get; set; }
    }
}
