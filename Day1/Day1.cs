using System.IO;
using System.Linq;

namespace AdventOfCode2024
{
    public class Day1
    {
        public static void Solve()
        {
            string input = "../../../Day1/input.txt";
            string[] lines = File.ReadAllLines(input);
            int[] array1 = new int[lines.Length]; int[] array2 = new int[lines.Length];

            for(int i = 0; i < lines.Length; i++){
                string[] columns = lines[i].Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries);
                array1[i] = int.Parse(columns[0]);
                array2[i] = int.Parse(columns[1]);
            }

            int[] array3 = new int[array1.Length];
            int ans = 0;

            Array.Sort(array1);
            Array.Sort(array2);

            for(int i = 0; i < array1.Length; i++){ array3[i]=Math.Abs(array1[i]-array2[i]); }
            for(int i = 0; i < array3.Length; i++){ ans += array3[i]; }
            Console.WriteLine(ans);

            ans = 0;
            for(int i = 0; i < array1.Length; i++){
                int count = array2.Count(x => x == array1[i]);
                ans += array1[i]*count;
            }
            Console.WriteLine(ans);
        }
    }
}