namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class Match
    {
        public int Match_ID { get; set; }
        public virtual required User User { get; set; }
        public DateTime StartDate { get; set; }
        public bool IsFinished { get; set; }
        public float PositionX { get; set; }
        public float PositionY { get; set; }
        public float PositionZ { get; set; }
        public int CurrentScore { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
