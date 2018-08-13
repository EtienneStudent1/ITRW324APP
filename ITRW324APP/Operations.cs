using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using System.IO;
using Android.Net;
using System.Net.Http;
using System.Xml.Serialization;
using Newtonsoft.Json;
namespace ITRW324APP
{
    [Activity(Label = "Operations", Theme = "@style/AppTheme")]
    public class Operations : Activity, BottomNavigationView.IOnNavigationItemSelectedListener
    {

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:

                    Intent intent = new Intent(this, typeof(MainActivity));//hjkhkj
                    this.StartActivity(intent);
                    this.Finish();
                    item.SetChecked(true);
                    return true;
                case Resource.Id.navigation_statistics://This is the statistics activity

                    Intent intent1 = new Intent(this, typeof(Statistics));
                    this.StartActivity(intent1);
                    this.Finish();
                    item.SetChecked(true);
                    return true;
                case Resource.Id.navigation_operations://This is the Operations activity

                    Intent intent2 = new Intent(this, typeof(Operations));
                    this.StartActivity(intent2);
                    this.Finish();
                    item.SetChecked(true);
                    return true;
            }
            return false;
        }



        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.OperationsLayout);
            TextView operationsText = FindViewById<TextView>(Resource.Id.textViewOperations);
            TextView operationsText1 = FindViewById<TextView>(Resource.Id.textViewOperations1);
            operationsText.Text = "Operations Panel";


            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);










            ///////////////////
            /////////////////////
            //////////////////


            Button readJson = FindViewById<Button>(Resource.Id.readJson);
            Button sendData = FindViewById<Button>(Resource.Id.sendData);


            readJson.Click += async delegate
            {
                using (var client = new HttpClient())
                {
                    // send a GET request  
                    var uri = "http://jsonplaceholder.typicode.com/posts";
                    var result = await client.GetStringAsync(uri);

                    //handling the answer  
                    var posts = JsonConvert.DeserializeObject<List<Post>>(result);

                    // generate the output  
                    var post = posts.First();
                    operationsText1.Text = "First post:\n\n" + post;
                }
            };


            sendData.Click += async delegate
            {
                using (var client = new HttpClient())
                {
                    // Create a new post  
                    var novoPost = new Post
                    {
                        UserId = 12,
                        Title = "My First Post",
                        Content = "Macoratti .net - Quase tudo para .NET!"
                    };

                    // create the request content and define Json  
                    var json = JsonConvert.SerializeObject(novoPost);
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    //  send a POST request  
                    var uri = "http://jsonplaceholder.typicode.com/posts";
                    var result = await client.PostAsync(uri, content);

                    // on error throw a exception  
                    result.EnsureSuccessStatusCode();

                    // handling the answer  
                    var resultString = await result.Content.ReadAsStringAsync();
                    var post = JsonConvert.DeserializeObject<Post>(resultString);

                    // display the output in TextView  
                    operationsText1.Text = post.ToString();
                }
            };

            ///////////////////
            /////////////////
            //////////////////
        }
    }
}