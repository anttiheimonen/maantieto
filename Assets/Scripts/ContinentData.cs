using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;


[DataContract]
public class ContinentData
{
    [DataMember]
    private string tag;

    [DataMember]
    private string continentName;

    [DataMember]
    private CountryData[] countriesArray;

    private Dictionary<string, CountryData> countries;

    private int numberOfCountries;


    /// Sets up a directory structure of countries so that countries can be
    /// get by tag.
    public void Initialize()
    {
        countries = new Dictionary<string, CountryData>();
        numberOfCountries = countriesArray.Length;

        foreach (var c in countriesArray)
        {
            countries.Add(c.GetTag(), c);
        }
    }


    public string GetName() => continentName;


    public string GetTag() => tag;


    public int GetNumberOfCountries() => numberOfCountries;


    public Dictionary<string, CountryData> GetCountries() =>
        countries;
}
