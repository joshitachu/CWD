// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

 public class Asset
{
    public string type { get; set; }
    public Init init { get; set; }

    public Inputs? inputs{get;set;}

    public Outputs? outputs{get;set;}

}


public class Outputs{
    public Dictionary<string,object> components{get;set;}

    public Outputs(){
        this.components= new Dictionary<string, object>();
    }

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

     public Dictionary<string, object>? components { get; set; } // Move components here

    // Constructor to initialize the dictionary
    public Inputs()
    {
        this.components = new Dictionary<string, object>();
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


public class SharedService
{
    public Asset SelectedAsset { get; set; }
}


public class AssetStateService
{
    private Asset _selectedAsset;
    public Asset SelectedAsset
    {
        get => _selectedAsset;
        set
        {
            _selectedAsset = value;
            NotifyAssetSelectionChanged();
        }
    }

    public event Action OnAssetSelectionChanged;

    private void NotifyAssetSelectionChanged() => OnAssetSelectionChanged?.Invoke();
}

