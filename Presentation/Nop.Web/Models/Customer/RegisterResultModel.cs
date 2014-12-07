using Nop.Web.Framework.Mvc;

namespace Nop.Web.Models.Customer
{
    public partial class RegisterResultModel : BaseNopModel
    {
        public string ResultTitle { get; set; }
        public string Result { get; set; }
    }
}