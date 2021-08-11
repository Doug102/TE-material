const NumRows = 10;
const NumColumns = 10;

/**
 * Creates the game grid and adds it to the DOM
 */
function createGrid() {
    const frame = document.getElementById('frame');
    frame.innerHTML = ''; // Clear prior game content

    // Add Code to create the game grid
    for (let i = 0; i < NumRows ; i++) {
        buildRow(frame); 
    }
}

/**
 * Builds a grid row and adds it to the frame
 * @param {element} frame the element that should contain the rows
 */
function buildRow(frame) {
    // Add code to create rows
    const row = document.createElement('div');
    row.classList.add('row');
    frame.appendChild(row);

    for (let i = 0; i < NumColumns ; i++) {
        buildSquare(row); 
    }    
}

/**
 * Builds a grid square and appends it into the row
 * @param {element} row the row that square should be added to
 */
function buildSquare(row) {
    const container = document.createElement('div');
    container.classList.add('square');

    // Optionally add a pirate
    const chanceOfGeneratingAPirate = 15;
    if ((Math.random() * 100) <= chanceOfGeneratingAPirate) {
        container.classList.add('pirate');
    } 

    row.appendChild(container);
}

/**
 * Gets the element in a row at the same index in the row as the source element is in its
 * parent. This allows us to see tiles that are in the same column
 * @param {Node} sourceElement the child of a given row that we are looking for
 * @param {Node} row the row to grab the element from
 */
function getElementAtSameIndex(sourceElement, row) {
    let elementAtIndex = null;
    if (row) {
        const index = getIndexOfElementWithinParent(sourceElement);
        elementAtIndex = row.childNodes[index];
    }
    return elementAtIndex;
}

/**
 * Determines the index of the specified element is within its parent.
 * @param {Node} element the HTMLElement to check
 * @returns the index of element within its parent
 */
function getIndexOfElementWithinParent(element) {
    const parent = element.parentNode;
    const children = parent.children;

    return Array.from(children).indexOf(element);
}

/**
 * Finds the HTMLElement containing the boat (indicated by the boat class) and returns it
 * @returns {Node} the HTMLElement containing the boat
 */
function getShipLocation() {
    return document.getElementById('frame').querySelector('.boat');
}

/**
 * Returns whether or not the specified element has treasure in it
 * @param {Node} element the HTMLElement to check to see if it has treasure
 * @returns {boolean} whether or not the specified element has treasure in it
 */
function containsTreasure(element) {
    return element.classList.contains("treasure");
}
