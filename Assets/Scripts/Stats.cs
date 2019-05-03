public struct Stats {

    public int physicalStrength;
    public int poisonStrength;
    public int coldStrength;
    public int fireStrength;

    public int physicalResistance;
    public int poisonResistance;
    public int coldResistance;
    public int fireResistance;

    public int maxhealth;

    public Stats(int str, int def) {

        physicalStrength = str;
        poisonStrength = str;
        coldStrength = str;
        fireStrength = str;

        physicalResistance = def;
        poisonResistance = def;
        coldResistance = def;
        fireResistance = def;

        maxhealth = 0;
    }

    public Stats(Stats s) {
        physicalStrength = s.physicalStrength;
        poisonStrength = s.poisonStrength;
        coldStrength = s.coldStrength;
        fireStrength = s.fireStrength;

        physicalResistance = s.physicalResistance;
        poisonResistance = s.poisonResistance;
        coldResistance = s.coldResistance;
        fireResistance = s.fireResistance;

        maxhealth = s.maxhealth;
    }

    public void Add(Stats s) {
        physicalStrength += s.physicalStrength;
        poisonStrength += s.poisonStrength;
        coldStrength += s.coldStrength;
        fireStrength += s.fireStrength;

        physicalResistance += s.physicalResistance;
        poisonResistance += s.poisonResistance;
        coldResistance += s.coldResistance;
        fireResistance += s.fireResistance;

        maxhealth += s.maxhealth;
    }

    public void SetAll(int val) {
        physicalStrength = val;
        poisonStrength = val;
        coldStrength = val;
        fireStrength = val;

        physicalResistance = val;
        poisonResistance = val;
        coldResistance = val;
        fireResistance = val;

        maxhealth = val;
    }

}