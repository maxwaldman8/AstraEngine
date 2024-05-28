
using AstraEngine.Examples.PlayerMovement;

(string name, Action action)[] examples =
[
    ("Player Movement", PlayerMovementExample.Run),
    ("Draw Pixels Example", DrawPixelsExample.Run),
    ("Exit", () => Environment.Exit(0)),
];

Run();

void Run()
{
    while (true)
    {
        Console.Clear();
        int ix = 1;
        foreach ((string name, Action _) in examples)
        {
            Console.WriteLine($"{ix}. {name}");
            ix++;
        }
        Console.Write("Select an example: ");
        string choice = Console.ReadLine()!;
        if (int.TryParse(choice, out int selected) && selected > 0 && selected <= examples.Length)
        {
            examples[selected - 1].action.Invoke();
        }
        else
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Invalid choice. Press enter to continue");
            Console.ResetColor();
            Console.ReadLine();
        }
    }
}