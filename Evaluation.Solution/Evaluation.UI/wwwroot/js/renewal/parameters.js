var columnConfig = [
    { data: 'productCategory', title: 'Product Category', },
    { data: 'clientType', title: 'Client Type' },
    { data: 'branchId', title: 'Branch #' },
    { data: 'branchDescription', title: 'Branch Desc' },
    { data: 'productClass', title: 'Product Class' },
    { data: 'nbrInsured', title: 'Insured #' },
    { data: 'renewalTriggerDays', title: 'RenewalTriggerDays' },
];

var columnDefs = columnConfig.map(function (column, index) {
    return {
        targets: index,
        data: column.data,
        title: column.title,
        width: column.width,
        createdCell: function (cell, cellData) {
            var attributeName = 'data-' + column.data.toLowerCase();
            $(cell).attr(attributeName, cellData);
        }
    };
});
var table = $('#tParameters').DataTable({
    data: datatable,
    responsive: false,
    autoWidth: false,
    pageLength: 25,
    columns: [
        { data: 'productCategory', title: 'Product Category', },
        { data: 'clientType', title: 'Client Type' },
        { data: 'branchId', title: 'Branch #' },
        { data: 'branchDescription', title: 'Branch Desc' },
        { data: 'productClass', title: 'Product Class' },
        { data: 'nbrInsured', title: 'Insured #' },
        { data: 'renewalTriggerDays', title: 'RenewalTriggerDays' },
        {
            data: '', title: 'Actions', render: function (data, type, row, meta) {
                var rowDataJson = JSON.stringify(row); // Convert the row object to a JSON string
                var html = '<a href="#" onclick="editModule(this)"><i class="fas fa-edit"></i></a> ';
                return html;
            }
        }
    ],
    columnDefs: columnDefs,
});
var modelValues;
function editModule(sender) {
    var tr = $(sender).closest('tr');
    modelValues = table.row(tr);

    var model = modelValues.data();
    if (model != null) {
        $("#txtRenewalTriggerDays").val(model.renewalTriggerDays);
    } else {

    }
    $('#modalEdit').modal('show');
}
$("#btnSaveModel").click(function () {
    var editModel = modelValues.data();
    editModel.renewalTriggerDays = $("#txtRenewalTriggerDays").val();
    // Redraw the row to reflect the updated data
    modelValues.data(editModel).draw();
    resetModal();
    $("#btnCloseModal").click();
});
function resetModal() {

    $("#txtRenewalTriggerDays").val(0)
}

