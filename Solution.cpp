
#include <vector>
using namespace std;

class Solution {
    
    static constexpr array<int, 2> RANGE_OF_PILE_SIZE {1, 10000};

public:
    int maxCoins(const vector<int>& pileSizes) const {
        array<int, RANGE_OF_PILE_SIZE[1] + 1 > frequencyPileSizes{};
        for (int current : pileSizes) {
            ++frequencyPileSizes[current];
        }

        int maxNumberOfCoinsToCollect = 0;
        size_t maxNumberOfAvailablePilesPerPerson = pileSizes.size() / 3;

        bool myTurn = false;
        int pileSize = frequencyPileSizes.size() - 1;

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
};
