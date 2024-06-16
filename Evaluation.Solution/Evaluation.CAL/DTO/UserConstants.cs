using System.Collections.Generic;

namespace Evaluation.CAL.DTO
{
    public class UserConstants
    {
        public static List<UserModel> Users = new()
        {
            new UserModel
            {
                UserName = "jason_admin",
                EamilAddress = "jason.admin@email.com",
                Password = "MyPass_w0rd",
                Givename = "Jason",
                Surname = "Bryant",
                Role = "Administrator"
            },
            new UserModel
            {
                UserName = "elyse_seller",
                EamilAddress = "elyse.seller@email.com",
                Password = "MyPass_w0rd",
                Givename = "ELyse",
                Surname = "Lambert",
                Role = "Seller"
            }
        };
    }
}
