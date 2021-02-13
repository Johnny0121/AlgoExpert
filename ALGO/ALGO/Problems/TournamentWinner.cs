using System;
using System.Collections.Generic;

namespace ALGO.Problems
{
    // Problem: https://gyazo.com/96d932e9edfdb48f4c12e2b4423d4fe8?token=7323fb3d2ad64e800588defcb716ddef
    public class TournamentWinner : IProblem
    {
        private List<List<string>> Competitions;
        private List<int> Results;

        public TournamentWinner()
        {
            Competitions = new List<List<string>> {
                new List<string> { "HTML", "C#" },
                new List<string> { "C#", "Python" },
                new List<string> { "Python", "HTML" },
            };

            Results = new List<int> { 0, 0, 1 };
        }

        public void Run()
        {
            Console.WriteLine($"Winner: {HashtableMethod(Competitions, Results)}");
        }

        private string HashtableMethod(List<List<string>> competitions, List<int> results)
        {
            Dictionary<string, int> Teams = new Dictionary<string, int>();
            KeyValuePair<string, int> Winner = new KeyValuePair<string, int>("No team", 0);

            for (int i = 0; i < competitions.Count; i++)
            {
                List<string> match = competitions[i];

                if (results[i] == 0)
                {
                    if (!Teams.ContainsKey(match[1]))
                    {
                        Teams.Add(match[1], 0);
                    }

                    Teams[match[1]] += 3;

                    if (Teams[match[1]] > Winner.Value)
                    {
                        Winner = new KeyValuePair<string, int>(match[1], Teams[match[1]]);
                    }
                }
                else
                {
                    if (!Teams.ContainsKey(match[0]))
                    {
                        Teams.Add(match[0], 0);
                    }

                    Teams[match[0]] += 3;

                    if (Teams[match[0]] > Winner.Value)
                    {
                        Winner = new KeyValuePair<string, int>(match[0], Teams[match[0]]);
                    }
                }
            }

            return Winner.Key;
        }
    }
}
