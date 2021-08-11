const homes = [
  {
    mlsId: '1000',
    address: {
      street: '123 Java Green Lane',
      city: 'Columbus',
      state: 'Ohio',
      zip: '43023',
    },
    price: '1,222,345.00'
  },
  {
    mlsId: '1001',
    address: {
      street: '123 Vue Street',
      city: 'Grandview',
      state: 'Ohio',
      zip: '43015'
    },
    price: '952,345.72'
  },
  {
    mlsId: '1002',
    address: {
      street: '123 Java Blue Court',
      city: 'Columbus',
      state: 'Ohio',
      zip: '43023'
    },
    price: '750,000.00'
  },
  {
    mlsId: '1003',
    address: {
      address: '999 C-Sharp Rd.',
      city: 'Dublin',
      state: 'Ohio',
      zip: '43017'
    },
    price: '99.97'
  },
  {
    mlsId: '1004',
    address: {
      street: '555 Cohort Lane. Apt. 1',
      city: 'Columbus',
      state: 'Ohio',
      zip: '43022'
    },
    price: '1,000,000.01'
  }
];

console.log('input values:');
console.log(homes);
console.log('------------------------');

//write your code below
function basic_zip_filter(zipcode) {
  return homes.filter(e => e.address.zip === zipcode);
}
console.log(basic_zip_filter('43023'));