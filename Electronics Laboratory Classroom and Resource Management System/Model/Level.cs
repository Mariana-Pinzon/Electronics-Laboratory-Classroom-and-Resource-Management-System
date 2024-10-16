namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Level
    {
        public int Level_ID { get; set; } 
        public required string Level_Name { get; set; } 
        public required int ScorePerLevel { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
