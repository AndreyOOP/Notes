var x = 1;

var a = function(){

    var x = 2;
    console.log("a function ->" + x);
    
    function b(){
        console.log("b function ->" + x);
    }
    b();

    c();
}

function c(){
    console.log("c function ->" + x);
}

a();