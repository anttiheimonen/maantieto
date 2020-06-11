using System.Collections;
using System.Collections.Generic;

public class CountryData
{
    private string countryName;

    public CountryData(string name)
    {
        countryName = name;
    }

    public string GetName() => countryName;
}
