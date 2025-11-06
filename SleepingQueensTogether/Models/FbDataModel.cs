using Firebase.Auth;
using Firebase.Auth.Providers;
using Plugin.CloudFirestore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SleepingQueensTogether.Models
{
    abstract class FbDataModel
    {
        protected FirebaseAuthClient facl;
        protected IFirestore fdb;
        public abstract string DisplayName { get; }
        public abstract string UserID { get; }
        public abstract void CreateUserWithEmailAndPasswordAsync(string email, string password, string name, Action<System.Threading.Tasks.Task> OnComplete);
        public abstract void SignInWithEmailAndPasswordAsync(string email, string password, Action<System.Threading.Tasks.Task> OnComplete);
        public abstract string GetErrorMessage(string message);
        public abstract string SetDocument(object obj, string collectonName, string id, Action<System.Threading.Tasks.Task> OnComplete);
        public abstract IListenerRegistration AddSnapshotListener(string collectonName, Plugin.CloudFirestore.QuerySnapshotHandler OnChange);
        public abstract IListenerRegistration AddSnapshotListener(string collectonName, string id, Plugin.CloudFirestore.DocumentSnapshotHandler OnChange);
        //public abstract void SignInWithGoogleAsync(Action<System.Threading.Tasks.Task> OnComplete);
        public FbDataModel()
        {
            FirebaseAuthConfig fac = new()
            {
                ApiKey = Keys.JsonApiKey,
                AuthDomain = Keys.JsonApiAuthDomainKey,
                Providers = [new EmailProvider()]
            };
            facl = new FirebaseAuthClient(fac);
            fdb = CrossCloudFirestore.Current.Instance;
        }
    }
}
