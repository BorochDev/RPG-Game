namespace RPGGame.Domains.Helpers
{
    public class Requirement
    {
        public int RequirementWood { get; set; }
        public int RequirementStone { get; set; }
        public int RequirementIron { get; set; }
        public int RequirementWater { get; set; }

        public Requirement(int wood, int stone, int iron, int water)
        {
            RequirementWood = wood;
            RequirementStone = stone;
            RequirementIron = iron;
            RequirementWater = water;
        }
    }
}
