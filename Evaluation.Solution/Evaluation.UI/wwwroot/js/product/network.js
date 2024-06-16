var tableNetowrk = $('#tNetwork').DataTable({
    data: datatablelist,
    responsive: true,
    autoWidth: false,
    columns: [
        { data: 'recId', title: 'ID',width: "5%" },
        { data: 'networkLevel', title: 'Level' },
        { data: 'networkName', title: 'Name' },
      //  { data: 'thirdPartyAdminId', title: 'Name' },
        { data: 'networkExplanation', title: 'Explanation' },
        {
            data: 'recId', title: 'Actions', render: function (data, type, row, meta) {
                var html = '<a href="#" onclick="editNetoworkModel(this,' + row.recId + ')"><i class="fas fa-edit"></i></a> ';
                return html;
            }
        }
    ],
    
});
var currentRowSelectedCombination;
var isCreate = true;
function editNetoworkModel(sender, id) {
    var tr = $(sender).closest('tr');
    currentRowSelectedCombination = tableNetowrk.row(tr);

    var model = currentRowSelectedCombination.data();
    if (model != null) {
        oldClassId = model.classId;
        $("#txtRecId").val(model.recId);
        $("#txtLevel").val(model.networkLevel);
        $("#txtName").val(model.networkName);
        $("#txtExplanation").val(model.networkExplanation);

        
    } else {

    }
    isCreate = false;
    $('#modelNetwork').modal('show');
}
function resetNetworkFields() {
    $("#txtLevel").val("");
    $("#txtName").val("");
    $("#txtExplanation").val("");

}
$('#btnSave').on('click', function () {
    var obj = {};
    var objProduct = {};
    objProduct.RecId = parseInt($("#txtRecId").val());
    objProduct.NetworkLevel = $('#txtLevel').val();
    objProduct.NetworkName = $('#txtName').val();
    objProduct.NetworkExplanation = $('#txtExplanation').val();

    obj.ProductDetailsPOINetwork = objProduct;
    var formBody = new FormData();
    formBody.append("network", JSON.stringify(obj));
   

        $.ajax({
            url: "/Product/EditNetwork",
            type: "POST",
            contentType: false,
            processData: false,
            data: formBody,
            beforeSend: function (xhr) {
                showLoading();
                // xhr.setRequestHeader('Authorization', 'Bearer ' + localStorage.getItem('jwt'));
                //  xhr.setRequestHeader('X-CSRF-TOKEN', $('input[name="__RequestVerificationToken"]').val());
            },
            success: function (data) {
                hideLoading();
                if (data != null && data.webResponseCommon != null && data.webResponseCommon.returnCode == '202') {
                    toastr.success("", "Saved");
                    $("#btnCloseNetwork").click();
                    window.location.href = window.location.href.replace("#",'')
                    //var editModel = {
                    //    recId: objProduct.RecId,
                    //    networkLevel: objProduct.NetworkLevel,
                    //    networkName: objProduct.NetworkName,
                    //  //  thirdPartyAdminId: objProduct.NetworkName,
                    //    networkExplanation: objProduct.NetworkExplanation,
                    //}
                    //tableNetowrk.data(editModel).draw();
                    //resetNetworkFields();
                 
                } else {
                    toastr.warning(data.webResponseCommon.returnMessage, "UnSaved");
                }
            },
            error: function (xhr, status, error) {
                hideLoading();
                toastr.error(error, "Error Editing Network");

            }
        });
    

});