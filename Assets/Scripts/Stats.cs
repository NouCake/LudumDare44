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

}