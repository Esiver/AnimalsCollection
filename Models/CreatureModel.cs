using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace AnimalsCollection.Models
{
    public class CreatureModel
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [DisplayName("Description")]
        public string? Description { get; set; }
        public int Age { get; set; }
        public int Speed { get; set; }
        public int Strength { get; set; }
        public int Intelligence { get; set; }
        public int Level { get; set; }

        public CreatureModel()
        {
            Id = -1;
            Name = "No Name";
            Description = "No Description";
            Age = 0;
            Speed = 0;
            Strength = 0;
            Intelligence = 0;
            Level = 0;

        }

        public CreatureModel(int id, string name, string? description, int age, int speed, int strength, int intelligence, int level)
        {
            Id = id;
            Name = name;
            Description = description;
            Age = age;
            Speed = speed;
            Strength = strength;
            Intelligence = intelligence;
            Level = level;
        }
    }
}
