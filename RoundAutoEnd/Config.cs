using Exiled.API.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RoundAutoEnd
{
    public sealed class Config : IConfig
    {
        [Description("Are you on the plugin?")]
        public bool IsEnabled { get; set; } = true;

        [Description("How many seconds after the start of the round does the round end ? Defualt : 30minutes.")]
        public float EndMessage { get; set; } = 1800f;
    }
}
