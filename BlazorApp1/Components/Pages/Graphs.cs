public class StatePropertyHistory
{
    public string Name { get; set; }
    public string Desc { get; set; }
    public string Unit { get; set; }
    public DateTime Start { get; set; }
    public double DeltaT { get; set; }
    public List<double> Values { get; set; }
}

public class AssetStateHistory
{
    public List<StatePropertyHistory> Recorded { get; set; }
    public string Clazz { get; set; }

    public string Name{get;set;}
}
