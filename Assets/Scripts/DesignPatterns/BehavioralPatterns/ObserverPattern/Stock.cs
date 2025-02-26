using System.Collections.Generic;
using UnityEngine;

public class Stock
{
    private string _symbol;
    private double _price;
    private List<IInvestor> _investors = new List<IInvestor>();

    public double Price
    {
        get { return _price; }
        set
        {
            if (_price != value)
            {
                _price = value;
                Notify();
            }
        }
    }
    public string Symbol
    {
        get { return _symbol; }
    }

    public Stock(string symbol, double price)
    {
        _price = price;
        _symbol = symbol;
    }

    public void AddSubscriber(IInvestor investor)
    {
        _investors.Add(investor);
    }

    public void RemoveSubscriber(IInvestor investor)
    {
        if (_investors.Contains(investor))
        {
            _investors.Remove(investor);
        }
    }

    public void Notify()
    {
        foreach (IInvestor investor in _investors)
        {
            investor.Update(this);
        }
    }
}


class IBM : Stock
{
    public IBM(string symbol, double price) : base(symbol, price)
    {
    }
}