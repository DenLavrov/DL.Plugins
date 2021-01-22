using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;
using Xamarin.Forms.Sample.Droid.Renderers;
using Xamarin.Forms.Sample.UI.Controls;

[assembly:ExportRenderer(typeof(NoUnderlineEntry), typeof(NoUnderlineEntryRenderer))]
namespace Xamarin.Forms.Sample.Droid.Renderers
{
    class NoUnderlineEntryRenderer: EntryRenderer
    {
        public NoUnderlineEntryRenderer(Context context): base(context)
        {
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);
            Control?.SetBackground(null);
        }
    }
}