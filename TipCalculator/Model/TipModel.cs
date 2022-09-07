using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TipCalculator.Model
{
    public class TipModel : INotifyPropertyChanged
    {
        private double _billTotal;
        private double _tipPercent;
        private int _splitAmount;
        private double _splitTotal;

        public double BillTotal
        {
            get
            {
                return _billTotal;
            }
            set
            {
                _billTotal = value;
                OnPropertyChanged(nameof(BillTotalLabel));
            }
        }

        public string BillTotalLabel
        {
            get
            {
                return "$ " + _billTotal;
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
                OnPropertyChanged(nameof(TipPercentLabel));
            }
        }

        public string TipPercentLabel
        {
            get
            {
                return _tipPercent + "%";
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

        public double SplitTotal
        {
            get
            {
                return _splitTotal;
            }
            set
            {
                _splitTotal = value;
                OnPropertyChanged(nameof(SplitTotalLabel));
            }
        }

        public string SplitTotalLabel
        {
            get
            {
                return String.Format("{0:0.00}", _splitTotal);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            var handler = PropertyChanged;
            if (handler != null)
                handler(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
