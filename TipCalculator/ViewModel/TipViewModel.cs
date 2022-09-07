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
        public TipViewModel()
        {
            tipModel.BillTotal = 0.00;
            tipModel.TipPercent = 10;
            tipModel.SplitAmount = 2;
            tipModel.SplitTotal = 0.00;
        }

        public void ChangeBillTotal(double newBillTotal)
        {
            if (newBillTotal < 0) return;
            tipModel.BillTotal = newBillTotal;
            CalculateSplitTotal();
        }

        public void ChangeSplitAmount(int newSplitAmount)
        {
            if (newSplitAmount < 0) return;
            tipModel.SplitAmount = newSplitAmount;
        }

        public void CalculateSplitTotal()
        {
            var tipPercent = 0.0;
            switch (tipModel.TipPercent)
            {
                case 10:
                    tipPercent = 0.10;
                    break;
                case 15:
                    tipPercent = 0.15;
                    break;
                case 20:
                    tipPercent = 0.20;
                    break;
                default:
                    break;
            }
            double billWithTip = tipModel.BillTotal + (tipModel.BillTotal * tipPercent);
            tipModel.SplitTotal = billWithTip / tipModel.SplitAmount;
        }

        public void IncrementSplitAmount()
        {
            tipModel.SplitAmount++;
            CalculateSplitTotal();
        }

        public void DecrementSplitAmount()
        {
            if (tipModel.SplitAmount <= 0) return;
            tipModel.SplitAmount--;
            CalculateSplitTotal();
        }
    }
}
