namespace SocialConnect.Exceptions
{
    public class BulletinExceptions : Exception
    {
        public BulletinExceptions(string messsage) : base(messsage)
        {

        }
        public BulletinExceptions(string messsage, Exception exception) : base(messsage)
        {

        }
    }
}
