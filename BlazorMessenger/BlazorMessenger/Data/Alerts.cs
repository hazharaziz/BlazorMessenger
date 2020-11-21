﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace BlazorMessenger.Data
{
    public static class Alerts
    {
        public static string InvalidLoginInfo = "Login info is not correct!";
        public static string InvalidUsername = "The username is not valid!";
        public static string InvalidMessage = "The input message is invalid!";
    }
}
