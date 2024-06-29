var columnConfig = [
    { data: 'ticketId', title: 'Ticket', },
    { data: 'policyId', title: 'Policy' },
    { data: 'policyEffectiveDate', title: 'Effective Date' },
    { data: 'policyExpiryDate', title: 'Expiry Date' },
    { data: 'productName', title: 'Product Name' },
    { data: 'insurerProductName', title: 'Insurer Product Name' },
    { data: 'businessLine', title: 'Business Line' },
    { data: 'policyHolder', title: 'Policy Holder' },
    { data: 'premium', title: 'Premium' },
    { data: 'lastModifiedBy', title: 'Last Modified By' },
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
var table = $('#tPolicy').DataTable({
    data: datatable,
    responsive: true,
    autoWidth: false,
    pageLength: 25,
    columns: [
        { data: 'ticketId', title: 'Ticket',  width: "10px"},
        { data: 'policyId', title: 'Policy' },
        {
            data: 'policyEffectiveDate', title: 'Effective Date', render: function (data, type, row) {

                if (data != null) {
                    return data.split('T')[0];
                } else {
                    return "";
                }
            }
},
        {
            data: 'policyExpiryDate', title: 'Expiry Date', render: function (data, type, row) {

                if (data != null) {
                    return data.split('T')[0];
                } else {
                    return "";
                }
            }
},
        { data: 'productName', title: 'Product Name' },
        { data: 'insurerProductName', title: 'Insurer Product Name' ,width:"160px"},
        { data: 'businessLine', title: 'Business Line', width: "160px" },
        { data: 'policyHolder', title: 'Policy Holder' },
        { data: 'premium', title: 'Premium' },
        { data: 'lastModifiedBy', title: 'Last Modified By' },
        {
            data: null, title: 'Action',
            render: function (data, type, row) {
                var html = ' <a  onclick="consolidation(this)"   data-ticketid="' + row.ticketId + '"  data-id="' + row.recId + '" data-businesslinecode="' + row.businessLine + '" data-parentid="' + row.parentPolicyId + '" data-policyid="' + row.policyId + '" title="Consolidation"> <i class="fas fa-edit"></i></a>';
                return html;
            }
        }
    ],
    columnDefs: columnDefs,
    initComplete: function () {
        this.api().columns(0).every(function () {
            filterAddForGrid(this);
        }),
            this.api().columns(1).every(function () {
                filterAddForGrid(this);
            }),
            this.api().columns(2).every(function () {
                filterAddForGrid(this);
            }),
            this.api().columns(3).every(function () {
                filterAddForGrid(this);
            }),
            this.api().columns(4).every(function () {
                filterAddForGrid(this);
            }),
            this.api().columns(5).every(function () {
                filterAddForGrid(this);
            }),
            this.api().columns(6).every(function () {
                filterAddForGrid(this);
            }),
            this.api().columns(7).every(function () {
                filterAddForGrid(this);
            }),
            this.api().columns(8).every(function () {
                filterAddForGrid(this);
            }),
            this.api().columns(9).every(function () {
                filterAddForGrid(this);
            }),
            this.api().columns(10).every(function () {
                filterAddForGrid(this);
            });;

    },
});
function filterAddForGrid(sender) {
    var column = sender;
    var select = $('<select  class="select2 form-select"><option value="">-Select--</option></select>\n')
        .appendTo($(column.header()))
        .on('change', function () {
            var val = $.fn.dataTable.util.escapeRegex(
                $(this).val()
            );

            column
                .search(val ? '^' + val + '$' : '', true, false)
                .draw();
        });

    column.data().unique().sort().each(function (d, j) {
        select.append('<option value="' + d + '">' + d + '</option>');
    });
}
function consolidation(e) {
    var buscode = e.dataset.businesslinecode.split(" -")[0];
    ////var parentid = e.dataset.parentsalestransacrionid;
    //var ticketid = e.dataset.ticketid;
    ////var ticketCode = e.dataset.ticketcode;
    //var salesTransactionId = e.dataset.recid;
    var policyparentId = e.dataset.parentid;
    var params = encodeParameters("?parentpolicyId=" + policyparentId);
    window.location.href = "/Consolidation/Consolidation" + buscode + "/" + params;

}