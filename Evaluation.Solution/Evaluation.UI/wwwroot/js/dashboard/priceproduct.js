var columnConfig = [
    { data: 'businessLineCode', title: 'BL Code', },
    { data: 'businessLineName', title: 'BL Name' },
    { data: 'productId', title: 'Product #' },
    { data: 'insurerProductName', title: 'Insurer Product Name' },
    { data: 'insurerId', title: 'Insurer #' },
    { data: 'insurerName', title: 'Insurer Name' },
    { data: 'insurerCountry', title: 'Insurer Country' },
    { data: 'lastDatePrice', title: 'Last Date Price', width: '70px' },
    { data: 'modificationCount', title: 'Modification Count' },
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
var table = $('#tProdcutPrice').DataTable({
    data: datatable,
    responsive: false,
    autoWidth: false,
    pageLength: 25,
    columns: [
        { data: 'businessLineCode', title: 'BL Code', },
        { data: 'businessLineName', title: 'BL Name' },
        { data: 'productId', title: 'Prd #' },
        { data: 'insurerProductName', title: 'Insurer Product Name' },
        { data: 'insurerId', title: 'Ins #' },
        { data: 'insurerName', title: 'Insurer Name' },
        { data: 'insurerCountry', title: 'Insurer Country' },
        {
            data: 'lastDatePrice', title: 'Last Date Price', width: '70px'
            , render: function (data, type, row) {

                if (data != null) {
                    return data.split('T')[0];
                } else {
                    return "";
                }
            }
        },
        { data: 'modificationCount', title: 'Modification Count' },
    ],
    columnDefs: columnDefs,
});