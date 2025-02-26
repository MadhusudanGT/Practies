using UnityEngine;

public class Investor : IInvestor
{
    private string _investorName;
    private string stocks;

    public string Stocks
    {
        get { return stocks; }
        set
        {
            if (stocks != value)
            {
                stocks = value;
            }
        }
    }

    public Investor(string name)
    {
        this._investorName = name;
    }
    public void Update(Stock stock)
    {
        Debug.Log($"{_investorName} get notify by the {stock.Symbol} new value is {stock.Price}");
    }
}
