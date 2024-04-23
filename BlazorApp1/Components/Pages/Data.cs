public class Installation
{
    public string type { get; set; }
    public Init Init { get; set; }
    public List<Asset> assets { get; set; }
}

public class Init
{
    public string Name { get; set; }
    public DateTime T0 { get; set; }
}

public class Asset
{
    public string Name { get; set; } = null!;
    public string Desc { get; set; }
    public string IconType { get; set; }
    public List<Property> Properties { get; set; }
    public List<InputOutput> Inputs { get; set; }
    public List<InputOutput> Outputs { get; set; }
}

public class Property
{
    public string Name { get; set; }
    public string Desc { get; set; }
    public object Value { get; set; }
    public bool Editable { get; set; }
    public string _Clazz { get; set; }
}

public class InputOutput
{
    public string Name { get; set; }
    public string Desc { get; set; }
    public string _Clazz { get; set; }
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


 public class YourDataModel
    {
        public string name { get; set; }
        public string desc { get; set; }
        public List<RecordedData> recorded { get; set; }
    }

    public class RecordedData
    {
        public string name { get; set; }
        public string desc { get; set; }
        public string unit { get; set; }
        public string start { get; set; }
        public double delta_t { get; set; }
        public List<double> values { get; set; }
    }

    
    
