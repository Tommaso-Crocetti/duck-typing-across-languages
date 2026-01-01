class StaticType {

    class Animal {
        void speak() { System.out.println("Animal"); }
    }
    class Dog extends Animal {
        void speak() { System.out.println("Woof"); }
    }
    
    public static void main(String[] args) {
        // Static type of a is Animal, dynamic type is Dog
        Animal a = new Dog();
        //  The static type is used for compile-time type checking
        //  The dynamic type is used for method resolution at runtime
        a.speak(); // prints "Woof"
    }
}