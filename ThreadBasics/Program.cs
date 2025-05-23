Console.WriteLine("Simulating Server Request ");


while (true)
{
    string input = Console.ReadLine();
    if (input == "exit")
    {
        break;
    }
    SimulateServerRequest(input);
}


static void SimulateServerRequest(string input)
{
    Thread.Sleep(2000);
    Console.WriteLine("Server Request Completed");
}