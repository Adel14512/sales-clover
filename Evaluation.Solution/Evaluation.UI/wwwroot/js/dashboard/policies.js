var columnConfig = [
    { data: 'clientType', title: 'Client Type', },
    { data: 'blCode', title: 'BL Code' },
    { data: 'blName', title: 'BL Name' },
    { data: 'policyId', title: 'Policy #' },
    { data: 'masterName', title: 'Master Name' },
    { data: 'clientName', title: 'Client Name' },
    { data: 'decisionMaker', title: 'Decision Maker' },
    { data: 'policyHandler', title: 'Policy Handler' },
    { data: 'principal', title: 'Principal' },
    { data: 'spouce', title: 'Spouce' },
    { data: 'child', title: 'Child' },
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
        { data: 'principal', title: 'Principal' },
        { data: 'spouce', title: 'Spouce' },
        { data: 'child', title: 'Child' },
    ],
    columnDefs: columnDefs,
});