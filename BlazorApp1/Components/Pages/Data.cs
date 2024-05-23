

//selected asset in een service opslaan
using System.Text;
using System.Text.Json;

public class AssetService
{
    private Roott _selectedAsset;
    public Roott SelectedAsset
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

 public class Output
    {
        public string name { get; set; }
        public string desc { get; set; }
        public string _clazz { get; set; }
    }

    public class Propertyy
    {
        public string name { get; set; }
        public string desc { get; set; }
        public object value { get; set; }
        public bool editable { get; set; }
        public string _clazz { get; set; }
    }

    //data van de assets config

    public class Roott
    {
        public string name { get; set; }
        public string desc { get; set; }
        public string icon_type { get; set; }
        public List<Propertyy> properties { get; set; }
        public List<object> inputs { get; set; }
        public List<Output> outputs { get; set; }
        public string _clazz { get; set; }
    }




//Data van de grafiek
public class StatePropertyHistory
{
    public string name { get; set; }
    public string desc { get; set; }
    public string unit { get; set; }
    public string Start { get; set; }
    public double delta_t { get; set; }
    public List<double> values { get; set; }
    public string _clazz { get; set; }
}

public class AssetStateHistory
{
    public List<StatePropertyHistory> recorded { get; set; }
    public string desc { get; set; }
    public string name { get; set; }
    public string result_table_base64 { get; set; }
}

public class RunSimulationEndpointResponse
{
    public List<AssetStateHistory> asset_history { get; set; }
    public string result_table_base64 { get; set; }
    public string _clazz { get; set; }
}



public class AssetDataService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiUrl = "http://3.72.197.240:5001/fetch_assets_config";
    private readonly string _token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjoiY29fbWFrZXIifQ.NQYYS882LhzIyx7CrynwbRub8cf-6ic7KvGwyk77WC8";
    private List<Roott> _assets;
    private bool _isDataFetched = false;

    public bool IsLoading { get; private set; } = false;

    public AssetDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<Roott>> GetAssetsAsync()
    {
        if (!_isDataFetched)
        {
            IsLoading = true;
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
            _assets = await _httpClient.GetFromJsonAsync<List<Roott>>(_apiUrl);
            _isDataFetched = true;
            IsLoading = false;
        }
        return _assets;
    }
}


public class SimulationDataService
{
    private readonly HttpClient _httpClient;
    private readonly string _apiUrl = "http://3.72.197.240:5001/run_simulation";
    private readonly string _token = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1c2VyIjoiY29fbWFrZXIifQ.NQYYS882LhzIyx7CrynwbRub8cf-6ic7KvGwyk77WC8";
    public List<AssetStateHistory> _bigData;
    private bool _isDataFetched = false;

    public bool IsLoading { get;  set; } = false;
    public string DecodedHtml { get; private set; }

    public SimulationDataService(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public async Task<List<AssetStateHistory>> GetSimulationDataAsync()
    {
        if (!_isDataFetched)
        {
            IsLoading = true;

            var payload = new
            {
                runner_update = new
                {
                    start = "2023-01-01T00:00:00",
                    end = "2023-01-02T00:00:00",
                    _clazz = "SimulationConfigJson"
                },
                assets_update = new object[] { },
                _clazz = "RunSimulationEndpointRequest"
            };

            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);
            var responseMessage = await _httpClient.PostAsJsonAsync(_apiUrl, payload);

            if (responseMessage != null)
            {
                var json = await responseMessage.Content.ReadAsStringAsync();
                var responseObj = JsonSerializer.Deserialize<RunSimulationEndpointResponse>(json);

                if (responseObj != null)
                {
                    _bigData = responseObj.asset_history;
                    DecodedHtml = DecodeBase64(responseObj.result_table_base64);
                }

                _isDataFetched = true;
            }

           
        }
        IsLoading = false;

        return _bigData;
    }

    public string DecodeBase64(string base64String)
{
    if (string.IsNullOrEmpty(base64String))
    {
        return string.Empty;
    }

    try
    {
        var base64EncodedBytes = Convert.FromBase64String(base64String);
        return Encoding.UTF8.GetString(base64EncodedBytes);
    }
    catch (FormatException)
    {
        // Handle invalid Base64 string
        return string.Empty;
    }
}


}


