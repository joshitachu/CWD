// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

 public class Asset
{
    public string type { get; set; }
    public Init init { get; set; }

    public Inputs inputs{get;set;}
}

public class Init
{
    public string name { get; set; }
    public string t0 { get; set; }
    public Dictionary<string, object> components { get; set; } // Move components here

    // Constructor to initialize the dictionary
    public Init()
    {
        components = new Dictionary<string, object>();
    }
}

public class Inputs
{
    public String type{get;set;}

     public Dictionary<string, object> components { get; set; } // Move components here

    // Constructor to initialize the dictionary
    public Inputs()
    {
        components = new Dictionary<string, object>();
    }
   
}

public class Installation
{
    public string type { get; set; }
    public Init init { get; set; }
    public List<Asset> assets { get; set; }
}

public class Root
{
    public Installation installation { get; set; }
}
