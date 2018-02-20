﻿using Microsoft.IdentityModel.Clients.ActiveDirectory;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace MFATest
{
    public partial class MainPage : ContentPage
    {
        public static string clientId = "<<Insert your mobile client ID here>>";
        public static string authority = "https://login.windows.net/common";
        public static string returnUri = "http://localhost:3000";
        private const string graphResourceUri = "<<Insert your App ID URI of Node.js endpoint here>>";
        private AuthenticationResult authResult = null;
        private static string userLogin = null;
        private static string RestUri = "<<Insert your REST API endpoint here>>"; // for example "http://MyRestServer.com:3000/api/tasks/" 

        HttpClient client = new HttpClient();


        public MainPage()
        {
            
            InitializeComponent();
        }

        private async void btnLogin_Clicked(object sender, EventArgs e)
        {
            try
            {
                var auth = DependencyService.Get<IAuthenticator>();
                authResult = await auth.Authenticate(authority, graphResourceUri, clientId, returnUri);
                string userUpn = authResult.UserInfo.DisplayableId.ToString();
                int userAt = userUpn.IndexOf('@');
                userLogin = userUpn.Substring(0, userAt);
                var userName = authResult.UserInfo.GivenName + " " + authResult.UserInfo.FamilyName;
                lblUserName.Text = userName;
                lblMessage.Text = "Access Token: " + authResult.AccessToken.ToString();
                await DisplayAlert("User Login", userLogin, "Ok", "Cancel");
                btnLogout.IsEnabled = true;
            }
            catch (Exception ex)
            {
                await DisplayAlert("Error", ex.Message, "Ok");
            }
        }

        private void btnLogout_Clicked(object sender, EventArgs e)
        {
            if (authResult != null)
            {
                AuthenticationContext ac = new AuthenticationContext(authority);
                ac.TokenCache.Clear();
                var auth = DependencyService.Get<IAuthenticator>();
                auth.ClearAllCookies();
            }
            btnLogout.IsEnabled = false;
        }

        private async void btnCallRestAdal_Clicked(object sender, EventArgs e)
        {

            if (!(authResult is null))
            {
                client.MaxResponseContentBufferSize = 256000;
                var uri = new Uri(string.Format(RestUri + userLogin, string.Empty));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);

                try
                {
                    var response = await client.GetAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        lblMessage.Text = await response.Content.ReadAsStringAsync();
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = $"ERROR: {ex.Message}";
                }
            }
            else
                lblMessage.Text = "Please press Login to Azure button first";
        }

        private async void btnAddTaskRestAdal_Clicked(object sender, EventArgs e)
        {

            if (authResult != null)
            {
                client.MaxResponseContentBufferSize = 256000;
                string userTask = txtInput.Text;
                var uri = new Uri(string.Format(RestUri + userLogin + "/" + txtInput.Text, string.Empty));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);

                try
                {
                    string mydata = "test01";
                    StringContent queryString = new StringContent(mydata);
                    var response = await client.PostAsync(uri, queryString);
                    if (response.IsSuccessStatusCode)
                    {
                        lblMessage.Text = await response.Content.ReadAsStringAsync();
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = $"ERROR: {ex.Message}";
                }
            }
            else
                lblMessage.Text = "Please press Login to Azure button first";
        }

        private async void btnDeleteTaskRestAdal_Clicked(object sender, EventArgs e)
        {
            if (authResult != null)
            {
                client.MaxResponseContentBufferSize = 256000;
                var uri = new Uri(string.Format(RestUri + userLogin + "/" + txtInput.Text, string.Empty));
                client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", authResult.AccessToken);

                try
                {
                    var response = await client.DeleteAsync(uri);
                    if (response.IsSuccessStatusCode)
                    {
                        lblMessage.Text = await response.Content.ReadAsStringAsync();
                    }
                }
                catch (Exception ex)
                {
                    lblMessage.Text = $"ERROR: {ex.Message}";
                }
            }
            else
                lblMessage.Text = "Please press Login to Azure button first";

        }

        private void btnShowCookies_Clicked(object sender, EventArgs e)
        {
            var auth = DependencyService.Get<IAuthenticator>();
             
            StringBuilder cookies = new StringBuilder();
            foreach(var cookie in auth.GetCookies())
            {
                cookies.Append($"{cookie.Name}  Expiration:{cookie.MaxAge.ToString()}");
            }
            lblMessage.Text = cookies.ToString();
        }
    }
}
