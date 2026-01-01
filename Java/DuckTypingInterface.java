interface Quacker {
    void quack();
}

class Duck implements Quacker {
    public void quack() {
        System.out.println("Quack!");
    }
}

class RobotDuck implements Quacker {
    public void quack() {
        System.out.println("Electronic quack!");
    }
}

class LegacyDuck {
    public void makeNoise() {
        System.out.println("Quack!");
    }
}

// Adapter
class LegacyDuckAdapter implements Quacker {
    private final LegacyDuck legacy;
    LegacyDuckAdapter(LegacyDuck legacy) { this.legacy = legacy; }
    public void quack() { legacy.makeNoise(); }
}


public class DuckTypingInterface {

    public static void makeItQuack(Quacker q) {
        q.quack();
    }
    
    public static void main(String[] args) {
        makeItQuack(new Duck());
        makeItQuack(new RobotDuck());
        //makeItQuack(new LegacyDuck());
        makeItQuack(new LegacyDuckAdapter(new LegacyDuck()));
    }

}


