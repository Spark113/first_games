using mtpfinal;
using Rectangles;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace mtpfinal
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("if you want to play flappy bird press 0 if you want to play iland game press 1");
            int whatgame= int.Parse(Console.ReadLine());
            if (whatgame == 0) 
            birdplay();
            if (whatgame==1)
            landgame();
        }

        public static void birdplay()//In this game, you need to avoid the pipes and go between them until you lose
        {
            Random rnd = new Random();
            int trecty = rnd.Next(10, 24);
            int trecty1 = rnd.Next(10, 24);
            int trecty2 = rnd.Next(10, 24);

            TRect rect = new TRect(90, 2, 10, 30, ConsoleColor.White);
            TRect rect1 = new TRect(90, trecty, 1, 5, ConsoleColor.Black);
            TRect rect2 = new TRect(99, trecty, 1, 5, ConsoleColor.Black);
            trecty1 = rnd.Next(10, 24);
            TRect rect3 = new TRect(90, 2, 10, 30, ConsoleColor.White);
            TRect rect4 = new TRect(90, trecty1, 1, 5, ConsoleColor.Black);
            TRect rect5 = new TRect(99, trecty1, 1, 5, ConsoleColor.Black);
            trecty2 = rnd.Next(10, 24);
            TRect rect6 = new TRect(90, 2, 10, 30, ConsoleColor.White);
            TRect rect7 = new TRect(90, trecty2, 1, 5, ConsoleColor.Black);
            TRect rect8 = new TRect(99, trecty2, 1, 5, ConsoleColor.Black);
            MTP bird = new MTP(20, 12, 'o', ConsoleColor.White, ConsoleColor.Black, 1);
            int cnt = 1;
            int cnt1 = 30;
            int cnt2 = 60;
            bool stopgame = false;
            int score = 0;
            int time = 1;
            int time1 = 1;
            int color1 = 1;
            int colorcnt = 0;
            while (stopgame != true)
            {
                Console.SetCursorPosition(0, 6);
                Console.WriteLine("score:" + " " + score);
                Console.SetCursorPosition(0, 5);
                Console.WriteLine("time:" + " " + time);
                bird.Draw();
                rect.Undraw();
                rect1.Undraw();
                rect2.Undraw();
                rect3.Undraw();
                rect4.Undraw();
                rect5.Undraw();
                rect6.Undraw();
                rect7.Undraw();
                rect8.Undraw();
                rect.SetX(90 - cnt);
                rect1.SetX(90 - cnt);
                rect2.SetX(99 - cnt);
                rect3.SetX(90 - cnt1);
                rect4.SetX(90 - cnt1);
                rect5.SetX(99 - cnt1);
                rect6.SetX(90 - cnt2);
                rect7.SetX(90 - cnt2);
                rect8.SetX(99 - cnt2);
                rect.Draw();
                rect1.Draw();
                rect2.Draw();
                rect3.Draw();
                rect4.Draw();
                rect5.Draw();
                rect6.Draw();
                rect7.Draw();
                rect8.Draw();
                Thread.Sleep(200);
                if (color1 % 15 == colorcnt)
                {
                    color1 += 1;
                    colorcnt = 0;
                }
                int color = color1 % 15+1;
                
                bird.SetFcolor((ConsoleColor)color);
                rect.SetFcolor((ConsoleColor)color);
                rect3.SetFcolor((ConsoleColor)color);
                rect6.SetFcolor((ConsoleColor)color);
                cnt++;
                cnt1++;
                cnt2++;
                time1++;
                color1++;
                colorcnt++;
                if (time1 % 5 == 0)
                    time += 1;
                if (rect.GetX() <= 10)
                {
                    cnt = 1;
                    trecty = rnd.Next(10, 24);
                    rect1.SetY(trecty);
                    rect2.SetY(trecty);
                }
                if (rect3.GetX() <= 10)
                {
                    cnt1 = 0;
                    trecty1 = rnd.Next(10, 24);
                    rect4.SetY(trecty1);
                    rect5.SetY(trecty1);
                }
                if (rect6.GetX() <= 10)
                {
                    cnt2 = 0;
                    trecty2 = rnd.Next(10, 24);
                    rect7.SetY(trecty2);
                    rect8.SetY(trecty2);
                }


                if (Console.KeyAvailable)
                {
                    bird.Undraw();
                    ConsoleKeyInfo k = Console.ReadKey();
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey();
                    }

                    if (k.Key == ConsoleKey.UpArrow)
                        bird.MoveUp();
                    else if (k.Key == ConsoleKey.DownArrow)
                        bird.MoveDown();
                    else if (k.Key == ConsoleKey.LeftArrow)
                        bird.MoveLeft();
                    else if (k.Key == ConsoleKey.RightArrow)
                        bird.MoveRight();
                    bird.Draw();

                }
                if (bird.GetX() == rect1.GetX())
                {
                    if (bird.GetY() >= rect1.GetY() && bird.GetY() <= (rect1.GetY() + 5))
                    {
                        score += 10;
                        Console.SetCursorPosition(0, 6);
                        Console.WriteLine("score:" + " " + score);
                    }
                    else
                    {
                        stopgame = true;
                        break;
                    }
                }
                if (bird.GetX() == rect2.GetX())
                {
                    if (bird.GetY() >= rect2.GetY() && bird.GetY() <= (rect2.GetY() + 5))
                    {
                        score += 10;
                        Console.SetCursorPosition(0, 6);
                        Console.WriteLine("score:" + " " + score);
                    }
                    else
                    {
                        stopgame = true;
                        break;
                    }
                }

                if (bird.GetX() == rect4.GetX())
                {
                    if (bird.GetY() >= rect4.GetY() && bird.GetY() <= (rect4.GetY() + 5))
                    {
                        score += 10;
                        Console.SetCursorPosition(0, 6);
                        Console.WriteLine("score:" + " " + score);
                    }
                    else
                    {
                        stopgame = true;
                        break;
                    }
                }
                if (bird.GetX() == rect5.GetX())
                {
                    if (bird.GetY() >= rect5.GetY() && bird.GetY() <= (rect5.GetY() + 5))
                    {
                        score += 10;
                        Console.SetCursorPosition(0, 6);
                        Console.WriteLine("score:" + " " + score);
                    }
                    else
                    {
                        stopgame = true;
                        break;
                    }
                }

                if (bird.GetX() == rect7.GetX())
                {
                    if (bird.GetY() >= rect7.GetY() && bird.GetY() <= (rect7.GetY() + 5))
                    {
                        score += 10;
                        Console.SetCursorPosition(0, 6);
                        Console.WriteLine("score:" + " " + score);
                    }
                    else
                    {
                        stopgame = true;
                        break;
                    }
                }
                if (bird.GetX() == rect8.GetX())
                {
                    if (bird.GetY() >= rect8.GetY() && bird.GetY() <= (rect8.GetY() + 5))
                    {
                        score += 10;
                        Console.SetCursorPosition(0, 6);
                        Console.WriteLine("score:" + " " + score);
                    }
                    else
                    {
                        stopgame = true;
                        break;
                    }
                }


            }






            Console.Clear();
            int i = 0;
            int i1 = 0;
            bool stopy = false;
            TRect tr2 = new TRect(35, 1, 21, 10, ConsoleColor.White);
            string lose = "you lose:( ";
            while (tr2.GetX() < 90)
            {
                i++;
                if (stopy != true)
                {
                    i1++;
                }


                tr2.SetX(i);
                tr2.SetY(i1);
                tr2.Draw();
                tr2.WriteText(lose);
                Thread.Sleep(100);
                tr2.UnWriteText(lose);
                tr2.Undraw();
                tr2.SetFcolor((ConsoleColor)(i % 16));
                if (tr2.GetY() == 20)
                {
                    stopy = true;
                }


                while (stopy != false)
                {
                    i++;
                    i1 -= 2;

                    tr2.SetX(i);
                    tr2.SetY(i1);
                    tr2.Draw();
                    tr2.WriteText(lose);
                    Thread.Sleep(100);
                    tr2.UnWriteText(lose);
                    tr2.Undraw();
                    tr2.SetFcolor((ConsoleColor)(i % 16));
                    if (tr2.GetY() == 2)
                    {
                        stopy = false;
                    }


                }

                Console.WriteLine("end");

            }
            while (tr2.GetX() > 2)
            {
                i--;
                if (stopy != true)
                {
                    i1++;
                }


                tr2.SetX(i);
                tr2.SetY(i1);
                tr2.Draw();
                tr2.WriteText(lose);
                Thread.Sleep(100);
                tr2.UnWriteText(lose);
                tr2.Undraw();
                tr2.SetFcolor((ConsoleColor)(i % 16));
                if (tr2.GetY() == 20)
                {
                    stopy = true;
                }


                while (stopy != false)
                {
                    i--;
                    i1 -= 2;

                    tr2.SetX(i);
                    tr2.SetY(i1);
                    tr2.Draw();
                    tr2.WriteText(lose);
                    Thread.Sleep(100);
                    tr2.UnWriteText(lose);
                    tr2.Undraw();
                    tr2.SetFcolor((ConsoleColor)(i % 16));
                    if (tr2.GetY() == 2)
                    {
                        stopy = false;
                    }


                }


            }


        }
        public static void landgame()//in this game, you need to jump from one island to the other until you lose
        {
            Random rnd = new Random();
            int landleft = rnd.Next(5, 35);
            int landright = rnd.Next(50, 70);
            TRect rect = new TRect(landleft, 14, 10, 1, ConsoleColor.Blue);
            TRect rect1 = new TRect(landright, 24, 10, 1, ConsoleColor.Red);
            MTP player = new MTP(45, 15, '1', ConsoleColor.White, ConsoleColor.Black, 4);

            rect.Draw();
            rect1.Draw();
            player.Draw();
            bool stopgame = false;
            int cnt = 0;
            int cnt1 = 0;
            int cnt3 = 1;
            int maxYlimit = 1;
            int minYlimit = 24;
            int minYlimit1 = 24;
            bool down =false;
            bool up = true;
            int color1 = 1;
            int colorcnt = 0;
            int score = 0;
            while (stopgame != true)
            {
                if (Console.KeyAvailable)
                {
                    player.Undraw();
                    ConsoleKeyInfo k = Console.ReadKey();
                    while (Console.KeyAvailable)
                    {
                        Console.ReadKey();
                    }

                    if (k.Key == ConsoleKey.UpArrow)
                        player.MoveUp();
                    else if (k.Key == ConsoleKey.DownArrow)
                        player.MoveDown();
                    else if (k.Key == ConsoleKey.LeftArrow)
                        player.MoveLeft();
                    else if (k.Key == ConsoleKey.RightArrow)
                        player.MoveRight();
                    player.Draw();

                }
                Console.SetCursorPosition(0, 6);
                Console.WriteLine("score:" + " " + score);
                rect.Undraw();
                rect1.Undraw();
                player.Undraw();
                if (rect.GetY() > maxYlimit&&up==true)
                {
                    rect.SetY(rect.GetY() - 1);
                }
                else if (up == true)
                {
                    rect.SetY(minYlimit);
                    landleft = rnd.Next(1, 40);
                    rect.SetX(landleft);
                }

                if (rect1.GetY() > maxYlimit&&up==true)
                {
                    rect1.SetY(rect1.GetY() - 1);
                }
                else if(up == true)
                {
                    rect1.SetY(minYlimit1);
                    landright = rnd.Next(46, 78);
                    rect1.SetX(landright);
                }

                if (cnt3 > 0 && down == true)
                {
                    rect.Undraw();
                    rect1.Undraw();

                    if (rect.GetY() < minYlimit)
                    {
                        rect.SetY(rect.GetY() + 1);
                    }
                    else if (down == true)
                    {
                        rect.SetY(maxYlimit);
                        landleft = rnd.Next(5, 35);
                        rect.SetX(landleft);
                    }

                    if (rect1.GetY() < minYlimit)
                    {
                        rect1.SetY(rect1.GetY() + 1);
                    }
                    else if (down == true)
                    {
                        rect1.SetY(maxYlimit);
                        landright = rnd.Next(50, 70);
                        rect1.SetX(landright);
                    }

                    cnt3++;
                    if (cnt3 % 15 == 0) 
                    {
                        up = true;  
                        down = false;
                    }
                }




                if (color1 % 15 == colorcnt)
                {
                    color1 += 1;
                    colorcnt = 0;
                }
                int color = color1 % 15+1;

                player.SetFcolor((ConsoleColor)color);
                rect.Draw();
                rect1.Draw();
                player.Draw();
                Thread.Sleep(500);
                if (rect.GetY() == player.GetY() && up == true)
                {
                    if (rect.GetX() <= player.GetX() && rect.GetX() + 5 >= player.GetX())
                    {
                        rect.Undraw();
                        landleft = rnd.Next(5, 35);
                        rect.SetX(landleft);
                        score += 10;
                        up = false;
                        down = true;
                    }
                    else
                    {
                        stopgame = true;
                    }
                }
                if (rect1.GetY() == player.GetY() && up == true)
                {
                    if (rect1.GetX() <= player.GetX() && rect1.GetX() + 5 >= player.GetX())
                    {
                        rect1.Undraw();
                        landright = rnd.Next(50, 70);
                        rect1.SetX(landright);
                        up = false;
                        down = true;
                        score += 10;


                    }
                    else
                    {
                        stopgame = true;
                    }
                }


                cnt++;
                cnt1++;
                color1++;
                colorcnt++;
            }
            
            Console.Clear();
            int i = 0;
            int i1 = 0;
            bool stopy = false;
            TRect tr2 = new TRect(35, 1, 21, 10, ConsoleColor.White);
            string lose = "you lose:( ";
            while (tr2.GetX() < 90)
            {
                i++;
                if (stopy != true)
                {
                    i1++;
                }


                tr2.SetX(i);
                tr2.SetY(i1);
                tr2.Draw();
                tr2.WriteText(lose);
                Thread.Sleep(100);
                tr2.UnWriteText(lose);
                tr2.Undraw();
                tr2.SetFcolor((ConsoleColor)(i % 16));
                if (tr2.GetY() == 20)
                {
                    stopy = true;
                }


                while (stopy != false)
                {
                    i++;
                    i1 -= 2;

                    tr2.SetX(i);
                    tr2.SetY(i1);
                    tr2.Draw();
                    tr2.WriteText(lose);
                    Thread.Sleep(100);
                    tr2.UnWriteText(lose);
                    tr2.Undraw();
                    tr2.SetFcolor((ConsoleColor)(i % 16));
                    if (tr2.GetY() == 2)
                    {
                        stopy = false;
                    }


                }

                Console.WriteLine("end");

            }
            while (tr2.GetX() > 2)
            {
                i--;
                if (stopy != true)
                {
                    i1++;
                }


                tr2.SetX(i);
                tr2.SetY(i1);
                tr2.Draw();
                tr2.WriteText(lose);
                Thread.Sleep(100);
                tr2.UnWriteText(lose);
                tr2.Undraw();
                tr2.SetFcolor((ConsoleColor)(i % 16));
                if (tr2.GetY() == 20)
                {
                    stopy = true;
                }


                while (stopy != false)
                {
                    i--;
                    i1 -= 2;

                    tr2.SetX(i);
                    tr2.SetY(i1);
                    tr2.Draw();
                    tr2.WriteText(lose);
                    Thread.Sleep(100);
                    tr2.UnWriteText(lose);
                    tr2.Undraw();
                    tr2.SetFcolor((ConsoleColor)(i % 16));
                    if (tr2.GetY() == 2)
                    {
                        stopy = false;
                    }


                }


            }

        }

    }

}
