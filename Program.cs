using System;

namespace Bullet_Trajectory_Calculator
{
    class Program
    {
        static string UserInput_BulletWeight;
        static int BulletWeight;
        static string UserInput_LoadWeight;
        static double LoadWeight;

        //150grain
        const int Vel_Inital_150 = 775;
        const double Min_Load_150 = 39.8;
        const double Vel_Increment_150 = (254 / 13);

        //168grain
        const int Vel_Inital_168 = 753;
        const double Min_Load_168 = 39.8;
        const double Vel_Increment_168 = (245 / 12);

        static void Main(string[] args)
        {
            Console.WriteLine("Norma 11 Calulator (#20185074) @Copyright 2020 Espen Bekkelien");
            BulletWeight = 1;
            while (BulletWeight != 0) { 
            Console.WriteLine("\nEnter Bullet Weight (150grain/168grain) or 0 to exit:");
            UserInput_BulletWeight = Console.ReadLine();
            BulletWeight = Convert.ToInt32(UserInput_BulletWeight);
            Console.WriteLine($"\nYou Entered: {BulletWeight}grain");

            if (BulletWeight == 150)
            {
                Console.WriteLine("\nEnter Load Weight (39.8grain to 46.3grain):");
                UserInput_LoadWeight = Console.ReadLine();
                LoadWeight = Convert.ToDouble(UserInput_LoadWeight);
                Console.WriteLine($"\nYou Entered: {LoadWeight}grain");
                double Bullet_Velocity = Vel_Bullet(LoadWeight);
                Console.WriteLine($"\nVelocity are: {Bullet_Velocity} m/s for a load of {LoadWeight}grain With a Bullet Weight of {BulletWeight}grain");
                double Grain_Compansation = Weight_Compansation(Bullet_Velocity, 1);
                Console.WriteLine($"\nTo reach same speed with 168grain a load weight of {Grain_Compansation}grain is required");
            }

            if (BulletWeight == 168)
            {
                Console.WriteLine("\nEnter Load Weight (39.8grain to 44.6grain):");
                UserInput_LoadWeight = Console.ReadLine();
                LoadWeight = Convert.ToDouble(UserInput_LoadWeight);
                Console.WriteLine($"\nYou Entered: {LoadWeight}grain");
                double Bullet_Velocity = Vel_Bullet(LoadWeight);
                Console.WriteLine($"\nVelocity are: {Bullet_Velocity} m/s for a load of {LoadWeight}grain With a Bullet Weight of {BulletWeight}grain");
                double Grain_Compansation = Weight_Compansation(Bullet_Velocity,1);
                Console.WriteLine($"\nTo reach same speed with 150grain a load weight of {Grain_Compansation}grain is required");

                }
            }  

        }

        static double Vel_Bullet(double Bullet_Velocity)
        {

            if (BulletWeight == 150) 
            {
                Bullet_Velocity = Vel_Inital_150 + ((Bullet_Velocity - Min_Load_150) * Vel_Increment_150);
            }

            if (BulletWeight == 168)
            {
                Bullet_Velocity = Vel_Inital_168 + ((Bullet_Velocity - Min_Load_168) * Vel_Increment_168);
            }
            return Bullet_Velocity;
        }

        static double Weight_Compansation(double Bullet_Velocity, double Grain_Compansation_grain)
        {

            if (BulletWeight == 150)
            {
                Grain_Compansation_grain = (1 / Vel_Increment_168) * (Bullet_Velocity + (Min_Load_168 * Vel_Increment_168) - Vel_Inital_168);
            }

            if (BulletWeight == 168)
            {
                Grain_Compansation_grain = (1 / Vel_Increment_150) * (Bullet_Velocity + (Min_Load_150 * Vel_Increment_150) - Vel_Inital_150);
            }
                return Grain_Compansation_grain;
        }
    }
}
