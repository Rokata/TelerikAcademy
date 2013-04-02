using System;
using System.Collections.Generic;

class Midget
{
    static void Main()
    {
        string[] tempValleyArr = Console.ReadLine().Split(',');
        List<int> valley = new List<int>();

        foreach (string item in tempValleyArr) valley.Add(int.Parse(item));

        int M = int.Parse(Console.ReadLine());

        List<List<int>> patterns = new List<List<int>>();
        List<int> pattern = new List<int>();
        string[] tempPatternArr;

        for (int ctr = 0; ctr < M; ctr++)
        {
            tempPatternArr = Console.ReadLine().Split(',');
            foreach (string item in tempPatternArr) pattern.Add(int.Parse(item));
            patterns.Add(pattern);
            pattern = new List<int>();
        }

        int bestCoinsCount = int.MinValue;
        int currentCoinsCount = 0;
        int prev = 0;
        List<int> visitedPos = new List<int>();
        bool isEnd = false;
        int position = 0;
        int i = 0, j = 0;

        for (i = 0; i < patterns.Count; i++)
        {
            currentCoinsCount += valley[0];
            visitedPos.Add(0);

            while (!isEnd)
            {
                for (j = 0; j < patterns[i].Count; j++)
                {
                    position = prev + patterns[i][j];

                    if (visitedPos.Contains(position) || position >= valley.Count || position < 0)
                    {
                        isEnd = true;
                        break;
                    }

                    visitedPos.Add(position);

                    currentCoinsCount += valley[position];
                    prev = position;
                }
            }

            if (currentCoinsCount > bestCoinsCount) bestCoinsCount = currentCoinsCount;

            currentCoinsCount = prev = position = 0;
            visitedPos.Clear();
            isEnd = false;
        }

        Console.WriteLine(bestCoinsCount);
    }
}