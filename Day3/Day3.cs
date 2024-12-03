using System.IO;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2024
{
    public class Day3
    {
        public static void Solve()
        {
            string input = "../../../Day3/input.txt";
            string data = File.ReadAllText(input);
            int ans = 0;
            string sPattern = @"mul\(\d+,\d+\)";
            var matches = Regex.Matches(data, sPattern);
            int[] values = new int[2];
            int index = 0;
            foreach(Match match in matches){
                string sPattern2 = @"\d+";
                foreach(Match match2 in Regex.Matches(match.Value, sPattern2)){
                    values[index] = int.Parse(match2.Value);
                    index++;
                }
                ans += values[0] * values[1];
                index = 0;
            }

            Console.WriteLine(ans);
            ans = 0;
            bool mul = true;
            index = 0;

            sPattern = @"do\(\)|don't\(\)|mul\(\d+,\d+\)";
            matches = Regex.Matches(data, sPattern);
            foreach(Match match in matches){
                if(match.Value == "do()"){mul = true;}
                else if(match.Value == "don't()"){mul = false;}
                else{
                    if(mul == true){
                        string sPattern2 = @"\d+";
                        foreach(Match match2 in Regex.Matches(match.Value, sPattern2)){
                            values[index] = int.Parse(match2.Value);
                            index++;
                        }
                        ans += values[0] * values[1];
                        index = 0;
                    }
                }
            }
            Console.WriteLine(ans);
        }
    }
}