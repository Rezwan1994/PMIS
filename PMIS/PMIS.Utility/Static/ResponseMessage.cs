using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PMIS.Utility.Static
{
    public static class ResponseMessage
    {
        public const string CREATE_ERROR = "Unable to create";
        public const string UPDATE_ERROR = "Unable to update";
        public const string DELETE_ERROR = "Unable to delete";
        public const string BAD_REQUEST = "Bad Request";
        public const string NOT_FOUND = "Not Found";
        public const string SERVER_ERROR = "Sorry! Something went wrong";
        public const string SUCCESSFULLY_CREATED = "Successfully Created";
        public const string SUCCESSFULLY_UPDATED = "Successfully Updated";
        public const string SUCCESSFULLY_DELETED = "Successfully Deleted";
        public const string SUCCESSFULLY_APPROVED = "Successfully Approved";
        public const string SUCCESSFULLY_CANCELED = "Successfully Canceled";
        public const string DUPLICATE_VALUE = "Cannot Insert Duplicate Value";
        public const string UNABLE_TO_DELETE = "Unable to Delete. The data is being used by another part";
        public const string ATTACHMENT_UNAVAILABLE = "Attachment Un-available";
        public const string INVALID_INPUT = "Please, Provide all the information correctly";

        public static string Get(Exception exp)
        {
            string msg = SERVER_ERROR;

            if (exp.Message == NOT_FOUND)
            {
                msg = NOT_FOUND;
            }
            else if (exp.InnerException != null)
            {
                if (exp.InnerException.Message.Contains("duplicate key"))
                {
                    msg = DUPLICATE_VALUE;
                }
                else if (exp.InnerException.Message.Contains("DELETE statement conflicted with"))
                {
                    msg = UNABLE_TO_DELETE;
                }
            }

            return msg;
        }
    }
}
