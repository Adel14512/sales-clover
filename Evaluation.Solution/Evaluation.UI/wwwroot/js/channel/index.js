



$(document).ready(function () {
    // initialize DataTables with the data
  var  table = $('#tableContact').DataTable({
        searching: true,
        data: channelsList,
        columns: [
            { data: 'description' },
            { data: 'code' },
            { data: 'type' },
            { data: 'recId' },

        ],
        columnDefs: [{
            targets: -1, // The last column in the table

            data: null,
            render: function (data, type, row, meta) {
                // Use the Font Awesome edit icon
                var html = "";
                if (row.isActive) {
                    html='<a href=""><i class="fas fa-eye"></i></a>'
                } else {
                    html ='<a href=""><i class="fas fa-eye-slash"></i></a>'
                }
                html += '    <a href="../channel/edit/' + row.recId + '"><i class="fas fa-edit"></i></a>';
                return html;
            }
        }
        ],
    });
});
$("#btnHref").click(function (e) {
    window.location.href = "../channel/create";
})
