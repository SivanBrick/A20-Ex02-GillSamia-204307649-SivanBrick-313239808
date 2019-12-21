using System;
using System.Collections.Generic;
using System.Windows.Forms;
using Ex02;
using FacebookWrapper.ObjectModel;

namespace Ex02
{
    internal class TopPostsLiker
    {

        public static User GetYourBestPostFan(User i_LoggedInUser)
        {
            User bestFriend = null;
            Dictionary<User, int> friendsLikes = new Dictionary<User, int>();

            try
            {
                if (FacebookTabs.UserPostsList == null)
                {
                    InitializeUserLists.InitializePostList(i_LoggedInUser);
                }

                if (FacebookTabs.UserPostsList.Count == 0)
                {
                    MessageBox.Show("Sorry, you dont have any post - you can't play this game :(");
                }
                else
                {
                    foreach (Post userPost in FacebookTabs.UserPostsList)
                    {
                        foreach (User whoLike in userPost.LikedBy)
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