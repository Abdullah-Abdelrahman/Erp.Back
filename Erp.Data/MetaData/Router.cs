namespace Name.Data.MetaData
{
    public static class Router
    {

        public const string Root = "/Api";
        public const string Rule = Root + "/";


        public static class CourseRouter
        {
            public const string prefix = Rule + "Course/";

            public const string GetList = prefix + "List";

            public const string GetById = prefix + "{Id}";

            public const string Create = prefix + "Create";

            public const string Edit = prefix + "Edit";

            public const string Delete = prefix + "Delete/{Id}";

        }

        public static class UserRouter
        {
            public const string prefix = Rule + "UserApp/";

            public const string GetList = prefix + "List";

            public const string GetById = prefix + "{Id}";

            public const string Create = prefix + "Create";

            public const string Edit = prefix + "Edit";

            public const string Delete = prefix + "Delete/{Id}";

            public const string ChangePassword = prefix + "ChangePassword";

        }

        public static class AuthenticationRouter
        {
            public const string prefix = Rule + "Authentication/";

            public const string GetList = prefix + "List";

            public const string CanResetPassword = prefix + "CanResetPassword";

            public const string SignIn = prefix + "SignIn";

            public const string ConfirmEmail = prefix + "ConfirmEmail";

            public const string SendResetPasswordEmail = prefix + "SendResetPasswordEmail";


        }

        public static class AuthorizationRouter
        {
            public const string prefix = Rule + "Authorization/";

            public const string GetList = prefix + "Role/List";

            public const string GetById = prefix + "Role/{Id}";

            public const string Create = prefix + "Role/Create";

            public const string Edit = prefix + "Role/Edit";

            public const string Delete = prefix + "Role/Delete/{Id}";

            ////
            ///
            public const string ManageUserRoles = prefix + "ManageUserRolesQuery/{Id}";

            public const string UpdateUserRoles = prefix + "UpdateUserRoles";

            public const string ManageUserClaims = prefix + "ManageUserClaims/{Id}";

            public const string UpdateUserClaims = prefix + "UpdateUserClaims";
        }


        public static class AnswerRouter
        {
            public const string prefix = Rule + "Answer/";

            public const string GetList = prefix + "List";

            public const string GetById = prefix + "{Id}";

            public const string Create = prefix + "Create";

            public const string Edit = prefix + "Edit";

            public const string Delete = prefix + "Delete/{Id}";


        }




        public static class QuestionRouter
        {
            public const string prefix = Rule + "Question/";

            public const string GetList = prefix + "List";

            public const string GetById = prefix + "{Id}";

            public const string Create = prefix + "Create";

            public const string CreateQuestionWithAnswer = prefix + "CreateQuestionWithAnswer";


            public const string Edit = prefix + "Edit";

            public const string Delete = prefix + "Delete/{Id}";

            public const string TypeList = prefix + "TypeList";

        }


        public static class ContentRouter
        {
            public const string prefix = Rule + "Content/";

            public const string GetList = prefix + "List";

            public const string GetGeneralContentById = prefix + "GeneralContent/" + "{Id}";

            public const string CreateGeneralContent
                = prefix + "GeneralContent/" + "Create";

            public const string EditGeneralContent = prefix + "GeneralContent/" + "Edit";

            public const string Delete = prefix + "Delete/{Id}";

            public const string TypeList = prefix + "TypeList";

        }

        public static class QuizRouter
        {
            public const string prefix = Rule + "Quiz/";

            public const string GetList = prefix + "List";

            public const string GetById = prefix + "{Id}";

            public const string Create = prefix + "Create";

            public const string Edit = prefix + "Edit";

            public const string Delete = prefix + "Delete/{Id}";

            public const string Open = prefix + "Open";

            public const string Close = prefix + "Close";


        }


        public static class PaymentRouter
        {
            public const string prefix = Rule + "Payment/";

            public const string GetList = prefix + "List";

            public const string GetById = prefix + "{Id}";

            public const string Create = prefix + "Create";

        }


        public static class EnrollmentRouter
        {
            public const string prefix = Rule + "Enrollment/";

            public const string GetList = prefix + "List";

            public const string GetById = prefix + "{Id}";

            public const string Create = prefix + "Create";

        }

        public static class EmailRouter
        {
            public const string prefix = Rule + "Email/";

            public const string GetList = prefix + "List";

            public const string GetById = prefix + "{Id}";

            public const string Send = prefix + "Send";

        }
    }
}
