using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using SQLitePCL;
using Xamarin.Forms;
using TiblerZone;
namespace TiblerZone
{
    public partial class EditAdd : ContentPage
    {
        
        TiblerItem tibleritem = new TiblerItem();
        TiblerItem itemshere = new TiblerItem();

        int id = 0;
        Dictionary<string, string> nameclass = new Dictionary<string, string>
        {
            { "Please Select", "Please Select" },
            { "Programming Essentials", "Programming Essentials" },
            { "Computing Mathematics", "Computing Mathematics" },
            { "Network Technology", "Network Technology" },
            { "Commnucation Skills", "Communication Skills" },


        };

        String module = "";

        public EditAdd(int id)
        {
            this.id = id;


            InitializeComponent();
         
            

            Label header = new Label
            {
                Text = "Picker",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            Picker pickersec = new Picker
            {

                VerticalOptions = LayoutOptions.CenterAndExpand

            };
            GridSec.Children.Add(pickersec);
            Grid.SetRow(pickersec, 6);
            pickersec.Margin = new Thickness(10, 0, 10, 0);
            foreach (string colorName in nameclass.Keys)
            {
                pickersec.Items.Add(colorName);
            }


            // Create BoxView for displaying picked Color




            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            itemshere = App.Database.GetItem(id);
            Topic.Text = itemshere.Name;
            Location.Text = itemshere.Location;
            bigtb.Text = itemshere.Description;
            TimePick.Time = itemshere.timeitem.TimeOfDay;
            DatePick.Date = itemshere.timeitem.Date;




            String value = itemshere.Module;
            switch (value)
            {
                case "Programming Essentials":
                    pickersec.SelectedIndex = 1;
                    break;
                case "Computing Mathematics":
                    pickersec.SelectedIndex = 2;
                    break;
                case "Network Technology":
                    pickersec.SelectedIndex = 3;
                    break;
                case "Commnucation Skills":
                    pickersec.SelectedIndex = 4;
                    break;
                default:
                    pickersec.SelectedIndex = 0;
                    break;

            }



       
        }

        public EditAdd()
        {
            InitializeComponent();
            godelete.Text = "Cancel";
            gosave.Text = "Add";
            Label header = new Label
            {
                Text = "Picker",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };

            Picker pickersec = new Picker
            {
                
                VerticalOptions = LayoutOptions.CenterAndExpand
              
            };
            GridSec.Children.Add(pickersec);
            Grid.SetRow(pickersec, 6);
            pickersec.Margin = new Thickness(10, 0, 10, 0);
            foreach (string colorName in nameclass.Keys)
            {
                pickersec.Items.Add(colorName);
            }

            pickersec.SelectedIndex = 0;

            // Create BoxView for displaying picked Color

    


            // Accomodate iPhone status bar.
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);

            pickersec.SelectedIndexChanged += (sender, args) =>
            {
                module=pickersec.Items[pickersec.SelectedIndex];

            };


        }

        void saveClicked(object sender, EventArgs e)
        {
        
            TiblerItem tibleritemsave = new TiblerItem();
           
            String topic = null;
            topic = Topic.Text;

            String location = null;
            location = Location.Text;



           

            String desc = bigtb.Text;

            tibleritemsave.Location = location;
            tibleritemsave.Name = topic;
            tibleritemsave.Module = module;
            tibleritemsave.Description = desc;
            tibleritemsave.category = "Lecture";
            tibleritemsave.color = "#009688";

         

            DateTime newDateTime = DatePick.Date.Add(TimePick.Time);
            tibleritemsave.timeitem = newDateTime;
         
            if (tibleritemsave.Name == "" || tibleritemsave.Name == null)
            {
                DisplayAlert("Invalid Name", "Please Enter Valid Name ", "OK");
            }
            else if (tibleritemsave.Location == "" || tibleritemsave.Location == null)
            {
                DisplayAlert("Invalid Location", "Please Enter Valid Location ", "OK");
            }

            else if (tibleritemsave.Description == "Please Enter Description Here" || tibleritemsave.Description == null)
            {
                DisplayAlert("Invalid Decription", "Please Enter Valid Description ", "OK");
            }
            else if (tibleritemsave.timeitem.Date < DateTime.Today)
            {

                DisplayAlert("Invalid Date & Time", "Please Enter Future Date & Time ", "OK");

            }

            else if (tibleritemsave.timeitem.Date == DateTime.Today && tibleritemsave.timeitem.TimeOfDay < DateTime.Now.TimeOfDay)
            {

                DisplayAlert("Invalid Date & Time", "Please Enter Future Date & Time ", "OK");
            }
            else
            {




                if (id != 0)
                {
                    tibleritemsave = App.Database.GetItem(id);

                    topic = Topic.Text;


                    location = Location.Text;





                    desc = bigtb.Text;

                    tibleritemsave.Location = location;
                    tibleritemsave.Name = topic;
                    tibleritemsave.Module = module;
                    tibleritemsave.Description = desc;
                    tibleritemsave.category = "Lecture";
                    tibleritemsave.color = "#009688";
                    newDateTime = DatePick.Date.Add(TimePick.Time);
                    tibleritemsave.timeitem = newDateTime;
                    App.Database.SaveItem(tibleritemsave);
                }

                else
                    App.Database.SaveItem(tibleritemsave);

                Navigation.PushAsync(new Page2());
            }
        }

        void deleteClicked(object sender, EventArgs e)
        {
     
           App.Database.DeleteItem(itemshere.ID);
            Navigation.PushAsync(new Page2());
        }

        void cancelClicked(object sender, EventArgs e)
        {
           
            this.Navigation.PopAsync();
        }

        

        //protected override bool OnBackButtonPressed()
        //{
        //    base.OnBackButtonPressed();
        //    //Navigation.PushAsync(new Page2());
        //    return true;
        //}

        protected override bool OnBackButtonPressed()
        {
            return base.OnBackButtonPressed();
        }


    }
}
