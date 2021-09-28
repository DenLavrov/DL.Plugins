namespace Xamarin.Forms.Sample.BL.Models
{
    public class Person
    {
        public string Name { get; set; }
        
        public string Surname { get; set; }

        public override string ToString()
        {
            return $"{Surname} {Name}";
        }
    }
}