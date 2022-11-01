namespace ElectronicDiary.Models
{
    public class Lesson : IsOnSchedule
    {
        public string Title { get; set; }
        public LessonType lessonType { get; set; }
        public string Topic { get; set; }
        public string Homework { get; set; }
        public TimePoint StartTime { get; set; }
        public TimePoint EndTime { get; set; }
        public List<Grade> Grades { get; set; }
        /// <summary>
        ///Полноценное заполнение 
        /// </summary>
        public Lesson(string title, LessonType lessonType, string topic, string homework, TimePoint startTime, TimePoint endTime)
        {
            Title = title;
            this.lessonType = lessonType;
            Topic = topic;
            Homework = homework;
            StartTime = startTime;
            EndTime = endTime;

        }
        /// <summary>
        /// Краткая форма создания
        /// </summary>
        public Lesson(string title, TimePoint startTime, TimePoint endTime)
        {
            Title = title;
            StartTime = startTime;
            EndTime = endTime;
        }

        public void SetTime1(TimePoint startTime, TimePoint endTime)
        {
            StartTime = startTime;
            EndTime = endTime;
        }
        public void SetTime2(TimePoint startTime, Duration duration)
        {
            StartTime = startTime;
            EndTime.Hour = startTime.Hour + duration.Hours;
            EndTime.Minute = startTime.Minute + duration.Minutes;
        }
        public void AddGrade(Grade grade)
        {
            Grades.Add(grade);
        }
        public void RemoveGrade(Grade grade)
        {
            Grades.Remove(grade);
        }
    }
}