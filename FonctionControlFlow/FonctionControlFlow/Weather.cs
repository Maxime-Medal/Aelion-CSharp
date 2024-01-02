public class Weather
    {

    /// <summary>
    /// Switch Statement
    /// </summary>
    /// <param name="temperature"></param>
    /// <returns></returns>
    public static String Kind(Double temperature)
    {
        switch (temperature) {
            case < 5:
                return "COLD";
            case < 20:
                return "COOL";
            case 20:
                return "SPECIAL _20";
            default:
                return "HOT";
        }
    }

    /// <summary>
    /// Switch Statement
    /// </summary>
    /// <param name="temperature"></param>
    /// <returns></returns>
    public static String Kind2(Double temperature)
    {

        var res = "HOT";
        switch (temperature) {
            case < 5:
                res = "COLD";
            break;
            case < 19:
                res = "COOL";
            break;
            case 19:
            case 20:
                res = "SPECIAL 19_20";
            break;
        }
            return res;
    }

    /// <summary>
    /// Switch Expression
    /// </summary>
    /// <param name="temperature"></param>
    /// <returns></returns>
    public static String Kind3(Double temperature) => temperature switch
    {
        5 => "COLD",
        < 20 => "COOL",
        20 => "Special_20",
        _ => "HOT"
    };
    }
