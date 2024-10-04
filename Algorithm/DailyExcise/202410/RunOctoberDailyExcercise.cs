﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Algorithm.DailyExcise
{
    public class RunOctoberDailyExcercise
    {
        public static void Run()
        {
            var minCosTicketsClass = new MincostTicketsClass();
            var minCostTicketsResult = minCosTicketsClass.MincostTickets(new int[] { 1, 4, 6, 7, 8, 20 },new int[] { 2, 7, 15 });//11

            minCostTicketsResult = minCosTicketsClass.MincostTickets(new int[] { 1, 4, 6, 7, 8, 365 }, new int[] { 2,7,15});//11

            minCostTicketsResult = minCosTicketsClass.MincostTickets2(new int[] { 1, 4, 6, 7, 8, 20 }, new int[] { 2, 7, 15 });//11

            var minSpeedOnTimeClass = new MinSpeedOnTimeClass();
            var minSpeedOnTimeResult = minSpeedOnTimeClass.MinSpeedOnTime(new int[] { 1, 3, 2 },6);//1

            minSpeedOnTimeResult = minSpeedOnTimeClass.MinSpeedOnTime(new int[] { 1, 3, 2 }, 2.7);//3

            minSpeedOnTimeResult = minSpeedOnTimeClass.MinSpeedOnTime(new int[] { 1, 1, 100000 }, 2.01);//10000000

            minSpeedOnTimeResult = minSpeedOnTimeClass.MinSpeedOnTime(new int[] { 37, 64, 81 }, 3.11);//73

            var minCostClass = new MinCostClass();
            var minCostResult = minCostClass.MinCost(30,new int[][] { 
                new int[]{ 0,1,10},
                new int[]{ 1,2,10}, 
                new int[]{2,5,10},
                new int[]{0,3,1 },
                new int[]{3,4,10},
                new int[]{4,5,15}
            }, new int[] { 5, 1, 2, 20, 20, 3 });//11


            minCostResult = minCostClass.MinCost(100, new int[][] {
                new int[]{ 0,1,100}
            }, new int[] { 2,5 });//7


            minCostResult = minCostClass.MinCost2(30, new int[][] {
                new int[]{ 0,1,10},
                new int[]{ 1,2,10},
                new int[]{2,5,10},
                new int[]{0,3,1 },
                new int[]{3,4,10},
                new int[]{4,5,15}
            }, new int[] { 5, 1, 2, 20, 20, 3 });//11

            var nthPersonGetNthSeatClass = new NthPersonGetsNthSeatClass();
            var nthPersonGetNthSeatResult = nthPersonGetNthSeatClass.NthPersonGetsNthSeat(4);//0.5
        }
    }
}
