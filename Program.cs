using System;
using System.Collections.Generic;
using BattlefieldTEST;
using System.Linq;
using System.Threading;
using System.Text.RegularExpressions;

namespace BattlefieldTEST
{
    class Field
    {
        bool side; // если true - пользователь, если false - комп
        int hp = 20;
        public string name; // название кому относится поле - пользователю или компу
        public int width = 11;
        public int height = 11;
        string[,] field = new string[11, 11]; //визуальное поле
                                              
        public Field(bool side, string name)
        {
            this.side = side;
            this.name = name;
            
        }
        public void setEmptyField() //заполняет null техническое и визуальное поле пустыми клетками
        {
            for (int n = 0; n < height; n++) // заполняем визуальное поле
            {
                for (int i = 0; i < width; i++)
                {
                    this.field[n, i] = "_";

                }
            }
            this.field[0, 0] = "  "; // заполняем визуальные координаты
            this.field[0, 1] = "a";
            this.field[0, 2] = "b";
            this.field[0, 3] = "c";
            this.field[0, 4] = "d";
            this.field[0, 5] = "e";
            this.field[0, 6] = "f";
            this.field[0, 7] = "g";
            this.field[0, 8] = "h";
            this.field[0, 9] = "i";
            this.field[0, 10] = "j";
            this.field[1, 0] = " 1";
            this.field[2, 0] = " 2";
            this.field[3, 0] = " 3";
            this.field[4, 0] = " 4";
            this.field[5, 0] = " 5";
            this.field[6, 0] = " 6";
            this.field[7, 0] = " 7";
            this.field[8, 0] = " 8";
            this.field[9, 0] = " 9";
            this.field[10, 0] = "10";


        }


        public void setHp(int hp)
        {
            this.hp = hp;

        }

        public int getHp()
        {
            return this.hp;

        }

        public void showFields() // отобразить поле юзера, которое должно быть видно
        {
            //Igor: для обращения к текущему объекту используем this
            Console.WriteLine("Visual Field of " + this.name + ". HP: " + (this.getHp()));
            Console.WriteLine();
            for (int n = 0; n < height; n++) // показываем визуальное поле
            {
                for (int i = 0; i < width; i++)
                {
                    Console.Write(this.field[n, i] + " ");

                }
                Console.WriteLine();
            }

            Console.WriteLine();

        }

        public void showComputerFields() // отобразить поле компьютера закрывая корабли
        {
            
            Console.WriteLine("Visual Field of " + this.name + ". HP: " + (this.getHp()));
            Console.WriteLine();
            for (int n = 0; n < height; n++) // показываем визуальное поле
            {
                for (int i = 0; i < width; i++)
                {
                    if (n==0)
                    {
                        Console.Write(field[n, i]+ " ");
                    }
                    else if (n==1 && i == 0)
                    {
                        Console.Write(this.field[n, i] + " ");
                    }
                    else if (n == 2 && i == 0)
                    {
                        Console.Write(this.field[n, i] + " ");
                    }
                    else if (n == 3 && i == 0)
                    {
                        Console.Write(this.field[n, i] + " ");
                    }
                    else if (n == 4 && i == 0)
                    {
                        Console.Write(this.field[n, i] + " ");
                    }
                    else if (n == 5 && i == 0)
                    {
                        Console.Write(this.field[n, i] + " ");
                    }
                    else if (n == 6 && i == 0)
                    {
                        Console.Write(this.field[n, i] + " ");
                    }
                    else if (n == 7 && i == 0)
                    {
                        Console.Write(this.field[n, i] + " ");
                    }
                    else if (n == 8 && i == 0)
                    {
                        Console.Write(this.field[n, i] + " ");
                    }
                    else if (n == 9 && i == 0)
                    {
                        Console.Write(this.field[n, i] + " ");
                    }
                    else if (n == 10 && i == 0)
                    {
                        Console.Write(this.field[n, i] + " ");
                    }
                    else if (n == 11 && i == 0)
                    {
                        Console.Write(this.field[n, i] + " ");
                    }
                    else if (this.field[n, i] == "X" | this.field[n, i] == "o")
                    {
                        Console.Write(this.field[n, i] + " ");
                    }
                    else
                    {
                        Console.Write(" " + " ");
                    }


                }
                Console.WriteLine();
            }

            Console.WriteLine();

        }

  /*      public void setRandomShips2()    // не доработанный метод генерации суден в более коротком варианте
        {
            var desiredShips = new List<int> { 4, 3, 3, 2, 2, 2, 1, 1, 1, 1 };

            Random rand = new Random();

            foreach (var shipLength in desiredShips)
            {
                
                // генерация нового судна пользователя четырехпалубного
                int randomHorizontalOrVertical = rand.Next(2);

                bool orientation = (randomHorizontalOrVertical == 0 ? true : false);
                int randomVerticalNumber = rand.Next(1, 8);
                int randomHorizontalNumber = rand.Next(1, 8);

                while (!this.isCanSetupShipHere(randomVerticalNumber, randomHorizontalNumber, orientation, shipLength))
                {
                    randomHorizontalOrVertical = rand.Next(2);
                    orientation = (randomHorizontalOrVertical == 0 ? true : false);
                    randomVerticalNumber = rand.Next(1, 8);
                    randomHorizontalNumber = rand.Next(1, 8);
                }
                
                var deltaX = orientation ? 1 : 0;
                var deltaY = orientation ? 0 : 1;
                for (var i = 0; i < shipLength; i++)
                {
                    field[randomVerticalNumber + deltaY * i, randomHorizontalNumber + deltaX * i] = shipLength.ToString();
                }
            }
            
        }

        private bool isCanSetupShipHere(int vert, int hor, bool orientation, int shipLength)
        {
            var result = true;

            var deltaX = orientation ? 1 : 0;
            var deltaY = orientation ? 0 : 1;

            for (var i = 0; i < shipLength; i++)
            {
                var currentX = deltaX * i + hor;
                var currentY = deltaY * i + vert;
                if (currentX > 8 || currentY > 8)
                {
                    result = false;
                    break;
                }
                if (this.field[currentY, currentX] != "_")
                {
                    //then field is filled with one of the numbers from 1 to 4 - per ship data
                    result = false;
                    break;
                }
            }
            

            return result;
        }*/

        public void setRandomShips() // установка суден на поле
                                     //TODO: добавить проверку соседних клеток, корабль не может соприкасаться с другими, пока так

        {

            Random rand = new Random();
            // генерация нового судна пользователя четырехпалубного
            int randomHorizontalOrVertical = rand.Next(2);
            bool orientation = (randomHorizontalOrVertical == 0 ? true : false);

            int randomVerticalNumber = rand.Next(1, 8);
            int randomHorizontalNumber = rand.Next(1, 8);

            if (orientation == true)
            {
                for (int i = 1; i < 5; i++)
                {

                    field[randomVerticalNumber, randomHorizontalNumber] = "4";

                    randomHorizontalNumber++;
                }
            }
            else
            {
                for (int i = 1; i < 5; i++)
                {
                    field[randomVerticalNumber, randomHorizontalNumber] = "4";
                    randomVerticalNumber++;
                }
            }

            void setRandomShip3() // генерация начала палубы одного трехпалубного судна пользователя
            {
                randomHorizontalOrVertical = rand.Next(2); // переделать потом на случайное
                randomVerticalNumber = rand.Next(1, 9);
                randomHorizontalNumber = rand.Next(1, 9);

            }

            for (int d = 0; d < 2; d++) // цикл на генерацию двух трехпалубных суден
            {
                setRandomShip3();
                int randomVerticalNumberInitial = randomVerticalNumber;
                int randomHorizontalNumberInitial = randomHorizontalNumber;
                while (randomHorizontalOrVertical == 1 ? (randomHorizontalNumberInitial != (randomHorizontalNumber + 3)) : (randomVerticalNumberInitial != (randomVerticalNumber + 3)))//начало проверки на наложение 
                {

                    if (field[randomVerticalNumberInitial, randomHorizontalNumberInitial] == "_") // проверка по интерфейсному полюзанятости ячеек
                    {
                        if (randomHorizontalOrVertical == 1)
                        {
                            randomHorizontalNumberInitial++;
                        }
                        else { randomVerticalNumberInitial++; }

                    }

                    else // перегененрирование в случае занятости
                    {
                        setRandomShip3();
                        randomVerticalNumberInitial = randomVerticalNumber;
                        randomHorizontalNumberInitial = randomHorizontalNumber;
                    }
                }
                //Console.WriteLine("Отладочный, цифры если горизонталь:" + Convert.ToInt32((randomVerticalNumber - 1) + "" + (randomHorizontalNumber + 1)) + "Отладочные если вертикаль" + Convert.ToInt32((randomVerticalNumber - 1) + "" + (randomHorizontalNumber + 1))); // отладочный 
                if (randomHorizontalOrVertical == 1) // генерирование корабля
                {


                    for (int i = 1; i < 4; i++)
                    {

                        field[randomVerticalNumber, randomHorizontalNumber++] = "3";
                        //   userTechnicalField[Convert.ToInt32((randomVerticalNumber - 1) + "" + (randomHorizontalNumber++ - 1))] = ship;
                    }
                }
                else
                {
                    for (int i = 1; i < 4; i++)
                    {
                        field[randomVerticalNumber++, randomHorizontalNumber] = "3";
                        //  userTechnicalField[Convert.ToInt32((randomVerticalNumber++ - 1) + "" + (randomHorizontalNumber - 1))] = ship;
                    }
                }
            }

            //двухпалубные суда пользователя
            void setRandomShip2() // генерация начала палубы одного трехпалубного судна
            {
                randomHorizontalOrVertical = rand.Next(2); // переделать потом на случайное
                randomVerticalNumber = rand.Next(1, 10);

                randomHorizontalNumber = rand.Next(1, 10);

            }

            for (int d = 0; d < 3; d++) // цикл на генерацию 3 суден
            {
                setRandomShip2();
                int randomVerticalNumberInitial = randomVerticalNumber;
                int randomHorizontalNumberInitial = randomHorizontalNumber;
                while (randomHorizontalOrVertical == 1 ? (randomHorizontalNumberInitial != (randomHorizontalNumber + 2)) : (randomVerticalNumberInitial != (randomVerticalNumber + 2)))//начало проверки на наложение 
                {

                    if (field[randomVerticalNumberInitial, randomHorizontalNumberInitial] == "_")
                    {
                        if (randomHorizontalOrVertical == 1)
                        {
                            randomHorizontalNumberInitial++;
                        }
                        else { randomVerticalNumberInitial++; }

                    }

                    else
                    {
                        setRandomShip2();
                        randomVerticalNumberInitial = randomVerticalNumber;
                        randomHorizontalNumberInitial = randomHorizontalNumber;
                    }
                }
                if (randomHorizontalOrVertical == 1) // генерирование корабля
                {


                    for (int i = 1; i < 3; i++)
                    {

                        field[randomVerticalNumber, randomHorizontalNumber++] = "2";
                    }
                }
                else
                {
                    for (int i = 1; i < 3; i++)
                    {
                        field[randomVerticalNumber++, randomHorizontalNumber] = "2";
                    }
                }
            }

            //однопалубные
            void setRandomShip1() // генерация начала палубы одного трехпалубного судна
            {
                randomHorizontalOrVertical = rand.Next(2); // переделать потом на случайное
                randomVerticalNumber = rand.Next(1, 11);
                randomHorizontalNumber = rand.Next(1, 11);

            }

            for (int d = 0; d < 4; d++) // цикл на генерацию 4 суден
            {
                setRandomShip1();
                int randomVerticalNumberInitial = randomVerticalNumber;
                int randomHorizontalNumberInitial = randomHorizontalNumber;
                while (true)//начало проверки на наложение 
                {

                    if (field[randomVerticalNumberInitial, randomHorizontalNumberInitial] == "_")
                    {

                        break;
                    }

                    else
                    {
                        setRandomShip1();
                        randomVerticalNumberInitial = randomVerticalNumber;
                        randomHorizontalNumberInitial = randomHorizontalNumber;
                    }
                }

                field[randomVerticalNumber, randomHorizontalNumber] = "1";

            }





        } // конец метода генерации суден

        public bool win() // проверка на окончание игры
        {
            if (this.hp == 0)
            {
                Console.WriteLine(name + " проиграл!");
                return false;
            }
            return true;

        }
            public bool userShoot() // выстрел от ползователя по компьютеру
            {
                int horizontalPos = 1;
                int verticalPos;
            Console.WriteLine("Пожалуйста введите координаты выстрела (в формате b3)");
                string userShootCoordinate = Console.ReadLine();
            string horizontalUserShootCoordinate = Regex.Replace(userShootCoordinate, "[0-9]", "", RegexOptions.IgnoreCase);
            switch (horizontalUserShootCoordinate)
                {
                    case "a":
                        horizontalPos = 1;
                        
                        break;
                    case "b":
                        horizontalPos = 2;
                        
                        break;
                    case "c":
                        horizontalPos = 3;
                        
                        break;
                    case "d":
                        horizontalPos = 4;
                        
                        break;
                    case "e":
                        horizontalPos = 5;
                        
                        break;
                    case "f":
                        horizontalPos = 6;
                        
                        break;
                    case "g":
                        horizontalPos = 7;
                        
                        break;
                    case "h":
                        horizontalPos = 8;
                        
                        break;
                    case "i":
                        horizontalPos = 9;
                       
                        break;
                    case "j":
                        horizontalPos = 10;
                        
                        break;
                }
                int.TryParse(string.Join("", userShootCoordinate.Where(c => char.IsDigit(c))), out verticalPos);
            Console.WriteLine("h:"+ horizontalPos + " V:" + verticalPos);
                if (this.hit(verticalPos, horizontalPos)==false)
            {
                return false;
            }
            else
            {
                return true;
            }
            }

        public bool computerShoot() // выстред от компьютера. Пока рандомно, пока судна соприкасаются
        {
            Random rand = new Random();
            Thread.Sleep(15);
            int randomVerticalNumber = rand.Next(1, 11);
            int randomHorizontalNumber = rand.Next(1, 11);
            if ( this.hit(randomVerticalNumber, randomHorizontalNumber)) 
            
            { return true;
            }
            else
            {
                return false;
            }
        }


        public bool hit(int i, int j) // метод выстрела
        {
            if (this.field[i, j] == "1" | this.field[i, j] == "2" | this.field[i, j] == "3" | this.field[i, j] == "4")
            {
                this.field[i, j] = "X";
                Console.WriteLine("Попадание!");
                this.setHp(this.getHp() - 1);
                Console.WriteLine("У " + name + " осталось жизней: " + getHp());
                return true;
            }
            else if (this.field[i, j] == "X" | this.field[i, j] == "o")
            {
                Console.WriteLine("Вы уже стреляли в эту точку! Очередь " + name + "!");
            }
            else
            {
                this.field[i, j] = "o";
                Console.WriteLine("Не попали. Очередь " + name + "!");
                return false;
            }

            return false;

        }



        public static void soundtrack() 
        {
            Console.Beep(300, 500);
            Thread.Sleep(50);
            Console.Beep(300, 500);
            Thread.Sleep(50);
            Console.Beep(300, 500);
            Thread.Sleep(50);
            Console.Beep(250, 500);
            Thread.Sleep(50);
            Console.Beep(350, 250);
            Console.Beep(300, 500);
            Thread.Sleep(50);
            Console.Beep(250, 500);
            Thread.Sleep(50);
            Console.Beep(350, 250);
            Console.Beep(300, 500);
            Thread.Sleep(50);
        }




    }



    

}

class Program
{
    static void Main(string[] args)
    {
        Field userField = new Field(true, "user");
        Field computerField = new Field(false, "computer");
        userField.setEmptyField();
        computerField.setEmptyField();
        Console.SetCursorPosition(30, 1);
        Console.ForegroundColor = ConsoleColor.Red;
        Field.soundtrack();
        Console.WriteLine("Welcome to BATTLEFIELD game! V0.1");
        Thread.Sleep(5000);
        Console.Clear();
        Console.WriteLine("You have 20 HP. Ships set are done randomly. In this version decks of ships can touch.");
        userField.setRandomShips();
        Console.ResetColor();
        Thread.Sleep(500);
        computerField.setRandomShips();
        userField.showFields();
        computerField.showComputerFields();
        Boolean yes = true;

        while (yes)
        {
            
            while (computerField.userShoot()==true)
            {
                Console.Clear();
                userField.showFields();
                computerField.showComputerFields();

                if (userField.win() == false | computerField.win() == false)
                {
                    yes = false;

                    
                    break;
                }
            }
            if (userField.win() == false | computerField.win() == false)
            {
                yes = false;

                Console.WriteLine("Спасибо за игру!");
                break;
            }
            if (userField.computerShoot() == true)
            {
                userField.showFields();
                computerField.showComputerFields();
                while (userField.computerShoot() == true)
            {
                
                userField.showFields();
                computerField.showComputerFields();

                if (userField.win() == false | computerField.win() == false)
                {
                    yes = false;

                    Console.WriteLine("Спасибо за игру!");
                    break;
                }
            }
            }
            else
            {
                userField.showFields();
                computerField.showComputerFields();
            }






        }
        Console.ReadLine();


    }
}