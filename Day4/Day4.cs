using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Marshalling;
using System.Xml;

namespace AdventOfCode2024
{
    public class Day4
    {
        public static void Solve()
        {
            string input = "../../../Day4/input.txt";
            string[] lines = File.ReadAllLines(input);
            int ans = 0;

            int rows = lines.Length;
            int columns = lines[0].Length;

            char[,] grid = new char[rows, columns];

            int[,] directions = new int[,] {
                { -1,  0 },
                {  1,  0 },
                {  0, -1 },
                {  0,  1 },
                { -1, -1 },
                { -1,  1 },
                {  1, -1 },
                {  1,  1 },
            };

            for(int i = 0; i < rows; i++){
                for(int j = 0; j < columns; j++){
                    grid[i, j] = lines[j][i];
                }
            }

            for(int x = 0; x < rows; x++){
                for(int y = 0; y < columns; y++){
                    if(grid[x, y] == 'X'){
                        for(int xDir = 0; xDir < directions.GetLength(0); xDir++){
                            int dx = directions[xDir, 0];
                            int dy = directions[xDir, 1];
                            int mRow = x + dx;
                            int mCol = y + dy;
                            if(mRow >= 0 && mRow <= rows-1 && mCol >= 0 && mCol <= columns-1 && grid[mRow, mCol] == 'M'){
                                int aRow = mRow + dx;
                                int aCol = mCol + dy;
                                if(aRow >= 0 && aRow <= rows-1 && aCol >= 0 && aCol <= columns-1 && grid[aRow, aCol] == 'A'){
                                    int sRow = aRow + dx;
                                    int sCol = aCol + dy;
                                    if(sRow >= 0 && sRow <= rows-1 && sCol >= 0 && sCol <= columns-1 && grid[sRow, sCol] == 'S'){ans++;}
                                }
                            }
                        }
                    }
                }
            }
            
            Console.WriteLine(ans);
            ans = 0;

            for(int x = 0; x < rows; x++){
                for(int y = 0; y < columns; y++){
                    if(grid[x,y] == 'A'){
                        if(x+1 < rows && y+1 < columns && x-1 >= 0 && y-1 >= 0){
                            if(grid[x-1, y+1] == 'M' || grid[x-1, y+1] == 'S'){
                                if((grid[x+1, y-1] == 'M' || grid[x+1, y-1] == 'S') && grid[x+1, y-1] != grid[x-1, y+1]){
                                    if(grid[x+1, y+1] == 'M' || grid[x+1, y+1] == 'S'){
                                        if((grid[x-1, y-1] == 'M' || grid[x-1, y-1] == 'S') && grid[x-1, y-1] != grid[x+1, y+1]){ans++;}
                                    }
                                }
                            }
                        }
                    }
                }
            }
            Console.WriteLine(ans);
        }
    }
}