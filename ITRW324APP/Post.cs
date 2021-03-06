﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Newtonsoft.Json;

namespace ITRW324APP
{
    public class Post
    {

        public int Id { get; set; }
        public int UserId { get; set; }
        public string Title { get; set; }

        [JsonProperty("body")]
        public string Content { get; set; }

        public override string ToString()
        {
            return string.Format(
                "Post Id: {0}\nTitle: {1}\nBody: {2}",
                Id, Title, Content);
        }



    }
}