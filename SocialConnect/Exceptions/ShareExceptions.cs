namespace SocialConnect.Exceptions
{
    public class ShareExceptions : Exception
    {
        public ShareExceptions(string messsage) : base(messsage)
        {

        }
        public ShareExceptions(string messsage, Exception exception) : base(messsage)
        {

        }
    }
}
