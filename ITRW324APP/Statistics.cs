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


namespace ITRW324APP
{
    [Activity(Label = "Statistics", Theme = "@style/AppTheme")]
    public class Statistics : Activity, BottomNavigationView.IOnNavigationItemSelectedListener
    {

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

            SetContentView(Resource.Layout.StatisticsLayout);
            TextView test = FindViewById<TextView>(Resource.Id.textViewStat);
            test.Text = "Hello world";


            BottomNavigationView navigation = FindViewById<BottomNavigationView>(Resource.Id.navigation);
            navigation.SetOnNavigationItemSelectedListener(this);
        }
    }
}