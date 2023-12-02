
/**
 * @param {number[]} pileSizes
 * @return {number}
 */
var maxCoins = function (pileSizes) {
    const RANGE_OF_PILE_SIZE = [1, Math.pow(10, 4)];
    const frequencyPileSizes = new Array(RANGE_OF_PILE_SIZE[1] + 1).fill(0);
    for (let current of pileSizes) {
        ++frequencyPileSizes[current];
    }

    let maxNumberOfCoinsToCollect = 0;
    let maxNumberOfAvailablePilesPerPerson = pileSizes.length / 3;

    let myTurn = false;
    let pileSize = frequencyPileSizes.length - 1;

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
};
