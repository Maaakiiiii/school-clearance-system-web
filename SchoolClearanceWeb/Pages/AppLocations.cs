namespace SchoolClearanceWeb.Pages;
public static class AppLocations
{
    private static readonly Dictionary<string, Dictionary<string, List<string>>> ByCampus = new()
    {
        ["College Campus"] = new()
        {
            ["1st Floor"] = new()
            {
                "Room 101","Room 102","Room 103","Room 104","Room 105","Room 106",
                "Room 107","Room 110","Room 111","Software Laboratory 1",
                "Software Laboratory 3","Student Affair Office","Health Care Office",
                "Property Custodian (Storage Room 1)","Cashier",
                "Office of the Scholarship Coordinator","Guidance Office",
                "Deans Office","Admin Office","Registrar Office","Faculty Room",
                "Accounting","Clinic"
            },
            ["2nd Floor"] = new()
            {
                "Room 201","Room 202","Room 203","Room 204","Room 205","Room 206",
                "Room 207","Room 208","Room 209","Room 210",
                "Room 211 (Electronics Laboratory)","Room 214","Room 215",
                "Library","Technical Office"
            },
            ["3rd Floor"] = new()
            {
                "Room 301","Room 302","Software Laboratory 2","Software Laboratory 4",
                "Software Laboratory 5","Network Laboratory","Linux Laboratory",
                "Canteen","Mock Hotel","Culinary Laboratory"
            }
        },
        ["SHS Campus"] = new()
        {
            ["1st Floor"] = new() { "Room 104A","Room 105A","Student Canteen","Faculty" },
            ["2nd Floor"] = new() { "Room 201","Room 202","Room 203","Room 204","Room 205","CL1" },
            ["3rd Floor"] = new()
            {
                "Room 301","Room 302","Room 303","Room 304","Room 305",
                "Room 306","Room 307","Room 308","Room 309"
            },
            ["4th Floor"] = new()
            {
                "Room 401","Room 402","Room 403","Room 404","Room 405",
                "Room 406","Room 407","Room 408","HM Lab Stock Room 01",
                "HM Lab Room 01/409"
            }
        }
    };

    /// <summary>
    /// Returns { campus, floor } for a given room name, or null if not found.
    /// </summary>
    public static (string Campus, string Floor)? LocationOf(string? location)
    {
        if (string.IsNullOrEmpty(location)) return null;
        foreach (var campusEntry in ByCampus)
            foreach (var floorEntry in campusEntry.Value)
                if (floorEntry.Value.Contains(location))
                    return (campusEntry.Key, floorEntry.Key);
        return null;
    }

    /// <summary>
    /// Builds "College Campus · 2nd Floor · Technical Office" from a room name.
    /// Falls back to just the room name if not found in the map.
    /// </summary>
    public static string BuildLocationDisplay(string? location)
    {
        if (string.IsNullOrEmpty(location)) return "No location set";
        var info = LocationOf(location);
        if (info == null) return location;
        return $"{info.Value.Campus} · {info.Value.Floor} · {location}";
    }
}
