// SHADOWING

let clickCounter = 0;

function incrementCounter(clickCounter){
  clickCounter++;
}

// SPREAD OPERATOR (...) FOR FUNCTIONS

function add(num1, num2, num3) {
  return num1 + num2 + num3;
}

const myNumbers = [1, 2, 3];

const result = 0; // TODO: Call add with our numbers

console.log('Spreading our numbers out results in ', result);

// SPREAD OPERATOR (...) FOR OBJECT CLONING

const myCar = {
  make: 'Honda',
  model: 'Civic',
  color: 'Blue',
  vin: 12345,
}

const friendsCar = myCar; //TODO: Use spread to clone our objects
friendsCar.vin = 67890;

console.log('I drive this car', myCar);
console.log('My friend drives this car', friendsCar);