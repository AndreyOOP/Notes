var f = function(){
    return "Hello";
};

console.log(f); //returns text of function
console.log( f() );

function abc(){
    return "Some value";
}

console.log( abc() );

var c = "bbbbbbbbb";
var c1 = "aaaaaaaaaaaaa";

function par(a, b, c){
    console.log("a: = " + a);
    console.log("b: = " + b);
    console.log("c: = " + c); //could not found in global scope
    console.log(c1); //found in global scope
}

par(1);
par(1, "");
par(2, 3, {});