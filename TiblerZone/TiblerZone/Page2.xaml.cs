using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace TiblerZone
{
    public partial class Page2 : ContentPage
    {


        TiblerItem todoItem = null;
        TiblerItem tibyy = new TiblerItem();
        Dictionary<string, String> nameToColor = new Dictionary<string, String>
        {
            {"All","All" },
            { "Lecture", "Lecture" },
            { "Task", "Task"},
            { "Meeting", "Meeting" }

        };
        protected override void OnAppearing()
        {
            MainListView.SelectedItem = null;
        }
        public Page2()
        {
            InitializeComponent();

            string lectureColor = "#009688";
            string taskColor = "#2196F3";
            string meetingcolor = "#FF5722";
            NavigationPage.SetHasBackButton(this, false);
          
            foreach (var total in App.Database.GetItemsList())
            {
                if (total.timeitem < DateTime.Today)
                {
                    App.Database.DeleteItem(total.ID);
                 

                }

                else if (total.timeitem.Date== DateTime.Today && total.timeitem.TimeOfDay < DateTime.Now.TimeOfDay)
                {
                 
                    
                        App.Database.DeleteItem(total.ID);
                    

                }
            }


                Label header = new Label
            {
                Text = "Picker",
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label)),
                HorizontalOptions = LayoutOptions.Center
            };


            Picker picker = new Picker
            {

                Title = "",
                VerticalOptions = LayoutOptions.CenterAndExpand,
                SelectedIndex = 0

            };

            Label blantext = new Label();
            blantext.VerticalTextAlignment = TextAlignment.Start;
            blantext.HorizontalTextAlignment = TextAlignment.Center;
            blantext.FontAttributes = FontAttributes.Bold;
            blantext.FontSize = 24;
            blantext.TextColor = Color.Gray;

            List<TiblerItem> list = new List<TiblerItem>();
            foreach (var total in App.Database.GetItemsList())
            {
                if (total.timeitem.Date == DateTime.Today.Date)
                {
                    total.stringDate = "Today at " + total.timeitem.ToString("hh:mm tt");
                }

                else if (total.timeitem.Date == DateTime.Today.Date.AddDays(1))
                {
                    total.stringDate = "Tomorrow at " + total.timeitem.ToString("hh:mm tt");
                }
                else if (total.timeitem.Date >= DateTime.Today.Date.AddDays(2) && total.timeitem.Date <= DateTime.Today.Date.AddDays(7))
                {
                    total.stringDate = total.timeitem.ToString("ddd, hh:mm tt");
                }
                else
                {
                    total.stringDate = total.timeitem.ToString("dd MMM, hh:mm tt");

                }

                if (total.Description.Length > 25)
                {

                    total.Description = total.Description.Substring(0, 25);
                    total.Description = total.Description + "...";
                }


                if (total.Name.Length > 25)
                {
                     total.Name = total.Name.Substring(0, 25);
                    total.Name = total.Name + "...";


                }

                if (total.Location.Length > 15)
                {
                    total.Location = total.Location.Substring(0, 15);


                }


                if (total.category == "Lecture")
                {
                    total.color = lectureColor;
                    list.Add(total);
                }

                else if (total.category == "Task")
                {
                    total.color = taskColor;
                    list.Add(total);
                }


                else if (total.category == "Meeting")
                {
                    total.color = meetingcolor;
                    list.Add(total);
                }

                else
                {
                    total.color = lectureColor;
                }


            }
            MainListView.ItemsSource = list;

            String selectedcat = null;

            picker.SelectedIndexChanged += (sender, args) =>
            {
                selectedcat = picker.Items[picker.SelectedIndex];

                if (selectedcat == "All")
                {
                    List<TiblerItem> list1 = new List<TiblerItem>();
                    foreach (var total in App.Database.GetItemsList())
                    {
                        if (total.Description.Length > 25)
                        {
                            total.Description = total.Description.Substring(0, 25);
                            total.Description = total.Description + "...";  
                        }


                        if (total.Name.Length > 25)
                        {

                            total.Name = total.Name.Substring(0, 25);
                            total.Name = total.Name + "...";

                        }

                        if (total.Location.Length > 15)
                        {



                            total.Location = total.Location.Substring(0, 15);


                        }

                        if (total.timeitem.Date==DateTime.Today.Date)
                        {
                            total.stringDate = "Today at " + total.timeitem.ToString("hh:mm tt");
                        }

                        else if (total.timeitem.Date == DateTime.Today.Date.AddDays(1))
                        {
                            total.stringDate = "Tomorrow at " + total.timeitem.ToString("hh:mm tt");
                        }
                       else if (total.timeitem.Date >= DateTime.Today.Date.AddDays(2) && total.timeitem.Date <= DateTime.Today.Date.AddDays(7))
                        {
                            total.stringDate = total.timeitem.ToString("ddd, hh:mm tt");
                        }
                        else
                        {
                            total.stringDate = total.timeitem.ToString("dd MMM, hh:mm tt");
                        }

                        if (total.category == "Lecture")
                        {
                            total.color = lectureColor;
                            list1.Add(total);
                        }

                        else if (total.category == "Task")
                        {
                            total.color = taskColor;
                            list1.Add(total);
                        }


                        else if (total.category == "Meeting")
                        {
                            total.color = meetingcolor;
                            list1.Add(total);
                        }

                        else
                        {
                            total.color = lectureColor;
                        }


                    }
                    MainListView.ItemsSource = list1;
                    if (list1.Count() == 0)
                    {
                         blantext.Text = "You Can Start Adding Items";
                        GridMain.Children.Add(blantext);
                        Grid.SetRow(blantext, 2);
                        blantext.IsVisible = true;
                 
                        blantext.HorizontalTextAlignment = TextAlignment.Center;
                    
                    }
                    else
                    {
                        blantext.IsVisible = false;
                        blantext.Text = "";
                    }
             
                }

                

                else if (selectedcat == "Lecture")
                {
                    List<TiblerItem> list2 = new List<TiblerItem>();
                    foreach (var total in App.Database.GetItemsLecture())
                    {
                        if (total.timeitem.Date == DateTime.Today.Date)
                        {
                            total.stringDate = "Today at " + total.timeitem.ToString("hh:mm tt");
                        }

                        else if (total.timeitem.Date == DateTime.Today.Date.AddDays(1))
                        {
                            total.stringDate = "Tomorrow at " + total.timeitem.ToString("hh:mm tt");
                        }
                        else if (total.timeitem.Date >= DateTime.Today.Date.AddDays(2) && total.timeitem.Date <= DateTime.Today.Date.AddDays(7))
                        {
                            total.stringDate = total.timeitem.ToString("ddd, hh:mm tt");
                        }
                        else
                        {
                            total.stringDate = total.timeitem.ToString("dd MMM, hh:mm tt");
                        }

                        if (total.Description.Length > 25)
                        {

                            total.Description = total.Description.Substring(0, 25);
                            total.Description = total.Description + "...";




                        }


                        if (total.Name.Length > 25)
                        {



                            total.Name = total.Name.Substring(0, 25);
                            total.Name = total.Name + "...";

                        }

                        if (total.Location.Length > 15)
                        {



                            total.Location = total.Location.Substring(0, 15);


                        }
                        total.color = lectureColor;

                        list2.Add(total);



                    }
                    MainListView.ItemsSource = list2;
                    if (list2.Count() == 0)
                    {
                        blantext.Text = "You Can Start Adding Lecture";


                        blantext.IsVisible = true;
                        blantext.HorizontalTextAlignment = TextAlignment.Center;

                        GridMain.Children.Add(blantext);
                        Grid.SetRow(blantext, 2);
                       
                    }
                    else
                    {
                        blantext.IsVisible = false;
                        blantext.Text = "";
                    }
                }

                else if (selectedcat == "Task")
                {
              
                  

                    List<TiblerItem> list3 = new List<TiblerItem>();
                    foreach (var total in App.Database.GetItemsTask())
                    {
                        if (total.timeitem.Date == DateTime.Today.Date)
                        {
                            total.stringDate = "Today at " + total.timeitem.ToString("hh:mm tt");
                        }

                        else if (total.timeitem.Date == DateTime.Today.Date.AddDays(1))
                        {
                            total.stringDate = "Tomorrow at " + total.timeitem.ToString("hh:mm tt");
                        }
                        else if (total.timeitem.Date >= DateTime.Today.Date.AddDays(2) && total.timeitem.Date <= DateTime.Today.Date.AddDays(7))
                        {
                            total.stringDate = total.timeitem.ToString("ddd, hh:mm tt");
                        }
                        else
                        {
                            total.stringDate = total.timeitem.ToString("dd MMM, hh:mm tt");
                        }
                        if (total.Description.Length > 25)
                {

                    total.Description = total.Description.Substring(0, 25);
                    total.Description = total.Description + "...";

                }


                if (total.Name.Length > 25)
                {
                     total.Name = total.Name.Substring(0, 25);
                     total.Name = total.Name + "...";
                }

                if (total.Location.Length > 15)
                {
                    total.Location = total.Location.Substring(0, 15);
                }
                        total.color = taskColor;
                        list3.Add(total);

              

                    }
                    MainListView.ItemsSource = list3;
                    if (list3.Count() == 0)
                    {
                        blantext.Text = "You Can Start Adding Tasks";
                        blantext.IsVisible = true;
                        blantext.HorizontalTextAlignment = TextAlignment.Center;
                        GridMain.Children.Add(blantext);
                        Grid.SetRow(blantext, 2);
                    }
                    else
                    {
                        blantext.IsVisible = false;
                        blantext.Text = "";
                    }
                }

                else if (selectedcat == "Meeting")
                {
                    List<TiblerItem> list4 = new List<TiblerItem>();
                    foreach (var total in App.Database.GetItemsMeeting())
                    {
                        if (total.timeitem.Date == DateTime.Today.Date)
                        {
                            total.stringDate = "Today at " + total.timeitem.ToString("hh:mm tt");
                        }

                        else if (total.timeitem.Date == DateTime.Today.Date.AddDays(1))
                        {
                            total.stringDate = "Tomorrow at " + total.timeitem.ToString("hh:mm tt");
                        }
                        else if (total.timeitem.Date >= DateTime.Today.Date.AddDays(2) && total.timeitem.Date <= DateTime.Today.Date.AddDays(7))
                        {
                            total.stringDate = total.timeitem.ToString("ddd, hh:mm tt");
                        }
                        else
                        {
                            total.stringDate = total.timeitem.ToString("dd MMM, hh:mm tt");
                        }
                        if (total.Description.Length > 25)
                        {
                            total.Description = total.Description.Substring(0, 25);
                            total.Description = total.Description + "...";
                        }


                        if (total.Name.Length > 25)
                        {
                            total.Name = total.Name.Substring(0, 25);
                            total.Name = total.Name + "...";
                        }

                        if (total.Location.Length > 15)
                        {
                            total.Location = total.Location.Substring(0, 15);
                        }
                        total.color = meetingcolor;
                        list4.Add(total);



                    }
                  
                    MainListView.ItemsSource = list4;
                    if (list4.Count() == 0)
                    {
                        blantext.Text = "You Can Start Adding Meetings";
                        blantext.IsVisible = true;
                        blantext.HorizontalTextAlignment = TextAlignment.Center;
                        GridMain.Children.Add(blantext);
                        Grid.SetRow(blantext, 2);
                    }
                    else
                    {
                        blantext.IsVisible = false;
                        blantext.Text = "";
                    }
                }

                else
                {

                    List<TiblerItem> list5 = new List<TiblerItem>();
                    foreach (var total in App.Database.GetItemsList())
                    {
                        if (total.timeitem.Date == DateTime.Today.Date)
                        {
                            total.stringDate = "Today at " + total.timeitem.ToString("hh:mm tt");
                        }

                        else if (total.timeitem.Date == DateTime.Today.Date.AddDays(1))
                        {
                            total.stringDate = "Tomorrow at " + total.timeitem.ToString("hh:mm tt");
                        }
                        else if (total.timeitem.Date >= DateTime.Today.Date.AddDays(2) && total.timeitem.Date <= DateTime.Today.Date.AddDays(7))
                        {
                            total.stringDate = total.timeitem.ToString("ddd, hh:mm tt");
                        }
                        else
                        {
                            total.stringDate = total.timeitem.ToString("dd MMM, hh:mm tt");
                        }
                        if (total.Description.Length > 25)
                        {
                            total.Description = total.Description.Substring(0, 25);
                            total.Description = total.Description + "...";

                        }


                        if (total.Name.Length > 25)
                        {
                            total.Name = total.Name.Substring(0, 25);
                            total.Name = total.Name + "...";
                        }

                        if (total.Location.Length > 15)
                        {



                            total.Location = total.Location.Substring(0, 15);


                        }
                        total.color = lectureColor;
                        list5.Add(total);



                    }
                    MainListView.ItemsSource = list5;
                    if (list5.Count() == 0)
                    {
                        blantext.Text = "You Can Start Adding Items";
                  

                        blantext.IsVisible = true;
                        blantext.HorizontalTextAlignment = TextAlignment.Center;

                        GridMain.Children.Add(blantext);
                        Grid.SetRow(blantext, 2);
                    }
                    else
                    {
                        blantext.IsVisible = false;
                        blantext.Text = "";
                    }
                }

            };

         
            GridMain.Children.Add(picker);
            Grid.SetRow(picker, 1);
            foreach (string colorName in nameToColor.Keys)
            {
                picker.Items.Add(colorName);
            
            }
            picker.SelectedIndex = 0;
            this.Padding = new Thickness(10, Device.OnPlatform(20, 0, 0), 10, 5);


  


        }
        public void gotoadd(object sender, EventArgs e)
        {
         
            Navigation.PushAsync(new EditAdd());
        }

        public void gotoaddtask(object sender, EventArgs e)
        {

            Navigation.PushAsync(new EditAddTask());
        }

        public void gotoaddmeeting(object sender, EventArgs e)
        {

            Navigation.PushAsync(new EditAddMeeting());
        }

        void listItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if (e.SelectedItem == null) return;

            todoItem = (TiblerItem)e.SelectedItem;
         
            if (todoItem.category == "Lecture")
            {
            
                Navigation.PushAsync(new EditAdd(todoItem.ID));
            }

            else if (todoItem.category == "Task")
            {
                Navigation.PushAsync(new EditAddTask(todoItem.ID));
            }

            else if (todoItem.category == "Meeting")
            {
                Navigation.PushAsync(new EditAddMeeting(todoItem.ID));
            }

            else
            {
                Navigation.PushAsync(new EditAdd(todoItem.ID));
            }
            todoItem= null;

       
        }
    

       

    }


}
