using System;
using System.Collections.Generic;

public class MainClass
{
    static int CardNumber(char card)
    {
        switch (card)
        {
            case '6': return 6;
            case '7': return 7;
            case '8': return 8;
            case '9': return 9;
            case '1': return 10;
            case 'В': return 11;
            case 'Д': return 12;
            case 'К': return 13;
            case 'Т': return 14;
            default: return -1;
        }
    }
    static int CardSuit(char card)
    {
        switch (card)
        {
            case '\u0006': return 1;
            case '\u0005': return 2;
            case '\u0004': return 3;
            case '\u0003': return 4;
            default: return -1;
        }
    }
    public static void Main()
    {
        var str = Console.ReadLine().Split();
        var player1 = new Queue<string>();
        var player2 = new Queue<string>();
        for (int i = 0; i < str.Length; i++)
        {
            if (i % 2 == 0) player1.Enqueue(str[i]);
            else player2.Enqueue(str[i]);
        }
        while (player1.Count > 0 && player2.Count > 0)
        {
            Console.WriteLine($"Player1 {player1.Peek()} - Player2 {player2.Peek()}");
            var p1 = CardNumber(player1.Peek()[0]);
            var p2 = CardNumber(player2.Peek()[0]);
            if (p1 == p2)
            {
                if(p1 == 10)
                {
                    p1 = CardSuit(player1.Peek()[2]);
                    p2 = CardSuit(player2.Peek()[2]);
                }
                else
                {
                    p1 = CardSuit(player1.Peek()[1]);
                    p2 = CardSuit(player2.Peek()[1]);
                }
                
            }
            if (p1 == 6 && p2 == 14)
            {
                player1.Enqueue(player1.Dequeue());
                player1.Enqueue(player2.Dequeue());
            }
            else if (p2 == 6 && p1 == 14)
            {
                player2.Enqueue(player2.Dequeue());
                player2.Enqueue(player1.Dequeue());
            }
            else if (p1 > p2)
            {
                player1.Enqueue(player1.Dequeue());
                player1.Enqueue(player2.Dequeue());
            }
            else 
            {
                player2.Enqueue(player2.Dequeue());
                player2.Enqueue(player1.Dequeue());
            }
        }
        Console.WriteLine(player1.Count == 0 ? "Player2" : "Player1");
    }
}