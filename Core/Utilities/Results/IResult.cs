using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{   
    //Temel voidler için başlangıç
    public interface IResult
    {
        //başarılı mı başarısız mı bunu kontrol eder. True veya false döner.
        bool Success { get; }

        //Kullanıcıya bilgilendirme mesajı döner.
        string Message { get; } 
    }
}
