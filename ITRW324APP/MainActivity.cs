using Android.App;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using System;
using System.IO;
using System.Collections.Generic;
using Android.Content;
using Android.Net;

using System.Linq;
using System.Net.Http;
using System.Text;
using System.Xml.Serialization;
using Newtonsoft.Json;


namespace ITRW324APP
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : AppCompatActivity, BottomNavigationView.IOnNavigationItemSelectedListener
    {
        private TextView _textMessage;
        BottomNavigationView navigation;

        public bool OnNavigationItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.navigation_home:

                    Intent intent = new Intent(this, typeof(MainActivity));
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
            SetContentView(Resource.Layout.activity_main);
            _textMessage = FindViewById<TextView>(Resource.Id.messageMain);
            navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
            ///////////////////
            ////////////////////
            ///////////////////////
           






            /////////////////////
            //////////////////
            ////////////////////////





        }
    }
}

