namespace CopyableBenchmark
{
    public class ClassA : IClassA
    {
        public int Property1 { get; set; }
        public int Property2 { get; set; }
        public int Property3 { get; set; }
    }


    public sealed class Person
        : IEquatable<Person?>
    {
        public Person(uint age, string name) =>
            (this.Age, this.Name) = (age, name);
        public uint Age { get; }
        public string Name { get; }
        public override bool Equals(object? obj) =>
            this.Equals(obj as Person);
        public bool Equals(Person? other) =>
            other is not null &&
            this.Age == other.Age &&
            this.Name == other.Name;
        public override int GetHashCode() =>
            HashCode.Combine(this.Age, this.Name);
        public static bool operator ==(Person? left, Person? right) =>
            EqualityComparer<Person>.Default.Equals(left, right);
        public static bool operator !=(Person? left, Person? right) =>
            !(left == right);
    }
}