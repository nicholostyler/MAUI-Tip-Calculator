using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TipCalculator.Model;

namespace TipCalculator.ViewModel
{
    public class TipViewModel
    {
        public TipModel tipModel = new TipModel();
        public bool IsCents { get; set; }

        public TipViewModel()
        {
            tipModel.BillTotal = 0.00;
            tipModel.TipPercent = .10;
            tipModel.SplitAmount = 2;
            tipModel.SplitTotal = 0.00;
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
            tipModel.BillTotal = newBillTotal;
            CalculateSplitTotal();
        }

        public void ChangeTipPercentage(string tipPercent)
        {
            switch (tipPercent)
            {
                case "10%":
                    tipModel.TipPercent = .10;
                    CalculateSplitTotal();
                    break;
                case "15%":
                    tipModel.TipPercent = .15;
                    CalculateSplitTotal();
                    break;
                case "20%":
                    tipModel.TipPercent = .20;
                    CalculateSplitTotal();
                    break;
                default:
                    tipModel.TipPercent = .10;
                    CalculateSplitTotal();
                    break;
            }
        }

        public void ChangeSplitAmount(int newSplitAmount)
        {
            if (newSplitAmount < 0) return;
            tipModel.SplitAmount = newSplitAmount;
        }

        public void CalculateSplitTotal()
        {
            double billWithTip = tipModel.BillTotal + (tipModel.BillTotal * tipModel.TipPercent);
            tipModel.SplitTotal = billWithTip / tipModel.SplitAmount;
        }

        public void IncrementSplitAmount()
        {
            tipModel.SplitAmount++;
            CalculateSplitTotal();
        }

        public void DecrementSplitAmount()
        {
            if (tipModel.SplitAmount == 1) return;
            tipModel.SplitAmount--;
            CalculateSplitTotal();
        }
    }
}
