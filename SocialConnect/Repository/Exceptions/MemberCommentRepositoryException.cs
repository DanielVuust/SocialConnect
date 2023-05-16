namespace SocialConnect.Repository.Exceptions
{
    public class MemberCommentRepositoryException : Exception
    {

        public MemberCommentRepositoryException(string message) : base(message) { }
        public MemberCommentRepositoryException(string message, Exception innerException) : base(message)
        {
        }
    }
}
