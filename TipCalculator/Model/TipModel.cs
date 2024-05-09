using System.ComponentModel;
using CommunityToolkit.Mvvm;
using CommunityToolkit.Mvvm.ComponentModel;

namespace TipCalculator.Model
{
    public partial class TipModel
    {
        public double BillTotal;
        public double TipPercent;
        public double SplitAmount;
        public double SplitTotal;
        public double TipAmount;

        //[ObservableProperty]
        //double billTotal;
        //[ObservableProperty]
        //double tipPercent;
        //[ObservableProperty]
        //int splitAmount;
        //[ObservableProperty]
        //double splitTotal;
        //[ObservableProperty]
        //double tipAmount;

        /*private double _billTotal;
        private double _tipPercent;
        private int _splitAmount;
        private double _splitTotal;
        private double _tipAmount;

        public double BillTotal
        {
            get
            {
                return _billTotal;
            }
            set
            {
                _billTotal = value;
                OnPropertyChanged(nameof(BillTotal));
            }
        }

        public double TipPercent
        {
            get
            {
                return _tipPercent;
            }
            set
            {
                _tipPercent = value;
                OnPropertyChanged(nameof(TipPercent));
            }
        }

        public int SplitAmount
        {
            get
            {
                return _splitAmount;
            }
            set
            {
                _splitAmount = value;
                OnPropertyChanged("SplitAmount");
            }
        }

        public double TipAmount
        {
            get
            {
                return _tipAmount;
            }
            set
            {
                _tipAmount = value;
                OnPropertyChanged("TipAmount");
            }
        }

        public double SplitTotal
        {
            get
            {
                return _splitTotal;
            }
            set
            {
                _splitTotal = value;
                OnPropertyChanged(nameof(SplitTotal));
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }*/
    }
}
