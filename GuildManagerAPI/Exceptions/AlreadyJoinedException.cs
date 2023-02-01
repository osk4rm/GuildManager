using GuildManager_DataAccess.Enum;

namespace GuildManagerAPI.Exceptions
{
    public class AlreadyJoinedException : Exception
    {
        private readonly string _message;

        public AlreadyJoinedException(AcceptanceStatus status)
        {
            switch (status)
            {
                case AcceptanceStatus.Accepted:
                    _message = "Your character have already been accepted to this event."; break;
                case AcceptanceStatus.Rejected:
                    _message = "Your character have already been rejected from this event."; break;
                case AcceptanceStatus.Waiting:
                    _message = "Your character is already pending for this event."; break;
                default:
                    _message = "Your character status is unknown for this event."; break;
            }
        }

        public override string Message
        {
            get { return _message; }
        }
    }
}
