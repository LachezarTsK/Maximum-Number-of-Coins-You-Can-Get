
using System;

public class Solution
{
    private static readonly int[] RANGE_OF_PILE_SIZE = { 1, (int)Math.Pow(10, 4) };

    public int MaxCoins(int[] pileSizes)
    {
        int[] frequencyPileSizes = new int[RANGE_OF_PILE_SIZE[1] + 1];
        foreach (int current in pileSizes)
        {
            ++frequencyPileSizes[current];
        }

        int maxNumberOfCoinsToCollect = 0;
        int maxNumberOfAvailablePilesPerPerson = pileSizes.Length / 3;

        bool myTurn = false;
        int pileSize = frequencyPileSizes.Length - 1;

        while (maxNumberOfAvailablePilesPerPerson > 0)
        {
            if (--frequencyPileSizes[pileSize] < 0)
            {
                --pileSize;
                continue;
            }
            if (!myTurn)
            {
                myTurn = true;
                continue;
            }
            maxNumberOfCoinsToCollect += pileSize;
            --maxNumberOfAvailablePilesPerPerson;
            myTurn = false;
        }

        return maxNumberOfCoinsToCollect;
    }
}
