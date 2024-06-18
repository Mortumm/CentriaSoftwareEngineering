const array = ["One", "Two", "Three", "Four", "Five"];
for (let i = 0; i < array.length; i++) {
  console.log(array[i]);
}

console.log("---");

for (const value of array) {
  console.log(value);
}