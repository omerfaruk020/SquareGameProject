Random random = new Random();
int cursorx = 5;
int cursory = 4;
int humanpoints = 0;
ConsoleKeyInfo cki;

Console.SetCursorPosition(3, 3);
Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
for (int i = 1; i <= 17; i++)
{
    Console.SetCursorPosition(3, i + 3);
    if (i % 2 == 1) Console.WriteLine("|                               |");
    else Console.WriteLine("+ + + + + + + + + + + + + + + + +");
}
Console.SetCursorPosition(3, 21);
Console.WriteLine("+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+-+");
bool linevarmi = false;

List<(int x, int y)> verticalLines = new List<(int, int)>();
List<(int x, int y)> horizontalLines = new List<(int, int)>();
List<(int x, int y)> humanPositions = new List<(int, int)>();
List<(int x, int y)> ownerlessPositions = new List<(int, int)>();

for (int i = 4; i <= 34; i += 2)
{
    horizontalLines.Add((i, 3));
    horizontalLines.Add((i, 21));
}        
for (int i = 4; i <= 20; i += 2)
{
    verticalLines.Add((3, i));
    verticalLines.Add((35, i));
}

    for (int i = 1; i < 90; i++)
{
    int olasilik = random.Next(1, 264);
    if (olasilik < 136)
    {
        // dikey
        int[] xposition = { 5, 7, 9, 11, 13, 15, 17, 19, 21, 23, 25, 27, 29, 31 };
        int[] yposition = { 4, 6, 8, 10, 12, 14, 16, 18, 20 };
        int rndLinesx = xposition[random.Next(0, xposition.Length)];
        int rndLinesy = yposition[random.Next(0, yposition.Length)];
        verticalLines.Add((rndLinesx, rndLinesy));
        Console.SetCursorPosition(rndLinesx, rndLinesy);
        Console.WriteLine("|");
    }
    
    else if (olasilik > 135)
    {
        // yatay
        int[] xposition = { 4, 6, 8, 10, 12, 14, 16, 18, 20, 22, 24, 26, 28, 30, 32, 34 };
        int[] yposition = { 5, 7, 9, 11, 13, 15, 17, 19 };
        int rndLinesx = xposition[random.Next(0, xposition.Length)];
        int rndLinesy = yposition[random.Next(0, yposition.Length)];
        horizontalLines.Add((rndLinesx, rndLinesy));
        Console.SetCursorPosition(rndLinesx, rndLinesy);
        Console.WriteLine("-");
    }

}


for (int i = 0; i < verticalLines.Count; i++)
{
    int tempx = verticalLines[i].x;
    int tempy = verticalLines[i].y;

    if ((verticalLines.Any(l => l.x == tempx && l.y == tempy)) &&
        (verticalLines.Any(l => l.x == tempx + 2 && l.y == tempy)) &&
        (horizontalLines.Any(l => l.x == tempx + 1 && l.y == tempy + 1)) &&
        (horizontalLines.Any(l => l.x == tempx + 1 && l.y == tempy - 1)))
    {
        Console.SetCursorPosition(tempx + 1, tempy);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(":");
        Console.ResetColor();
        ownerlessPositions.Add((tempx + 1, tempy));
    }
}

int finalsquarex = 0;
int finalsquarey = 0;
int firstSquare = 1;

int stage = 1;
int turn = 0;

while (true)
{
    if (Console.KeyAvailable)
    {
        cki = Console.ReadKey(true);

        if (cki.Key == ConsoleKey.Backspace)
        {
            stage++;
        }
        Console.SetCursorPosition(40, 8);
        Console.Write("stage: " + stage);

        // stage 1
        if (cki.Key == ConsoleKey.Spacebar && stage == 1)
        {
            if (firstSquare != 1)
            {
                if (cursory % 2 == 0)
                {
                    if ((verticalLines.Any(l => l.x == cursorx + 2 && l.y == cursory)) &&
                    (horizontalLines.Any(l => l.x == cursorx + 1 && l.y == cursory + 1)) &&
                    (horizontalLines.Any(l => l.x == cursorx + 1 && l.y == cursory - 1)))
                    {
                        if (((finalsquarex == cursorx + 1 && finalsquarey == cursory + 2) ||
                            (finalsquarex == cursorx + 1 && finalsquarey == cursory - 2) ||
                            (finalsquarex == cursorx + 3 && finalsquarey == cursory)))
                        {
                            Console.SetCursorPosition(cursorx + 1, cursory);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("P");
                            Console.ResetColor();
                            humanPositions.Add((cursorx + 1, cursory));
                            humanpoints++;

                            finalsquarex = cursorx + 1;
                            finalsquarey = cursory;
                        }

                        else if (humanPositions.Any(l => l.x == cursorx + 1 && l.y == cursory + 2) ||
                                 humanPositions.Any(l => l.x == cursorx + 1 && l.y == cursory - 2) ||
                                 humanPositions.Any(l => l.x == cursorx + 3 && l.y == cursory))
                        {
                            // komşu fakat bir öncekiyle komşu değil
                            Console.SetCursorPosition(cursorx + 1, cursory);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(":");
                            Console.ResetColor();
                            ownerlessPositions.Add((cursorx + 1, cursory));
                            humanpoints--;
                        }

                        else
                        {
                            // komşu değil
                            Console.SetCursorPosition(cursorx + 1, cursory);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(":");
                            Console.ResetColor();
                            ownerlessPositions.Add((cursorx + 1, cursory));
                            humanpoints -= 5;

                        }

                        Console.SetCursorPosition(cursorx, cursory);
                        Console.WriteLine("|");
                        linevarmi = true;
                        verticalLines.Add((cursorx, cursory));
                    }

                    if ((verticalLines.Any(l => l.x == cursorx - 2 && l.y == cursory)) &&
                    (horizontalLines.Any(l => l.x == cursorx - 1 && l.y == cursory + 1)) &&
                    (horizontalLines.Any(l => l.x == cursorx - 1 && l.y == cursory - 1)))
                    {
                        if (((finalsquarex == cursorx - 1 && finalsquarey == cursory - 2) ||
                            (finalsquarex == cursorx - 1 && finalsquarey == cursory + 2) ||
                            (finalsquarex == cursorx - 3 && finalsquarey == cursory)))
                        {
                            Console.SetCursorPosition(cursorx - 1, cursory);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("P");
                            Console.ResetColor();
                            humanPositions.Add((cursorx - 1, cursory));
                            humanpoints++;

                            finalsquarex = cursorx - 1;
                            finalsquarey = cursory;
                        }

                        else if (humanPositions.Any(l => l.x == cursorx - 1 && l.y == cursory - 2) ||
                                 humanPositions.Any(l => l.x == cursorx - 1 && l.y == cursory + 2) ||
                                 humanPositions.Any(l => l.x == cursorx - 3 && l.y == cursory))
                        {
                            // komşu fakat bir öncekiyle komşu değil
                            Console.SetCursorPosition(cursorx - 1, cursory);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(":");
                            Console.ResetColor();
                            ownerlessPositions.Add((cursorx - 1, cursory));
                            humanpoints--;
                        }

                        else
                        {
                            // komşu değil
                            Console.SetCursorPosition(cursorx - 1, cursory);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(":");
                            Console.ResetColor();
                            ownerlessPositions.Add((cursorx - 1, cursory));
                            humanpoints -= 5;
                        }

                        Console.SetCursorPosition(cursorx, cursory);
                        Console.WriteLine("|");
                        linevarmi = true;
                        verticalLines.Add((cursorx, cursory));
                    }
                }

                if (cursory % 2 == 1)
                {
                    if ((horizontalLines.Any(l => l.x == cursorx && l.y == cursory + 2)) &&
                        (verticalLines.Any(l => l.x == cursorx + 1 && l.y == cursory + 1)) &&
                        (verticalLines.Any(l => l.x == cursorx - 1 && l.y == cursory + 1)))
                    {
                        if (((finalsquarex == cursorx - 2 && finalsquarey == cursory + 1) ||
                            (finalsquarex == cursorx + 2 && finalsquarey == cursory + 1) ||
                            (finalsquarex == cursorx && finalsquarey == cursory + 3)))
                        {
                            Console.SetCursorPosition(cursorx, cursory + 1);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("P");
                            Console.ResetColor();
                            humanPositions.Add((cursorx, cursory + 1));
                            humanpoints++;

                            finalsquarex = cursorx;
                            finalsquarey = cursory + 1;
                        }

                        else if (humanPositions.Any(l => l.x == cursorx - 2 && l.y == cursory + 1) ||
                                 humanPositions.Any(l => l.x == cursorx + 2 && l.y == cursory + 1) ||
                                 humanPositions.Any(l => l.x == cursorx && l.y == cursory + 3))
                        {
                            // komşu fakat bir öncekiyle komşu değil
                            Console.SetCursorPosition(cursorx, cursory + 1);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(":");
                            Console.ResetColor();
                            ownerlessPositions.Add((cursorx, cursory + 1));
                            humanpoints--;
                        }

                        else
                        {
                            // komşu değil
                            Console.SetCursorPosition(cursorx, cursory + 1);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(":");
                            Console.ResetColor();
                            ownerlessPositions.Add((cursorx, cursory + 1));
                            humanpoints -= 5;
                        }

                        Console.SetCursorPosition(cursorx, cursory);
                        Console.WriteLine("-");
                        linevarmi = true;
                        horizontalLines.Add((cursorx, cursory));
                    }

                    if ((horizontalLines.Any(l => l.x == cursorx && l.y == cursory - 2)) &&
                        (verticalLines.Any(l => l.x == cursorx + 1 && l.y == cursory - 1)) &&
                        (verticalLines.Any(l => l.x == cursorx - 1 && l.y == cursory - 1)))
                    {
                        if (((finalsquarex == cursorx + 2 && finalsquarey == cursory - 1) ||
                            (finalsquarex == cursorx - 2 && finalsquarey == cursory - 1) ||
                            (finalsquarex == cursorx && finalsquarey == cursory - 3)))
                        {
                            Console.SetCursorPosition(cursorx, cursory - 1);
                            Console.ForegroundColor = ConsoleColor.Blue;
                            Console.Write("P");
                            Console.ResetColor();
                            humanPositions.Add((cursorx, cursory - 1));
                            humanpoints++;

                            finalsquarex = cursorx;
                            finalsquarey = cursory - 1;
                        }

                        else if (humanPositions.Any(l => l.x == cursorx + 2 && l.y == cursory - 1) ||
                                 humanPositions.Any(l => l.x == cursorx - 2 && l.y == cursory - 1) || 
                                 humanPositions.Any(l => l.x == cursorx && l.y == cursory - 3))
                        {
                            // komşu fakat bir öncekiyle komşu değil
                            Console.SetCursorPosition(cursorx, cursory - 1);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(":");
                            Console.ResetColor();
                            ownerlessPositions.Add((cursorx, cursory - 1));
                            humanpoints--;
                        }

                        else
                        {
                            // komşu değil
                            Console.SetCursorPosition(cursorx, cursory - 1);
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.Write(":");
                            Console.ResetColor();
                            ownerlessPositions.Add((cursorx, cursory - 1));
                            humanpoints -= 5;
                        }

                        Console.SetCursorPosition(cursorx, cursory);
                        Console.WriteLine("-");
                        linevarmi = true;
                        horizontalLines.Add((cursorx, cursory));
                    }
                }
            }

            else if (firstSquare == 1)
            {
                if (cursory % 2 == 0)
                {
                    if ((verticalLines.Any(l => l.x == cursorx + 2 && l.y == cursory)) &&
                    (horizontalLines.Any(l => l.x == cursorx + 1 && l.y == cursory + 1)) &&
                    (horizontalLines.Any(l => l.x == cursorx + 1 && l.y == cursory - 1)))
                    {
                        Console.SetCursorPosition(cursorx + 1, cursory);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("P");
                        Console.ResetColor();
                        humanPositions.Add((cursorx + 1, cursory));
                        humanpoints++;

                        finalsquarex = cursorx + 1;
                        finalsquarey = cursory;
                        firstSquare++;

                        Console.SetCursorPosition(cursorx, cursory);
                        Console.WriteLine("|");
                        linevarmi = true;
                        verticalLines.Add((cursorx, cursory));
                    }

                    if ((verticalLines.Any(l => l.x == cursorx - 2 && l.y == cursory)) &&
                    (horizontalLines.Any(l => l.x == cursorx - 1 && l.y == cursory + 1)) &&
                    (horizontalLines.Any(l => l.x == cursorx - 1 && l.y == cursory - 1)))
                    {
                        Console.SetCursorPosition(cursorx - 1, cursory);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("P");
                        Console.ResetColor();
                        humanPositions.Add((cursorx - 1, cursory));
                        humanpoints++;

                        finalsquarex = cursorx - 1;
                        finalsquarey = cursory;
                        firstSquare++;

                        Console.SetCursorPosition(cursorx, cursory);
                        Console.WriteLine("|");
                        linevarmi = true;
                        verticalLines.Add((cursorx, cursory));
                    }
                }

                if (cursory % 2 == 1)
                {
                    if ((horizontalLines.Any(l => l.x == cursorx && l.y == cursory + 2)) &&
                        (verticalLines.Any(l => l.x == cursorx + 1 && l.y == cursory + 1)) &&
                        (verticalLines.Any(l => l.x == cursorx - 1 && l.y == cursory + 1)))
                    {
                        Console.SetCursorPosition(cursorx, cursory + 1);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("P");
                        Console.ResetColor();
                        humanPositions.Add((cursorx, cursory + 1));
                        humanpoints++;

                        finalsquarex = cursorx;
                        finalsquarey = cursory + 1;
                        firstSquare++;

                        Console.SetCursorPosition(cursorx, cursory);
                        Console.WriteLine("-");
                        linevarmi = true;
                        horizontalLines.Add((cursorx, cursory));
                    }

                    if ((horizontalLines.Any(l => l.x == cursorx && l.y == cursory - 2)) &&
                        (verticalLines.Any(l => l.x == cursorx + 1 && l.y == cursory - 1)) &&
                        (verticalLines.Any(l => l.x == cursorx - 1 && l.y == cursory - 1)))
                    {
                        Console.SetCursorPosition(cursorx, cursory - 1);
                        Console.ForegroundColor = ConsoleColor.Blue;
                        Console.Write("P");
                        Console.ResetColor();
                        humanPositions.Add((cursorx, cursory - 1));
                        humanpoints++;

                        finalsquarex = cursorx;
                        finalsquarey = cursory - 1;
                        firstSquare++;

                        Console.SetCursorPosition(cursorx, cursory);
                        Console.WriteLine("-");
                        linevarmi = true;
                        horizontalLines.Add((cursorx, cursory));
                    }
                }
            }

            //else
            //{
            //    Console.SetCursorPosition(40, 3);
            //    Console.WriteLine("Buraya Koyamazsınız!!");
            //    Thread.Sleep(1000);
            //    Console.SetCursorPosition(40, 3);
            //    Console.WriteLine("                     ");
            //}
            // uyarıyı çıkarmak için dene
        }

        // stage 2
        if (cki.Key == ConsoleKey.Spacebar && stage == 2)
        {
            if (cursory % 2 == 0 && cursorx % 2 == 1)
            {
                if ((verticalLines.Any(l => l.x == cursorx + 2 && l.y == cursory)) &&
                    (horizontalLines.Any(l => l.x == cursorx + 1 && l.y == cursory + 1)) &&
                    (horizontalLines.Any(l => l.x == cursorx + 1 && l.y == cursory - 1)))
                {
                    Console.SetCursorPosition(cursorx + 1, cursory);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(":");
                    Console.ResetColor();
                    ownerlessPositions.Add((cursorx + 1, cursory));
                }

                if ((verticalLines.Any(l => l.x == cursorx - 2 && l.y == cursory)) &&
                    (horizontalLines.Any(l => l.x == cursorx - 1 && l.y == cursory + 1)) &&
                    (horizontalLines.Any(l => l.x == cursorx - 1 && l.y == cursory - 1)))
                {
                    Console.SetCursorPosition(cursorx - 1, cursory);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(":");
                    Console.ResetColor();
                    ownerlessPositions.Add((cursorx - 1, cursory));
                }

                Console.SetCursorPosition(cursorx, cursory);
                Console.WriteLine("|");
                linevarmi = true;
                verticalLines.Add((cursorx, cursory));
            }

            if (cursory % 2 == 1 && cursorx % 2 == 0)
            {
                if ((horizontalLines.Any(l => l.x == cursorx && l.y == cursory + 2)) &&
                        (verticalLines.Any(l => l.x == cursorx + 1 && l.y == cursory + 1)) &&
                        (verticalLines.Any(l => l.x == cursorx - 1 && l.y == cursory + 1)))
                {
                    Console.SetCursorPosition(cursorx, cursory + 1);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(":");
                    Console.ResetColor();
                    ownerlessPositions.Add((cursorx, cursory + 1));
                }

                if ((horizontalLines.Any(l => l.x == cursorx && l.y == cursory - 2)) &&
                        (verticalLines.Any(l => l.x == cursorx + 1 && l.y == cursory - 1)) &&
                        (verticalLines.Any(l => l.x == cursorx - 1 && l.y == cursory - 1)))
                {
                    Console.SetCursorPosition(cursorx, cursory - 1);
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(":");
                    Console.ResetColor();
                    ownerlessPositions.Add((cursorx, cursory - 1));
                }

                Console.SetCursorPosition(cursorx, cursory);
                Console.WriteLine("-");
                linevarmi = true;
                horizontalLines.Add((cursorx, cursory));
            }

            stage++;
        }


        if (cki.Key == ConsoleKey.RightArrow && cursorx < 34)
        {
            if (cursory % 2 == 1 && cursorx % 2 == 1)
            {
                Console.SetCursorPosition(cursorx, cursory);
                Console.Write("+");
            }
            else if (((!verticalLines.Any(l => l.x == cursorx && l.y == cursory)) && (!horizontalLines.Any(l => l.x == cursorx && l.y == cursory))) && linevarmi == false)
            {
                Console.SetCursorPosition(cursorx, cursory);
                Console.Write(" ");
            }
            else if (verticalLines.Any(l => l.x ==  cursorx && l.y == cursory))
            {
                Console.SetCursorPosition(cursorx, cursory);
                Console.Write("|");
            }
            else if (horizontalLines.Any(l => l.x == cursorx && l.y == cursory))
            {
                Console.SetCursorPosition(cursorx, cursory);
                Console.Write("-");
            }
            if (humanPositions.Any(l => l.x == cursorx && l.y == cursory))
            {
                Console.SetCursorPosition(cursorx, cursory);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("P");
                Console.ResetColor();
            }
            if (ownerlessPositions.Any(l => l.x == cursorx && l.y == cursory))
            {
            Console.SetCursorPosition(cursorx, cursory);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(":");
            Console.ResetColor();
            }
            cursorx++;
            linevarmi = false;
        }

        if (cki.Key == ConsoleKey.LeftArrow && cursorx > 4)
        {
            if (cursory % 2 == 1 && cursorx % 2 == 1)
            {
                Console.SetCursorPosition(cursorx, cursory);
                Console.Write("+");
            }
            else if (((!verticalLines.Any(l => l.x == cursorx && l.y == cursory)) && (!horizontalLines.Any(l => l.x == cursorx && l.y == cursory))) && linevarmi == false)
            {
                Console.SetCursorPosition(cursorx, cursory);
                Console.Write(" ");
            }
            else if (verticalLines.Any(l => l.x == cursorx && l.y == cursory))
            {
                Console.SetCursorPosition(cursorx, cursory);
                Console.Write("|");
            }
            else if (horizontalLines.Any(l => l.x == cursorx && l.y == cursory))
            {
                Console.SetCursorPosition(cursorx, cursory);
                Console.Write("-");
            }
            if (humanPositions.Any(l => l.x == cursorx && l.y == cursory))
            {
                Console.SetCursorPosition(cursorx, cursory);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("P");
                Console.ResetColor();
            }
            if (ownerlessPositions.Any(l => l.x == cursorx && l.y == cursory))
            {
                Console.SetCursorPosition(cursorx, cursory);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(":");
                Console.ResetColor();
            }
            cursorx--;
            linevarmi = false;
        }

        if (cki.Key == ConsoleKey.UpArrow && cursory > 4)
        {
            if (cursory % 2 == 1 && cursorx % 2 == 1)
            {
                Console.SetCursorPosition(cursorx, cursory);
                Console.Write("+");
            }
            else if (((!verticalLines.Any(l => l.x == cursorx && l.y == cursory)) && (!horizontalLines.Any(l => l.x == cursorx && l.y == cursory))) && linevarmi == false)
            {
                Console.SetCursorPosition(cursorx, cursory);
                Console.Write(" ");
            }
            else if (verticalLines.Any(l => l.x == cursorx && l.y == cursory))
            {
                Console.SetCursorPosition(cursorx, cursory);
                Console.Write("|");
            }
            else if (horizontalLines.Any(l => l.x == cursorx && l.y == cursory))
            {
                Console.SetCursorPosition(cursorx, cursory);
                Console.Write("-");
            }
            if (humanPositions.Any(l => l.x == cursorx && l.y == cursory))
            {
                Console.SetCursorPosition(cursorx, cursory);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("P");
                Console.ResetColor();
            }
            if (ownerlessPositions.Any(l => l.x == cursorx && l.y == cursory))
            {
                Console.SetCursorPosition(cursorx, cursory);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(":");
                Console.ResetColor();
            }
            cursory--;
            linevarmi = false;
        }

        if (cki.Key == ConsoleKey.DownArrow && cursory < 20)
        {
            if (cursory % 2 == 1 && cursorx % 2 == 1)
            {
                Console.SetCursorPosition(cursorx, cursory);
                Console.Write("+");
            }
            else if (((!verticalLines.Any(l => l.x == cursorx && l.y == cursory)) && (!horizontalLines.Any(l => l.x == cursorx && l.y == cursory))) && linevarmi == false)
            {
                Console.SetCursorPosition(cursorx, cursory);
                Console.Write(" ");
            }
            else if (verticalLines.Any(l => l.x == cursorx && l.y == cursory))
            {
                Console.SetCursorPosition(cursorx, cursory);
                Console.Write("|");
            }
            else if (horizontalLines.Any(l => l.x == cursorx && l.y == cursory))
            {
                Console.SetCursorPosition(cursorx, cursory);
                Console.Write("-");
            }
            if (humanPositions.Any(l => l.x == cursorx && l.y == cursory))
            {
                Console.SetCursorPosition(cursorx, cursory);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("P");
                Console.ResetColor();
            }
            if (ownerlessPositions.Any(l => l.x == cursorx && l.y == cursory))
            {
                Console.SetCursorPosition(cursorx, cursory);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(":");
                Console.ResetColor();
            }
            cursory++;
            linevarmi = false;
        }

        Console.SetCursorPosition(40, 5);
        Console.Write("İnsan Skoru:" + humanpoints);
        

        if (linevarmi == false)
        {
            Console.SetCursorPosition(cursorx, cursory);
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write("X");
            Console.ResetColor();
        }

        Thread.Sleep(50);
    }
}