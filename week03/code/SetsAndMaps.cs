using System.Text.Json;

public static class SetsAndMaps
{
    /// <summary>
    /// The words parameter contains a list of two character 
    /// words (lower case, no duplicates). Using sets, find an O(n) 
    /// solution for returning all symmetric pairs of words.  
    ///
    /// For example, if words was: [am, at, ma, if, fi], we would return :
    ///
    /// ["am & ma", "if & fi"]
    ///
    /// The order of the array does not matter, nor does the order of the specific words in each string in the array.
    /// at would not be returned because ta is not in the list of words.
    ///
    /// As a special case, if the letters are the same (example: 'aa') then
    /// it would not match anything else (remember the assumption above
    /// that there were no duplicates) and therefore should not be returned.
    /// </summary>
    /// <param name="words">An array of 2-character words (lowercase, no duplicates)</param>
    public static string[] FindPairs(string[] words)
    {
        var wordSet = new HashSet<string>(words);
        var result = new List<string>();

        foreach (var word in words)
        {
            string reversed = new string(word.Reverse().ToArray());

            // Avoid adding words with themselves or already processed pairs
            if (wordSet.Contains(reversed) && word != reversed)
            {
                result.Add($"{word} & {reversed}");
                wordSet.Remove(word); // Remove to avoid duplicates in result
                wordSet.Remove(reversed); // Remove to avoid duplicate pair matching
            }
        }

        return result.ToArray();
    }

    /// <summary>
    /// Read a census file and summarize the degrees (education)
    /// earned by those contained in the file.  The summary
    /// should be stored in a dictionary where the key is the
    /// degree earned and the value is the number of people that 
    /// have earned that degree.  The degree information is in
    /// the 4th column of the file.  There is no header row in the
    /// file.
    /// </summary>
    /// <param name="filename">The name of the file to read</param>
    /// <returns>fixed array of divisors</returns>
    public static Dictionary<string, int> SummarizeDegrees(string filename)
    {
        var degrees = new Dictionary<string, int>();
        foreach (var line in File.ReadLines(filename))
        {
            var fields = line.Split(",");
            string degree = fields[3]; // Degree is in the 4th column (index 3)

            // Increment the degree count
            if (degrees.ContainsKey(degree))
            {
                degrees[degree]++;
            }
            else
            {
                degrees[degree] = 1;
            }
        }

        return degrees;
    }

    /// <summary>
    /// Determine if 'word1' and 'word2' are anagrams.  An anagram
    /// is when the same letters in a word are re-organized into a 
    /// new word.  A dictionary is used to solve the problem.
    /// 
    /// Examples:
    /// is_anagram("CAT","ACT") would return true
    /// is_anagram("DOG","GOOD") would return false because GOOD has 2 O's
    /// 
    /// Important Note: When determining if two words are anagrams, you
    /// should ignore any spaces.  You should also ignore cases.  For 
    /// example, 'Ab' and 'Ba' should be considered anagrams
    /// 
    /// Reminder: You can access a letter by index in a string by 
    /// using the [] notation.
    /// </summary>
    public static bool IsAnagram(string word1, string word2)
    {
         // Remove spaces and convert to lower case
        word1 = word1.Replace(" ", "").ToLower();
        word2 = word2.Replace(" ", "").ToLower();

        if (word1.Length != word2.Length)
        {
            return false;
        }

        var charCount = new Dictionary<char, int>();

        foreach (var ch in word1)
        {
            if (charCount.ContainsKey(ch))
            {
                charCount[ch]++;
            }
            else
            {
                charCount[ch] = 1;
            }
        }

        foreach (var ch in word2)
        {
            if (!charCount.ContainsKey(ch))
            {
                return false;
            }

            charCount[ch]--;

            if (charCount[ch] == 0)
            {
                charCount.Remove(ch);
            }
        }

        return charCount.Count == 0; // If empty, the words are anagrams
    }

    /// <summary>
    /// This function will read JSON (Javascript Object Notation) data from the 
    /// United States Geological Service (USGS) consisting of earthquake data.
    /// The data will include all earthquakes in the current day.
    /// 
    /// JSON data is organized into a dictionary. After reading the data using
    /// the built-in HTTP client library, this function will return a list of all
    /// earthquake locations ('place' attribute) and magnitudes ('mag' attribute).
    /// Additional information about the format of the JSON data can be found 
    /// at this website:  
    /// 
    /// https://earthquake.usgs.gov/earthquakes/feed/v1.0/geojson.php
    /// 
    /// </summary>
    public static string[] EarthquakeDailySummary()
    {
        const string uri = "https://earthquake.usgs.gov/earthquakes/feed/v1.0/summary/all_day.geojson";
        using var client = new HttpClient();
        using var getRequestMessage = new HttpRequestMessage(HttpMethod.Get, uri);
        using var jsonStream = client.Send(getRequestMessage).Content.ReadAsStream();
        using var reader = new StreamReader(jsonStream);
        var json = reader.ReadToEnd();
        var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };

        var featureCollection = JsonSerializer.Deserialize<FeatureCollection>(json, options);

        var result = featureCollection.Features
              .Select(f => 
        {
            // If Mag has a value, display it. Otherwise, use "No Magnitude"
            var magnitude = f.Properties.Mag.HasValue 
                ? f.Properties.Mag.Value.ToString("0.00") // Format to 2 decimal places
                : "No Magnitude";
            
            // Construct the string in the required format
            return $"{f.Properties.Place} - Mag {magnitude}";
        })
        .ToArray();

        // TODO Problem 5:
        // 1. Add code in FeatureCollection.cs to describe the JSON using classes and properties 
        // on those classes so that the call to Deserialize above works properly.
        // 2. Add code below to create a string out each place a earthquake has happened today and its magitude.
        // 3. Return an array of these string descriptions.
        return result;
    }
}  