namespace Shop.Persistence.EF.SendingEmail
{
    public interface IEmail
    {
        Task SendEmail(MessageParams messageParams);
    }
}