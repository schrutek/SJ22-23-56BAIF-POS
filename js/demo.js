function doSomething(callback) {
    setTimeout(function toDoAfterTimeout() {
        callback();
    }, 2000) 
}

function myCallbackTemp() { 
    console.log('Callback Done!');
}

// doSomething(function myCallback() { 
//     console.log('Callback Done!');
// });

// promise

function myPromise(state) {
    return new Promise(function resolveOrReject(resolve, reject) {
        if (state === 0) {
            resolve('OK!');
        } else {
            reject('NOK!')
        }
     })
}

myPromise(1)
.then(function getResult(data) { 
    console.log(data);
})
.catch(function getResult(err) {
    console.log(err);
})
