var table = $('#tableLead').DataTable({
    // DataTable initialization options
    searching: true
});

$('#tableLead').DataTable().destroy();

// initialize DataTables with the data
table = $('#tableLead').DataTable({
    data: leadList,
    buttons: [
        'excel',
    ],
    processing: true,
    language: {
        processing: '<i class="fa fa-spinner fa-spin"></i> Loading...'
    },
    columns: [
        { data: 'businessLine' },
        { data: 'owner' },
        {
            "data": null,
            "render": function (data, type, row) {
                return data.firstName + ' ' + data.lastName;
            }
        },
        { data: 'mobile' },
        { data: 'company' },
        { data: 'job' },
        { data: 'topic' },
        { data: 'summaryFeedback' },
        { data: 'recId' }
    ],
    columnDefs: [{
        targets: -1, // The last column in the table

        data: null,
        render: function (data, type, row, meta) {
            // Use the Font Awesome edit icon
            var html = '<a href="../lead/edit/' + row.recId + '"><i class="fas fa-edit"></i></a>';
            return html;
        }
    }
    ],
});

