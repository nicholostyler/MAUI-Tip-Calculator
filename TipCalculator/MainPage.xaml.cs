﻿using TipCalculator.ViewModel;

namespace TipCalculator;

public partial class MainPage : ContentPage
{
    public string BillPrincipal { get; set; }
    TipViewModel viewModel;

    public MainPage()
    {
        viewModel = new TipViewModel();
        InitializeComponent();
        MainGrid.BindingContext = viewModel;
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
            if (viewModel.BillPrincipal.Contains("."))
            {
                // Split the Principal
                string[] principalSplit = viewModel.BillPrincipal.Split('.');

                // if value after dot is two 00 then it is default
                if (principalSplit[1] == "00")
                {
                    viewModel.BillPrincipal = principalSplit[0] + "." + number;
                }
                else if (principalSplit[1].Count() == 2) 
                {
                    return;
                }
                else
                {
                    viewModel.BillPrincipal += number;
                }
                
            }
        }
        else
        {
            if (viewModel.BillPrincipal == "0.00")
            {
                viewModel.BillPrincipal = string.Empty;
            }
            viewModel.BillPrincipal += number;
        }

        SetLabelUpdateTotal();
    }

    private void DotButton_Tapped(object sender, EventArgs e)
    {
        // Dot button pressed
        if (viewModel.BillPrincipal.Contains("."))
        {
            return;
        }

        // Change the view to let viewmodel know its on the cents portion
        viewModel.ChangeCents();
        // add to main string 
        viewModel.BillPrincipal += ".00";
        //BillTotalLabel.Text = viewModel.BillPrincipal;
        SetLabelUpdateTotal();
    }

    private void DeleteButton_Tapped(object sender, EventArgs e)
    {
        if (viewModel.BillPrincipal == "0.00")
        {
            return;
        }
        
        viewModel.BillPrincipal = viewModel.BillPrincipal.Remove(viewModel.BillPrincipal.Length - 1, 1);

        // if string is empty
        if (viewModel.BillPrincipal.Length == 0)
        {
            ResetLabels();
            return;
        }
        
        

        SetLabelUpdateTotal();

        // if the next item in string is the dot.
        if (viewModel.BillPrincipal[viewModel.BillPrincipal.Length - 1] == '.')
        {
            viewModel.BillPrincipal = viewModel.BillPrincipal.Remove(viewModel.BillPrincipal.Length - 1, 1);
            viewModel.ChangeCents();
        }

    }

    private void ResetLabels()
    {
        viewModel.BillPrincipal = "0.00";
        viewModel.IsCents = false;
        SetLabelUpdateTotal();
    }

    private void SetLabelUpdateTotal()
    {
        //BillTotalLabel.Text = viewModel.BillPrincipal;
        double totalDouble = Double.Parse(viewModel.BillPrincipal);
        viewModel.ChangeBillTotal(totalDouble);
    }

    private void btnDecrease_Clicked(object sender, EventArgs e)
    {
        viewModel.DecrementSplitAmount();
        // if the split amount is 1 disable the button
        if (viewModel.SplitAmount == 1)
        {
            btnDecrease.IsEnabled = false;
        }
    }

    private void btnIncrease_Clicked(object sender, EventArgs e)
    {
        if (viewModel.SplitAmount == 1)
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

