using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace DormitoryApp.Pages
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GuardPage : TabbedPage
    {
		public GuardPage ()
		{
			InitializeComponent ();
            NavigationPage.SetHasNavigationBar(this, false);
        }
	}
}