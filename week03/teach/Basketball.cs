/*
 * CSE 212 Lesson 6C 
 * 
 * This code will analyze the NBA basketball data and create a table showing
 * the players with the top 10 career points.
 * 
 * Note about columns:
 * - Player ID is in column 0
 * - Points is in column 8
 * 
 * Each row represents the player's stats for a single season with a single team.
 */

using Microsoft.VisualBasic.FileIO;

public class Basketball
{
    public static void Run()
    {
        // Dictionary to store total points for each player
        var players = new Dictionary<string, int>();

        using var reader = new TextFieldParser("basketball.csv");
        reader.TextFieldType = FieldType.Delimited;
        reader.SetDelimiters(",");
        reader.ReadFields(); // Skip the header row

        while (!reader.EndOfData)
        {
            var fields = reader.ReadFields()!;
            var playerId = fields[0];
            var points = int.Parse(fields[8]);

            // Add points to the player's total
            if (players.ContainsKey(playerId))
            {
                players[playerId] += points;
            }
            else
            {
                players[playerId] = points;
            }
        }

        // Sort players by total points in descending order and take the top 10
        var topPlayers = players
            .OrderByDescending(p => p.Value)
            .Take(10)
            .ToList();

        // Print the top 10 players
        Console.WriteLine("Top 10 Players by Career Points:");
        Console.WriteLine("-------------------------------");
        Console.WriteLine($"{"Rank",-5} {"Player ID",-20} {"Total Points",10}");
        Console.WriteLine("-------------------------------");

        int rank = 1;
        foreach (var player in topPlayers)
        {
            Console.WriteLine($"{rank,-5} {player.Key,-20} {player.Value,10}");
            rank++;
        }
    }
}
    