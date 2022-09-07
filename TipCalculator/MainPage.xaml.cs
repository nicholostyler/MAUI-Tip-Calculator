using Microsoft.Maui.Controls;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using TipCalculator.ViewModel;

namespace TipCalculator;

public partial class MainPage : ContentPage
{
    public string BillPrincipal { get; set; }
    TipViewModel viewModel;

    public MainPage()
    {
        viewModel = new TipViewModel();
        InitializeComponent();
        MainGrid.BindingContext = viewModel.tipModel;
        TipPercentPicker.SelectedIndex = 0;
    }

    private void Number_Tapped(object sender, EventArgs e)
    {
        // Get the number by navigating through tree.
        Border parentBorder = sender as Border;
        Label child = parentBorder.Content as Label;
        if (child == null) return;
        // the number the user tapped on 
        string number = child.Text;

        // if the user is editing the cents
        if (viewModel.IsCents == true)
        {
            // if the string contains the dot 
            int index = BillPrincipal.IndexOf('.');
            if (index > 0)
            {
                // remove the dot and add it again with the number
                BillPrincipal = BillPrincipal.Substring(0, index);
                BillPrincipal += "." + number;
                viewModel.IsCents = false;
            }

        }
        else
        {
            BillPrincipal += number;
        }

        SetLabelUpdateTotal();
    }

    private void DotButton_Tapped(object sender, EventArgs e)
    {
        // Dot button pressed
        if (BillPrincipal.Contains("."))
        {
            return;
        }

        // Change the view to let viewmodel know its on the cents portion
        viewModel.ChangeCents();
        // add to main string 
        BillPrincipal += ".";
        BillTotalLabel.Text = BillPrincipal;
    }

    private void DeleteButton_Tapped(object sender, EventArgs e)
    {
        // delete button
        //if (BillPrincipal.Length > 0)
        // remove the next item in string
        BillPrincipal = BillPrincipal.Remove(BillPrincipal.Length - 1, 1);

        // if string is empty
        if (BillPrincipal.Length <= 0)
        {
            ResetLabels();
            return;
        }

        SetLabelUpdateTotal();

        // if the next item in string is the dot.
        if (BillPrincipal[BillPrincipal.Length - 1] == '.')
        {
            BillPrincipal = BillPrincipal.Remove(BillPrincipal.Length - 1, 1);
        }

    }

    private void ResetLabels()
    {
        BillTotalLabel.Text = "0.00";
    }

    private void SetLabelUpdateTotal()
    {
        BillTotalLabel.Text = BillPrincipal;
        double totalDouble = Double.Parse(BillPrincipal);
        viewModel.ChangeBillTotal(totalDouble);
    }

    private void btnDecrease_Clicked(object sender, EventArgs e)
    {
        viewModel.DecrementSplitAmount();
        // if the split amount is 1 disable the button
        if (viewModel.tipModel.SplitAmount == 1)
        {
            btnDecrease.IsEnabled = false;
        }
    }

    private void btnIncrease_Clicked(object sender, EventArgs e)
    {
        if (viewModel.tipModel.SplitAmount == 1)
        {
            btnDecrease.IsEnabled = true;
        }

        viewModel.IncrementSplitAmount();
    }

    private void TipPercentPicker_SelectedIndexChanged(object sender, EventArgs e)
    {
        viewModel.ChangeTipPercentage(TipPercentPicker.SelectedItem as string);
    }
}

