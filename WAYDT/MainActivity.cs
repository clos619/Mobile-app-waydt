using Android.App;
using Android.Widget;
using Android.OS;
using Android.Views;
using Android.Content;
using Android.Runtime;
using System.Collections;
using System;
namespace WAYDT 
{

    [Activity(Label = "WAYDT", MainLauncher = true)]
    public class MainActivity : Activity
    {
        private SearchView search;
        ListView list;
       private  ArrayList std;
       private  ArrayAdapter adapt;
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            
            
            //will add information to the arraylist
            addData();
            //intiallize views
            list = FindViewById<ListView>(Resource.Id.listView1);
            search = FindViewById<SearchView>(Resource.Id.searchView1);

            
            //array adapter
            adapt = new ArrayAdapter(this,Android.Resource.Layout.SimpleListItem1, std);
            list.Adapter = adapt;
            search.QueryTextChange += search_QueryTextChange;
            list.ItemClick += list_ItemClick;
        }

        private void list_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, "Sweet! you chose  ", ToastLength.Short).Show();
            Toast.MakeText(this, adapt.GetItem(e.Position).ToString(),ToastLength.Short).Show();
        }

        void search_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            //Filter or search 
            adapt.Filter.InvokeFilter(e.NewText);

        }

        private void addData()
        {
            std = new ArrayList();
            std.Add("Running");
            std.Add("Hiking");
            std.Add("playing Football");
            std.Add("Playing Basketball");
            std.Add("Playing Baseball");
            std.Add("Going to the Gym");
            std.Add("Walking Downtown");
            std.Add("Climbing");
            

        }
    }

  
}

