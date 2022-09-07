using Microsoft.Maui.Controls;
using System.ComponentModel;
using TipCalculator.ViewModel;

namespace TipCalculator;

public partial class MainPage : ContentPage
{
	public string BillPrincipal { get; set; }
	private bool isCents = false;
	TipViewModel viewModel;

    public MainPage()
	{
		viewModel = new TipViewModel();
		InitializeComponent();
        MainGrid.BindingContext = viewModel.tipModel;
        TipPercentPicker.SelectedIndex = 0;

    }

	private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
	{
		Border parentBorder = sender as Border;
		Label child = parentBorder.Content as Label;
		if (child == null) return;
		string number = child.Text;

		if (isCents == true)
		{
			int index = BillPrincipal.IndexOf('.');
            if (index > 0)
            {
                BillPrincipal = BillPrincipal.Substring(0, index);
                BillPrincipal += "." + number;
                BillTotalLabel.Text = "$ " + BillPrincipal;
                isCents = false;
            }
			
        }
		else
		{
            BillPrincipal += number;
            BillTotalLabel.Text = "$ " + BillPrincipal;
        }

        double totalDouble = Double.Parse(BillPrincipal);
		
        // update viewmodel
        viewModel.ChangeBillTotal(totalDouble);


    }

    private void TapGestureRecognizer_Tapped_1(object sender, EventArgs e)
	{
        if (BillPrincipal.Contains("."))
        {
            return;
        }

        isCents = true;
		BillPrincipal += ".";
        BillTotalLabel.Text = "$ " + BillPrincipal;
        // dot pressed
        

        //BillPrincipal += ".00";
        //double totalDouble = Double.Parse(BillPrincipal);
        // update viewmodel
        //viewModel.ChangeBillTotal(totalDouble);
    }

	private void TapGestureRecognizer_Tapped_2(object sender, EventArgs e)
	{
        // delete button
        BillPrincipal = BillPrincipal.Remove(BillPrincipal.Length - 1, 1);

    }

	private void btnDecrease_Clicked(object sender, EventArgs e)
	{
		viewModel.DecrementSplitAmount();
	}

	private void btnIncrease_Clicked(object sender, EventArgs e)
	{
		viewModel.IncrementSplitAmount();
	}
}

