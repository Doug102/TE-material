/**
 * Moves the ship one tile up
 */
function moveShipUp() {
    const ship = getShipLocation();
    const up = getElementAtSameIndex(ship, ship.parentElement.previousElementSibling);
    moveShip(ship, up);
}

/**
 * Moves the ship one tile down
 */
function moveShipDown() {
    const ship = getShipLocation();
    const down = getElementAtSameIndex(ship, ship.parentElement.nextElementSibling);
    moveShip(ship, down);
}

/**
 * Moves the ship one tile right
 */
function moveShipRight() {
    const ship = getShipLocation();
    const right = ship.nextElementSibling;
    moveShip(ship, right);
}

/**
 * Moves the ship one tile left
 */
function moveShipLeft() {
    const ship = getShipLocation();
    const left = ship.previousElementSibling;
    moveShip(ship, left);
}

/**
 * Moves the boat from the currentParent to the newParent
 * @param {Node} currentParent the current parent of the ship
 * @param {Node} newParent the new parent that should contain the ship
 */
function moveShip(currentParent, newParent) {
    if (canMoveToElement(newParent)) {
        currentParent.classList.remove('boat');
        newParent.classList.add('boat');

        if (containsTreasure(newParent)) {
            handleGameWon();
        }
    }
}

/**
 * Determines whether or not the boat can move to the specified element.
 * This will be true unless the element is null (off the map) or has a pirate.
 * @param {Node} element the square the boat wants to move to
 * @returns {boolean} whether or not the boat can move to the square
 */
function canMoveToElement(element) {
    return element && !element.classList.contains('pirate');
}