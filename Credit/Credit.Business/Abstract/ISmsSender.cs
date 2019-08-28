using Credit.Business.DTOs.Sms;

namespace Credit.Business.Abstract
{
    public interface ISmsSender
    {
         void SendSms(SendSmsDto dto);
    }
}
