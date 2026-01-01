// This file contains various AI-generated Proxy examples


function printFunctionName(func) {
  return function (...args) {
    console.log(`\nRunning ${func.name}:`);
    return func.apply(this, args);
  };
}


function proxyGet() {
    const target = { name: "Alice", age: 30 };

    const handler = {
    get(target, prop, receiver) {
        console.log(`Accessing ${String(prop)}`);
        return Reflect.get(target, prop, receiver); // default behavior
    }
    };

    const proxy = new Proxy(target, handler);

    console.log(proxy.name); // Logs: "Accessing name" + "Alice"

}

function proxyGetWithReflect() {
    const handler = {
    get(target, prop, receiver) {
        return prop in target
        ? Reflect.get(target, prop, receiver)
        : "⟨undefined property⟩";
    }
    };

    const p = new Proxy({ a: 1 }, handler);

    console.log(p.a); // 1
    console.log(p.b); // "⟨undefined property⟩"
}

function proxySet() {
    const target = {};

    const handler = {
    set(target, prop, value, receiver) {
        console.log(`Setting ${prop} = ${value}`);
        return Reflect.set(target, prop, value, receiver);
    }
    };

    const proxy = new Proxy(target, handler);

    proxy.value = 100; // Logs: Setting value = 100
}

function proxyApply() {
    function sum(a, b) {
        return a + b;
    }

    const handler = {
        apply(target, thisArg, args) {
            console.log(`Called with `, args);
            return Reflect.apply(target, thisArg, args) * 10;
        }
    };

    const proxySum = new Proxy(sum, handler);

    console.log(proxySum(2, 3)); // logs call and outputs 50
}

function proxyConstruct() {
    const handler = {
        construct(target, args, newTarget) {
            console.log("Constructing with:", args);
            return new target(...args);
        }
    };

    class User {
        constructor(name) {
            this.name = name;
        }
    }

    const ProxyUser = new Proxy(User, handler);

    const u = new ProxyUser("Bob");
    // Logs: Constructing with: ["Bob"]
    console.log(u.name); // "Bob"
}

// Run proxy examples
printFunctionName(proxyGet)();
printFunctionName(proxyGetWithReflect)();
printFunctionName(proxySet)();
printFunctionName(proxyApply)();
printFunctionName(proxyConstruct)();

function proxyDefault() {
    const defaults = { x: 0, y: 0 };

    function withDefaults(obj) {
        return new Proxy(obj, {
                get(target, prop) {
                return prop in target ? target[prop] : defaults[prop];
                }
            });
        }

    const p = withDefaults({ y: 5 });
    console.log(p.x, p.y); // 0 5
}

function proxyValidation() {
    const userValidator = {
        set(target, prop, value) {
            if (prop === "age" && typeof value !== "number") {
                throw new TypeError("Age must be a number");
            }
            return Reflect.set(target, prop, value);
        }
    };

    const user = new Proxy({}, userValidator);
    user.age = 30;     // OK
    // user.age = "old"; // TypeError
}

printFunctionName(proxyDefault)();
printFunctionName(proxyValidation)();