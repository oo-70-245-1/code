// Defining the class
// We marked it as abstract instead of interface because we defined implementations for the Health and Type properties
abstract class Enemy {

	// Defining variables which will be referenced by the properties
	protected int _health;
	protected string _type;
	
	// Defining the properties
	// health property
	public int Health {
		get { return _health; }
		set { _health = value; }
	}
	
	// type property
	public string Type {
		get { return _type; }
		set { _type = value; }
	}
	
	// Defining our speak and attack methods
	// marking it as abstract so that whoever inherits from our Enemy class must provide an implementation of speak and attack
	public abstract void Speak();
	public abstract void Attack(Player p);
	
}

// Creating 2 enemies
// Note how they implemented the abstract methods defined in the Enemy class
class Paladin : Enemy {
	public void Speak() { //do something }
	public void Attack(Player p) { //do something }
}

class Wizard : Enemy {
	public void Speak() { // do something }
	public void Attack(Player p) { //do something }
}

// Defining a player class per the homework
class Player {
	protected int _health;
	
	// Defining the properties
	// health property
	public int Health {
		get { return _health; }
		set { _health = value; }
	}
	
	public void Attack(Enemy e) { // do something }
}