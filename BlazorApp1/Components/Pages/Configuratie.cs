using System.ComponentModel;

public class EmmaSysteem{

    public Installation installation{get;set;}


}

public class Installation{
    public Dictionary<string, object> assets { get; set; } // Change the type to Dictionary<string, object>

    public Init init{get;set;}

    public String type{get;set;}

}

public class EmmaPLC{

    public String type{get;set;}
    public Init init{get;set;}

    public Input? input{get;set;}

}


public class Asset{

     public EmmaPLC emma_plc {get;set;}

    public String? name{get;set;}
    public String type { get; set; }
    public Init init{get;set;}

    public Input input{get;set;}

    public Output? output{get;set;}

}

public class Init{

    public String name{get;set;}

    public String InitName {get;set;}

    public DateTime t0{get;set;}

    public int? power{get;set;}

}

public class Assets{
    public Dictionary<string, Asset> assets { get; set; }
}

public class Input{

}

public class Output{

}

public class Boilers{

    public string InputTickSetpoint { get; set; }
    public string InputTemperature { get; set; }
}


public class Laadpalen{

    public int NrOfPoles { get; set; }
    public int ChargesPerWeekPerPole { get; set; }
    public int RatedPowerInKwPerPole { get; set; }
    public string PoleType { get; set; }


}

public class Config{

    public int StandbyPower{get;set;}
    public int MaxPower{get;set;}


}
