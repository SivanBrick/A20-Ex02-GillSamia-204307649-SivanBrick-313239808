namespace EX02
{
    public interface ILoggedInUser
    {
        void Login();
        string GetProfilePictureURL();
        string GetName();
    }
}
