using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Shared.ViewModel
{
    public enum ToastType
    {
        Success, Error, Info, Warning,
    }


    public class Toast
    {
        public string Title { get { return Type == ToastType.Error ? "خطا" : "موفقیت آمیز"; } }
        public string Message { get; set; } = "";
        public ToastType Type { get; set; } = ToastType.Error;

    }

}
