using Firebase.Auth;
using Firebase.Auth.Providers;
using SleepingQueensTogether.Models;

namespace SleepingQueensTogether.ModelsLogic
{
    internal class FbData : FbDataModel
    {
        public override async void CreateUserWithEmailAndPasswordAsync(string email, string password, string name, Action<System.Threading.Tasks.Task> OnComplete)
        {
            await facl.CreateUserWithEmailAndPasswordAsync(email, password, name).ContinueWith(OnComplete);
        }
        public override async void SignInWithEmailAndPasswordAsync(string email, string password, Action<System.Threading.Tasks.Task> OnComplete)
        {
            await facl.SignInWithEmailAndPasswordAsync(email, password).ContinueWith(OnComplete);
        }
        //public override async void SignInWithGoogleAsync(Action<System.Threading.Tasks.Task> OnComplete)
        //{
        //    SignInRedirectDelegate redirectHandler = (string redirectUri) =>
        //    {
        //        // Use WebAuthenticator to open the popup
        //        Task<WebAuthenticatorResult> authTask = WebAuthenticator.AuthenticateAsync(
        //            new Uri("https://accounts.google.com/o/oauth2/v2/auth?client_id=705683475351-412ohb30j929v7jk5sq51pdorlgapunv.apps.googleusercontent.com&response_type=token&scope=email profile"),
        //            new Uri(redirectUri)
        //        );

        //        // Convert Task<WebAuthenticatorResult> -> Task<string>
        //        Task<string> stringTask = authTask.ContinueWith(t => t.Result?.AccessToken ?? string.Empty);
        //        return stringTask;
        //    };
        //    await facl.SignInWithRedirectAsync(FirebaseProviderType.Google, redirectHandler).ContinueWith(OnComplete);
        //}

        public override string DisplayName
        {
            get
            {
                string dn = string.Empty;
                if (facl.User != null)
                    dn = facl.User.Info.DisplayName;
                return dn;
            }
        }
        public override string UserID
        {
            get
            {
                return facl.User.Uid;
            }
        }
    }
}
