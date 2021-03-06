﻿namespace BoM {
	// Traits
	[System.Serializable]
	public class Traits : JSONSerializable<Traits> {
		public const int defaultValue = 0;

		public static string[] statNames = new string[] {
			"Attack",
			"Defense",
			"Energy",
			"Cooldown Reduction",
			"Attack Speed",
			"Move Speed"
		};
		
		public int attack;
		public int defense;
		public int energy;
		public int cooldownReduction;
		public int attackSpeed;
		public int moveSpeed;
		
		// Empty constructor
		public Traits() {
			attack = defaultValue;
			defense = defaultValue;
			energy = defaultValue;
			cooldownReduction = defaultValue;
			attackSpeed = defaultValue;
			moveSpeed = defaultValue;
		}
		
		// Default value - needs to be separate from empty constructor
		public Traits(int value) {
			attack = value;
			defense = value;
			energy = value;
			cooldownReduction = value;
			attackSpeed = value;
			moveSpeed = value;
		}
		
		// Copy constructor
		public Traits(Traits other) {
			attack = other.attack;
			defense = other.defense;
			energy = other.energy;
			cooldownReduction = other.cooldownReduction;
			attackSpeed = other.attackSpeed;
			moveSpeed = other.moveSpeed;
		}
		
		// Compare
		public bool Compare(Traits other) {
			return
				attack == other.attack &&
				defense == other.defense && 
				energy == other.energy && 
				cooldownReduction == other.cooldownReduction && 
				attackSpeed == other.attackSpeed && 
				moveSpeed == other.moveSpeed;
		}
		
		// Apply offset
		public void ApplyOffset(int val) {
			attack += val;
			defense += val;
			energy += val;
			cooldownReduction += val;
			attackSpeed += val;
			moveSpeed += val;
		}
		
		// Apply offset
		public void ApplyOffset(Traits stats) {
			attack += stats.attack;
			defense += stats.defense;
			energy += stats.energy;
			cooldownReduction += stats.cooldownReduction;
			attackSpeed += stats.attackSpeed;
			moveSpeed += stats.moveSpeed;
		}
		
		// Multi line string
		public string multiLineString {
			get {
				var s = "\n";
				return string.Concat(
					"Attack +", attack, s,
					"Defense +", defense, s,
					"Energy +", energy, s,
					"CD reduction +", cooldownReduction, s,
					"Attack speed +", attackSpeed, s,
					"Move speed +", moveSpeed
				);
			}
		}
		
		// Get multi line string combined
		public string GetMultiLineStringCombined(Traits other, string formatStart = "<b>", string formatEnd = "</b>") {
			var s = "\n";
			return string.Concat(
				"Attack: ", attack, " ", formatStart, "+", other.attack, formatEnd, s,
				"Defense: ", defense, " ", formatStart, "+", other.defense, formatEnd, s,
				"Energy: ", energy, " ", formatStart, "+", other.energy, formatEnd, s,
				"CD reduction: ", cooldownReduction, " ", formatStart, "+", other.cooldownReduction, formatEnd, s,
				"Attack speed: ", attackSpeed, " ", formatStart, "+", other.attackSpeed, formatEnd, s,
				"Move speed: ", moveSpeed, " ", formatStart, "+", other.moveSpeed, formatEnd
			);
		}
		
		// To string
		public override string ToString() {
			var s = " / ";
			return attack + s + defense + s + energy + s + cooldownReduction + s + attackSpeed + s + moveSpeed;
		}
		
		// Valid
		public bool valid {
			get {
				return totalPointsUsed <= maxPoints;
			}
		}
		
		// Total points used
		public int totalPointsUsed {
			get {
				return
					attack +
					defense +
					energy +
					cooldownReduction + 
					attackSpeed +
					moveSpeed;
			}
		}
		
		// Max points
		public int maxPoints {
			get {
				return defaultValue * 6;
			}
		}
		
		// Points left
		public int pointsLeft {
			get {
				return maxPoints - totalPointsUsed;
			}
		}
		
		// Attack damage multiplier
		public float attackDmgMultiplier {
			get {
				return 1.0f + (attack * 0.005f);
			}
		}
		
		// Defense damage multiplier
		public float defenseDmgMultiplier {
			get {
				return 1f / (1f + (defense * 0.005f));
			}
		}
		
		// Energy multiplier
		public float energyMultiplier {
			get {
				return 1.0f + (energy * 0.0075f);
			}
		}
		
		// Cooldown multiplier
		public float cooldownMultiplier {
			get {
				return 1.0f - (cooldownReduction * 0.005f);
			}
		}
		
		// Attack speed multiplier
		public float attackSpeedMultiplier {
			get {
				return 1.0f - (attackSpeed * 0.005f);
			}
		}
		
		// Move speed multiplier	
		public float moveSpeedMultiplier {
			get {
				return 1.0f + (moveSpeed * 0.005f);
			}
		}
	}
}