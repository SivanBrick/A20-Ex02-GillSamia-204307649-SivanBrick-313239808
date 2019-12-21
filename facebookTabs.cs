using System;
using System.Windows.Forms;
using FacebookWrapper.ObjectModel;
using System.Globalization;
using System.Collections.Generic;

namespace Ex02
{
    public partial class FacebookTabs : Form
    {
        private User m_LoggedInUser;
        private string m_errorMsg = "somthing went wrong..";
        private ZodiacSignManager m_myZodiac;
        private static List<User> m_UserFriends;
        private static List<Post> m_UserPosts;
        private static List<Photo> m_UserPhotos;

        public FacebookTabs(User i_loggedInUser)
        {
            FacebookWrapper.FacebookService.s_CollectionLimit = 200;
            FacebookWrapper.FacebookService.s_FbApiVersion = 2.8f;
            this.Text = string.Format("Logged in as {0} {1}", i_loggedInUser.FirstName, i_loggedInUser.LastName);
            this.InitializeComponent();
            this.m_LoggedInUser = i_loggedInUser;
            try
            {
                string currentUserBirthday = this.m_LoggedInUser.Birthday;
                if (currentUserBirthday.Length > 0)
                {
                    DateTime currentUserBirthdayDate = DateTime.ParseExact(currentUserBirthday, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    this.m_myZodiac = new ZodiacSignManager(currentUserBirthdayDate);
                    userZodiacSignLabel.Text = this.m_myZodiac.ZodiacSign;
                    zodiacHoroscopBox.Text = this.m_myZodiac.ZodiacHoroscop;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("You must have a valid birthday");
                findMatchButton.Enabled = false;
                userZodiacSignLabel.Text = "You cant play this geme, you need to fill your birthday:(";
            }

            this.fetchUserInfo();
        }

        public static List<User> UserFriendsList
        {
            get { return m_UserFriends; }
            set { m_UserFriends = value; }
        }

        public static List<Post> UserPostsList
        {
            get { return m_UserPosts; }
            set { m_UserPosts = value; }
        }

        public static List<Photo> UserPhotosList
        {
            get { return m_UserPhotos; }
            set { m_UserPhotos = value; }
        }

        private void fetchUserInfo()
        {
            try
            {
                welcomeLabel.Text = "Hey " + this.m_LoggedInUser.FirstName;
                string userProfilePictureUrl = this.m_LoggedInUser.PictureNormalURL;
                userPictureBox.LoadAsync(userProfilePictureUrl);

                this.userDetailsTextBox.Text = string.Format(
                    "User Name: {0} {1}\n" +
                    "Gender: {2}\n" +
                    "Relationship Status: {3}\n" +
                    "HomeTown : {4}\n" +
                    "Education: {5}\n" +
                    "Email: {6}",
                    this.m_LoggedInUser.FirstName, this.m_LoggedInUser.LastName,
                    this.m_LoggedInUser.Gender,
                    this.m_LoggedInUser.RelationshipStatus,
                    this.m_LoggedInUser.Hometown,
                    this.m_LoggedInUser.Educations,
                    this.m_LoggedInUser.Email);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void fetchFriends()
        {
            try
            {
                listBoxFriends.Items.Clear();
                listBoxFriends.DisplayMember = "Name";

                if (UserFriendsList == null)
                {
                    InitializeUserLists.InitializeFriendsList(this.m_LoggedInUser);
                }

                if (UserFriendsList.Count == 0)
                {
                    MessageBox.Show("No Friends to retrieve :(");
                }

                foreach (User friend in UserFriendsList)
                {
                    listBoxFriends.Items.Add(friend);
                    friend.ReFetch(DynamicWrapper.eLoadOptions.Full);
                }
            }
            catch (Exception ex)
            {
                this.listBoxFriends.Items.Add(string.Format("{0}..\n{1}", this.m_errorMsg, ex));
            }
        }

        private void fetchPosts()
        {
            try
            {
                recentPostListBox.Items.Clear();
                recentPostListBox.DisplayMember = "Post";
                
                if (UserPostsList == null)
                {
                   InitializeUserLists.InitializePostList(this.m_LoggedInUser);
                }

                if (UserPostsList.Count == 0)
                {
                    MessageBox.Show("No post to show :(");
                }

                foreach (Post userPost in UserPostsList)
                {
                    if (userPost.Message != null)
                    {
                        recentPostListBox.Items.Add(userPost.Message);
                    }
                    else if (userPost.Caption != null)
                    {
                        recentPostListBox.Items.Add(userPost.Caption);
                    }
                    else
                    {
                        recentPostListBox.Items.Add(string.Format("[{0}]", userPost.Type));
                    }
                }
            }
            catch (Exception ex)
            {
                recentPostListBox.Items.Add(string.Format("{0}..\n{1}", this.m_errorMsg, ex));
            }
        }

        private void fetchPhotos()
        {
            try
            {
                this.userPhotosBox.Items.Clear();
                this.userPhotosBox.DisplayMember = "URL";

                if (UserPhotosList == null)
                {
                    InitializeUserLists.InitializePhotosList(this.m_LoggedInUser);
                }

                if (UserPhotosList.Count == 0)
                {
                    userPhotosBox.Items.Add("No photos to retrive..");
                }
                else
                {
                    foreach (Photo userPhoto in UserPhotosList)
                    {
                        userPhotosBox.Items.Add(userPhoto.PictureNormalURL);
                    }

                    if (UserPhotosList.Count > 3)
                    {
                        this.userPhoto1.LoadAsync(UserPhotosList[0].PictureNormalURL);
                        this.userPhoto2.LoadAsync(UserPhotosList[1].PictureNormalURL);
                        this.userPhoto3.LoadAsync(UserPhotosList[2].PictureNormalURL);
                        this.userPhoto4.LoadAsync(UserPhotosList[3].PictureNormalURL);
                    }
                }
            }
            catch (Exception ex)
            {
                userPhotosBox.Items.Add(string.Format("{0}..\n{1}", this.m_errorMsg, ex));
            }
        }

        private void fetchAlbums()
        {
            try
            {
                this.userAlbumsBox.Items.Clear();
                this.userAlbumsBox.DisplayMember = "Album";

                if (this.m_LoggedInUser.Albums.Count == 0)
                {
                    MessageBox.Show("No albums to show :(");
                    return;
                }

                foreach (Album userAlbum in this.m_LoggedInUser.Albums)
                {
                    this.userAlbumsBox.Items.Add(userAlbum.Name);
                }

                if (this.m_LoggedInUser.Albums.Count > 4)
                {
                    this.userAlbumPictureBox1.LoadAsync(this.m_LoggedInUser.Albums[0].PictureAlbumURL);
                    this.userAlbumPictureBox2.LoadAsync(this.m_LoggedInUser.Albums[1].PictureAlbumURL);
                    this.userAlbumPictureBox3.LoadAsync(this.m_LoggedInUser.Albums[2].PictureAlbumURL);
                    this.userAlbumPictureBox4.LoadAsync(this.m_LoggedInUser.Albums[3].PictureAlbumURL);
                }
            }
            catch (Exception ex)
            {
                this.userAlbumsBox.Items.Add(string.Format("{0}..\n{1}", this.m_errorMsg, ex));
            }
        }

        private void fetchCheckIns()
        {
            try
            {
                this.userCheckInsBox.Items.Clear();
                this.userCheckInsBox.DisplayMember = "Location";
                if (this.m_LoggedInUser.Checkins.Count == 0)
                {
                    userCheckInsBox.Items.Add("No CheckIns to retrive :(");
                    return;
                }

                foreach (Checkin userCheckIn in this.m_LoggedInUser.Checkins)
                {
                    this.userCheckInsBox.Items.Add(userCheckIn.Place);
                }
            }            
            catch (Exception ex)
            {
                this.userCheckInsBox.Items.Add(string.Format("{0}..\n{1}", this.m_errorMsg, ex));
            }
        }

        private void fetchPages()
        {
            try
            {
                if (this.m_LoggedInUser.LikedPages.Count == 0)
                {
                    this.userPagesBox.Items.Add("No Pages to retrive..");
                }
                else
                {
                    foreach (Page userLikedPage in this.m_LoggedInUser.LikedPages)
                    {
                        this.userPagesBox.Items.Add(userLikedPage.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                this.userPagesBox.Items.Add(string.Format("{0}..\n{1}", this.m_errorMsg, ex));
            }
        }

        private void fetchVideos()
        {
            try
            {
                if (this.m_LoggedInUser.Videos.Count == 0)
                {
                    userVideosBox.Items.Add("No videos to retrive..");
                }
                else
                {
                    foreach (Video userVideo in this.m_LoggedInUser.Videos)
                    {
                        userVideosBox.Items.Add(userVideo.Name);
                    }
                }
            }
            catch (Exception ex)
            {
                this.userCheckInsBox.Items.Add(string.Format("{0}..\n{1}", this.m_errorMsg, ex));
            }
        }

        private void fetchZodiacSignFriends()
        {
            try
            {
                listBoxFriends.Items.Clear();
                listBoxFriends.DisplayMember = "Name";
                int counterZodiacMatches = 0;
                foreach (User friend in this.m_LoggedInUser.Friends)
                {
                    if (friend.Birthday != null && friend.Birthday.Length > 0)
                    {
                        string currentFriendBirthday = friend.Birthday;
                        if (currentFriendBirthday.Length < 6 && currentFriendBirthday.Length > 0)
                        {
                            currentFriendBirthday = currentFriendBirthday + "/2000";
                        }

                        DateTime currentFriendDate = DateTime.ParseExact(currentFriendBirthday, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                        if (ZodiacSignManager.GetZodiacSign(currentFriendDate).Equals(this.m_myZodiac.ZodiacSign))
                        {
                            counterZodiacMatches++;
                            listBoxFriendsSign.Items.Add(friend);
                            friend.ReFetch(DynamicWrapper.eLoadOptions.Full);
                        }
                    }
                }

                if (counterZodiacMatches == 0)
                {
                    string noFriendsWithTheSameSign = String.Format("No Friends with Zodiac sign {0} to retrieve", this.m_myZodiac.ZodiacSign);
                    listBoxFriendsSign.Items.Add(noFriendsWithTheSameSign);
                }
            }
            catch (Exception ex)
            {
                this.listBoxFriendsSign.Items.Add(string.Format("{0}..\n{1}", this.m_errorMsg, ex));
            }
        }

        private void statusText_TextChanged(object sender, EventArgs e)
        {
            postTextButton.Enabled = !(statusText.Text == "What's on your mind?" || statusText.Text == string.Empty);
        }

        // DEPRECATED function
        private void postTextBox_Click(object sender, EventArgs e)
        {
            MessageBox.Show("We can't upload your post - Sorry");
        }

        private void recentPostsLable_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.fetchPosts();   
        }

        private void showFriendsLable_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.fetchFriends();
        }

        private void getUserPhotosLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.fetchPhotos();
        }

        private void getAlbumsLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.fetchAlbums();
        }

        private void getUserEventsLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.fetchCheckIns();
        }

        private void getUserPagesLable_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.fetchPages();
        }

        private void getUserVideosLable_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.fetchVideos();
        }

        private void findZodiacMatchButton_Click(object sender, EventArgs e)
        {
            this.fetchZodiacSignFriends();
        }

        private void findTheBestPostsFanButton_Click(object sender, EventArgs e)
        {
            User bestPostFan = FindTheBestFan.GetYourBestPostFan(this.m_LoggedInUser);
            
            if (bestPostFan != null)
            {
                nameOfBestPostsFanLabel.Text = bestPostFan.Name;
                picturBoxBestFriend.LoadAsync(bestPostFan.PictureSmallURL);
            }
            else
            {
                nameOfBestPostsFanLabel.Text = "We're sorry none of your friends likes your posts";
            }
        }

        private void findTheBestPhotosFanButton_Click(object sender, EventArgs e)
        {
            User bestPhotosFan = FindTheBestFan.GetYourBestPhotosFan(this.m_LoggedInUser);

            if (bestPhotosFan != null)
            {
                nameOfBestPhotosFanLabel.Text = bestPhotosFan.Name;
                bestPhotosFanPictureBox.LoadAsync(bestPhotosFan.PictureSmallURL);
            }
            else
            {
                nameOfBestPhotosFanLabel.Text = "We're sorry none of your friends likes your posts";
            }
        }

        private void logoutButton_Click(object sender, EventArgs e)
        {
            FacebookWrapper.FacebookService.Logout(this.logOutActions);
        }

        private void logOutActions()
        {
            this.Close();
        }

        private void userDetailsTextBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
