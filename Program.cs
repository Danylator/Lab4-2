using Newtonsoft.Json;
using System;
using System.Text.Json;
using static System.Net.Mime.MediaTypeNames;

public class Program
{
    public static void Main()
    {
        Train t = new Train(5);
        t.All();
        Console.WriteLine();
        t.SortByComfort();
        t.All();
     //   t.ShowAllVagonsBellowX(15);
    }
}
public class Train
{
    public Vagon[] vagons;
    public Train(int Amount_Of_Vagons)
    {
        vagons = new Vagon[Amount_Of_Vagons];
        Random r = new Random();
        for (int i = 0; i < vagons.Length; i++)
        {
            vagons[i] = new Vagon(r.Next(1, 3), r.Next(1, 40), r.Next(1, 40));
        }

    }
    public void SortByComfort()
    {
        for (int i = 0; i < vagons.Length; i++)
        {
            for (int j = 0; j < vagons.Length; j++)
            {
                if (vagons[i].ComfLvl < vagons[j].ComfLvl)
                {
                    (vagons[i], vagons[j]) = (vagons[j], vagons[i]);
                }
            }
        }
    }

    public void ShowAllVagonsBellowX(int X)
    {
        for (int i = 0; i < vagons.Length; i++)
        {
            if (vagons[i].Pasangers < X)
            {
                Console.WriteLine(vagons[i].Info());
            }
        }
    }

    public void All()
    {
        for (int i = 0; i < vagons.Length; i++)
        {
            Console.WriteLine(vagons[i].Info());
        }
    }
}
public class Vagon
{
    public int ComfLvl;
    public int Pasangers;
    public int Bags;
    public Vagon(int comfLvl, int pasangers, int bags)
    {
        ComfLvl = comfLvl;
        Pasangers = pasangers;
        Bags = bags;
    }
    public string Info() => $"Comfort LVL: {ComfLvl}, Passangers: {Pasangers}, Bags: {Bags}";
}