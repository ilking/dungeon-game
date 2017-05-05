using System;

namespace DungeonPuzzle
{
  public class Program
  {
    public static int[,] Dungeon(int[,] dungeon)
    {
      int m = dungeon.GetLength(0);
      int n = dungeon.GetLength(1);
      
      int[,] h = new int[m,n];
      h[m-1,n-1] = Math.Max(1-dungeon[m-1,n-1], 1);
      
      for(int i = m-2; i >= 0; i--) {      
        h[i,n-1] = Math.Max(h[i+1,n-1] - dungeon[i,n-1], 1);
      }
      
      for(int j = n-2; j >= 0; j--){
        h[m-1,j] = Math.Max(h[m-1,j+1] - dungeon[m-1,j], 1);
      }
      
      for(int i = m-2; i >= 0; i--){
        for(int j = n-2; j >= 0; j--) {
          int down = Math.Max(h[i+1,j] - dungeon[i,j], 1);
          int right = Math.Max(h[i,j+1] - dungeon[i,j], 1);
          h[i,j] = Math.Min(right, down);
        }
      }
      
      return h;
    }
    
    public static void Main(string[] args)
    {
      Random r = new Random();
      int width = r.Next(2,6);
      int height = r.Next(2,6);
      int[,] dungeon = new int[height, width];
      Console.WriteLine("Dungeon:");
      for(int i = 0; i < dungeon.GetLength(0); i++) {
        for(int j = 0; j < dungeon.GetLength(1); j++) {
          dungeon[i,j] = r.Next(51) - 20;
          Console.Write("{0,3} ", dungeon[i,j]);
        }
        Console.WriteLine();
      }
      
      Console.WriteLine();
      Console.WriteLine("HVals:");
      
      int[,] results = Dungeon(dungeon);
      
      Console.WriteLine("Dungeon Game: Needs {0} health.", results[0,0]);
      for(int i = 0; i < results.GetLength(0); i++) {
        for(int j = 0; j < results.GetLength(1); j++) {
          Console.Write("{0,3} ", results[i,j]);
        }
        Console.WriteLine();
      }
    }
  }
}