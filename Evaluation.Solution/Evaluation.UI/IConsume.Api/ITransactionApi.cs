using Evaluation.UI.Request.BL051807;
using Evaluation.UI.Request;
using Evaluation.UI.Request.BL021502;
using Evaluation.UI.Request.BL041312;
using Evaluation.UI.Request.BL080501;
using Evaluation.UI.Request.BL301401;
using Evaluation.UI.Request.BL321110;
using Evaluation.UI.Request.BL77;
using Evaluation.UI.Response;
using Evaluation.UI.Response.BL021502;
using Evaluation.UI.Response.BL041312;
using Evaluation.UI.Response.BL051807;
using Evaluation.UI.Response.BL080501;
using Evaluation.UI.Response.BL301401;
using Evaluation.UI.Response.BL321110;
using Evaluation.UI.Response.BL77;
using Evaluation.UI.Request.BL331211;
using Evaluation.UI.Response.BL331211;
using Evaluation.UI.Response.BL311703;
using Evaluation.UI.Request.BL311703;
using Evaluation.UI.Request.BL281609;
using Evaluation.UI.Response.BL281609;
using Evaluation.UI.Request.BL291908;
using Evaluation.UI.Response.BL291908;
using Evaluation.UI.Request.BL010602;
using Evaluation.UI.Response.BL010602;
using Evaluation.UI.Request.BL030904;
using Evaluation.UI.Response.BL030904;
using Evaluation.UI.Request.BL090703;
using Evaluation.UI.Response.BL090703;
using Evaluation.UI.Request.BL070806;
using Evaluation.UI.Response.BL070806;
using Evaluation.UI.Response.BL061005;
using Evaluation.UI.Request.BL061005;

namespace Evaluation.UI.IConsume.Api
{
    public interface ITransactionApi
    {
        Task<SalesTransactionBL77RecResp> CreateBl77(SalesTransactionBL77NewRecReq request, CancellationToken ct);
        Task<SalesTransactionBL77RecResp> UpdateBl77(SalesTransactionBL77UpdRecReq request, CancellationToken ct);
        Task<SalesTransactionBL77RecResp> GetBl77(SalesTransactionBL77FindWithColFilterReq request, CancellationToken ct);
        Task<BusinessLineRelatedDocFindWithBusinessLineIdFilterResp> GetDocumentByBussinessID(BusinessLineRelatedDocFindWithBusinessLineIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL301401Resp> CreateAF1_30(SalesTransactionBL301401NewRecReq request, CancellationToken ct);
        Task<SalesTransactionBL321110Resp> CreateAF1_32(SalesTransactionBL321110NewRecReq request, CancellationToken ct);
        Task<SalesTransactionBL080501Resp> CreateAf8(SalesTransactionBL080501NewRecReq request, CancellationToken ct);
      
        Task<SalesTransactionBL321110Resp> GetAf32(SalesTransactionBL321110FindAF1WithRecIdReq request, CancellationToken ct);
        Task<SalesTransactionBL331211Resp> GetAf33(SalesTransactionBL331211FindAF1WithRecIdReq request, CancellationToken ct);
        Task<SalesTransactionBL041312Resp> GetAf04(SalesTransactionBL041312FindAF1WithRecIdReq request, CancellationToken ct);
        Task<SalesTransactionBL080501Resp> GetAf8(SalesTransactionBL080501FindAF1WithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL301401Resp> GetAf30(SalesTransactionBL301401FindAF1WithRecIdReq request, CancellationToken ct);
        Task<SalesTransactionBL321110Resp> UpdateAf32(SalesTransactionBL321110UpdAF1RecReq request, CancellationToken ct);
        Task<SalesTransactionBL301401Resp> UpdateAf30(SalesTransactionBL301401UpdAF1RecReq request, CancellationToken ct);
        Task<SalesTransactionBL080501Resp> UpdateAf8(SalesTransactionBL080501UpdAF1RecReq request, CancellationToken ct);
        Task<SalesTransactionBL021502Resp> CreateAF1_2(SalesTransactionBL021502NewRecReq request, CancellationToken ct);
        Task<SalesTransactionBL021502Resp> UpdateAF1_2(SalesTransactionBL021502UpdAF1RecReq request, CancellationToken ct);
        Task<SalesTransactionBL021502Resp> GetAF1_2(SalesTransactionBL021502FindAF1WithRecIdReq request, CancellationToken ct);
        Task<SalesTransactionBL041312Resp> CreateAF1_4(SalesTransactionBL041312NewRecReq request, CancellationToken ct);
        Task<SalesTransactionBL041312Resp> UpdateAF1_4(SalesTransactionBL041312UpdAF1RecReq request, CancellationToken ct);
        Task<SalesTransactionBL041312Resp> GetAF1_4(SalesTransactionBL041312FindAF1WithRecIdReq request, CancellationToken ct);
        Task<SalesTransactionBL051807Resp> CreateAF1_5(SalesTransactionBL051807NewRecReq request, CancellationToken ct);
        Task<SalesTransactionBL051807Resp> UpdateAF1_5(SalesTransactionBL051807UpdAF1RecReq request, CancellationToken ct);
        Task<SalesTransactionBL051807Resp> GetAF1_5(SalesTransactionBL051807FindAF1WithRecIdReq request, CancellationToken ct);
        Task<SalesTransactionBL331211Resp> GetAF1_33(SalesTransactionBL331211FindAF1WithRecIdReq request, CancellationToken ct);
        Task<SalesTransactionBL331211Resp> CreateAF1_33(SalesTransactionBL331211NewRecReq request, CancellationToken ct);
        Task<SalesTransactionBL331211Resp> UpdateAF1_33(SalesTransactionBL331211UpdAF1RecReq request, CancellationToken ct);
        Task<SalesTransactionBL311703Resp> GetAF1_31(SalesTransactionBL311703FindAF1WithRecIdReq request, CancellationToken ct);
        Task<SalesTransactionBL311703Resp> CreateAF1_31(SalesTransactionBL311703NewRecReq request, CancellationToken ct);
        Task<SalesTransactionBL311703Resp> UpdateAF1_31(SalesTransactionBL311703UpdAF1RecReq request, CancellationToken ct);
        Task<SalesTransactionBL281609Resp> GetAF1_28(SalesTransactionBL281609FindAF1WithRecIdReq request, CancellationToken ct);
        Task<SalesTransactionBL281609Resp> CreateAF1_28(SalesTransactionBL281609NewRecReq request, CancellationToken ct);
        Task<SalesTransactionBL281609Resp> UpdateAF1_28(SalesTransactionBL281609UpdAF1RecReq request, CancellationToken ct); Task<SalesTransactionBL291908Resp> GetAF1_29(SalesTransactionBL291908FindAF1WithRecIdReq request, CancellationToken ct);
        Task<SalesTransactionBL291908Resp> CreateAF1_29(SalesTransactionBL291908NewRecReq request, CancellationToken ct);
        Task<SalesTransactionBL291908Resp> UpdateAF1_29(SalesTransactionBL291908UpdAF1RecReq request, CancellationToken ct);
        Task<SalesTransactionBL010602Resp> GetAF1_01(SalesTransactionBL010602FindAF1WithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL010602Resp> CreateAF1_01(SalesTransactionBL010602NewRecReq request, CancellationToken ct);
        Task<SalesTransactionBL010602Resp> UpdateAF1_01(SalesTransactionBL010602UpdAF1RecReq request, CancellationToken ct);
        Task<SalesTransactionBL030904Resp> GetAF1_03(SalesTransactionBL030904FindAF1WithRecIdReq request, CancellationToken ct);
        Task<SalesTransactionBL030904Resp> CreateAF1_03(SalesTransactionBL030904NewRecReq request, CancellationToken ct);
        Task<SalesTransactionBL030904Resp> UpdateAF1_03(SalesTransactionBL030904UpdAF1RecReq request, CancellationToken ct);
        Task<SalesTransactionBL080501SlipResp> Slip080501(SalesTransactionBL080501FindAF1WithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL010602SlipResp> Slip010602(SalesTransactionBL010602FindAF1WithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL070806SlipResp> Slip070806(SalesTransactionBL070806FindAF1WithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL090703SlipResp> Slip090703(SalesTransactionBL090703FindAF1WithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL021502SlipResp> Slip021502(SalesTransactionBL021502FindAF1WithRecIdReq request, CancellationToken ct);
        Task<SalesTransactionBL030904SlipResp> Slip030904(SalesTransactionBL030904FindAF1WithRecIdReq request, CancellationToken ct);
        Task<SalesTransactionBL051807SlipResp> Slip051807(SalesTransactionBL051807FindAF1WithRecIdReq request, CancellationToken ct);
        Task<SalesTransactionBL061005SlipResp> Slip061005(SalesTransactionBL061005FindAF1WithRecIdReq request, CancellationToken ct);

        Task<SalesTransactionBL041312SlipResp> Slip041312(SalesTransactionBL041312FindAF1WithRecIdReq request, CancellationToken ct);
        Task<SalesTransactionBL291908SlipResp> Slip291908(SalesTransactionBL291908FindAF1WithRecIdReq request, CancellationToken ct);
        Task<SalesTransactionBL331211SlipResp> Slip331211(SalesTransactionBL331211FindAF1WithRecIdReq request, CancellationToken ct);
        Task<SalesTransactionBL301401SlipResp> Slip301401(SalesTransactionBL301401FindAF1WithRecIdReq request, CancellationToken ct);
        Task<SalesTransactionBL321110SlipResp> Slip321110(SalesTransactionBL321110FindAF1WithRecIdReq request, CancellationToken ct);
        Task<SalesTransactionBL281609SlipResp> Slip281609(SalesTransactionBL281609FindAF1WithRecIdReq request, CancellationToken ct);
        Task<SalesTransactionBL311703SlipResp> Slip311703(SalesTransactionBL311703FindAF1WithRecIdReq request, CancellationToken ct);
        Task<SalesTransactionBL080501Resp> EditAf8Consolidation(SalesTransactionBL080501UpdGlobalRecReq request, CancellationToken ct);
        Task<SalesTransactionBL281609Resp> EditAf28Consolidation(SalesTransactionBL281609UpdGlobalRecReq request, CancellationToken ct);
      
        Task<SalesTransactionBL331211Resp> EditAf33Consolidation(SalesTransactionBL331211UpdGlobalRecReq request, CancellationToken ct);
        
        Task<SalesTransactionBL321110Resp> EditAf32Consolidation(SalesTransactionBL321110UpdGlobalRecReq request, CancellationToken ct);
        Task<SalesTransactionBL041312Resp> EditAF04Consolidation(SalesTransactionBL041312UpdGlobalRecReq request, CancellationToken ct);
      
        Task<SalesTransactionBL090703Resp> GetAF1_09(SalesTransactionBL090703FindAF1WithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL090703Resp> UpdateAF1_09(SalesTransactionBL090703UpdAF1RecReq request, CancellationToken ct);
        Task<SalesTransactionBL090703Resp> CreateAF1_09(SalesTransactionBL090703NewRecReq request, CancellationToken ct);
        Task<SalesTransactionBL090703Resp> EditAf9Consolidation(SalesTransactionBL090703UpdGlobalRecReq request, CancellationToken ct);
        Task<SalesTransactionBL070806Resp> GetAF1_07(SalesTransactionBL070806FindAF1WithRecIdFilterReq request, CancellationToken ct);
        Task<SalesTransactionBL070806Resp> UpdateAF1_07(SalesTransactionBL070806UpdAF1RecReq request, CancellationToken ct);
        Task<SalesTransactionBL070806Resp> CreateAF1_07(SalesTransactionBL070806NewRecReq request, CancellationToken ct);
        Task<SalesTransactionBL070806Resp> EditAf7Consolidation(SalesTransactionBL070806UpdGlobalRecReq request, CancellationToken ct);
    
        Task<SalesTransactionBL061005Resp> GetAF1_06(SalesTransactionBL061005FindAF1WithRecIdReq request, CancellationToken ct);
        Task<SalesTransactionBL061005Resp> UpdateAF1_06(SalesTransactionBL061005UpdAF1RecReq request, CancellationToken ct);
        Task<SalesTransactionBL061005Resp> CreateAF1_06(SalesTransactionBL061005NewRecReq request, CancellationToken ct);
        Task<SalesTransactionBL321110DetailsResp> GetAF1_32Details(SalesTransactionBL321110DetailsFindWithSalesTrxIdReq request, CancellationToken ct);
        Task<SalesTransactionBL331211DetailsResp> GetAF1_33Details(SalesTransactionBL331211DetailsFindWithSalesTrxIdReq request, CancellationToken ct);
        Task<SalesTransactionBL041312DetailsResp> GetAF1_04Details(SalesTransactionBL041312DetailsFindWithSalesTrxIdReq request, CancellationToken ct);
        Task<SalesTransactionBL301401Resp> EditAF30Consolidation(SalesTransactionBL301401UpdGlobalRecReq request, CancellationToken ct);
        // Task<SalesTransactionBL061005Resp> EditAf6Consolidation(SalesTransactionBL061005UpdGlobalRecReq request, CancellationToken ct);

    }
}
