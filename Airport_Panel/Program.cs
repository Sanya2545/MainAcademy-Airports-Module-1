// See https://aka.ms/new-console-template for more information
namespace Airport_Panel
{
    public class Program
    {
        public static void Main (string [] args)
        {
            int[] numsOfGates = new int[5];
            for(int i = 0; i < numsOfGates.Length; ++i)
            {
                numsOfGates[i] = i + 1;
            }
            List<Terminal> terminals = new List<Terminal>() { new Terminal("Europe direct.", numsOfGates), new Terminal("NewYork direct.", numsOfGates), new Terminal("Asia direct.", numsOfGates) };
            Airport airport = new Airport("Fiumicino", terminals);

            Console.WriteLine(airport);
        }
    }

}