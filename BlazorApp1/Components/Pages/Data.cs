// Root myDeserializedClass = JsonConvert.DeserializeObject<Root>(myJsonResponse);

 public class Asset
{
    public string type { get; set; }
    public Init init { get; set; }

    public Inputs? inputs{get;set;}

    public Outputs? outputs{get;set;}

    public string? name{get;set;}

    public string? desc{get;set;}

    public List<Property>? Properties { get; set; }


    public string? icon_type{get;set;}

}

    public class Property
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        
        public bool Editable { get; set; }

         public Dictionary<string,object> value{get;set;}


        public Property(){
            this.value= new Dictionary<string, object>();
        }

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

    

public class RecordedData
{
    public string Name { get; set; }
    public string Desc { get; set; }
    public List<DataRecord> Recorded { get; set; }
}

public class DataRecord
{
    public string Name { get; set; }
    public string Desc { get; set; }
    public string Unit { get; set; }
    public DateTime Start { get; set; }
    public int DeltaT { get; set; }
    public List<double> Values { get; set; }
}