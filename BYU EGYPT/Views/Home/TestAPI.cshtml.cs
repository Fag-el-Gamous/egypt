using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Box.V2;
using Box.V2.Auth;
using Box.V2.Config;
using Box.V2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Ubiety.Dns.Core;

//ADDED
using Box.V2.Auth;
using Box.V2.Config;
using Box.V2;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Box.V2.Models;
using static System.Net.WebRequestMethods;
using Microsoft.AspNetCore.Http;



namespace BYU_EGYPT.Views.Home
{
    public class TestAPIModel : PageModel
    {
        public IEnumerable<BoxItem> FolderItems { get; private set; }
        public BoxFile imageInfo { get; set; }
        public Uri embedUri { get; set; }
        public string authorizationUrl { get; set; }
        // chatGPT generated attempt at getting the authorization code from the URL
        public async Task<IActionResult> BoxCallback(string code)
        {
            // Use the ‘code’ parameter directly
            string authorizationCode = code;
            // Check state for security (optional but recommended)
            // Now you can use the authorization code to authenticate with Box
            var redirectUrl = "https://localhost:7218/";
            var config = new BoxConfig("5zbozuhwobclkx4irixpwt5rz7x5awkv", "HBcQ96QiJJcyGGQ38qeL2t8qBlemN9mb", new Uri(redirectUrl));
            var sdk = new BoxClient(config);
            var session = await sdk.Auth.AuthenticateAsync(authorizationCode);
            var client = new BoxClient(config, session);
            // Continue with your logic...
            // Redirect to your application’s home page or wherever you want the user to go after successful login
            return RedirectToAction("Index", "Home");
        }
        public async Task OnGetAsync()
        {
            // set up Box configuration with OAuth 2.0
            //var redirectUrl = "https://localhost:7218/";
            //var config = new BoxConfig("5zbozuhwobclkx4irixpwt5rz7x5awkv", "HBcQ96QiJJcyGGQ38qeL2t8qBlemN9mb", new Uri(redirectUrl));
            //var sdk = new BoxClient(config);
            //authorizationUrl = "https://account.box.com/api/oauth2/authorize?client_id=5zbozuhwobclkx4irixpwt5rz7x5awkv&redirect_uri=https://localhost:7218/&response_type=code";
            //redirectTo(authorizationUrl);
            //string authorizationCode = HttpContext.Request.Query["code"];
            //var session = await sdk.Auth.AuthenticateAsync(authorizationCode);
            //var client = new BoxClient(config, session);
            // set up Box configuration with Developer Token
            var config = new BoxConfigBuilder("5zbozuhwobclkx4irixpwt5rz7x5awkv", "HBcQ96QiJJcyGGQ38qeL2t8qBlemN9mb", new Uri("https://localhost:7218")).Build();
            var session = new OAuthSession("RW77Xv2CVaPvIQaI1QOrCXi2n9gJTH5V", "N / A", 3600, "bearer"); // add developer token here
            var client = new BoxClient(config, session);
            // API call to get list of folder contents
            FolderItems = (await client.FoldersManager.GetFolderItemsAsync("236625959604", 100, 0, null, false, null, BoxSortDirection.ASC, null, null)).Entries.ToList();
            // view pictures
            imageInfo = await client.FilesManager.GetInformationAsync(id: "1370536808926"); //gets the info of files at the specified ID
            embedUri = await client.FilesManager.GetPreviewLinkAsync(id: "1370536808926"); //gets embed URI of the specified file
        }
    }
}