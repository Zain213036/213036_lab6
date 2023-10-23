using System;
namespace _213036_Ex2

{

    class Question2
    {
        static void Test(string[] args)
        {

            System.IO.StreamWriter sw = null;
            try
            {
                sw = new System.IO.StreamWriter(@"text.cases");
                sw.WriteLine("Hellow world");
            }

            catch (System.IO.FileNotFoundException)
            {
                System.Console.WriteLine(ex.ToString());
            }

            catch (System.IO.IOException ex)
            {
                System.Console.WriteLine(ex.ToString());
            }

            finally

            {
                sw.Close();
            }
            System.Console.WriteLine("Done");
        }

    }




}