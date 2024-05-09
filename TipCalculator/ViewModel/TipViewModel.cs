using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipCalculator.Model;

namespace TipCalculator.ViewModel
{
    public partial class TipViewModel : ObservableObject
    {
        //public TipModel tipModel = new TipModel();
        public bool IsCents { get; set; }

        // Model 
        [ObservableProperty]
        double billTotal;
        [ObservableProperty]
        double tipPercent;
        [ObservableProperty]
        int splitAmount;
        [ObservableProperty]
        double splitTotal;
        [ObservableProperty]
        double tipAmount;
        [ObservableProperty]
        string billPrincipal;

        public TipViewModel()
        {
            BillTotal = 0.00;
            TipPercent = 10;
            SplitAmount = 2;
            SplitTotal = 0.00;
            IsCents = false;
        }

        public void ChangeCents()
        {
            if (IsCents == false)
            {
                IsCents = true;
            }
            else
            {
                IsCents = false;
            }
        }

        public void ChangeBillTotal(double newBillTotal)
        {
            if (newBillTotal < 0) return;
            BillTotal = newBillTotal;
            CalculateSplitTotal();
        }

        public void ChangeTipPercentage(string tipPercent)
        {
            switch (tipPercent)
            {
                case "10%":
                    TipPercent = 10;
                    CalculateSplitTotal();
                    break;
                case "15%":
                    TipPercent = 15;
                    CalculateSplitTotal();
                    break;
                case "20%":
                    TipPercent = 20;
                    CalculateSplitTotal();
                    break;
                default:
                    TipPercent = 10;
                    CalculateSplitTotal();
                    break;
            }
        }

        public void ChangeSplitAmount(int newSplitAmount)
        {
            if (newSplitAmount < 0) return;
            SplitAmount = newSplitAmount;
        }

        public void CalculateSplitTotal()
        {
            TipAmount = (BillTotal * (TipPercent / 100));
            double billWithTip = BillTotal + TipAmount;
            SplitTotal = billWithTip / SplitAmount;
        }

        public void IncrementSplitAmount()
        {
            SplitAmount++;
            CalculateSplitTotal();
        }

        public void DecrementSplitAmount()
        {
            if (SplitAmount == 1) return;
            SplitAmount--;
            CalculateSplitTotal();
        }

        [RelayCommand]
        private void DeleteButtonClicked()
        {

        }
    }
}
