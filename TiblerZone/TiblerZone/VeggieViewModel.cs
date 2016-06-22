using System.ComponentModel;

namespace TiblerZone
{
    public class VeggieViewModel : INotifyPropertyChanged
    {
        #region INotifyPropertyChanged implementation

        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        public string Name { get; set; }
        public string Location { get; set; }
        public string AddOnDesc { get; set; }
        public string Time { get; set; }
        public string Category { get; set; }

        public VeggieViewModel()
        {
        }


    }
}