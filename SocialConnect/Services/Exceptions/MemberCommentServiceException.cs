namespace SocialConnect.Services.Exceptions
{
    public class MemberCommentServiceException : Exception
    {
        public MemberCommentServiceException(string messsage) : base(messsage)
        {

        }
        public MemberCommentServiceException(string messsage, Exception exception) : base(messsage)
        {

        }
    }
}
