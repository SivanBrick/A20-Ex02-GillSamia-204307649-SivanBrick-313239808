using System.Collections.Generic;
using FacebookWrapper.ObjectModel;

namespace Ex01
{
    public class InitializeUserLists 
    {
        public static void InitializeFriendsList(User i_LoggedInUser)
        {
            List<User> userFriends = new List<User>();
            foreach (User friend in i_LoggedInUser.Friends)
            {
                userFriends.Add(friend);
            }

            FacebookTabs.UserFriendsList = userFriends;
        }

        public static void InitializePhotosList(User i_LoggedInUser)
        {
            List<Photo> userPhotos = new List<Photo>();
            foreach (Photo photo in i_LoggedInUser.PhotosTaggedIn)
            {
                userPhotos.Add(photo);
            }

            FacebookTabs.UserPhotosList = userPhotos;
        }

        public static void InitializePostList(User i_LoggedInUser)
        {
            List<Post> userPosts = new List<Post>();
            foreach (Post post in i_LoggedInUser.Posts)
            {
                userPosts.Add(post);
            }

            FacebookTabs.UserPostsList = userPosts;
        }
    }
}
