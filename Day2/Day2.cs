using System.IO;
using System.Net;
using System.Runtime.CompilerServices;

namespace AdventOfCode2024
{
    public class Day2
    {
        static bool isValid(int[] line)
        {
            bool safe = true, isAscending = true, isDescending = true;
            for(int x = 0; x < line.Length-1; x++){
                if(Math.Abs((line[x])-(line[x+1])) > 3 || Math.Abs((line[x])-(line[x+1])) < 1){safe = false; break;}
                if(line[x]<line[x+1]){isDescending = false;}
                if(line[x]>line[x+1]){isAscending = false;}
                if(!isDescending && !isAscending){safe = false; break;}
            }
            return safe;
        }
        public static void Solve()
        {
            string input = "../../../Day2/input.txt";
            string[] lines = File.ReadAllLines(input);

            int safeNo = 0;
            for(int i = 0; i < lines.Length; i++){
                int[] line = Array.ConvertAll(lines[i].Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries), int.Parse);
                if(isValid(line) == true){safeNo++;}
            }
            Console.WriteLine(safeNo);

            safeNo = 0;
            for(int i = 0; i < lines.Length; i++){
                int[] line = Array.ConvertAll(lines[i].Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries), int.Parse);
                if(isValid(line) == true){safeNo++;}
                else{
                    int[] line2 = new int[line.Length - 1];
                    for(int j = 0; j < line.Length; j++){
                        int index = 0;
                        for(int k = 0; k < line.Length; k++){
                            if(k == j){continue;}
                            line2[index++] = line[k];
                        }
                        if(isValid(line2) == true){safeNo++; break;}
                    }
                }
            }
            Console.WriteLine(safeNo);
        }
    }
}