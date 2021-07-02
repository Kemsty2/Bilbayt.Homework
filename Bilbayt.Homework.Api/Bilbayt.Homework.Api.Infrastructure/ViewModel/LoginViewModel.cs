namespace Bilbayt.Homework.Api.Infrastructure.ViewModel
{
    public class LoginViewModel
    {
        public string UserName { get; set; }
        public string AccessToken { get; set; }

        public LoginViewModel(string userName, string accessToken)
        {
            UserName = userName;
            AccessToken = accessToken;
        }
    }
}