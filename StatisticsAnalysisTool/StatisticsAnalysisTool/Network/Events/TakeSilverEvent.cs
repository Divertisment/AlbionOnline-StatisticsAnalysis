﻿using Albion.Network;
using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace StatisticsAnalysisTool.Network.Handler
{
    public class TakeSilverEvent : BaseEvent
    {
        public TakeSilverEvent(Dictionary<byte, object> parameters) : base(parameters)
        {
            try
            {
                Debug.Print($"-----------------------------------------");
                foreach (var parameter in parameters)
                {
                    Debug.Print($"{parameter}");
                }

                if (parameters.ContainsKey(3))
                {
                    TotalCollectedSilver = int.Parse(parameters[3].ToString().Remove(parameters[3].ToString().Length - 4));
                    GuildTax = parameters.ContainsKey(5) ? int.Parse(parameters[5].ToString().Remove(parameters[5].ToString().Length - 4)) : 0;
                    EarnedSilver = TotalCollectedSilver - GuildTax;
                }
                else
                {
                    TotalCollectedSilver = 0;
                    GuildTax = 0;
                    EarnedSilver = 0;
                }
            }
            catch(Exception e)
            {
                Debug.Print(e.Message);
            }
        }

        public long UserId { get; }
        public int TotalCollectedSilver { get; }
        public int GuildTax { get; }
        public int EarnedSilver { get; }
    }
}