namespace LINQdemo
{

    public class Student : IComparable<Student>
    {
        public string Name { get; set; }
        public int Age { get; set; }
        public int Grade { get; set; }

        public int CompareTo(Student other)
        {
            return this.Grade.CompareTo(other.Grade);
        }
    }
}
