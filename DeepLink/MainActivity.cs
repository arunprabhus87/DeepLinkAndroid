using Android.App;
using Android.Widget;
using Android.OS;
using BranchXamarinSDK;
using System;
using System.Collections.Generic;

namespace DeepLink
{
	[Activity(Label = "DeepLink", MainLauncher = true, Icon = "@mipmap/icon")]
	[IntentFilter(new[] { "android.intent.action.VIEW" },
			Categories = new[]{"android.intent.category.DEFAULT",
						"android.intent.category.BROWSABLE"},
			DataScheme = "Schema Name",
			DataHost = "open")]

	[IntentFilter(new[] { "android.intent.action.VIEW" },
			Categories = new[] { "android.intent.category.DEFAULT", "android.intent.category.BROWSABLE" },
			DataScheme = "https", DataHost = "Datahost Name")]

	public class MainActivity : Activity, IBranchSessionInterface
	{
		int count = 1;
		public static Dictionary<string, object> branchData;

		protected override void OnCreate(Bundle savedInstanceState)
		{
			base.OnCreate(savedInstanceState);

			// Set our view from the "main" layout resource
			SetContentView(Resource.Layout.Main);
			BranchAndroid.GetAutoInstance(this.ApplicationContext);
			BranchAndroid.Init(this, "Branch key", this);
		}


		public void InitSessionComplete(Dictionary<string, object> data)
		{
			if (data != null && data.ContainsKey("loc-key"))
			{
				branchData = new Dictionary<string, object>();
				branchData = data;
			}
		}

		public void SessionRequestError(BranchError error)
		{
			Console.WriteLine("Branch session initialization error: " + error.ErrorCode);
			Console.WriteLine(error.ErrorMessage);
		}
	}
}

