namespace Electronics_Laboratory_Classroom_and_Resource_Management_System.Model
{
    public class MatchLevel
    {
        public int MatchLevel_ID { get; set; }
        public required virtual Match Match { get; set; }

        public required virtual Level Level { get; set; }

        public required int PointsEarned { get; set; } // Puntos obtenidos en ese nivel

        public bool IsDeleted { get; set; } = false;
    }
}
