﻿/******************************************************
* Programmer: Lance Zotigh (lzotigh1@cnm.edu/lzotigh1@gmail.com)
* Program: API Demo
* Purpose: Demo that shows how to create a Minimal API
*******************************************************/

//TODO Make a database using SQL to store the data. Need to find an appropriate data base such as MySQL or SQL Lite.

using DemoAPI.Models;

namespace DemoAPI.Data
{
    //Made this a static class so we do not have to create this as an object every time.
    public static class CouponStore
    {
        public static List<Coupon> couponList = new List<Coupon>()
        {
            new Coupon { Id = 1, Name = "10OFF", Percent = 10, IsActive = true },
            new Coupon { Id = 2, Name = "20OFF", Percent = 20, IsActive = false }
        };
    }
}
