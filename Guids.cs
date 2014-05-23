// Guids.cs
// MUST match guids.h
using System;

namespace UtkarshShigihalli.ProgressWindowDemo
{
    static class GuidList
    {
        public const string guidProgressWindowDemoPkgString = "7d54222f-33ee-4003-964f-0e8e6bb2153a";
        public const string guidProgressWindowDemoCmdSetString = "eb6933cb-bb2a-450b-9147-4d06650b8ed2";
        public const string guidToolWindowPersistanceString = "7bb54aac-652d-4000-a679-b5d9adc67a09";

        public static readonly Guid guidProgressWindowDemoCmdSet = new Guid(guidProgressWindowDemoCmdSetString);
    };
}