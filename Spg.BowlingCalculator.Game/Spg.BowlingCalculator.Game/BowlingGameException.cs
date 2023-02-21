using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Spg.BowlingCalculator.Game
{
    public class BowlingGameException : Exception
    {
        public BowlingGameException()
            : base()
        { }

        public BowlingGameException(string message)
            : base(message)
        { }

        public BowlingGameException(string message, Exception innerException)
            : base(message, innerException)
        { }
    }
}
