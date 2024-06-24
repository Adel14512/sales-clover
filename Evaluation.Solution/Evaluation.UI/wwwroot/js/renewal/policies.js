var columnConfig = [
    { data: 'clientType', title: 'Client Type', },
    { data: 'blCode', title: 'BL Code' },
    { data: 'blName', title: 'BL Name' },
    { data: 'policyId', title: 'Policy #' },
    { data: 'masterName', title: 'Master Name' },
    { data: 'clientName', title: 'Client Name' },
    { data: 'decisionMaker', title: 'Decision Maker' },
    { data: 'policyHandler', title: 'Policy Handler' },
    { data: 'principal', title: 'P' },
    { data: 'spouce', title: 'S' },
    { data: 'child', title: 'C' },
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
    responsive: false,
    autoWidth: false,
    pageLength: 25,
    columns: [
        { data: 'clientType', title: 'Client Type', },
        { data: 'blCode', title: 'BL Code' },
        { data: 'blName', title: 'BL Name' },
        { data: 'policyId', title: 'Policy #' },
        { data: 'masterName', title: 'Master Name' },
        { data: 'clientName', title: 'Client Name' },
        { data: 'decisionMaker', title: 'Decision Maker' },
        { data: 'policyHandler', title: 'Policy Handler' },
        {
            data: 'principal', title: 'P'
        },
        {
            data: 'spouce', title: 'S'
        },
        {
            data: 'child', title: 'C'
        },
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
            });

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