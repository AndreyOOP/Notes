function a(){

    var f = function(a, b){
        return a + b;
    }

    return f;
}

console.log(a);
console.log(a());
console.log( a()(1, 2) );

//it is possible to assign fields to function
a.version = "v1.0.0";
console.log(a.version);

//function factory
function Factory(outParam){

    var createdFunction = function() {
        return "createdFunction actions " + outParam;
    };

    return createdFunction;
}

var f1 = Factory("first out param");
var f2 = Factory("second out param");

console.log(f1);
console.log( f1());
console.log( f2());

//passing functions as arguments
var doFunct = function(x, operation){
    return operation(x);
}

function operationDouble(n){
    return 2*n;
}

function operationSame(a){
    return "" + a + a;
}

console.log( doFunct(3, operationDouble));
console.log( doFunct(3, operationSame));