//js error - a is not defined
// console.log(a);

//in this case a has undefined value
var a; 
console.log(a);

//blank object creation, and some variable declaration without var
var a = {};
a.undeclared = 10;
console.log(a.undeclared);

var b = {
    x : 10,
    y : "Y",
    z : {
        val : "Some value"
    }
};

console.log(b);
console.log(b.z.val);