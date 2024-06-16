using Evaluation.UI.IConsume.Api;
using Evaluation.UI.IControllerBusiness;
using Evaluation.UI.IUtil;

namespace Evaluation.UI.ControllerBusiness
{
    public class SlipControllerBusiness: ISlipControllerBusiness
    {
        private readonly IGeneralListApi _generalListApi;
        private readonly IContactApi _contactApi;
        private readonly IGlobal _global;
        private readonly IUserApi _userApi;
        private readonly ISlipApi _slipApi;
        public SlipControllerBusiness(IGeneralListApi generalListApi, ITransactionApi transactionApi, IContactApi contactApi, IGlobal global, IUserApi userApi, IProductApi productApi, ISlipApi slipApi) 
        {
            _generalListApi = generalListApi;
            _contactApi = contactApi;
            _global = global;
            _userApi = userApi;
            _slipApi = slipApi;
        }
    }
}
