using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class Result : IResult
    {
        //this burada resultı kasteder. ** "this(success)" ** Resultın tek parametreli olan constructorına successi yolla demektir. Mesela buraya iki parametre verse yine kendisini çalıştırırdı ama tek parametre verdiği için aynı metodun alttaki tek parametreli olanını da çalıştırıyor.
        public Result(bool success, string message ):this(success) 
        {
            //Getter yapıları read onlydir ve constructorda set edilebilir.
            Message=message;
        }
        //Metotlarda overloadinge bir örnek
        //** "this(success)" ** ifadesi alttaki metodu çalıştırır.
        public Result(bool success)
        { 
           Success=success;
        }
        public bool Success { get; }

        public string Message { get; }
    }
}
