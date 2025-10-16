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
        //    GoogleAuthService google = new GoogleAuthService();
        //    string idToken = await google.GetGoogleIdTokenAsync();

        //    if (string.IsNullOrEmpty(idToken))
        //    {
        //        throw new Exception("No Google ID token returned.");
        //    }

        //    // Correct call for FirebaseAuthentication.net
        //    Firebase.Auth.FirebaseAuthLink user = await facl.SignInWithOAuthAsync("google.com", idToken);

        //    OnComplete(Task.CompletedTask);
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
