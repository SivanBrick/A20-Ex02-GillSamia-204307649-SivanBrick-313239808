﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FacebookWrapper;
using FacebookWrapper.ObjectModel;

namespace Ex02
{
    public class FBLoggedInUserAdapter : FacebookService, ILoggedInUser
    {
        private User m_LoggedInUser = null;
        
        public User LoggedInUser
        {
            get { return m_LoggedInUser; }
        }

        public void loginAndInit()
        {
            try
            {
                // Owner: design.patterns

                // Use the FacebookService.Login method to display the login form to any user who wish to use this application.
                // You can then save the result.AccessToken for future auto-connect to this user:
                LoginResult result = FacebookService.Login(
                "1905574636240159", /// (desig patter's "Design Patterns Course App 2.4" app)
                  "public_profile",
                "email",
                "publish_to_groups",
                "user_birthday",
                "user_age_range",
                "user_gender",
                "user_link",
                "user_tagged_places",
                "user_videos",
                "publish_to_groups",
                "groups_access_member_info",
                "user_friends",
                "user_events",
                "user_likes",
                "user_location",
                "user_photos",
                "user_posts",
                "user_hometown",
                "manage_pages",
                "publish_pages"
               // DEPRECATED PERMISSIONS:
               // "publish_actions"
               // "user_about_me",
               // "user_education_history",
               // "user_actions.video",
               // "user_actions.news",
               // "user_actions.music",
               // "user_actions.fitness",
               // "user_actions.books",
               // "user_games_activity",
               // "user_managed_groups",
               // "user_relationships",
               // "user_relationship_details",
               // "user_religion_politics",
               // "user_tagged_places",
               // "user_website",
               // "user_work_history",
               // "read_custom_friendlists",
               // "read_page_mailboxes",
               // "manage_pages",
               // "publish_pages",
               // "publish_actions",
               // "rsvp_event"
               // "user_groups" (This permission is only available for apps using Graph API version v2.3 or older.)
               // "user_status" (This permission is only available for apps using Graph API version v2.3 or older.)
               // "read_mailbox", (This permission is only available for apps using Graph API version v2.3 or older.)
               // "read_stream", (This permission is only available for apps using Graph API version v2.3 or older.)
               // "manage_notifications", (This permission is only available for apps using Graph API version v2.3 or older.)
               );

                if (!string.IsNullOrEmpty(result.AccessToken))
                {
                    this.m_LoggedInUser = result.LoggedInUser;
                    Form nextForm = new FacebookTabs(this.m_LoggedInUser);
                    this.Hide();
                    nextForm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(result.ErrorMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        public string GetProfilePictureURL()
        {
            return LoggedInUser.PictureNormalURL;
        }

        public string GetName()
        {
            return LoggedInUser.FirstName;
        }
  }
}