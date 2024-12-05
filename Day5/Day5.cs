using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Security;

namespace AdventOfCode2024
{
    public class Day5
    {
        public static void Solve()
        {
            
            string input = "../../../Day5/input.txt";
            string[] lines = File.ReadAllLines(input);

            bool isUpdates = false;
            List<int> RLower = [];
            List<int> RHigher = [];
            List<List<int>> Updates = [];

            int ans = 0;

            foreach(string line in lines){
                if(string.IsNullOrWhiteSpace(line)){
                    isUpdates = true;
                    continue;
                }
                if(isUpdates == false){
                    string[] parts = line.Split('|');
                    RLower.Add(int.Parse(parts[0].Trim()));
                    RHigher.Add(int.Parse(parts[1].Trim()));
                }
                else{
                    string[] parts = line.Split(',');
                    List<int> row = [];
                    foreach(string part in parts){
                        row.Add(int.Parse(part));
                    }
                    Updates.Add(row);
                }
            }
            foreach(var row in Updates){
                bool flag = true;

                for(int i = 1; i < row.Count; i++){
                    for(int j = 0; j < RLower.Count; j++){
                        if(RLower[j] == row[i]){
                            if(row[i-1] == RHigher[j]){
                                flag = false;
                                break;
                            }
                        }
                    }
                    if(!flag){break;}
                }
                if(!flag){continue;}
                ans += row[(int)Math.Floor((double)row.Count / 2)];
            }

            Console.WriteLine(ans);
            ans = 0;

            foreach(var row in Updates){

                bool flag = false;
                bool incorrectRow = false;

                while(flag == false){
                    flag = true;
                    
                    for(int i = 1; i < row.Count; i++){
                        for(int j = 0; j < RLower.Count; j++){
                            if(RLower[j] == row[i]){
                                if(row[i-1] == RHigher[j]){

                                    int temp = RHigher[j];
                                    row[i-1] = row[i];
                                    row[i] = temp;
                                    flag = false;
                                    incorrectRow = true;

                                }
                            }
                        }
                    }
                }
                if(incorrectRow){ans+=row[(int)Math.Floor((double)row.Count / 2)];}
            }

            Console.WriteLine(ans);

        }
    }
}