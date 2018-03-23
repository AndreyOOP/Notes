var z = new Object();

z.name = "Z name";
z.address = "Address Z";

console.log(z.name); //dot notation
console.log(z["address"]); //bracket notation

var space = "Param with sapce";
z[space] = 100;

console.log(z["Param with sapce"]);

//object literal notation
var ob = {
    a : "some a",
    b : 10,
    c : {
        name : "some object name"
    }
};

console.log(ob);