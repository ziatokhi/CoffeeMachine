using System;
using System.Collections.Generic;
using System.Text;

namespace CoffeeMachine.Common
{
  public  interface IDateTime
    {
        DateTime Now { get; }
    }
}
