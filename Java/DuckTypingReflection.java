import java.lang.reflect.*;

public class DuckTypingReflection {

    public static void tryQuack(Object obj) {
        try {
            Method quackMethod = obj.getClass().getMethod("quack");
            quackMethod.invoke(obj);
        } catch (NoSuchMethodException e) {
            System.out.println(obj.getClass().getSimpleName() + " cannot quack!");
        } catch (Exception ex) {
            throw new RuntimeException(ex);
        }
    }

    public static Object callIfExists(Object target, String methodName, Object... args) {
        try {
            Class<?>[] paramTypes = new Class<?>[args.length];
            for (int i = 0; i < args.length; i++) {
                paramTypes[i] = args[i].getClass();
            }
            Method method = target.getClass().getMethod(methodName, paramTypes);
            return method.invoke(target, args);
        } catch (NoSuchMethodException e) {
            System.out.println("Method " + methodName + " not found in " +
                               target.getClass().getSimpleName());
        } catch (Exception ex) {
            throw new RuntimeException(ex);
        }
        return null;
    }

    public static void printField(Object obj, String fieldName) {
        try {
            Field f = obj.getClass().getDeclaredField(fieldName);
            f.setAccessible(true); // access private as well
            Object value = f.get(obj);
            System.out.println(fieldName + " = " + value);
        } catch (NoSuchFieldException e) {
            System.out.println("No field `" + fieldName + "` in " +
                               obj.getClass().getSimpleName());
        } catch (Exception ex) {
            throw new RuntimeException(ex);
        }
    }

    public static void main(String[] args) {
        
        class Duck { public void quack() { System.out.println("Quack!"); } }
        class RobotDuck { public void quack() { System.out.println("Electronic quack!"); } }
        class Dog { public void bark() { System.out.println("Woof!"); } }

        
        tryQuack(new Duck());       // Quack!
        tryQuack(new RobotDuck());  // Electronic quack!
        tryQuack(new Dog());        // Dog cannot quack!
        
        // ------------------------------

        class Printer {
            public void print(String s) { System.out.println(s); }
        }

        
        Printer p = new Printer();
        callIfExists(p, "print", "Hello via reflection!"); // Hello via reflection!
        callIfExists(p, "noSuch", "ignored"); // Method noSuch not found…
        
        // ------------------------------

        class Person { private String name = "Alice"; }
        class Car { private String name = "Zoom"; }

        printField(new Person(), "name"); // name = Alice
        printField(new Car(), "name");    // name = Zoom
        printField(new Car(), "age");     // No field `age` in Car

    }
}
