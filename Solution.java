
public class Solution {

    private static final int[] RANGE_OF_PILE_SIZE = {1, (int) Math.pow(10, 4)};

    public int maxCoins(int[] pileSizes) {
        int[] frequencyPileSizes = new int[RANGE_OF_PILE_SIZE[1] + 1];
        for (int current : pileSizes) {
            ++frequencyPileSizes[current];
        }

        int maxNumberOfCoinsToCollect = 0;
        int maxNumberOfAvailablePilesPerPerson = pileSizes.length / 3;

        boolean myTurn = false;
        int pileSize = frequencyPileSizes.length - 1;

        while (maxNumberOfAvailablePilesPerPerson > 0) {
            if (--frequencyPileSizes[pileSize] < 0) {
                --pileSize;
                continue;
            }
            if (!myTurn) {
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
