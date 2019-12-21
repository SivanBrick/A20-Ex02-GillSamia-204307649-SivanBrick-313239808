using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ex02;
using FacebookWrapper.ObjectModel;

namespace EX02_SivanGill
{
    internal class TopPhotosLiker
    {
        public static User GetYourBestPhotosFan(User i_LoggedInUser)
        {
            User bestFriend = null;
            Dictionary<User, int> friendsLikes = new Dictionary<User, int>();

            try
            {
                if (FacebookTabs.UserPhotosList == null)
                {
                    InitializeUserLists.InitializePhotosList(i_LoggedInUser);
                }

                if (FacebookTabs.UserPhotosList.Count == 0)
                {
                    MessageBox.Show("Sorry, you don't have any photos - you can't play this game :(");
                }
                else
                {
                    foreach (Photo photo in FacebookTabs.UserPhotosList)
                    {
                        foreach (User whoLike in photo.LikedBy)
                        {
                            if (friendsLikes.ContainsKey(whoLike))
                            {
                                friendsLikes[whoLike] += 1;
                            }
                            else
                            {
                                friendsLikes.Add(whoLike, 1);
                            }
                        }
                    }


                    int maxLikes = 0;
                    foreach (KeyValuePair<User, int> friend in friendsLikes)
                    {
                        int numOfLikesByThisFriend = friend.Value;
                        if (numOfLikesByThisFriend > maxLikes && friend.Key.Id != i_LoggedInUser.Id)
                        {
                            maxLikes = numOfLikesByThisFriend;
                            bestFriend = friend.Key;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            return bestFriend;
        }
    }
}