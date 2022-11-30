namespace PerfectPay;

public partial class MainPage : ContentPage
{
    decimal bill;
    int tip;
    int noPersons = 1;
    
	public MainPage()
	{
		InitializeComponent();
	}

    private void CalculateTotal()
    {
        //Total tip
        var totalTip = (bill * tip) / 100;

        //Tip by person
        var tipByPerson = totalTip / noPersons;
        lblTipByPerson.Text = $"{tipByPerson:C}";

        //Subtotal
        var subTotal = bill / noPersons;
        lblSubtotal.Text = $"{subTotal:C}";

        //Total by person
        var totalByPerson = (bill + totalTip) / noPersons;
        lblTotal.Text = $"{totalByPerson:C}";
    }

    private void TxtBill_Completed(object sender, EventArgs e)
    {
        bill = decimal.Parse(txtBill.Text);
        CalculateTotal();
    }

    private void BtnTip_Clicked(object sender, EventArgs e)
    {
        if (sender is Button btn)
        {
            var percentage = int.Parse(btn.Text.Replace("%", ""));
            sldTip.Value = percentage;
        }
    }

    private void SldTip_ValueChanged(object sender, ValueChangedEventArgs e)
    {
        tip = (int)sldTip.Value;
        lblTip.Text = $"Tip: {tip}%";
        CalculateTotal();
    }

    private void BtnMinus_Clicked(object sender, EventArgs e)
    {
        if (noPersons > 1)
            noPersons--;
        lblNoPersons.Text = noPersons.ToString();
        CalculateTotal();
    }

    private void BtnPlus_Clicked(object sender, EventArgs e)
    {
        noPersons++;
        lblNoPersons.Text = noPersons.ToString();
        CalculateTotal();
    }
}

