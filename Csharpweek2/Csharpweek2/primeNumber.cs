﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharpweek2
{
    //求质因数
    public class PrimeNumber
    {
        //判断一个数是不是质数
        public static bool IsPrime(int var)
        {
            int i = 2;
            while (i < var)
            {
                if (var % i == 0)
                {
                    return false;
                }
                i++;
            }
            return true;
        }

        //求质因数
        public static void PrimeFactors(int var,out List<int>result)
        {
            int i;
            result = new List<int>();
            for (i = 2; i <= var; i++)
            {
                while (var % i == 0)
                {
                    var = var / i;
                    result.Add(i);                  
                    if (IsPrime(var))
                    {
                        result.Add(var);
                        return;
                    }
                }
            }
        }

        //测试
        public  void PrimeFactorsMain()
        {
            Console.Write("输入数字:");
            int x = Convert.ToInt32(Console.ReadLine());
            List<int> result ;
            PrimeFactors(x,out result);
            foreach(int i in result)
            {
                Console.Write(i+" ");
               
            }
            Console.WriteLine();
        }
        
    }

    //数组计算
    public class Array
    {
        //创建数组
        public int[] CreateArray()
        {
            Random rd = new Random();
            int[] testArray = new int[10];
            for (int i = 0; i < testArray.Length; i++)
            {
                testArray[i] = rd.Next()%50;
                Console.Write(testArray[i]+" ");
            }
            return testArray;
        }

        //计算得到数组的最小值，最大值，和以及平均值
        public void Calculate(int[] testArray, out int min, out int max, out int sum, out double mean)
        {
            mean = min = max = testArray[0];
            sum = 0;
            for (int i = 0; i < testArray.Length; i++)
            {
               
                sum = sum + testArray[i];
                if (testArray[i] < min)
                    min = testArray[i];
                if (testArray[i] > max)
                    max = testArray[i]; 

            }
            mean = (double)sum / (testArray.Length);
        }

        //测试
        public void ArrayTest()
        {
            int min, max, sum;
            double mean;
            int[] testArray = this.CreateArray();
            this.Calculate(testArray, out min, out max, out sum, out mean);
            
            Console.WriteLine("最小值：" + min + "最大值：" + max + "平均值：" + mean + "和：" + sum);
        }

    }

    //埃氏筛法
    class Eratosthenes
    {
        //埃氏筛法
        public void Transform(out List<int> list)
        {  
            //创建2-100的List
            list = new List<int>();
            for (int i = 0; i < 99; i++)
            {
                list.Add(i + 2);
            }

            //将不符合埃氏筛法的数去除
            int count;
            for (count = 0; count < 99; count++)
            {
                if (count * count > 99)
                    return;
                for (int i = 0; i < list.Count; i++)
                {
                    if (list[i] % list[count] == 0&&i!=count)
                    {
                        list.Remove(list[i]);
                    }
                }
            }
        }
        public void EratosthenesTest()
        {
            List<int> list;
            this.Transform(out list);
            Console.WriteLine("2-100中的素数：");
            for(int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i]+" ");
            }
        }
       
    }

    //测试类
    class Test
    {
        static void Main(string []args)
        {
            PrimeNumber p = new PrimeNumber();
            p.PrimeFactorsMain();
            Array arr = new Array();
            arr.ArrayTest();
            Eratosthenes era = new Eratosthenes();
            era.EratosthenesTest();
        }
        
        
    }
}
